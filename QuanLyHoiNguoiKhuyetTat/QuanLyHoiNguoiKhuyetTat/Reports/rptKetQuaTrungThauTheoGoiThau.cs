using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DauThau.Class;

namespace DauThau.Reports
{
    public partial class rptKetQuaTrungThauTheoGoiThau : DevExpress.XtraReports.UI.XtraReport
    {
        public rptKetQuaTrungThauTheoGoiThau()
        {
            InitializeComponent();
        }

        private void txtSP_TEN_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRTableCell txt = (XRTableCell)sender;
            Boolean sp_DACBIET = clsChangeType.change_bool((GetCurrentColumnValue("SP_DACBIET")));

            if (sp_DACBIET)
            {
                txt.Font = new Font("Times New Roman", 10F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))));
            }
            else
            {
                txt.Font = new Font("Times New Roman", 10F, ((FontStyle)((FontStyle.Regular))));
            }
        }
    }
}
