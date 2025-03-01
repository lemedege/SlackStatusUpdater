﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZulipStatusUpdater.Models
{
    /// <summary>
    /// Zulip status
    /// </summary>
    public class ZulipStatus
    {
        [XmlElement("emoji")]
        public string Emoji { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }



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
                ZulipStatus s = (ZulipStatus)obj;
                return (Emoji == s.Emoji) && (Text == s.Text);
            }
        }
    }
}
