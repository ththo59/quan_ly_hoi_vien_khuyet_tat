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
    public partial class ucDeNghiTrungThauTheoGoiThau_GiaKeKhai : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDeNghiTrungThauTheoGoiThau_GiaKeKhai()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        private void ucDanhGiaHoSoDuThau_Print_Load(object sender, EventArgs e)
        {
            LibraryDev.PermissionButton(btnControl, previewBar1);
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();
            try
            {
                lueGoiThau.ItemIndex = 0;
            }
            catch
            {
            }
           
            btnControl.btnPrint.Enabled = false;

            FormHelper.LookUpEdit_Init(lueGoiThau);
        }

       
        
        rptTrungThauTheoTungGoiThau_GiaKeKhai rpt;
        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            if (lueGoiThau.EditValue == null)
            {
                clsMessage.MessageInfo("Vui lòng chọn gói thầu");
                return;
            }
            ds = new DataSet();
            ds = FunctionHelper.HoSoDauThau(Convert.ToInt64(lueGoiThau.EditValue));
            WaitDialogForm _wait = new WaitDialogForm("Đang hiển thị dữ liệu ...", "Vui lòng đợi giây lát");
            rpt = new rptTrungThauTheoTungGoiThau_GiaKeKhai();
            DataView dv = ds.Tables[0].DefaultView;
            //dv.RowFilter = "LOAI_PL=False and VUOTGIA_KH=False and KHONGDAT_KT=False";
            dv.RowFilter = "TT=True";
            dv.Sort = "SP_MA asc";
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;
            rpt.pNgayMoThau.Value = clsParameter.pNgayMoThau;

            rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM08);
            rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM08);

            rpt.DataSource = dv;
            rpt.DataMember = "ChiTietHoSo";
            rpt.pGoiThau.Value = lueGoiThau.Text;
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

        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            btnControl.btnView.PerformClick();
        }
    }
}
