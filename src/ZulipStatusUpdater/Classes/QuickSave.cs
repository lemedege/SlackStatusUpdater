using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZulipStatusUpdater.Models;

namespace ZulipStatusUpdater
{
    public static class QuickSave
    {
        public static void SaveCurrentProfile()
        {
            // Get current Wifis
            var currentWifis = NetworkCheck.GetWifiConnectionSSIDs();

            // Get current status
            var currentStatus = SlackStatusService.GetSlackStatus();

            // Get current settings
            var settings = SettingsManager.GetSettings();

            // Null checks etc.
            if (currentWifis == null || currentWifis.Count < 1 || currentStatus == null || settings == null)
                return;

            // Save current wifi and status to settings as a profile
            foreach (var wifi in currentWifis)
            {
                var matchingProfile = settings.StatusProfiles.Find(s => s.WifiName == wifi);

                if (matchingProfile != null)
                {
                    matchingProfile.Status = currentStatus;
                }
                else
                {
                    settings.StatusProfiles.Add(
                        new StatusProfile()
                        {
                            WifiName = wifi,
                            Status = currentStatus
                        }
                        );
                }
            }

            SettingsManager.ApplySettings(settings);

        }
    }
}
