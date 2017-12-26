using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DauThau.Class;

namespace DauThau.Reports
{
    public partial class rptDanhGiaChiTietHoSoDuThau : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhGiaChiTietHoSoDuThau()
        {
            InitializeComponent();
        }

        private void xrtTT_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (xrtTT.Text.Length > 0)
                if (Convert.ToBoolean(xrtTT.Text))
                    xrtTT.Text = "X";
                else xrtTT.Text = "";

        }

        private void txtGhiChu_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (txtGhiChu.Text.IndexOf(";") <= 1)
                txtGhiChu.Text = txtGhiChu.Text.Replace(";", "");
        }

        private void txtTitle_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            txtTitle.Text = "Đấu thầu mua thuốc, vật tư y tế hóa chất xét nghiệm " + DateTime.Now.Year;
        }

        private void txtSP_TEN_THUONGMAI_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRTableCell txt = (XRTableCell)sender;
            Boolean sp_DACBIET = clsChangeType.change_bool((GetCurrentColumnValue("SP_DACBIET")));

            if (sp_DACBIET)
            {
                txt.Font = new Font("Times New Roman", 10F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic | FontStyle.Underline))));
            }
            else
            {
                txt.Font = new Font("Times New Roman", 10F, ((FontStyle)((FontStyle.Regular))));
            }
        }
    }
}
