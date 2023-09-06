using RestSharp;
using RestSharp.Authenticators;
using ZulipStatusUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using NetTools;
using ZulipStatusUpdater.Classes;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web.UI.WebControls;
using Status = ZulipStatusUpdater.Models.Status;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using RestSharp.Serialization.Json;
using System.Xml.Linq;


namespace ZulipStatusUpdater
{
    /// <summary>
    /// Class for setting Zulip status
    /// </summary>
    public static class ZulipStatusService
    {
        /// <summary>
        /// Set zulip status with the API
        /// </summary>
        /// <param name="status">Status to set</param>
        /// <returns>Status setting success</returns>
        public static bool SetZulipStatus(Status status, string localIP)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var formData = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("status_text", (status.SendIP ? status.Text +" "+  localIP: (status.Text?? "").ToString())),
                new KeyValuePair<string, string>("emoji_name", status.Emoji),
                /*new KeyValuePair<string, string>("emoji_code", "1f697"),*/
                /*new KeyValuePair<string, string>("reaction_type", "unicode_emoji"),*/
                new KeyValuePair<string, string>("reaction_type",(GetRealmEmojis().Contains(status.Emoji) ? "realm_emoji":"unicode_emoji"))
            };


            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm + "/api/v1/users/me/status");
            client.Authenticator = new HttpBasicAuthenticator(SettingsManager.GetSettings().ZulipEmail, SettingsManager.GetSettings().ZulipApikey);

            var request = new RestRequest(Method.POST);

            request.RequestFormat = DataFormat.Json;
            foreach (var p in formData)
            {
                request.AddParameter(p.Key, p.Value);
            }

            var response = client.Execute(request);

            if(response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                Program.runicon.Say(JObject.Parse(response.Content).SelectToken("$.msg").ToString(),System.Windows.Forms.ToolTipIcon.Error);
                return false;
            }

            
        }

        public static bool SetZulipPresence(ActivityMonitor.ActivityState presence)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var formData = new List<KeyValuePair<string, string>>() {
                //new KeyValuePair<string, string>("status", presence.ToString().ToLower()),
                new KeyValuePair<string, string>("status", presence.ToString().ToLower()),
                new KeyValuePair<string, string>("ping_only", "true"),
                //new KeyValuePair<string, string>("new_user_input","true"),
                //new KeyValuePair<string, string>("slim_presence","true")
            };


            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm + "/api/v1/users/me/presence");
            client.Authenticator = new HttpBasicAuthenticator(SettingsManager.GetSettings().ZulipEmail, SettingsManager.GetSettings().ZulipApikey);

            var request = new RestRequest(Method.POST);

            request.RequestFormat = DataFormat.Json;
            foreach (var p in formData)
            {
                request.AddParameter(p.Key, p.Value);
            }

            var response = client.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Get zulip status from the API
        /// </summary>
        /// <returns>The current slack status</returns>
        public static Status GetZulipStatus()
        {


            /* Get user status endpoint not implemented... 
             * 
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm + "/api/v1/users/me/status");

            var request = new RestRequest(Method.POST);



            var tokenString = SettingsManager.GetSettings().LegacyApiToken;

            var client = new RestClient("https://slack.com/api/");

            var request = new RestRequest(Method.GET);

            request.Resource = "users.profile.get";
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", "Bearer " + tokenString);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            dynamic content = Newtonsoft.Json.Linq.JObject.Parse(response.content);

            string emoji = content["profile"]["status_emoji"] ?? "";
            string text = content["profile"]["status_text"] ?? "";

            var status = new Status() { Text = text, Emoji = emoji };

            return status;
            */
            var status = new Status() { };

            return status;
        }

        /// <summary>
        /// Get zulip Apikey
        /// </summary>
        /// <returns>Sets the API-key in the settings</returns>
        public static bool GetZulipApiKey(string Password)
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var username = SettingsManager.GetSettings().ZulipEmail;

            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm + "/api/v1/fetch_api_key");
            client.UserAgent = "ZulipStatusUpdater";

            var formData = new List<KeyValuePair<string, string>>() {
                new KeyValuePair<string, string>("username", SettingsManager.GetSettings().ZulipEmail),
                new KeyValuePair<string, string>("password", Password),
            };


            var request = new RestRequest(Method.POST);

            request.RequestFormat = DataFormat.Json;
            foreach (var p in formData)
            {
                request.AddParameter(p.Key, p.Value);
            }


            var response = client.Execute(request);


            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return false;

            dynamic content = Newtonsoft.Json.Linq.JObject.Parse(response.Content);

            var settings = SettingsManager.GetSettings();

            settings.ZulipApikey = content["api_key"] ?? "";

            SettingsManager.ApplySettings(settings);

            if (content["result"] == "success") return true;
            else return false;


        }

        /// <summary>
        /// Get zulip realm emojis
        /// </summary>
        /// <returns>list of realm emojis</returns>
        public static List<string> GetRealmEmojis()
        {
            List<string> ListOfRealmEmojis = new List<string>(0);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var username = SettingsManager.GetSettings().ZulipEmail;

            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm + "/api/v1/realm/emoji");
            client.UserAgent = "ZulipStatusUpdater";

            client.Authenticator = new HttpBasicAuthenticator(SettingsManager.GetSettings().ZulipEmail, SettingsManager.GetSettings().ZulipApikey);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return new List<string>(0);

            dynamic content = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
            foreach (var field in content.emoji)
            {
                foreach (var emoji in field)
                {
                    if (emoji.deactivated == "false")
                    {
                        ListOfRealmEmojis.Add((string)emoji.name);

                    }
                }
            }
            if (content["result"] == "success") return ListOfRealmEmojis;
            else return new List<string>(0);


        }


        /// <summary>
        /// Get Custom profile fields
        /// </summary>
        /// <returns>list of custom profile fields</returns>
        public static List<ProfileField> GetCustomProfileFields()
        {
            List<ProfileField> ListOfProfileFields = new List<ProfileField>(0);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var username = SettingsManager.GetSettings().ZulipEmail;

            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm + "/api/v1/realm/profile_fields");
            client.UserAgent = "ZulipStatusUpdater";

            client.Authenticator = new HttpBasicAuthenticator(SettingsManager.GetSettings().ZulipEmail, SettingsManager.GetSettings().ZulipApikey);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return new List<ProfileField>(0);

            CustomFields custom_fields = JsonConvert.DeserializeObject<CustomFields>(response.Content);
            // Automatic deserialization is not working for the FieldData content of the response. 
            // This loops implements getting options for a combobox
            foreach (ProfileField list_of_options in custom_fields.ProfileFields.Where(field => field.Type == ProfileField.FieldType.LIST_OF_OPTIONS))
            {
                List<FieldDataContent> fieldDataContents = new List<FieldDataContent>();
                JObject list_options_content = JObject.Parse(list_of_options.FieldData_str);
                foreach (JProperty list_option in list_options_content.Properties())
                {
                    FieldDataContent fieldDataContent = new FieldDataContent();
                    fieldDataContent.Text = list_option.Value["text"].ToString();
                    fieldDataContent.Order = (int)list_option.Value["order"];
                    fieldDataContent.Value = list_option.Name;
                    fieldDataContents.Add(fieldDataContent);
                }
                list_of_options.FieldData = fieldDataContents.OrderBy(o => o.Order).ToList();
            }


            ListOfProfileFields = custom_fields.ProfileFields.ToList();
            if (custom_fields.Result == "success") return ListOfProfileFields;
            else return new List<ProfileField>(0);
        }

        /// <summary>
        /// Get Custom profile fields content
        /// </summary>
        /// <returns>list of custom profile fields</returns>
        public static List<ProfileField> FillCustomProfileFields(List<ProfileField> list_to_fill)
        {
            //List<ProfileField> ListOfProfileFields = new List<ProfileField>(0);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var username = SettingsManager.GetSettings().ZulipEmail;
            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm + "/api/v1/users/me");
            client.UserAgent = "ZulipStatusUpdater";

            client.Authenticator = new HttpBasicAuthenticator(SettingsManager.GetSettings().ZulipEmail, SettingsManager.GetSettings().ZulipApikey);
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return new List<ProfileField>(0);

            dynamic content = Newtonsoft.Json.Linq.JObject.Parse(response.Content);

            foreach (JProperty fields in content.profile_data)
            {
                bool containsItem = list_to_fill.Any(item => item.Id == int.Parse(fields.Name));
                string name = fields.Name;
                string value = fields.Value["value"].ToString();
                if (containsItem)
                {
                    list_to_fill.First(item => item.Id == int.Parse(fields.Name)).Content = value;
                }
            }
            //List<ProfileField> SortedList = ListOfProfileFields.OrderBy(o => o.order).ToList();
            if (content["result"] == "success") return list_to_fill;
            else return new List<ProfileField>(0);
        }


        /// <summary>
        /// Update values of custom profile fields on server
        /// </summary>
        /// <returns>list of custom profile fields</returns>
        public static void UpdateProfileOnServer(ProfileField field_to_update)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var username = SettingsManager.GetSettings().ZulipEmail;
            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm + "/api/v1/users/me/profile_data");
            client.UserAgent = "ZulipStatusUpdater";

            client.Authenticator = new HttpBasicAuthenticator(SettingsManager.GetSettings().ZulipEmail, SettingsManager.GetSettings().ZulipApikey);
            var request = new RestRequest(Method.PATCH);
            request.RequestFormat = DataFormat.Json;


            //request.AddJsonBody(new { A = "foo", B = "bar" });
            var json = JsonConvert.SerializeObject(
                new[] {
                         new {id = field_to_update.Id , value = field_to_update.Content },
                        }
            );

            request.AddParameter("data", json);

            var response = client.Execute(request);


            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return;
            }

            dynamic content = Newtonsoft.Json.Linq.JObject.Parse(response.Content);


            //List<ProfileField> SortedList = ListOfProfileFields.OrderBy(o => o.order).ToList();
            if (content["result"] == "success") return;
            else return;
        }


        public static bool CheckServerStatus()
        {
            IRestResponse resp = ZulipRequest("/api/v1/users/me", Method.GET);

            if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return false;
            }

            //JObject o = JObject.Parse(resp.Content);
            //$.result            
            if (JObject.Parse(resp.Content).SelectToken("$.result").ToString() == "success")
            { 
                return true;
            }
            else
            {
                return false;
            }
        }

        private static IRestResponse ZulipRequest(string endpoint, RestSharp.Method METHOD)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var username = SettingsManager.GetSettings().ZulipEmail;

            var client = new RestClient(SettingsManager.GetSettings().ZulipRealm + endpoint);
            client.UserAgent = "ZulipStatusUpdater";

            client.Authenticator = new HttpBasicAuthenticator(SettingsManager.GetSettings().ZulipEmail, SettingsManager.GetSettings().ZulipApikey);
            var request = new RestRequest(METHOD);
            var response = client.Execute(request);
            return response;
        }



        /// <summary>
        /// Get API key by SSO
        /// </summary>
        /// <returns>Sets the API-key in the settings by SSO</returns>
        //https://chat.zulip.org/#narrow/stream/16-desktop/topic/desktop.20app.20OAuth/near/803919
        // Create secret: 0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef
        // open browser with this url and secret: 
        //https://org.zulipchat.com/accounts/login/google/?mobile_flow_otp=0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef
        // The user needs to copy key to application
        // The app decrypts the key by XORing otp_encrypted_api_key with mobile_flow_otp to get the API key.
        //
        // How the desktop-client does it: 
        // https://github.com/zulip/zulip-mobile/blob/49ed2ef5de3892edf7bb28fbe01271903913bb3d/src/start/webAuth.js
        // How the server responds 
        // https://github.com/zulip/zulip/blob/f4d2d199e249f9c6437a952c201cb0d163eb9069/zerver/lib/mobile_auth_otp.py
        //
        //
        // The solution here is a hack using the mobile otp endpoint. 
        // ZsU registers as available for zulip:// URI. 
        // InitializeSSOLogin() creates the secret and opens a browser window where the user can authenticate using google SSO
        // When the page is redirected to zulip://... with the authentication token, a new instance of ZsU is launched capturing 
        // the (encrypted) token, saving it to the settingsfile and killing it self. 
        // Then DecryptAPIkeySSO can be called using the saved auth token and secret. 

        public static byte[] InitializeSSOLogin(string realm)
        {

            var randomGenerator = System.Security.Cryptography.RandomNumberGenerator.Create();

            byte[] randomBytes = new byte[32];
            randomGenerator.GetBytes(randomBytes, 0, 32);

            string randomString = BitConverter.ToString(randomBytes).Replace("-", "");

            var settings = SettingsManager.GetSettings();

            string target = realm + "/accounts/login/google/?mobile_flow_otp=";
            target += randomString;

            System.Diagnostics.Process.Start(target);

            return randomBytes;
        }


        public static string DecryptAPIkeySSO(string encryptedAPIkey, byte[] otp)
        {
            string APIkey = "";
            try {
                byte[] array = Tools.StringToByteArray(encryptedAPIkey);
                byte[] xored = Tools.exclusiveOR(otp, array);
                APIkey = System.Text.Encoding.ASCII.GetString(xored);
            }
            catch
            {
                Program.runicon.Say("Authentication failed");
            }
            return APIkey;
           }

    }
}
