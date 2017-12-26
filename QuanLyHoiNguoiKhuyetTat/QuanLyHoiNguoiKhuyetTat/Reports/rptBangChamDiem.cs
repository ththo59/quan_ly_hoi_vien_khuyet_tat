using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DauThau.Reports
{
    public partial class rptBangChamDiem : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBangChamDiem()
        {
            InitializeComponent();
        }

        private void xrtChon_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void xrTableCell22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
            
        }

        private void xrTableCell21_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xrTableCell21.Text.Length > 0)
                xrTableCell21.Text = "X";
        }

    }
}
