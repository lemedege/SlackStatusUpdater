using RestSharp;
using ZulipStatusUpdater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace ZulipStatusUpdater
{
    /// <summary>
    /// Class for setting slack status
    /// </summary>
    public static class SlackStatusService
    {
        /// <summary>
        /// Set slack status with the API
        /// </summary>
        /// <param name="status">Status to set</param>
        /// <returns>Status setting success</returns>
        public static bool SetSlackStatus(Status status)
        {
            var tokenString = SettingsManager.GetSettings().LegacyApiToken;

            var client = new RestClient("https://slack.com/api/");

            var request = new RestRequest(Method.POST);

            request.Resource = "users.profile.set";
            request.AddHeader("Content-Type", "application/json");
            // Slack API wants string "Bearer " in front of token
            request.AddHeader("Authorization", "Bearer " + tokenString);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(
                new
                {
                    profile = new
                    {
                        status_text = status.Text,
                        status_emoji = status.Emoji
                    }
                }
                );

            var response = client.Execute(request);

            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Get slack status from the API
        /// </summary>
        /// <returns>The current slack status</returns>
        public static Status GetSlackStatus()
        {
            var tokenString = SettingsManager.GetSettings().LegacyApiToken;

            var client = new RestClient("https://slack.com/api/");

            var request = new RestRequest(Method.GET);

            request.Resource = "users.profile.get";
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", "Bearer " + tokenString);
            request.RequestFormat = DataFormat.Json;

            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return null;

            dynamic content = Newtonsoft.Json.Linq.JObject.Parse(response.Content);

            string emoji = content["profile"]["status_emoji"] ?? "";
            string text = content["profile"]["status_text"] ?? "";

            var status = new Status() { Text = text, Emoji = emoji };

            return status;

        }
    }
}
