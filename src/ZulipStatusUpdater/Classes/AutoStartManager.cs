using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZulipStatusUpdater
{
    /// <summary>
    /// Class for handling automatic staring when windows starts
    /// </summary>
    public static class AutoStartManager
    {
        /// <summary>
        /// Autostart registry value name
        /// </summary>
        private const string REGISTRY_VALUE_NAME_AUTOSTART = "ZulipStatusUpdater";

        /// <summary>
        /// Autostart subkey registry path
        /// </summary>
        private const string AUTOSTART_SUBKEY = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

        /// <summary>
        /// Set autostart on or off
        /// </summary>
        /// <param name="autoStart">True, to turn autostart on. False, to turn autostart off.</param>
        public static void SetAutoStart(bool autoStart)
        {
            // Open registry subkey
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(AUTOSTART_SUBKEY, true);

            if (rkApp != null)
            {
                // Set or delete the registry value
                if (autoStart)
                    rkApp.SetValue(REGISTRY_VALUE_NAME_AUTOSTART, $"\"{Application.ExecutablePath}\"");
                else
                    rkApp.DeleteValue(REGISTRY_VALUE_NAME_AUTOSTART, false);
            }
        }

        /// <summary>
        /// Checks registry to see if autostart is on
        /// </summary>
        /// <returns>True, if autostart is on. Otherwise false.</returns>
        public static bool AutoStartIsActive()
        {
            // Assume false
            bool autoStartIsActive = false;

            // Open registry subkey
            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(AUTOSTART_SUBKEY, true);

            if (rkApp != null)
            {
                // If program name exist in autostart value names in registry
                // set return value to true
                if (rkApp.GetValueNames().ToList().Contains(REGISTRY_VALUE_NAME_AUTOSTART))
                {
                    autoStartIsActive = true;
                }
            }

            return autoStartIsActive;
        }
    }
}
