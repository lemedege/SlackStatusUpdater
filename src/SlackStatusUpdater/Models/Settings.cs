using System;
using System.Collections.Generic;
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
        public double idleThreshold { get; set; }

        [XmlElement("offline-threshold-ms")]
        public double offlineThreshold { get; set; }

        [XmlElement("disable-presence-update")]
        public bool disablePresenceUpdate { get; set; }

        [XmlElement("use-wifi")]
        public bool usewifi { get; set; }


        /// <summary>
        /// Use XmlIgnore attribute to prevent xml serialization. This field will be bound to the
        /// actual autostart key value in the Windows registry and will not be read from or
        /// written to the settings file.
        /// </summary>
        [XmlIgnore]
        public bool AutoStart { get; set; }

        [XmlElement("default-status")]
        public Status DefaultStatus { get; set; }

        [XmlElement("wifi-config")]
        public List<StatusProfile> StatusProfiles { get; set; }

    }
}