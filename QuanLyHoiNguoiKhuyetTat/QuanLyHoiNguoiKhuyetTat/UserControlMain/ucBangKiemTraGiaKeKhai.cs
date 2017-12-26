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
    public partial class ucBangKiemTraGiaKeKhai : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBangKiemTraGiaKeKhai(Boolean laTrungThau)
        {
            _laTrungThau = laTrungThau;
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        Boolean _laTrungThau = false;
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

       

        rptBangKiemTraGiaKeKhai rpt;
        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            DataSet dsDauThau = FunctionHelper.HoSoDauThau(clsChangeType.change_int64(lueGoiThau.EditValue));
            ds = dsDauThau.Copy();
            WaitDialogForm _wait = new WaitDialogForm("Đang hiển thị dữ liệu ...", "Vui lòng đợi giây lát");
            rpt = new rptBangKiemTraGiaKeKhai();

            //add column
            
                ds.Tables[0].Columns.Add("CQLD_GIA_KEKHAI", typeof(System.Decimal));
                ds.Tables[0].Columns.Add("CQLD_TEN_HOATCHAT", typeof(System.String));
                ds.Tables[0].Columns.Add("CQLD_HAMLUONG", typeof(System.String));
                ds.Tables[0].Columns.Add("CQLD_STT_KHONG_HOPLY", typeof(System.String));

            
            //Hiển thị thông tin từ cục quản lý dược.
            SqlDataAdapter da = new SqlDataAdapter("select * from DM_SANPHAM_CQLD", clsConnection._conn);
            DataTable t = new DataTable();
            da.Fill(t);

            if (t.Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string sdk_gpkd = ds.Tables[0].Rows[i]["SODK_VISA"] + string.Empty;
                    string so_dot_cqld = ds.Tables[0].Rows[i]["SO_DOT_CQLD"] + string.Empty;
                    if (sdk_gpkd == "")
                    {
                        continue;
                    }
                    //string stt_cqld = ds.Tables[0].Rows[i]["SO_DOT_CQLD"] + string.Empty;
                    so_dot_cqld = so_dot_cqld == "" ? "0" : so_dot_cqld;
                    DataRow[] rows = t.Select(string.Format("SP_SDK_GPKD = '{0}' AND SP_STT = {1} AND SP_MAU ='1'", sdk_gpkd,so_dot_cqld));
                    Boolean multiRows = false;
                    foreach (var r in rows)
                    {
                        ds.Tables[0].Rows[i]["CQLD_GIA_KEKHAI"] = r["SP_GIA_KEKHAI"];
                        ds.Tables[0].Rows[i]["CQLD_TEN_HOATCHAT"] = ds.Tables[0].Rows[i]["CQLD_TEN_HOATCHAT"] + (multiRows ? "; " : "") + r["SP_TENHOATCHAT"];
                        ds.Tables[0].Rows[i]["CQLD_HAMLUONG"] = ds.Tables[0].Rows[i]["CQLD_HAMLUONG"] + (multiRows ? "; " : "") + r["SP_NONGDO_HAMLUONG"];
                        multiRows = true;
                    }

                    DataRow[] rows02 = t.Select(string.Format("SP_SDK_GPKD = '{0}' AND SP_MAU='2'", sdk_gpkd));
                    multiRows = false;
                    string cqld_stt = string.Empty;
                    foreach (var r in rows02)
                    {
                        cqld_stt = cqld_stt + (multiRows ? "; " : "") + r["SP_STT"];
                        multiRows = true;
                    }

                    //Nếu chỉ có 1 dòng thì mới xét điều kiện khác nhau
                    if (cqld_stt != (ds.Tables[0].Rows[i]["SO_DOT_CQLD"] + string.Empty))
                    {
                        ds.Tables[0].Rows[i]["CQLD_STT_KHONG_HOPLY"] = cqld_stt;
                    }
                    
                }
            }

            DataView dv = ds.Tables[0].DefaultView;
            //dv.RowFilter = "LOAI_PL=False and VUOTGIA_KH=False and KHONGDAT_KT=False and CTY_MA='"+lueCongTy.EditValue+"'";
            string _filterData = ""; 
            if (_laTrungThau)
            {
                _filterData = "TT = True";
                rpt.pTieuDe.Value = "BẢNG KIỂM TRA GIÁ KÊ KHAI CÁC MẶT HÀNG TRÚNG THẦU";
            }
            else
            {
                _filterData = "LOAI_PL=False and VUOTGIA_KH=False and KHONGDAT_KT=False";
                rpt.pTieuDe.Value = "BẢNG KIỂM TRA GIÁ KÊ KHAI CÁC MẶT HÀNG DỰ THẦU";
            }

            if (lueCongTy.EditValue == null)
            {
                dv.RowFilter = _filterData;
            }
            else
            {
                dv.RowFilter = _filterData + " and CTY_MA='" + lueCongTy.EditValue + "'";
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
