using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DauThau.Reports
{
    public partial class rptLyLichHoiVien : DevExpress.XtraReports.UI.XtraReport
    {
        public rptLyLichHoiVien()
        {
            InitializeComponent();
        }

        private void txtDiaChiThuongTru_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }
    }
}
