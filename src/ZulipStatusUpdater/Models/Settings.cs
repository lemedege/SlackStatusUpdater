using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZulipStatusUpdater.Models
{
    /// <summary>
    /// Settings
    /// </summary>
    [XmlRoot("settings")]
    public class Settings
    {
        
        public Settings()
        {
            ZulipRealm = Classes.Tools.TidyUpURL("chat.zulipchat.com");
            ZulipEmail = "example@example.com";
            ZulipApikey = "Enter password and press Get API key";
            local_server = "192.168.111.100";
            idleThreshold = 1000 * 140;
            offlineThreshold = 1000 * 60 * 30;
            overide_status = false;
            lunch_duration_minutes = 30;
           

        }

        [XmlElement("last-otp-encrypted-api-token")]
        public string LastOTPEncryptedApiToken { get; set; }

        [XmlElement("legacy-api-token")]
        public string LegacyApiToken { get; set; }

        [XmlElement("zulip-realm")]
        public string ZulipRealm { get; set; }

        [XmlElement("zulip-email")]
        public string ZulipEmail { get; set; }

        [XmlElement("zulip-api-key")]
        public string ZulipApikey { get; set; }

        [XmlElement("local-server")]
        public string local_server { get; set; }

        [XmlElement("disable-status-update")]
        public bool disableStatusUpdate { get; set; }

        [XmlElement("idle-threshold-ms")]
        public int idleThreshold { get; set; }

        [XmlElement("offline-threshold-ms")]
        public int offlineThreshold { get; set; }

        [XmlElement("disable-presence-update")]
        public bool disablePresenceUpdate { get; set; }

        [XmlElement("use-wifi")]
        public bool usewifi { get; set; }

        [XmlElement("overide-status")]
        public bool overide_status { get; set; }

        [XmlElement("last-lunch")]
        public DateTime last_lunch_timestamp { get; set; }


        [XmlElement("lunch-duration")]
        public int lunch_duration_minutes { get; set; }

        /// <summary>
        /// Use XmlIgnore attribute to prevent xml serialization. This field will be bound to the
        /// actual autostart key value in the Windows registry and will not be read from or
        /// written to the settings file.
        /// </summary>
        [XmlIgnore]
        public bool AutoStart { get; set; }

        [XmlElement("default-status")]
        public ZulipStatus DefaultStatus { get; set; }

        [XmlElement("wifi-config")]
        public List<StatusProfile> StatusProfiles { get; set; }




    }
}