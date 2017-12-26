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
using DevExpress.XtraGrid.Views.BandedGrid;
using CuscLibrary.Offices;
using DevExpress.XtraReports.UI;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucDeNghiTrungThauTheoGoiThau : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDeNghiTrungThauTheoGoiThau(Boolean _GiaKH =false)
        {
            InitializeComponent();
            _khongGiaKH = _GiaKH;
        }
        Boolean _khongGiaKH = false;
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

       
        
        rptTrungThauTheoTungGoiThau rpt;
        rptTrungThauTheoTungGoiThauKhongGiaKH rpt2;
        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            if (lueGoiThau.EditValue == null)
            {
                clsMessage.MessageInfo("Vui lòng chọn gói thầu");
                return;
            }
            if (_khongGiaKH)
                LoadTungGoiThau_KhongGiaKH();
            else LoadTungKhoiThau();
        }

        Decimal _tongGiaTriTheoGiaKH = 0, _tongGiaTriTheoGiaChaoThau = 0;

        void LoadTungKhoiThau()
        {

            ds = new DataSet();
            ds = FunctionHelper.HoSoDauThau(Convert.ToInt64(lueGoiThau.EditValue));
            ds.Tables[0].Columns.Add("STT", typeof(Int32));

            WaitDialogForm _wait = new WaitDialogForm("Đang hiển thị dữ liệu ...", "Vui lòng đợi giây lát");
            rpt = new rptTrungThauTheoTungGoiThau();
            DataView dv = ds.Tables[0].DefaultView;
            //dv.RowFilter = "LOAI_PL=False and VUOTGIA_KH=False and KHONGDAT_KT=False";
            dv.RowFilter = "TT=True";
            dv.Sort = "SP_MA asc";
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;
            rpt.pNgayMoThau.Value = clsParameter.pNgayMoThau;

            rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM07);
            rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM07);

            rpt.DataSource = dv;
            
            gcGrid.DataSource = dv;
            //Tạo số STT
            _tongGiaTriTheoGiaKH = _tongGiaTriTheoGiaChaoThau = 0;
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                gvGrid.SetRowCellValue(i, colSTT, i + 1);
                _tongGiaTriTheoGiaKH += clsChangeType.change_decimal(gvGrid.GetRowCellValue(i, colTHANHTIEN_GIAKH));
                _tongGiaTriTheoGiaChaoThau += clsChangeType.change_decimal(gvGrid.GetRowCellValue(i, colThanhTien));
            }
            gcGrid.RefreshDataSource();

            rpt.DataMember = "ChiTietHoSo";
            rpt.pGoiThau.Value = lueGoiThau.Text;
            printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument(true);
            btnControl.btnPrint.Enabled = ds.Tables[0].Rows.Count > 0;
            _wait.Close();
        }

        void LoadTungGoiThau_KhongGiaKH()
        {
            ds = new DataSet();
            ds = FunctionHelper.HoSoDauThau(Convert.ToInt64(lueGoiThau.EditValue));
            WaitDialogForm _wait = new WaitDialogForm("Đang hiển thị dữ liệu ...", "Vui lòng đợi giây lát");
            rpt2 = new rptTrungThauTheoTungGoiThauKhongGiaKH();
            DataView dv = ds.Tables[0].DefaultView;
            //dv.RowFilter = "LOAI_PL=False and VUOTGIA_KH=False and KHONGDAT_KT=False";
            dv.RowFilter = "TT=True";
            dv.Sort = "SP_MA asc";
            rpt2.pHospital.Value = clsParameter.pHospital;
            rpt2.pParentHospital.Value = clsParameter.pParentHospital;
            rpt2.pNgayMoThau.Value = clsParameter.pNgayMoThau;
            rpt2.pQuyetDinh.Value = clsParameter.pQuyetDinh;

            rpt2.pQuyetDinh.Value = clsParameter.pQuyetDinh;
            rpt2.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM09);
            rpt2.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM09);

            ds.Tables[0].Columns.Add("STT", typeof(Int32));
            gcGrid.DataSource = dv;
            //Tạo số STT
            _tongGiaTriTheoGiaKH = _tongGiaTriTheoGiaChaoThau = 0;
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                gvGrid.SetRowCellValue(i, colSTT, i + 1);
                _tongGiaTriTheoGiaKH += clsChangeType.change_decimal(gvGrid.GetRowCellValue(i, colTHANHTIEN_GIAKH));
                _tongGiaTriTheoGiaChaoThau += clsChangeType.change_decimal(gvGrid.GetRowCellValue(i, colThanhTien));
            }
            gcGrid.RefreshDataSource();

            rpt2.DataSource = dv;
            rpt2.DataMember = "ChiTietHoSo";
            rpt2.pGoiThau.Value = lueGoiThau.Text;
            printControl1.PrintingSystem = rpt2.PrintingSystem;
            rpt2.CreateDocument(true);
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

        private void btnControl_btnEventExcel_Click(object sender, EventArgs e)
        {
            DevExpress.Utils.WaitDialogForm waitDialogForm = new DevExpress.Utils.WaitDialogForm("Đang xuất excel ...", "Vui lòng chờ giây lát !");
            try
            {
                ExcelManager excelManager = new ExcelManager(true);

                // Print band header
                BandedGridView view = gvGrid;
                view.ExpandAllGroups();
                object[] data = new object[view.VisibleColumns.Count];
                excelManager.BandedGridHeader2Excel(view, false, 9, 1, "headerRangeName");
                excelManager.SetTitleRows();
                excelManager.SelectRange()
                           .SetFontFamily("Times New Roman");

                waitDialogForm.SetCaption(String.Format("{0} - {1}%", "Đang xuất excel ...", 50));

                excelManager.GridData2Excel(gvGrid, 10, 1, false, false, "", false, false);

                excelManager.SelectRange(excelManager.WorkingRange.Row + excelManager.WorkingRange.Rows.Count, excelManager.WorkingRange.Column,
                    excelManager.WorkingRange.Row + excelManager.WorkingRange.Rows.Count, excelManager.WorkingRange.Column + excelManager.WorkingRange.Columns.Count - 1);


                // Save working range
                //excelManager.MoveRange(2, 0);
                //int maxCol = 12;
                //int xtraCol = 2;

                int sr = excelManager.WorkingRange.Row + 1;
                int sc = excelManager.WorkingRange.Column;
                int er = excelManager.WorkingRange.Row + 1;
                int ec = excelManager.WorkingRange.Column + excelManager.WorkingRange.Columns.Count - 1;

                //excelManager.SelectRange(8, 1, 8, maxCol).SetRowHeight("", 45);

                ////Dòng Title
                excelManager
                    .SelectRange(1, 1, 1, 1)
                    .SetFontStyle(true, false, false)
                    .SetFontSize(12)
                    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                    .SetRangeValue(clsParameter.pParentHospital);

                excelManager
                    .SelectRange(2, 1, 2, 1)
                    .SetFontStyle(false, false, false)
                    .SetFontSize(12)
                    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                    .SetRangeValue(clsParameter.pHospital);

                excelManager
                    .SelectRange(4, 1, 4, ec)
                    .Merge()
                    .SetFontStyle(true, false, false)
                    .SetFontSize(16)
                    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                    .SetRangeValue("DANH MỤC ĐỀ NGHỊ TRÚNG THẦU (CHO TỪNG GÓI THẦU)");

                excelManager
                    .SelectRange(5, 1, 5, ec)
                    .Merge()
                    .SetFontStyle(true, false, false)
                    .SetFontSize(16)
                    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                    .SetRangeValue(string.Format("Gói thầu : {0}", lueGoiThau.Text));

                excelManager
                    .SelectRange(6, 1, 6, ec)
                    .Merge()
                    .SetFontStyle(true, true, false)
                    .SetFontSize(16)
                    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                    .SetRangeValue(clsParameter.pQuyetDinh);

                excelManager
                    .SelectRange(er, 3, er, 3)
                    .SetFontStyle(true, false, false)
                    .SetFontSize(12)
                    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                    .SetRangeValue(string.Format("Tổng giá trị theo giá kế hoạch: {0:#,#0}", _tongGiaTriTheoGiaKH));

                excelManager
                    .SelectRange(er, 13, er, 18)
                    .Merge()
                    .SetFontStyle(true, false, false)
                    .SetFontSize(12)
                    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                    .SetRangeValue(string.Format("Tổng giá trị theo giá chào thầu: {0:#,#0}", _tongGiaTriTheoGiaChaoThau));
                //excelManager
                //   .SelectRange(4, 1, 4, 1)
                //   .SetFontStyle(false, false, false)
                //   .SetFontSize(12)
                //   .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                //   .SetRangeValue("MST: 1801318149");
                //excelManager
                //   .SelectRange(5, 1, 5, 1)
                //   .SetFontStyle(false, false, false)
                //   .SetFontSize(12)
                //   .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                //   .SetRangeValue("SĐT: 07103.737.261 - DĐ: 0932.993.081");
                //excelManager
                //   .SelectRange(6, 1, 6, 1)
                //   .SetFontStyle(false, false, false)
                //   .SetFontSize(12)
                //   .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                //   .SetRangeValue("Số TK: 1800201218555 tại NH Agribank Cần Thơ");

                //excelManager
                //    .SelectRange(8, 1, 8, ec)
                //    .Merge()
                //    .SetFontStyle(true, false, false)
                //    .SetFontSize(16)
                //    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                //    .SetRangeValue(Title);


                //if (RangeTime != string.Empty)
                //    excelManager
                //        .SelectRange(9, 1, 9, ec)
                //        .Merge()
                //        .SetFontStyle(true, false, false)
                //        .SetFontSize(12)
                //        .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                //        .SetRangeValue(RangeTime);

                excelManager.SelectRange(12, 2, er, ec).AutoFitColumn();
                excelManager.SelectRange(12, 2, er, ec).SetNumberFormat("#,#0");
                
                excelManager
                .SelectRange(er + 2, ec - 3, er + 2, ec)
                .Merge()
                .SetFontStyle(false, false, false)
                .SetFontSize(12)
                .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                .SetRangeValue(string.Format("Ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));

                excelManager
                .SelectRange(er + 3, ec - 3, er + 3, ec)
                .Merge()
                .SetFontStyle(false, false, false)
                .SetFontSize(12)
                .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                .SetRangeValue("Thư ký");

                excelManager
                .SelectRange(er + 6, ec - 3, er + 6, ec)
                .Merge()
                .SetFontStyle(false, false, false)
                .SetFontSize(12)
                .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                .SetRangeValue(clsParameter.pThuKy);

                excelManager
                .SelectRange(er + 3, 3, er + 3, 4)
                .Merge()
                .SetFontStyle(false, false, false)
                .SetFontSize(12)
                .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                .SetRangeValue("Giám đốc");

                excelManager
               .SelectRange(er + 6, 3, er + 6, 4)
               .Merge()
               .SetFontStyle(false, false, false)
               .SetFontSize(12)
               .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
               .SetRangeValue(clsParameter.pGiamDoc);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi trong quá trình xuất Excel.\nVui lòng kiểm tra lại biểu mẫu hoặc tài liệu đang mở.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Marshal.ReleaseComObject(excelSheet);
                //Marshal.ReleaseComObject(excelBook);
                //Marshal.ReleaseComObject(books);
                //Marshal.ReleaseComObject(excel);

                waitDialogForm.Close();
            }
        }
    }
}
