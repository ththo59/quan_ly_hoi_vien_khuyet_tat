using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DauThau.Class;

namespace DauThau.Forms
{
    public partial class frmEnterCode : DevExpress.XtraEditors.XtraForm
    {
        public frmEnterCode()
        {
            InitializeComponent();
        }

        private void frmEnterCode_Load(object sender, EventArgs e)
        {

        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            //txtKey.Text = FunctionHelper.Encrypt("THT", "PR9JT-V7XR7-WWQ7B-GG4DF-B4V37");
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            //txtHoTen.Text = FunctionHelper.Decrypt("THT",txtKey.Text);
        }
    }
}