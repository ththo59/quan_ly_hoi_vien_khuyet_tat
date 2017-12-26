using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DauThau.Forms;
using System.IO;

namespace DauThau.Class
{
    class clsConnection
    {
        public static SqlConnection _conn;
        public static string registryKeyName = "stringConnection";
        public static void OpenConn()
        {
            WaitDialogForm _wait = new WaitDialogForm("Hệ thống đang kết nối dữ liệu ...", "Vui lòng đợi giây lát");
            try
            {
                //string _connect = File.ReadAllText(Application.StartupPath + @"\config.txt");
                


                //Đọc kết nối được lưu trong registry
                //Lưu ý: cần đặt tên ProductName lại sao mỗi năm build
                string _connect = RegistryHelper.Read(registryKeyName);

                //Giải mã chuổi kết nối.
                _connect = clsEncryption.decode(_connect);
                _conn = new SqlConnection(_connect);
                _conn.Open();
                _wait.Close();
            }
            catch (Exception)
            {
                _wait.Close();
                frmConnectionDatabase f = new frmConnectionDatabase();
                f.ShowDialog();
                //XtraMessageBox.Show("Không thể kết nối cơ sở dữ liệu. Vui lòng kiểm tra lại.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                Application.Exit();
            }

        }


        /// <summary>
        /// Đọc chuổi kết nối
        /// </summary>
        /// <returns></returns>
        public static string readConnectionString()
        {
            String file_path = Application.StartupPath + @"\config.txt";
            string _connect = string.Empty;
            if (File.Exists(file_path))
            {
                _connect = File.ReadAllText(Application.StartupPath + @"\config.txt");
            }

            //Giải mã chuổi kết nối.
            _connect = clsEncryption.decode(_connect);

            return _connect;
        }

        /// <summary>
        /// Ghi chuỗi kết nối ra file.
        /// </summary>
        /// <param name="lines"></param>
        public static void writeConnectionString(string lines)
        {
            string path = Application.StartupPath + "\\config.txt";
            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
            //mã hóa kết nối.
            lines = clsEncryption.encode(lines);
            file.WriteLine(lines);
            file.Close();
        }
    }
}
