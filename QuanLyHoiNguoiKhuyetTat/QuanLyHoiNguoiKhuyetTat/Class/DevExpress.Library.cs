using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using System.Security.Cryptography;
using DevExpress.XtraPrinting.Preview;
using System.Net.NetworkInformation;
using System.IO;

namespace DauThau.Class
{
    class LibraryDev
    {
        public static string _username = "ththo59";
        public static string _pass = "giadinhhanhphuc";
        public static string _key = "tinhkhucvang";
        public static string _pathFolderSuccess = "C:\\Program Files\\Work_";
        public static string _pathSuccess = _pathFolderSuccess + "\\tmp.xml";
        public static string _pathDateTimesCurrent = _pathFolderSuccess + "\\_tmp.xml";
        public static string _strDeath = string.Empty;
        public static Boolean _print = false;
        public static Boolean _update = false;
        public static Boolean _excel = false;

        #region Security

        public static string Encrypt(string key, string content)
        {
            var toEncryptArray = Encoding.UTF8.GetBytes(content);
            var hashmd5 = new MD5CryptoServiceProvider();
            var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
            var tdes = new TripleDESCryptoServiceProvider { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
            var cTransform = tdes.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string key, string content)
        {
            var toEncryptArray = Convert.FromBase64String(content);
            var hashmd5 = new MD5CryptoServiceProvider();
            var keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
            var tdes = new TripleDESCryptoServiceProvider { Key = keyArray, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };
            var cTransform = tdes.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(
            toEncryptArray, 0, toEncryptArray.Length);
            return Encoding.UTF8.GetString(resultArray);
        }

        public static void PermissionButton(ControlsLib.ButtonsArray btnControl, PreviewBar _preview )
        {
            //if(_preview!=null)
            //_preview.Visible = _excel;

            //if (btnControl.ButtonModifyVisible)
            //btnControl.ButtonModifyVisible = _update;

            //if (btnControl.ButtonPrintVisible)
            //btnControl.ButtonPrintVisible = _print;
        }

        public static DataTable ActiveEvent()
        {
            DataTable dt = new DataTable();
            try
            {
                
                DataSet ds = new DataSet();
                ds.ReadXml(_pathSuccess);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string _permission = LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col4"] + string.Empty);
                    string _active = LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col6"] + string.Empty);
                    string _address = ds.Tables[0].Rows[0]["col7"] + string.Empty;
                    string _address_encypt = LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col8"] + string.Empty);
                    DateTime _dayEnd;

                    try
                    {
                        _dayEnd = Convert.ToDateTime(LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col10"] + string.Empty));
                    }
                    catch (Exception)
                    {
                        clsMessage.MessageExclamation("Vui lòng hiệu chỉnh thời gian theo định dạng dd/MM/yyyy.");
                        return dt;
                    }

                    if (_dayEnd.Date < DateTime.Now.Date)
                    {
                        _strDeath = "Hết hạn sử dụng phần mềm. Vui lòng kích hoạt.";
                        File.Delete(_pathSuccess);
                        return dt;
                    }

                    if (CheckDateTimesCurrent() > 10)
                    {
                        _strDeath = "Vui lòng hiệu chỉnh đúng thời gian hiện tại.";
                        return dt;
                    }

                    if (_active == "active" && _address == _address_encypt)
                    {
                        _print = _permission.Contains("print");
                        _update = _permission.Contains("update");
                        _excel = _permission.Contains("excel");
                    }
                    //Lấy dữ liệu kích hoạt
                    dt.Columns.Add("Key", typeof(String));//Key
                    dt.Columns.Add("Hospital", typeof(String));//bệnh viện
                    dt.Columns.Add("Day", typeof(DateTime));//ngày kích hoạt
                    dt.Columns.Add("DayEnd", typeof(DateTime));//ngày hết hạn
                    dt.Columns.Add("Time", typeof(String));//thời gian su dung
                    dt.Columns.Add("Permission", typeof(String));//quyền
                    dt.Columns.Add("Key_Enctypt", typeof(String));//Encrypt
                    dt.Columns.Add("Active", typeof(String));//Active

                    DataRow r = dt.NewRow();
                    r["Key"] = ds.Tables[0].Rows[0]["col1"] + string.Empty;
                    r["Hospital"] = LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col2"] + string.Empty);
                    r["Time"] = LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col3"] + string.Empty);
                    r["Permission"] = LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col4"] + string.Empty);
                    r["Key_Enctypt"] = ds.Tables[0].Rows[0]["col5"] + string.Empty; ;
                    r["Active"] = LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col6"] + string.Empty);
                    r["Day"] = Convert.ToDateTime(LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col9"] + string.Empty));
                    r["DayEnd"] = Convert.ToDateTime(LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col10"] + string.Empty));
                    dt.Rows.Add(r);
                }

                return dt;
            }
            catch (Exception)
            {
                return dt;
            }
            
        }

        public static void DeleteActive()
        {
            try
            {
                File.Delete(_pathSuccess);
                File.Delete(_pathDateTimesCurrent);
                clsMessage.MessageInfo("Xóa Key cũ thành công!.");
            }
            catch (Exception ex)
            {
                clsMessage.MessageExclamation(ex.Message);
                
            }
        }
        public static string GetMACAddress()
        {
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                String sMacAddress = string.Empty;
                foreach (NetworkInterface adapter in nics)
                {
                    if (sMacAddress == String.Empty)// only return MAC Address from first card  
                    {
                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        sMacAddress = adapter.GetPhysicalAddress().ToString();
                    }
                } return sMacAddress;
            }
            catch (Exception)
            {
                return string.Empty;
            }
            
        }

        public static void Active(DataSet ds,string path, string _address)
        {
            ds.Tables[0].Rows[0]["col6"] = LibraryDev.Encrypt(LibraryDev._key, "active");
            ds.Tables[0].WriteXml(path);
            System.IO.Directory.CreateDirectory(LibraryDev._pathFolderSuccess);

            ds.Tables[0].Columns.Add("col7", typeof(String));//Active
            ds.Tables[0].Columns.Add("col8", typeof(String));
            ds.Tables[0].Rows[0]["col7"] = _address;
            ds.Tables[0].Rows[0]["col8"] = LibraryDev.Encrypt(LibraryDev._key, _address);
            ds.Tables[0].WriteXml(LibraryDev._pathSuccess);
        }

        /// <summary>
        /// Kiểm tra trong một ngày sử dụng bao nhiêu lần
        /// </summary>
        public static int CheckDateTimesCurrent()
        {
            try
            {
                DataSet ds = new DataSet();
                int _times = 0;
                if (File.Exists(_pathDateTimesCurrent))
                {
                    ds.ReadXml(_pathDateTimesCurrent);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DateTime _date = Convert.ToDateTime(LibraryDev.Decrypt(_key, ds.Tables[0].Rows[0]["col1"] + string.Empty));
                        _times = Convert.ToInt32(LibraryDev.Decrypt(_key, ds.Tables[0].Rows[0]["col2"] + string.Empty));

                        //Nếu ngày hiện tại lớn hơn ngày log, cập nhật ngày mới
                        if (DateTime.Now.Date > _date)
                        {
                            _date = DateTime.Now.Date;
                            _times = 1;
                        }
                        else
                            _times = _times + 1;

                        ds.Tables[0].Rows[0]["col1"] = LibraryDev.Encrypt(LibraryDev._key, _date + string.Empty);
                        ds.Tables[0].Rows[0]["col2"] = LibraryDev.Encrypt(LibraryDev._key, _times + string.Empty);
                        ds.Tables[0].WriteXml(_pathDateTimesCurrent);
                    }
                }
                else
                {
                    //Tạo xml mới ngày hiện tại
                    ds.Tables.Add("DSkinWin");
                    ds.Tables[0].Columns.Add("col1", typeof(String));//Ngày
                    ds.Tables[0].Columns.Add("col2", typeof(String));//Số lần mở

                    DataRow r = ds.Tables[0].NewRow();
                    r["col1"] = LibraryDev.Encrypt(LibraryDev._key, DateTime.Now.Date + string.Empty);
                    r["col2"] = LibraryDev.Encrypt(LibraryDev._key, "1");
                    _times =1;
                    ds.Tables[0].Rows.Add(r);

                    ds.Tables[0].WriteXml(_pathDateTimesCurrent);
                }

                return _times;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion
    }
}
