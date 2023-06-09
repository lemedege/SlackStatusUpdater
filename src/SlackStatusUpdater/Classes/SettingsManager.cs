using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ZulipStatusUpdater.Models;

namespace ZulipStatusUpdater
{
    /// <summary>
    /// Class for managing application settings
    /// </summary>
    public static class SettingsManager
    {
        /// <summary>
        /// Absolute settings file directory payh
        /// </summary>
        private static string SettingsFileDirectoryPath
        {
            get
            {
                // In roaming AppData
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ZulipStatusUpdater");
            }
        }

        /// <summary>
        /// Absolute settings file path
        /// </summary>
        private static string SettingsFilePath
        {
            get
            {
                return Path.Combine(SettingsFileDirectoryPath, @"Settings.xml");
            }
        }

        /// <summary>
        /// Return current settings as object
        /// </summary>
        /// <returns>Current settings</returns>
        public static Settings GetSettings()
        {
            // If settings file doesn't exist, generate it
            if (!File.Exists(SettingsFilePath))
                GenerateDefaultSettingsFile();

            // Read settings from settings file
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
            Settings settings = new Settings();
            using (TextReader textReader = new StreamReader(SettingsFilePath))
            {
                settings = (Settings)xmlSerializer.Deserialize(textReader);
            }

            // Read autostart setting from registry
            settings.AutoStart = AutoStartManager.AutoStartIsActive();

            return settings;

        }

        /// <summary>
        /// Apply and save new settings
        /// </summary>
        /// <param name="settings">Settings to apply</param>
        public static void ApplySettings(Settings settings)
        {
            settings.ZulipRealm = TidyUpURL(settings.ZulipRealm);
            // Write to settings file
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
            using (TextWriter textWriter = new StreamWriter(SettingsFilePath))
            {
                xmlSerializer.Serialize(textWriter, settings);
            }

            // Set autostart setting to registry
            AutoStartManager.SetAutoStart(settings.AutoStart);

        }

        /// <summary>
        /// Generate a default settings file
        /// </summary>
        private static void GenerateDefaultSettingsFile()
        {
            var defaultSettings = new Settings()
            {

                ZulipRealm = TidyUpURL("chat.zulipchat.com"),
                ZulipEmail = "example@example.com",
                ZulipApikey = "Enter password and press Get API key",
                local_server = "192.168.111.100",
                idleThreshold = 1000 * 140,
                offlineThreshold = 1000 * 60 * 30,
                DefaultStatus = new Status()
                {
                    Emoji = "house",
                    Text = "Working remotely",
                    SendIP = false,
                },
                StatusProfiles = new List<StatusProfile>()
                {
                    new StatusProfile()
                    {
                        WifiName = "HOME_WIFI",
                        networkip = "192.168.145.0/24",
                        Emoji = "house",
                        SendIP = false,
                        Text = "At home"
                    },
                    new StatusProfile()
                    {
                        WifiName = "OFFICE_WIFI",
                        networkip = "192.168.111.0/24",
                        Emoji = "computer",
                        SendIP = false,
                        Text = "At the office"
                    }
                }
            };

            if (!Directory.Exists(SettingsFileDirectoryPath))
                Directory.CreateDirectory(SettingsFileDirectoryPath);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));

            using (TextWriter textWriter = new StreamWriter(SettingsFilePath))
            {
                xmlSerializer.Serialize(textWriter, defaultSettings);
            }
        }

        /// <summary>
        /// Checks whether the URL includes https:// or not and adds it if necessary. Also removes any trailing slash.
        /// </summary>
        /// <param name="ServerURL"></param>
        /// <returns></returns>
        private static string TidyUpURL(string ServerURL)
        {
            string Result = ServerURL.StartsWith("https://") ? ServerURL : "https://" + ServerURL;
            Result = Result.EndsWith("/") ? Result.Remove(Result.LastIndexOf('/')) : Result;

            return Result;
        }
    }
}
