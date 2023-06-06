using ZulipStatusUpdater.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;
using System.Runtime.CompilerServices;

namespace ZulipStatusUpdater
{

    class RunIcon : ApplicationContext
    {
        // Private field for the settings form to help ensure only one instance of it is opened
        private static ProfileForm _profileForm;
        //Component declarations
        public NotifyIcon TrayIcon;
        private ContextMenuStrip TrayIconContextMenu;
        private ToolStripMenuItem SettingsMenuItem;
        private ToolStripMenuItem DisableMenuItem;
        private ToolStripMenuItem CloseMenuItem;

        public RunIcon()
        {
            Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
            InitializeComponent();
            TrayIcon.Visible = true;
        }

        private void InitializeComponent()
        {
            TrayIcon = new NotifyIcon();
            TrayIcon.Text = Constants.NAME_OF_APP;

            TrayIcon.Icon = Properties.Resources.zulipicon;

            //handle clicks on the icon:
            TrayIcon.DoubleClick += TrayIcon_DoubleClick;
            TrayIcon.MouseClick += TrayIcon_LeftClick;

            //Add a context menu to the TrayIcon:
            TrayIconContextMenu = new ContextMenuStrip();
            SettingsMenuItem = new ToolStripMenuItem();
            DisableMenuItem = new ToolStripMenuItem();
            CloseMenuItem = new ToolStripMenuItem();
            TrayIconContextMenu.SuspendLayout();

            // 
            // TrayIconContextMenu
            // 
            this.TrayIconContextMenu.Items.AddRange(new ToolStripItem[] {
            this.SettingsMenuItem,
            this.DisableMenuItem,
            this.CloseMenuItem});

            this.TrayIconContextMenu.Name = "TrayIconContextMenu";
           
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Text = "Settings";
            this.SettingsMenuItem.Click += new EventHandler(this.SettingsItem_Click);

            // 
            // DisableSettingsMenu
            // 
            this.DisableMenuItem.Name = "DisableMenuItem";
            this.DisableMenuItem.Text = "Disable";
            this.DisableMenuItem.CheckOnClick = true;
            this.DisableMenuItem.Click += new EventHandler(this.DisableItem_Click);

            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Text = "Exit";
            this.CloseMenuItem.Click += new EventHandler(this.CloseMenuItem_Click);

            TrayIconContextMenu.ResumeLayout(false);
            TrayIcon.ContextMenuStrip = TrayIconContextMenu;
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            //Cleanup so that the icon will be removed when the application is closed
            TrayIcon.Visible = false;
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            //Here, you can do stuff if the tray icon is doubleclicked
            //TrayIcon.ShowBalloonTip(10000);
        }

        private void TrayIcon_LeftClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if(me.Button == MouseButtons.Left)
            { 
            Say("Force updating status");
            UpdateProcess.Execute();
            }
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private void DisableItem_Click(object sender, EventArgs e)
        {
            var settings = SettingsManager.GetSettings();
            settings.disableStatusUpdate = DisableMenuItem.Checked;
            SettingsManager.ApplySettings(settings);
            Say("Updates "+(SettingsManager.GetSettings().disableStatusUpdate ? "disabled": "enabled"));
        }

        public void Say(string text, ToolTipIcon icon = ToolTipIcon.Info)
        {
            int timeout = 3;
            TrayIcon.BalloonTipIcon = icon;
            TrayIcon.BalloonTipText = text;
            //TrayIcon.BalloonTipTitle = title;
            TrayIcon.ShowBalloonTip(timeout);
        }

        public void SetIconHoverText(string text)
        {
         TrayIcon.Text = "text";


        }


        /// <summary>
        /// Handle Settings click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsItem_Click(object sender, EventArgs e)
        {
            // Check that settings form is not already open
            if (_profileForm == null || _profileForm.IsDisposed)
            {
                // Open settings form
                _profileForm = ProfileForm.GetInstance;
                _profileForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                _profileForm.ShowDialog();
                _profileForm.Dispose();
            }
        }

    }





    /* /// <summary>
     /// Disposable class for handling the system tray icon
     /// </summary>
     public class TrayIcon
     {

         /// <summary>
         ///  System tray icon
         /// </summary>
         NotifyIcon ni;

         /// <summary>
         /// Constructor
         /// </summary>
         public TrayIcon()
         {
             // Initialize NotifyIcon
             ni = new NotifyIcon();
             ni.ContextMenuStrip = ContextMenuFactory.Create();
             ni.Icon = Resources.zulipicon;
             ni.Visible = true;
             ni.Click += new System.EventHandler(NotifyIcon_Click);
         }

         /// <summary>
         /// Dispose
         /// </summary>
         public void Dispose()
         {
             // Disappear the system tray icon as soon as the application exits
             ni.Icon = null;
             ni.Visible = false;
             ni.Dispose();
         }

         public void NotifyIcon_Click(object sender, System.EventArgs e)
         {
             UpdateProcess.Execute();
         }

         public void Show_Ballon(string text)
         {

             int timeout = 3;
             ToolTipIcon icon = new ToolTipIcon();
             ni.ShowBalloonTip(timeout,text,text,icon);

         }
     }*/
}
