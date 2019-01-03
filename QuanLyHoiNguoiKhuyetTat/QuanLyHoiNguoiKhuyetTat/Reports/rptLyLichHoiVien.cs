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
            string duong = GetCurrentColumnValue("HV_THUONGTRU_DUONG") + string.Empty;
            string khuvuc = GetCurrentColumnValue("HV_THUONGTRU_KHUVUC") + string.Empty;
            string phuong = GetCurrentColumnValue("HV_THUONGTRU_PHUONG") + string.Empty;
            string quan = GetCurrentColumnValue("HV_THUONGTRU_QUAN") + string.Empty;
            string tp = GetCurrentColumnValue("HV_THUONGTRU_TP") + string.Empty;
            string diachi = "";
            if(duong != "")
            {
                diachi += duong;
            }
            if (khuvuc != "")
            {
                diachi += khuvuc + ", ";
            }
            if (phuong != "")
            {
                diachi += phuong + ", ";
            }
            if (quan != "")
            {
                diachi += quan + ", ";
            }
            if (tp != "")
            {
                diachi += tp;
            }
            txtDiaChiThuongTru.Text = diachi;
        }
    }
}
