using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DauThau.Class;

namespace DauThau.Reports
{
    public partial class rptSanPhamKhongThamGiaXetThau : DevExpress.XtraReports.UI.XtraReport
    {
        public rptSanPhamKhongThamGiaXetThau()
        {
            InitializeComponent();
        }

        private void txtLoaiPL_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (clsChangeType.change_bool(txtLoaiPL.Text))
                txtLoaiPL.Text = "X";
            else txtLoaiPL.Text = "";
        }

        private void txtLoaiKT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (clsChangeType.change_bool(txtLoaiKT.Text))
                txtLoaiKT.Text = "X";
            else txtLoaiKT.Text = "";
        }

        

    }
}
