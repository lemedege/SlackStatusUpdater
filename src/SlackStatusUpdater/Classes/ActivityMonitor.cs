using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZulipStatusUpdater.Classes
{
    public static class ActivityMonitor
    {

        public enum ActivityState
        {
            OFFLINE,
            IDLE,
            ACTIVE
        }

        //taken from http://joelabrahamsson.com/detecting-mouse-and-keyboard-input-with-net/

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        public static DateTime GetLastInputTime()
        {
            var lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);

            GetLastInputInfo(ref lastInputInfo);

            return DateTime.Now.AddMilliseconds(-(Environment.TickCount - lastInputInfo.dwTime));
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }


        public static ActivityState GetPresenceUpdate()
        {
            DateTime lastInput = GetLastInputTime();
            DateTime currentTime = DateTime.Now;

            TimeSpan timeSinceInput = currentTime - lastInput;

            if (timeSinceInput.TotalMilliseconds > SettingsManager.GetSettings().offlineThreshold)
            {
                return ActivityState.OFFLINE;
            }
             
            else if (timeSinceInput.TotalMilliseconds > SettingsManager.GetSettings().idleThreshold)
            {
                return ActivityState.IDLE;
            }
            else return ActivityState.ACTIVE;
            
        }

    }
}
