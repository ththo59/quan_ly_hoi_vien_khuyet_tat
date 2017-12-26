using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DauThau.Class;
using Microsoft.Win32;

namespace DauThau.Forms
{
    public partial class frmConnectionDatabase : DevExpress.XtraEditors.XtraForm
    {
        public frmConnectionDatabase()
        {
            InitializeComponent();
        }

        

        private void frmConnectionDatabase_Load(object sender, EventArgs e)
        {
            List<object> _list = new List<object>();
            Object item = new
            {
                ID = clsConstant.WINDOW_AUTHENTICATION,
                TEN = "Window Authentication"
            };
            _list.Add(item);
            Object item2 = new
            {
                ID = clsConstant.SERVER_SQL_AUTHENTICATION,
                TEN = "SQL Server Authentication"
            };
            _list.Add(item2);
            lueAuth.Properties.DataSource = _list;
            lueAuth.EditValue = clsConstant.WINDOW_AUTHENTICATION;

            //Load thông tin cấu hình hiện tại
            string _connect = RegistryHelper.Read(clsConnection.registryKeyName);
            //Giải mã chuổi kết nối.
            string currentConn = clsEncryption.decode(_connect);

            string[] arrConnection = currentConn.Split(';');
            if(arrConnection.Length > 0)
            {
                switch (arrConnection.Length)
                {
                    //Chứng thực WINDOW_AUTHENTICATION
                    case 3:
                        txtServer.Text = arrConnection[0].Replace("Data Source=", "");
                        txtDB.Text = arrConnection[1].Replace("Initial Catalog=", "");
                        lueAuth.EditValue = clsConstant.WINDOW_AUTHENTICATION;
                        break;
                    //Chứng thực SERVER_SQL_AUTHENTICATION
                    case 4:
                        string ipAddress = arrConnection[0].Replace("Data Source=", "");
                        string[] ipAddressArr = ipAddress.Split(',');
                        if(ipAddressArr.Length == 2)
                        {
                            txtServer.Text = ipAddressArr[0];
                            txtPort.Text = ipAddressArr[1];
                        }
                        txtDB.Text = arrConnection[1].Replace("Initial Catalog=", "");
                        txtUser.Text = arrConnection[2].Replace("User ID=", "");
                        txtPass.Text = arrConnection[3].Replace("Password=", "");
                        lueAuth.EditValue = clsConstant.SERVER_SQL_AUTHENTICATION;
                        break;
                    default:
                        break;
                }
                
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Compose a string that consists of three lines.
            int auth = Convert.ToInt32(lueAuth.EditValue);
            
            string lines = string.Empty;
            if (auth == 1)
            {
                 lines = string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", txtServer.Text, txtDB.Text);
            }
            else {
                string ipAddress = txtServer.Text;
                if (txtPort.Text != "") {
                    ipAddress = string.Format("{0},{1}", ipAddress, txtPort.Text);
                }
                 lines = string.Format("Data Source={0};Initial Catalog={1};User ID={2}; Password={3}", ipAddress, txtDB.Text, txtUser.Text, txtPass.Text);
            }


            //// Write the string to a file.
            //clsConnection.writeConnectionString(lines);

            //Write info connection to registry
            lines = clsEncryption.encode(lines);
            Boolean isSuccess =  RegistryHelper.Write(clsConnection.registryKeyName, lines);
            if (!isSuccess) {
                return;
            }

            try
            {
                //string _connect = clsConnection.readConnectionString();
                string _connect = RegistryHelper.Read(clsConnection.registryKeyName);
                _connect = clsEncryption.decode(_connect);
                SqlConnection _conn = new SqlConnection(_connect);
                _conn.Open();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Không thể kết nối cơ sở dữ liệu. Vui lòng kiểm tra lại.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            XtraMessageBox.Show("Kết nối dữ liệu thành công. Chương trình sẽ khởi động lại.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            System.Windows.Forms.Application.Restart();
        }

        private void lueAuth_EditValueChanged(object sender, EventArgs e)
        {
            if (lueAuth.EditValue != null) {
                int auth = Convert.ToInt16(lueAuth.EditValue);
                txtUser.Enabled = txtPass.Enabled = txtPort.Enabled = auth == 2;
            }
        }
    }
}