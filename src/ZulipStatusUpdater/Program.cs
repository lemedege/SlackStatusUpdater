﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using ZulipStatusUpdater.Classes;

namespace ZulipStatusUpdater
{
    public static class Constants
    {
        public static readonly string NAME_OF_APP = "ZulipStatusUpdater";
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static RunIcon runicon;
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Register URI scheme so that zulip:// URIs will be opened by ZulipStatusUpdater
            Tools.RegisterURLProtocol("zulip", Assembly.GetExecutingAssembly().Location);


            //If arguments is passed we asume that the encrypted OPT key is passed from browser redirect
            if (args.Length > 0)
            {
                var url = new Uri(args[0]);
                string access_token = HttpUtility.ParseQueryString(url.Query).Get("otp_encrypted_api_key");
                string email = HttpUtility.ParseQueryString(url.Query).Get("email");
                var settings = SettingsManager.GetSettings();
                settings.LastOTPEncryptedApiToken = access_token;
                settings.ZulipEmail = email;
                SettingsManager.ApplySettings(settings);
                Application.Exit();
                return;
            }
            if (PriorProcess() != null)
            {
                MessageBox.Show("Another instance of "+ Constants.NAME_OF_APP + " is already running.");
                Application.Exit();
                return;
            }

            // Start automatic status updates process
            runicon = new RunIcon();
            UpdateProcess.Start();
            // Make sure the application runs!
            Application.Run(Program.runicon);
        }

        public static Process PriorProcess()
        // Returns a System.Diagnostics.Process pointing to
        // a pre-existing process with the same name as the
        // current one, if any; or null if the current process
        // is unique.
        {
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) &&
                    (p.MainModule.FileName == curr.MainModule.FileName))
                    return p;
            }
            return null;
        }

    }
}
