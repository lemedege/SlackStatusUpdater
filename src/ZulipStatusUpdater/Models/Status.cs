using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZulipStatusUpdater.Models
{
    /// <summary>
    /// Slack status
    /// </summary>
    public class Status
    {
        [XmlElement("emoji")]
        public string Emoji { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }



        [XmlElement("send_ip")]
        public bool SendIP { get; set; }
        

        /// <summary>
        /// Overriden method for checking equality between statuses.
        /// </summary>
        /// <param name="obj">Object to compare to</param>
        /// <returns>True if statuses are equal, false otherwise</returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                // Statuses are equal if emoji and text are equal
                Status s = (Status)obj;
                return (Emoji == s.Emoji) && (Text == s.Text);
            }
        }
    }
}
