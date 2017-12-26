using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DauThau.Class
{
    class clsEncryption
    {
        public static string encode(string text)
        {
            if (string.IsNullOrEmpty(text)) {
                return text;
            }

            byte[] mybyte = System.Text.Encoding.UTF8.GetBytes(text);
            string returntext = System.Convert.ToBase64String(mybyte);
            return returntext;
        }

        public static string decode(string text)
        {
            if (string.IsNullOrEmpty(text)) {
                return text;
            }

            byte[] mybyte = System.Convert.FromBase64String(text);
            string returntext = System.Text.Encoding.UTF8.GetString(mybyte);
            return returntext;
        }
    }
}
