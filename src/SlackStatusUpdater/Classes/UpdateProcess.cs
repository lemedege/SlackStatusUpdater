using ZulipStatusUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using ZulipStatusUpdater.Classes;

namespace ZulipStatusUpdater
{
    /// <summary>
    /// Class for guiding the update process
    /// </summary>
    public static class UpdateProcess
    {
        private static System.Timers.Timer _timer;

        private static Status _previousStatus;

        private static string _previousIP;

        /// <summary>
        /// Start process
        /// </summary>
        public static void Start()
        {
            // Execute update process once when application starts
            Execute();

            // Set timer interval for how often to check for changes that might require a status
            // update
            _timer = new Timer(2000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
            
        }

        /// <summary>
        /// Timer elapsed event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Execute the update process
            Execute();
        }

        /// <summary>
        /// Executes status update process
        /// </summary>
        public static void Execute()
        {

            ZulipStatusService.GetCustomProfileFields();
            if (!SettingsManager.GetSettings().disableStatusUpdate)
            {
                string localIP = NetworkCheck.GetCurrentIP();

                var statusToSet = SettingsManager.GetSettings().DefaultStatus;

                // Find out the corresponding status to be set
                if (SettingsManager.GetSettings().usewifi)
                {
                    // Get connected SSIDs
                    var wifiNames = NetworkCheck.GetWifiConnectionSSIDs();
                    statusToSet = StatusProfileService.GetStatusWifi(wifiNames);
                }
                else
                {
                    statusToSet = StatusProfileService.GetStatusIP(localIP);
                }
                // Null check and compare status to previous status. Update if changed.
                if (statusToSet != null && (!statusToSet.Equals(_previousStatus)) || !localIP.Equals(_previousIP))
                {
                    var success = ZulipStatusService.SetZulipStatus(statusToSet, localIP);
                    if (success)
                        _previousStatus = statusToSet;
                    _previousIP = localIP;
                }

            }

            ActivityMonitor.ActivityState currentPresence = ActivityMonitor.GetPresenceUpdate();
            //Program.runicon.Say(((int)currentPresence).ToString());

            if (!SettingsManager.GetSettings().disablePresenceUpdate)
            {
                if (currentPresence != ActivityMonitor.ActivityState.OFFLINE)
                {
                    //Program.runicon.Say(currentPresence.ToString());
                    var succes = ZulipStatusService.SetZulipPresence(ActivityMonitor.ActivityState.IDLE);
                }
            }
        }
    }
}
