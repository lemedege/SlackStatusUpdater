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
    /// Slack status profile for a specific wifi
    /// </summary>
    public class StatusProfile
    {
        [XmlElement("wifi-name")]
        public string WifiName { get; set; }

        [XmlElement("network-ip")]
        public string networkip { get; set; }

        [XmlElement("emoji")]
        public string Emoji { get; set; }

        [XmlElement("send_ip")]
        public bool SendIP { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }

        /// <summary>
        /// Status property constructed from Emoji and Text properties. Nonbrowsable, so it doesn't
        /// get rendered in the bound datagridview in settings form.
        /// </summary>
        [Browsable(false)]
        public Status Status
        {
            get
            {
                return new Status()
                {
                    Emoji = this.Emoji,
                    Text = this.Text,
                    SendIP = this.SendIP
                };
            }

            set
            {
                this.Emoji = value.Emoji;
                this.Text = value.Text;
                this.SendIP = value.SendIP;
            }
        }

    }
}
