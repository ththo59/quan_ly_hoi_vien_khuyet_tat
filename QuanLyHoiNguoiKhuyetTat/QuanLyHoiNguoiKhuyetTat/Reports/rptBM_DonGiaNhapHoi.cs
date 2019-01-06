using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DauThau.Reports
{
    public partial class rptBM_DonGiaNhapHoi : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBM_DonGiaNhapHoi()
        {
            InitializeComponent();
        }

        private void txtThuongTru_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string duong = GetCurrentColumnValue("HV_THUONGTRU_DUONG") + string.Empty;
            string khuvuc = GetCurrentColumnValue("HV_THUONGTRU_KHUVUC") + string.Empty;
            string phuong = GetCurrentColumnValue("HV_THUONGTRU_PHUONG") + string.Empty;
            string quan = GetCurrentColumnValue("HV_THUONGTRU_QUAN") + string.Empty;
            string tp = GetCurrentColumnValue("HV_THUONGTRU_TP") + string.Empty;
            string diachi = "";
            if (khuvuc != "")
            {
                diachi += khuvuc + ", ";
            }
            if (duong != "")
            {
                diachi += duong + ", ";
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
            txtThuongTru.Text = diachi;
        }

        private void txtTamTru_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string duong = GetCurrentColumnValue("HV_TAMTRU_DUONG") + string.Empty;
            string khuvuc = GetCurrentColumnValue("HV_TAMTRU_KHUVUC") + string.Empty;
            string phuong = GetCurrentColumnValue("HV_TAMTRU_PHUONG") + string.Empty;
            string quan = GetCurrentColumnValue("HV_TAMTRU_QUAN") + string.Empty;
            string tp = GetCurrentColumnValue("HV_TAMTRU_TP") + string.Empty;
            string diachi = "";
            
            if (khuvuc != "")
            {
                diachi += khuvuc + ", ";
            }
            if (duong != "")
            {
                diachi += duong + ", ";
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
            txtTamTru.Text = diachi;
        }
    }
}
