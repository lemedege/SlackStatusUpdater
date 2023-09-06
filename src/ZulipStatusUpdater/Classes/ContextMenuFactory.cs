using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZulipStatusUpdater
{
    /// <summary>
    /// Class for generating the context menu of the application system tray icon.
    /// </summary>
    public static class ContextMenuFactory
    {
        // Private field for the settings form to help ensure only one instance of it is opened
        private static SettingsForm _settingsForm;
        public static bool test_bool;
        
        /// <summary>
        /// Create the context menu for the tray icon.
        /// </summary>
        /// <returns>The context menu for the tray icon</returns>
        public static ContextMenuStrip Create()
        {
            ContextMenuStrip cms = new ContextMenuStrip();


            /*
            // Quick set profile
            ToolStripMenuItem quickSave = new ToolStripMenuItem("Quicksave profile");
            quickSave.Click += QuickSave_Click;
            cms.Items.Add(quickSave);*/

            
            // Settings selection
            ToolStripMenuItem settingsItem = new ToolStripMenuItem("Settings");
            settingsItem.Click += SettingsItem_Click;
            cms.Items.Add(settingsItem);

            //Disable program temporary
            ToolStripMenuItem disableItem = new ToolStripMenuItem("Disable program");
            disableItem.CheckOnClick = true;
            //test_bool = disableItem.Checked;
            //disableItem.CheckedChanged += disableItem_Changed();
            
          
            cms.Items.Add(disableItem);

            // Exit selection
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");
            exitItem.Click += ExitItem_Click;
            cms.Items.Add(exitItem);

            return cms;
        }


        /// <summary>
        /// Handle QuickSave click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void QuickSave_Click(object sender, EventArgs e)
        {
            // Save current connected wifi and Slack status as a profile
            QuickSave.SaveCurrentProfile();
        }

        /// <summary>
        /// Handle Settings click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void SettingsItem_Click(object sender, EventArgs e)
        {
            // Check that settings form is not already open
            if (_settingsForm == null || _settingsForm.IsDisposed)
            {
                // Open settings form
                _settingsForm = SettingsForm.GetInstance;
                _settingsForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                _settingsForm.ShowDialog();
                _settingsForm.Dispose();
            }
        }

        /// <summary>
        /// Handle Disable item checked changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void disableItem_Changed(object sender, EventArgs e)
        {
            SettingsManager.GetSettings().disableStatusUpdate = test_bool;
        }



        /// <summary>
        /// Handle Exit click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ExitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
