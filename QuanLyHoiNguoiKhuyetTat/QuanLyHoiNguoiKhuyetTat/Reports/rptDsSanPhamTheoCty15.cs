using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DauThau.Reports
{
    public partial class rptDsSanPhamTheoCty15 : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDsSanPhamTheoCty15()
        {
            InitializeComponent();
        }

        private void rptDsSanPhamTheoCty_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void txtNgayMo_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void txtNgay_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtNgay.Text = string.Format("Cần Thơ, ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
        }

        private void lbTitle_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lbTitle.Text = "Đấu thầu mua thuốc, hóa chất, vật tư y tế năm " + DateTime.Now.Year;
        }
    }
}
