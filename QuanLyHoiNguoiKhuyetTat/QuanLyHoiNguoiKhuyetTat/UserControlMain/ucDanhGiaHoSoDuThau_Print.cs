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
    public partial class ucDanhGiaHoSoDuThau_Print : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDanhGiaHoSoDuThau_Print()
        {
            InitializeComponent();
        }

        private void ucDanhGiaHoSoDuThau_Print_Load(object sender, EventArgs e)
        {
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();
            btnControl.btnPrint.Enabled = false;
            LibraryDev.PermissionButton(btnControl, previewBar1);

            FormHelper.LookUpEdit_Init(lueGoiThau);
        }

        DataTable DsSanPhamMa()
        {
            SqlCommand cmd = new SqlCommand("sp_HoSoDuThauSP_Ma", clsConnection._conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt).Value = Convert.ToInt32(lueGoiThau.EditValue);
            cmd.Parameters.Add("@DOT_MA", SqlDbType.NVarChar).Value = clsParameter._dotMaDauThau;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable t = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(t);
            return t;
        }

        void SelectData()
        {
            dsDanhGiaHoSoDuThau1 = new DataSets.dsDanhGiaHoSoDuThau();
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu đấu thầu ...", "Vui lòng đợi giây lát");

            SqlCommand cmd = new SqlCommand(clsParameter.pStoreDanhGiaHoSoDuThau, clsConnection._conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt).Value = Convert.ToInt32(lueGoiThau.EditValue);
            cmd.Parameters.Add("@DOT_MA", SqlDbType.NVarChar).Value = clsParameter._dotMaDauThau;
            cmd.Parameters.Add("@SP_MA", SqlDbType.NVarChar).Value = string.Empty;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dsDanhGiaHoSoDuThau1.ChiTietHoSo);
            

            _wait.Caption = "Đang tải sản phẩm ...";
            DataTable dtSP_MA = new DataTable();
            dtSP_MA = DsSanPhamMa();

            _wait.Caption = "Đang xét hồ sơ trúng thầu ...";
            string sp_ma = string.Empty;
            Int32 max_DiemTH;
            for (int k = 0; k < dtSP_MA.Rows.Count; k++)
            {
                _wait.Caption = string.Format("Đang xét sản phẩm {0}/{1}", k + 1, dtSP_MA.Rows.Count);
                sp_ma = dtSP_MA.Rows[k][0].ToString();

                try
                {
                    max_DiemTH = Convert.ToInt32(dsDanhGiaHoSoDuThau1.ChiTietHoSo.Compute("max(DiemTH)", "SP_MA='" + sp_ma + "' and LOAI_PL=False"));
                }
                catch (Exception)
                {
                    max_DiemTH = 0;
                }

                //Nếu sản phẩm đã được trúng thầu từ BTC có nghĩa là cột TT = 1
                //Không xét nữa nữa.
                DataRow[] r = dsDanhGiaHoSoDuThau1.ChiTietHoSo.Select(string.Format("SP_MA='{0}' and TT=1", sp_ma));
                if (r.Length > 0) continue;

                //Xét điều kiện trúng thầu.
                for (int i = 0; i < dsDanhGiaHoSoDuThau1.ChiTietHoSo.Count; i++)
                {
                    if (dsDanhGiaHoSoDuThau1.ChiTietHoSo.Rows[i]["SP_MA"].ToString() == sp_ma
                        && Convert.ToInt32(dsDanhGiaHoSoDuThau1.ChiTietHoSo.Rows[i]["DiemTH"]) > 0
                         && clsChangeType.change_bool(dsDanhGiaHoSoDuThau1.ChiTietHoSo.Rows[i]["LOAI_PL"]) == false
                        )
                        if (Convert.ToInt32(dsDanhGiaHoSoDuThau1.ChiTietHoSo.Rows[i]["DiemTH"]) == max_DiemTH)
                        {
                            dsDanhGiaHoSoDuThau1.ChiTietHoSo.Rows[i]["TT"] = true;
                            //break;
                        }
                }
            }


            _wait.Close();
        }

        rptDanhGiaChiTietHoSoDuThau rpt;
        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            if (lueGoiThau.EditValue == null)
            {
                clsMessage.MessageInfo("Vui lòng chọn nhà thầu");
                return;
            }

            //SelectData();
            WaitDialogForm _wait = new WaitDialogForm("Đang hiển thị dữ liệu ...", "Vui lòng đợi giây lát");
             rpt = new rptDanhGiaChiTietHoSoDuThau();
             rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;
            rpt.pNgayMoThau.Value = clsParameter.pNgayMoThau;

            DataSet ds = new DataSet();
            ds = FunctionHelper.HoSoDauThau(Convert.ToInt32(lueGoiThau.EditValue));
            DataView dv = ds.Tables[0].DefaultView;
            if (chkFilter.Checked)
            {
                dv.RowFilter = "LOAI_PL = false and KHONGDAT_KT = false";
            }
            dv.Sort = "SP_MA asc";
            rpt.DataSource = dv;

            rpt.pQuyetDinh.Value = clsParameter.pQuyetDinh;
            rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM01);
            rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM01);

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
