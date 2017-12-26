using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace DauThau.Class
{
    public static class RegistryHelper
    {
        static string subKey = "Software\\" + Application.ProductName;
        static RegistryKey baseRegistryKey = Registry.CurrentUser;

        /// <summary>
        /// Đọc registry theo keyName
        /// </summary>
        public static string Read(string KeyName)
        {
            // Opening the registry key
            RegistryKey rk = baseRegistryKey;
            // Open a subKey as read-only
            RegistryKey sk1 = rk.OpenSubKey(subKey);
            // If the RegistrySubKey doesn't exist -> (null)
            if (sk1 == null)
            {
                return null;
            }

            try
            {
                // If the RegistryKey exists I get its value
                // or null is returned.
                return (string)sk1.GetValue(KeyName);
            }
            catch (Exception e)
            {
                clsMessage.MessageError(string.Format("{0}\n{1}", "Reading registry " + KeyName, e.Message));
                return null;
            }
        }

        /// <summary>
        /// Đọc registry theo KeyName
        /// </summary>
        public static bool Write(string KeyName, object Value)
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;

                // I have to use CreateSubKey 
                // (create or open it if already exits), 
                // 'cause OpenSubKey open a subKey as read-only
                RegistryKey sk1 = rk.CreateSubKey(subKey);

                // Save the value
                sk1.SetValue(KeyName, Value);

                return true;
            }
            catch (Exception e)
            {
                clsMessage.MessageError(string.Format("{0}\n{1}", "Writing registry " + KeyName, e.Message));
                return false;
            }
        }

        /// <summary>
        /// Xóa registry theo keyName
        /// </summary>
        public static bool DeleteKey(string KeyName)
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(subKey);
                // If the RegistrySubKey doesn't exists -> (true)
                if (sk1 == null)
                    return true;
                else
                    sk1.DeleteValue(KeyName);

                return true;
            }
            catch (Exception e)
            {
                clsMessage.MessageError(string.Format("{0}\n{1}", "Deleting registry " + KeyName, e.Message));
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool DeleteSubKeyTree()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                // If the RegistryKey exists, I delete it
                if (sk1 != null)
                    rk.DeleteSubKeyTree(subKey);

                return true;
            }
            catch (Exception e)
            {
                clsMessage.MessageError(string.Format("{0}\n{1}", "Deleting registry " + subKey, e.Message));
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static int SubKeyCount()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                // If the RegistryKey exists...
                if (sk1 != null)
                    return sk1.SubKeyCount;
                else
                    return 0;
            }
            catch (Exception e)
            {
                clsMessage.MessageError(string.Format("{0}\n{1}", "Retriving subkeys of " + subKey, e.Message));
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static int ValueCount()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                // If the RegistryKey exists...
                if (sk1 != null)
                    return sk1.ValueCount;
                else
                    return 0;
            }
            catch (Exception e)
            {
                clsMessage.MessageError(string.Format("{0}\n{1}", "Retriving subkeys of " + subKey, e.Message));
                return 0;
            }
        }
    }
}
