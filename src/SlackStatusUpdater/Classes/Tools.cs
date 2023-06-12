using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZulipStatusUpdater.Classes
{
    public static class Tools
    {
        // using Microsoft.Win32; do not forget!
        /// </summary>
        /// <param name="protocolName">name of the protocol (e.g. "zulip"")</param>
        /// <param name="applicationPath">Complete file system path to the EXE file, which processes the URL being called.</param>
        public static void RegisterURLProtocol(string protocolName, string applicationPath)
        {
            try
            {
                // Create new key for desired URL protocol

                var KeyTest = Registry.CurrentUser.OpenSubKey("Software", true).OpenSubKey("Classes", true);
                RegistryKey key = KeyTest.CreateSubKey(protocolName);
                key.SetValue("URL Protocol", protocolName);
                key.CreateSubKey(@"shell\open\command").SetValue("", "\"" + applicationPath + "\" \"%1\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            if (hex.Length % 2 == 1)
                throw new Exception("The binary key cannot have an odd number of digits");

            byte[] arr = new byte[hex.Length >> 1];

            for (int i = 0; i < hex.Length >> 1; ++i)
            {
                arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
            }

            return arr;
        }
        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        public static byte[] exclusiveOR(byte[] arr1, byte[] arr2)
        {
            if (arr1.Length != arr2.Length)
                throw new ArgumentException("arr1 and arr2 are not the same length");

            byte[] result = new byte[arr1.Length];

            for (int i = 0; i < arr1.Length; ++i)
                result[i] = (byte)(arr1[i] ^ arr2[i]);

            return result;
        }

        // <summary>
        /// Checks whether the URL includes https:// or not and adds it if necessary. Also removes any trailing slash.
        /// </summary>
        /// <param name="ServerURL"></param>
        /// <returns></returns>
        public static string TidyUpURL(string ServerURL)
        {
            string Result = ServerURL.StartsWith("https://") ? ServerURL : "https://" + ServerURL;
            Result = Result.EndsWith("/") ? Result.Remove(Result.LastIndexOf('/')) : Result;

            return Result;
        }


    }


}
