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
    public partial class frmChangePass : DevExpress.XtraEditors.XtraForm
    {
        public frmChangePass()
        {
            InitializeComponent();
            
        }
        public Boolean _khoaQuyen = false;
        private void btDangNhap_Click(object sender, EventArgs e)
        {
            _khoaQuyen = false;
            if (txtPassOld.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassOld.Focus();
                return;
            }
            else if (txtPassNew.Text.Trim().Length == 0)
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassNew.Focus();
                return;
            }else if(txtPassConfirm.Text != txtPassNew.Text)
            {
                XtraMessageBox.Show("Vui lòng xác nhận lại mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassConfirm.Focus();
                return;
            }

            QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
            var query = (from p in context.QL_USERS where p.USER_NAME == clsParameter._username && p.USER_PASS == txtPassOld.Text select p).FirstOrDefault();
            if(query == null)
            {
                XtraMessageBox.Show("Mật khẩu cũ không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassOld.Focus();
                return;
            }
            query.USER_PASS = txtPassNew.Text;
            context.SaveChanges();
            XtraMessageBox.Show("Thay đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool checkLogin()
        {
            if ((txtPassOld.Text == LibraryDev._username && txtPassNew.Text == LibraryDev._pass))
            {
                clsParameter._username = "ththo59";
                return true;
            }
            QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
            var query = (from p in context.QL_USERS where p.USER_NAME == txtPassOld.Text && p.USER_PASS == txtPassNew.Text select p).FirstOrDefault();
            if (query!= null)
            {
                clsParameter._username = query.USER_NAME;
                clsParameter._isAdmin = query.USER_ADMIN ?? false;

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