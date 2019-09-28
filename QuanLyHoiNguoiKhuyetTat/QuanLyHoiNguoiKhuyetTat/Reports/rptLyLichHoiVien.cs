using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DauThau.Class;

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

        private void txtBHYT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRTableCell txt = (XRTableCell)sender;
            Boolean HV_BHYT_MIENPHI = clsChangeType.change_bool((GetCurrentColumnValue("HV_BHYT_MIENPHI")));

            txt.Text = HV_BHYT_MIENPHI ? "Có" : "Không";
            
        }
    }
}
