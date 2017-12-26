﻿    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DauThau.Class;
using DevExpress.Utils;
using DauThau.Reports;
using DevExpress.XtraReports.UI;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucKhongTTVuotKeHoach : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKhongTTVuotKeHoach()
        {
            InitializeComponent();
        }

        rptKhongTrungThau_VuotGiaKH rpt;
        private void ucKhongTTVuotKeHoach_Load(object sender, EventArgs e)
        {
            LibraryDev.PermissionButton(btnControl, previewBar1);
            DataSet ds = new DataSet();
            ds = FunctionHelper.HoSoDauThau(0);
            WaitDialogForm _wait = new WaitDialogForm("Đang hiển thị dữ liệu ...", "Vui lòng đợi giây lát");
            rpt = new rptKhongTrungThau_VuotGiaKH();
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "VUOTGIA_KH=True";
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;
            rpt.pNgayMoThau.Value = clsParameter.pNgayMoThau;
            rpt.pQuyetDinh.Value = clsParameter.pQuyetDinh;

            rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM13);
            rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM13);

            rpt.DataSource = dv;
            rpt.DataMember = "ChiTietHoSo";
            printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument(true);
            btnControl.btnPrint.Enabled = ds.Tables[0].Rows.Count > 0;
            _wait.Close();
        }

        private void btnControl_btnEventPrint_Click(object sender, EventArgs e)
        {
            try
            {
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.Print();
                    //or printTool.PrintDialog();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
