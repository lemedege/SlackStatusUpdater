using System;
using System.Collections.Generic;
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

            if(args.Length > 0)
            {
                var url = new Uri(args[0]);
                String access_token = HttpUtility.ParseQueryString(url.Query).Get("otp_encrypted_api_key");
                String email = HttpUtility.ParseQueryString(url.Query).Get("email");
                var settings = SettingsManager.GetSettings();
                settings.LastOTPEncryptedApiToken = access_token;
                settings.ZulipEmail = email;
                SettingsManager.ApplySettings(settings);
                Application.Exit();
                return;
            }
            
            // Start automatic status updates process
            runicon = new RunIcon();
            UpdateProcess.Start();
            // Make sure the application runs!
            Application.Run(Program.runicon);


        }
    }
}
