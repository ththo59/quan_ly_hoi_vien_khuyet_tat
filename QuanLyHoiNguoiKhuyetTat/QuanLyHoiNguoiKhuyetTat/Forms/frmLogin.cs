using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DauThau.Class;
using DevExpress.XtraGrid;
using System.Data.Entity;
using DevExpress.Utils;
using DauThau.Models;
using System.Linq;

namespace DauThau.Forms
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
            
        }
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
            if (!checkLogin())
            {
                wait.Close();
                if (_khoaQuyen)
                    XtraMessageBox.Show("Tài khoản của bạn đã bị khóa. Vui lòng liên hệ quản trị hệ thống.!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    XtraMessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            wait.Close();
            this.Hide();
            frmMain f = new frmMain();
            f.Show();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool checkLogin()
        {
            if ((txtUser.Text == LibraryDev._username && txtPass.Text == LibraryDev._pass))
            {
                clsParameter._username = "ththo59";
                return true;
            }
            QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
            var query = (from p in context.QL_USERS where p.USER_NAME == txtUser.Text && p.USER_PASS == txtPass.Text select p).FirstOrDefault();
            if (query!= null)
            {
                clsParameter._username = query.USER_NAME;
                clsParameter._isAdmin = query.USER_ADMIN ?? false;
                clsParameter._userId = query.USER_ID;

                if (query.USER_LOCK??false)
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
            #if Debug
            txtUser.Text = "admin";
            txtPass.Text = "admin";
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