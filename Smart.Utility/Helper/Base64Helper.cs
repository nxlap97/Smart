using System;
using System.Collections.Generic;
using System.Text;

namespace Smart.Utility.Helper
{
    public static class Base64Helper
    {
        public static string Base64Encode(this string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;
            try
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                return Convert.ToBase64String(plainTextBytes);
            }
            catch
            {
                return string.Empty;
            }

        }

        public static string Base64Decode(this string base64EncodedData)
        {
            if (string.IsNullOrEmpty(base64EncodedData))
                return string.Empty;
            try
            {
                var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception)
            {

                return string.Empty;
            }

        }
    }
}
