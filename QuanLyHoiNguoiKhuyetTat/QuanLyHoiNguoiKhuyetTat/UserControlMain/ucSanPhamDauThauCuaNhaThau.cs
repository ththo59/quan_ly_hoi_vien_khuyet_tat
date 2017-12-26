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
    public partial class ucSanPhamDauThauCuaNhaThau : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSanPhamDauThauCuaNhaThau()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        private void ucDanhGiaHoSoDuThau_Print_Load(object sender, EventArgs e)
        {
            LibraryDev.PermissionButton(btnControl, previewBar1);
            lueCongTy.Properties.DataSource = FunctionHelper.LoadCongTy();
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThauTheoCongTy(lueCongTy.EditValue +string.Empty);
            try
            {
                lueCongTy.ItemIndex = 0;
            }
            catch
            {
            }
            btnControl.btnPrint.Enabled = false;

            FormHelper.LookUpEdit_Init(lueCongTy);
            FormHelper.LookUpEdit_Init(lueGoiThau);
        }



        rptSanPhamDauThauTheoNhaThau rpt;
        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            if (lueCongTy.EditValue == null)
            {
                clsMessage.MessageInfo("Vui lòng chọn nhà thầu");
                return;
            }
            ds = new DataSet();
            ds = FunctionHelper.HoSoDauThau(0);
            WaitDialogForm _wait = new WaitDialogForm("Đang hiển thị dữ liệu ...", "Vui lòng đợi giây lát");
            rpt = new rptSanPhamDauThauTheoNhaThau();
            DataView dv = ds.Tables[0].DefaultView;
            if(chkAll.Checked)
            dv.RowFilter = "CTY_MA='"+lueCongTy.EditValue+"'";
            else dv.RowFilter = "CTY_MA='" + lueCongTy.EditValue + "' and GOITHAU_TEN='" + lueGoiThau.Text + "'";
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;
            rpt.pNgayMoThau.Value = clsParameter.pNgayMoThau;

            rpt.pQuyetDinh.Value = clsParameter.pQuyetDinh;
            rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM23);
            rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM23);

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

        private void lueCongTy_EditValueChanged(object sender, EventArgs e)
        {
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThauTheoCongTy(lueCongTy.EditValue + string.Empty);
            btnControl.btnView.PerformClick();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                    lueGoiThau.Enabled = false;
                else
                {
                    lueGoiThau.Enabled = true;
                    lueGoiThau.ItemIndex = 0;
                }
            }
            catch (Exception)
            {

            }
            btnControl.btnView.PerformClick(); 
        }

        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            btnControl.btnView.PerformClick();
        }
    }
}
