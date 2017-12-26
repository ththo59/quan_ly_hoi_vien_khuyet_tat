using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DauThau.Class;
using System.Data.SqlClient;
using DevExpress.Utils;
using DauThau.Reports;
using DevExpress.XtraReports.UI;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucChiTietHoSoDuThauKhac : DevExpress.XtraEditors.XtraUserControl
    {
        public ucChiTietHoSoDuThauKhac()
        {
            InitializeComponent();
        }

        private void ucDanhGiaHoSoDuThau_Print_Load(object sender, EventArgs e)
        {
            LibraryDev.PermissionButton(btnControl, previewBar1);
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();
            btnControl.btnPrint.Enabled = false;
            FormHelper.LookUpEdit_Init(lueGoiThau);

        }

        rptDanhGiaChiTietHoSoDuThau rpt;
        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            if (lueGoiThau.EditValue == null)
            {
                clsMessage.MessageInfo("Vui lòng chọn nhà thầu");
                return;
            }

            WaitDialogForm _wait = new WaitDialogForm("Đang hiển thị dữ liệu ...", "Vui lòng đợi giây lát");
             rpt = new rptDanhGiaChiTietHoSoDuThau();
             rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;
            rpt.pNgayMoThau.Value = clsParameter.pNgayMoThau;

            rpt.pQuyetDinh.Value = clsParameter.pQuyetDinh;
            rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM03);
            rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM03);

            DataSet ds = new DataSet();
            ds = FunctionHelper.HoSoDauThau(Convert.ToInt32(lueGoiThau.EditValue));
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "TT=True or (GIA_CHAOTHAU_FINAL=MIN_GIA_CHAOTHAU)";
            dv.Sort = "SP_MA asc";
            rpt.DataSource = dv; // dsDanhGiaHoSoDuThau1.ChiTietHoSo;
            
            rpt.txtDiemTH.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ChiTietHoSo.DiemTH", "{0:"+clsParameter.pFormatNumber+"}")});

            rpt.txtDiemTC.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ChiTietHoSo.DiemTC", "{0:"+clsParameter.pFormatNumber+"}")});

            rpt.DataMember = "ChiTietHoSo";
            rpt.pGoiThau.Value = lueGoiThau.Text;
            printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument(true);
            btnControl.btnPrint.Enabled = true;
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

        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            btnControl.btnView.PerformClick();
        }
    }
}
