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
    public partial class ucDeNghiTrungThauTheoNhaThau : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDeNghiTrungThauTheoNhaThau()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        private void ucDanhGiaHoSoDuThau_Print_Load(object sender, EventArgs e)
        {
            LibraryDev.PermissionButton(btnControl, previewBar1);
            lueCongTy.Properties.DataSource = FunctionHelper.LoadCongTy();
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();
            //try
            //{
            //    lueCongTy.ItemIndex = 0;
            //}
            //catch
            //{
            //}
            btnControl.btnPrint.Enabled = false;

            FormHelper.LookUpEdit_Init(lueCongTy);
            FormHelper.LookUpEdit_Init(lueGoiThau);
        }

       

        rptTrungThauTheoTungNhaThau rpt;
        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            //if (lueCongTy.EditValue == null)
            //{
            //    clsMessage.MessageInfo("Vui lòng chọn nhà thầu");
            //    return;
            //}
            ds = new DataSet();
            ds = FunctionHelper.HoSoDauThau(clsChangeType.change_int64(lueGoiThau.EditValue));
            WaitDialogForm _wait = new WaitDialogForm("Đang hiển thị dữ liệu ...", "Vui lòng đợi giây lát");
            rpt = new rptTrungThauTheoTungNhaThau();
            DataView dv = ds.Tables[0].DefaultView;
            //dv.RowFilter = "LOAI_PL=False and VUOTGIA_KH=False and KHONGDAT_KT=False and CTY_MA='"+lueCongTy.EditValue+"'";
            if (lueCongTy.EditValue == null)
            {
                dv.RowFilter = "TT=True";
            }
            else
            {
                dv.RowFilter = "TT=True and CTY_MA='" + lueCongTy.EditValue + "'";
            }
            dv.Sort = "SP_MA asc";
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;
            rpt.pNgayMoThau.Value = clsParameter.pNgayMoThau;

            rpt.pQuyetDinh.Value = clsParameter.pQuyetDinh;

            rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM06);
            rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM06);

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
            btnControl.btnView.PerformClick();
        }

        private void lueGoiThau_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueGoiThau.EditValue = null;
                lueGoiThau.Refresh();
            }
        }

        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            btnControl.btnView.PerformClick();
        }

        private void lueCongTy_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueCongTy.EditValue = null;
                lueCongTy.Refresh();
            }
        }

      
    }
}
