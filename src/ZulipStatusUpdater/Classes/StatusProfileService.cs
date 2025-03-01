﻿using ZulipStatusUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetTools;

namespace ZulipStatusUpdater
{
    /// <summary>
    /// Class for interpreting the status to set based on the list of connected wifis
    /// </summary>
    public static class StatusProfileService
    {
        /// <summary>
        /// Return the status to set based on the list of connected wifis
        /// </summary>
        /// <param name="wifiNames">List of connected wifis</param>
        /// <returns>ZulipStatus to be set</returns>
        public static ZulipStatus GetStatusWifi(List<string> wifiNames)
        {
            /*var settings = SettingsManager.GetSettings();

            ZulipStatus status = settings.DefaultStatus;

            foreach (StatusProfile profile in settings.StatusProfiles)
            {
                if (wifiNames.Contains(profile.WifiName))
                    status = profile.Status;
            }

            */
            return new ZulipStatus();
        }

        /// <summary>
        /// Return the status to set based on the current local IP
        /// </summary>
        /// <param name="localIP">Current local IP</param>
        /// <returns>ZulipStatus to be set</returns>
        public static ZulipStatus GetStatusIP(string localip)
        {
            var settings = SettingsManager.GetSettings();

            ZulipStatus status = settings.DefaultStatus;

            var cur_ip = IPAddressRange.Parse(localip);
            foreach (StatusProfile profile in settings.StatusProfiles)
            {

                var cur_network = IPAddressRange.Parse(profile.networkip);

                if (cur_network.Contains(cur_ip)) { 
                        status = profile.Status;
                }
            }
            return status;
        }

    }
}
