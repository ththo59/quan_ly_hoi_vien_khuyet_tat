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
    public partial class ucSanPhamTheoDiemKyThuat : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSanPhamTheoDiemKyThuat()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        private void ucDanhGiaHoSoDuThau_Print_Load(object sender, EventArgs e)
        {
            LibraryDev.PermissionButton(btnControl, previewBar1);
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();
            //try
            //{
            //    lueGoiThau.ItemIndex = 0;
            //}
            //catch
            //{
            //}
           
            btnControl.btnPrint.Enabled = false;
            List<Object> _list =new List<object>();
            Object _item = new
            {
                Id = "SP_MA asc",
                Ten = "Mã sản phẩm"
            };
            _list.Add(_item);

            Object _item2 = new
            {
                Id = "CTY_TEN asc",
                Ten = "Công ty"
            };
            _list.Add(_item2);
            lueSort.Properties.DataSource = _list;
        }



        rptSanPhamTheoDiemKyThuat rpt;
        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            //if (lueGoiThau.EditValue == null)
            //{
            //    clsMessage.MessageInfo("Vui lòng chọn gói thầu");
            //    return;
            //}
            ds = new DataSet();
            ds = FunctionHelper.HoSoDauThau(clsChangeType.change_int64(lueGoiThau.EditValue));
            WaitDialogForm _wait = new WaitDialogForm("Đang hiển thị dữ liệu ...", "Vui lòng đợi giây lát");
            rpt = new rptSanPhamTheoDiemKyThuat();
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;
            rpt.pNgayMoThau.Value = clsParameter.pNgayMoThau;

            rpt.pQuyetDinh.Value = clsParameter.pQuyetDinh;
            rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM19);
            rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM19);

            DataView dv = ds.Tables[0].DefaultView;
            if(Convert.ToInt32(rdSelect.EditValue) == 1)
            dv.RowFilter = "KHONGDAT_KT=False";
            else dv.RowFilter = "KHONGDAT_KT=True";
            dv.Sort = lueSort.EditValue + string.Empty;
            rpt.DataSource = dv;
            rpt.DataMember = "ChiTietHoSo";
            rpt.pTittle.Value = "DANH SÁCH SẢN PHẨM " + (Convert.ToInt32(rdSelect.EditValue) == 1 ? "TRÊN ĐIỂM KỸ THUẬT" : "DƯỚI ĐIỂM KỸ THUẬT");
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

        private void rdSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnControl.btnView.PerformClick();
        }

        private void lueSort_EditValueChanged(object sender, EventArgs e)
        {
            btnControl.btnView.PerformClick();
        }

        private void lueGoiThau_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.OK)
            {
                lueGoiThau.EditValue = null;
                //btnControl.btnView.PerformClick();
            }
        }
    }
}
