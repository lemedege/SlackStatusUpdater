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
using System.Data.SqlTypes;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

namespace ZulipStatusUpdater
{
    /// <summary>
    /// Class for guiding the update process
    /// </summary>
    public static class UpdateProcess
    {
        private static System.Timers.Timer _timer;

        private static ZulipStatus _previousStatus;

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
            Program.runicon.SetIconHoverText(ZulipStatusService.CheckServerStatus()? "Connected" : "Not connected");

            string localIP = NetworkCheck.GetCurrentIP();

            if (!SettingsManager.GetSettings().disableStatusUpdate)
            {
                var statusToSet = SettingsManager.GetSettings().DefaultStatus;

                // Find out the corresponding status to be set
                if (SettingsManager.GetSettings().usewifi)
                {
                    // Get connected SSIDs
                    var wifiNames = NetworkCheck.GetWifiConnectionSSIDs();
                    statusToSet = StatusProfileService.GetStatusWifi(wifiNames);
                }
                else if (!SettingsManager.GetSettings().overide_status)
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

            // Update IP
            List<ProfileField> fields = ZulipStatusService.GetCustomProfileFields();
            if (fields.Count > 0)
            {
                List<ProfileField> filled_fields = ZulipStatusService.FillCustomProfileFields(fields);
                try
                {
                    ProfileField field = filled_fields.Where(item => item.Name == "IP").First();

                    if (field.Content != localIP)
                    {
                        field.Content = localIP;
                        ZulipStatusService.UpdateProfileOnServer(field);
                    }
                }
                catch { }
            }
            // Check presence
            ActivityMonitor.ActivityState currentPresence = ActivityMonitor.GetPresenceUpdate();

            if (!SettingsManager.GetSettings().disablePresenceUpdate)
            {
                if (currentPresence != ActivityMonitor.ActivityState.OFFLINE)
                {
                    //Program.runicon.Say(currentPresence.ToString());
                    var succes = ZulipStatusService.SetZulipPresence(currentPresence);
                }
            }
        }
    }
}
