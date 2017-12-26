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
using static DauThau.frmMain;
using System.Linq;

namespace DauThau.UserControlCategoryMain
{
    /// <summary>
    /// Đây là view chung của tất cả function có giao diện chọn gói thầu.
    /// </summary>
    public partial class ucGlobalGoiThau : DevExpress.XtraEditors.XtraUserControl
    {
        public ucGlobalGoiThau(LoaiBaoCao loaiBC)
        {
            InitializeComponent();
            _loaiBC = loaiBC;
        }

        XtraReport rptGlobal = new XtraReport();
        LoaiBaoCao _loaiBC;

        private void ucDanhGiaHoSoDuThau_Print_Load(object sender, EventArgs e)
        {
            LibraryDev.PermissionButton(btnControl, previewBar1);
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();
            btnControl.btnPrint.Enabled = false;
            FormHelper.LookUpEdit_Init(lueGoiThau);
        }

        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            
            WaitDialogForm _wait = new WaitDialogForm("Đang hiển thị dữ liệu ...", "Vui lòng đợi giây lát");
            Int64 _goiThauID = clsChangeType.change_int64(lueGoiThau.EditValue);
            DataSet ds = new DataSet();
            DataView dv;
            switch (_loaiBC)
            {

                case LoaiBaoCao.BM20:
                    #region Sản phẩm không có nhà thầu tham gia
                    DataTable dt = new DataTable();
                    
                    string str = "SELECT sp.SP_MA, sp.SP_TEN, sp.SP_TENBIETDUOC, sp.SP_HAMLUONG, sp.SP_DANGDUNG, dvt.TEN DVT_TEN, SP_SOLUONG "
                             + " , SP_GIAKEHOACH, SP_SOLUONG*SP_GIAKEHOACH as THANHTIEN_GIAKH, gt.TEN GOITHAU_TEN FROM DM_SANPHAM sp "
                             + " LEFT JOIN DM_GOITHAU gt ON gt.GOITHAU_ID = sp.SP_GOITHAU "
                             + " LEFT JOIN dbo.DM_DVT dvt ON sp.DVT_ID = dvt.DVT_ID "
                             + " WHERE gt.DOT_MA = '" + clsParameter._dotMaDauThau + "' and gt.GOITHAU_ID = " + _goiThauID + " and sp.SP_MA NOT IN "
                             + " (SELECT DISTINCT SP_MA FROM DAU_THAU dt, DM_GOITHAU gt "
                             + " WHERE dt.GOITHAU_ID = gt.GOITHAU_ID and gt.GOITHAU_ID = " + _goiThauID + " AND gt.DOT_MA = '" + clsParameter._dotMaDauThau + "') "
                             + " ORDER BY sp.SP_MA ASC";
                    SqlDataAdapter d = new SqlDataAdapter(str, clsConnection._conn);
                    d.Fill(dt);

                    rptSanPhamKhongDuocDauThau rpt20 = new rptSanPhamKhongDuocDauThau();
                    rpt20.pHospital.Value = clsParameter.pHospital;
                    rpt20.pParentHospital.Value = clsParameter.pParentHospital;
                    rpt20.pNgayMoThau.Value = clsParameter.pNgayMoThau;

                    rpt20.pQuyetDinh.Value = clsParameter.pQuyetDinh;
                    rpt20.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM20);
                    rpt20.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM20);

                    rpt20.DataSource = dt;
                    rpt20.DataMember = "SANPHAM";
                    
                    btnControl.btnPrint.Enabled = dt.Rows.Count > 0;
                    rptGlobal = rpt20;
                    #endregion
                    break;
                case LoaiBaoCao.BM14:
                    #region Sản phẩm vượt giá kế hoạch (giá trị vượt)
                    ds = FunctionHelper.HoSoDauThau(clsChangeType.change_int64(lueGoiThau.EditValue));
                    rptKhongTrungThau_VuotGiaKH_GiaTriVuot rpt = new rptKhongTrungThau_VuotGiaKH_GiaTriVuot();
                    dv = ds.Tables[0].DefaultView;
                    dv.RowFilter = "VUOTGIA_KH=True";
                    rpt.pHospital.Value = clsParameter.pHospital;
                    rpt.pParentHospital.Value = clsParameter.pParentHospital;
                    rpt.pNgayMoThau.Value = clsParameter.pNgayMoThau;
                    rpt.pQuyetDinh.Value = clsParameter.pQuyetDinh;

                    rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM14);
                    rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM14);

                    rpt.DataSource = dv;
                    rpt.DataMember = "ChiTietHoSo";
                    btnControl.btnPrint.Enabled = ds.Tables[0].Rows.Count > 0;

                    rptGlobal = rpt;
                    #endregion
                    break;
                case LoaiBaoCao.BM19:
                    #region Danh mục sản phẩm không trúng thầu - theo gói thầu
                    ds = FunctionHelper.HoSoDauThau(clsChangeType.change_int64(lueGoiThau.EditValue));
                    rptKhongTT_GoiThau rpt25 = new rptKhongTT_GoiThau();
                    dv = ds.Tables[0].DefaultView;
                    dv.RowFilter = "KHONGDAT_KT=True or LOAI_PL=True";
                    rpt25.pHospital.Value = clsParameter.pHospital;
                    rpt25.pParentHospital.Value = clsParameter.pParentHospital;
                    rpt25.pNgayMoThau.Value = clsParameter.pNgayMoThau;
                    rpt25.pQuyetDinh.Value = clsParameter.pQuyetDinh;

                    rpt25.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM19);
                    rpt25.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM19);

                    rpt25.DataSource = dv;
                    rpt25.DataMember = "ChiTietHoSo";
                    btnControl.btnPrint.Enabled = ds.Tables[0].Rows.Count > 0;

                    rptGlobal = rpt25;
                    #endregion
                    break;
                case LoaiBaoCao.BM29:
                    #region Thống kê kết quả các công ty tham dự
                    ds = FunctionHelper.HoSoDauThau(clsChangeType.change_int64(lueGoiThau.EditValue));

                    List<clsThongKeKetQuaThamDu> query = (from p in ds.Tables[0].AsEnumerable()
                                                       group p by new { GOITHAU_TEN = p["GOITHAU_TEN"], CTY_MA = p["CTY_MA"], CTY_TEN = p["CTY_TEN"] } into grp
                                                       select new clsThongKeKetQuaThamDu
                                                       {
                                                           CTY_MA = grp.Key.CTY_MA +string.Empty,
                                                           CTY_TEN = grp.Key.CTY_TEN + string.Empty,
                                                           GOITHAU_TEN = grp.Key.GOITHAU_TEN + string.Empty,
                                                           SOLUONG_THAMDU = grp.Count(k => k.Field<Int64>("DAUTHAU_ID") > 0),
                                                           SOLUONG_TRUNGTHAU = grp.Count(k => k.Field<Boolean>("TT") == true),
                                                           THANHTIEN_THEO_GIA_CTY = grp.Sum(k => k.Field<Int64>("THANHTIEN")),
                                                           THANHTIEN_THEO_GIAKH = grp.Sum(k => k.Field<Decimal>("THANHTIEN_GIAKH")),
                                                           TIETKIEM = grp.Sum(k => k.Field<Int64>("THANHTIEN")) - grp.Sum(k => k.Field<Decimal>("THANHTIEN_GIAKH")),

                                                       }).ToList();
                    DataTable dataReport = FunctionHelper.ConvertToDataTable(query);

                    rptThongKeKetQuaCTYThamDu rpt26 = new rptThongKeKetQuaCTYThamDu();
                    rpt26.pHospital.Value = clsParameter.pHospital;
                    rpt26.pParentHospital.Value = clsParameter.pParentHospital;
                    rpt26.pNgayMoThau.Value = clsParameter.pNgayMoThau;
                    rpt26.pQuyetDinh.Value = clsParameter.pQuyetDinh;

                    rpt26.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM24);
                    rpt26.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM24);

                    rpt26.DataSource = dataReport;
                    rpt26.DataMember = "dtThongKeKetQuaCTy";
                    btnControl.btnPrint.Enabled = ds.Tables[0].Rows.Count > 0;

                    rptGlobal = rpt26;
                    #endregion
                    break;
                default:
                    break;
            }

            printControl1.PrintingSystem = rptGlobal.PrintingSystem;
            rptGlobal.CreateDocument(true);

            _wait.Close();
        }

        private void btnControl_btnEventPrint_Click(object sender, EventArgs e)
        {
            try
            {
                using (ReportPrintTool printTool = new ReportPrintTool(rptGlobal))
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
