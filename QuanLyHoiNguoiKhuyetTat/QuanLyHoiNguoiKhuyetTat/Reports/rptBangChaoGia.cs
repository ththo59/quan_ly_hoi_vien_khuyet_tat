using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DauThau.Reports
{
    public partial class rptBangChaoGia : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBangChaoGia()
        {
            InitializeComponent();
        }

        private void xrTableCell41_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrtNgay.Text = "Ngày " + DateTime.Now.Day +" tháng " +DateTime.Now.Month + " năm " + DateTime.Now.Year;
        }

    }
}
