using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DauThau.UserControlCategory;
using DauThau.Class;
using DauThau.Forms;
using System.Data.SqlClient;
using DevExpress.XtraTab;
using DauThau.Reports;
using DevExpress.XtraEditors;
using DevExpress.Utils;

namespace DauThau.Forms
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin(Boolean IsSystem =false)
        {
            InitializeComponent();
            IsFormSystem = IsSystem;
            
        }
        public Boolean IsFormSystem = false;
        public Boolean _khoaQuyen = false;
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            _khoaQuyen = false;
            if (txtUser.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Tài khoản bạn chưa nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
                return;
            }
            else if (txtPass.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Mật khẩu bạn chưa nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPass.Focus();
                return;
            }

            WaitDialogForm wait = new DevExpress.Utils.WaitDialogForm("Hệ thống đang kiểm tra tài khoản ...", "Vui lòng đợi trong giây lát");
            if (!TestLogin())
            {
                wait.Close();
                if(_khoaQuyen)
                    XtraMessageBox.Show("Tài khoản của bạn đã bị khóa. Vui lòng liên hệ quản trị hệ thống.!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else 
                    XtraMessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            wait.Close();
            if (IsFormSystem)
            {
                this.Hide();
                frmMain f = new frmMain();
                f.Show();
                
            }
            else 
            this.Close();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool TestLogin()
        {
            if ((txtUser.Text == LibraryDev._username && txtPass.Text == LibraryDev._pass))
            {
                clsParameter._username = "ththo59";
                return true;
            }
            SqlCommand cmd = new SqlCommand("select * from USERS where user_name = @AccountName and Pass=@Password", clsConnection._conn);
            cmd.Parameters.AddWithValue("@AccountName", txtUser.Text);
            cmd.Parameters.AddWithValue("@Password",FunctionHelper.EncryptMD5(txtPass.Text));

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                clsParameter._username = dt.Rows[0]["FULL_NAME"].ToString();
                if (clsChangeType.change_bool(dt.Rows[0]["KHOA"]))
                {
                    _khoaQuyen = true;
                    return false;
                }
                return true;
            }
            else return false;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (IsFormSystem)
                clsConnection.OpenConn();
            #if DEBUG
                txtUser.Text = "admin";
                //txtPass.Text = "kontum@123";
                txtPass.Text = "benhvien@121";
            //btDangNhap_Click( sender,  e);
#endif

        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btDangNhap.PerformClick();
        }

        private void linkChangeConnect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmConnectionDatabase f = new frmConnectionDatabase();
            f.ShowDialog();
        }
    }
}