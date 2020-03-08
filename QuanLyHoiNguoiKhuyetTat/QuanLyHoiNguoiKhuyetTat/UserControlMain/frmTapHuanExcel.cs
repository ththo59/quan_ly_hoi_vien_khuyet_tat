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
using DauThau.UserControlCategory;
using DauThau.Models;
using System.Linq;
using System.Data.Entity;
using DevExpress.XtraEditors.Controls;

namespace DauThau.UserControlCategoryMain
{
    public partial class frmTapHuanExcel : XtraForm
    {
        public frmTapHuanExcel()
        {
            InitializeComponent();
        }

        public clsHeaderData headerData = new clsHeaderData();
        public List<clsTapHuanDetailData> detailData = new List<clsTapHuanDetailData>();

        public class clsHeaderData
        {
            public string TH_TEN { get; set; }
            public string TH_TAPHUANVIEN { get; set; }
            public string TH_DIADIEM { get; set; }
            public string TH_THOIGIAN { get; set; }
        }

        private void ucBCHoatDongTheoDieuKien_Load(object sender, EventArgs e)
        {
            int i = 1;
            foreach (var item in detailData)
            {
                item.STT = i++;
            }
            this.Hide();
            gcGrid.DataSource = detailData;
            btnControl_btnEventExcel_Click(null, null);
            this.Close();
        }

        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            
        }

        private void btnControl_btnEventExcel_Click(object sender, EventArgs e)
        {
            WaitDialogForm waitDialogForm = new WaitDialogForm("Đang xuất excel ...", "Vui lòng chờ giây lát !");
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

                //excelManager.SelectRange(excelManager.WorkingRange.Row + excelManager.WorkingRange.Rows.Count, excelManager.WorkingRange.Column,
                //    excelManager.WorkingRange.Row + excelManager.WorkingRange.Rows.Count, excelManager.WorkingRange.Column + excelManager.WorkingRange.Columns.Count - 1);


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
                    .SetRangeValue(headerData.TH_TEN);
                excelManager
                    .SelectRange(5, 1, 5, 1)
                    .SetRangeValue("Tập huấn viên: " + headerData.TH_TAPHUANVIEN);
                excelManager
                    .SelectRange(6, 1, 6, 1)
                    .SetRangeValue("Địa điểm: " + headerData.TH_DIADIEM);
                excelManager
                    .SelectRange(7, 1, 7, 1)
                    .SetRangeValue("Thời gian: " + headerData.TH_THOIGIAN);
                excelManager
                    .SelectRange(8, 1, 8, 1)
                    .SetRangeValue("Tổng số người tham gia: " + detailData.Count().ToString());

                excelManager.SelectRange(11, 2, er, ec).AutoFitColumn();
                excelManager.SelectRange(7, 7, er, ec -1).SetNumberFormat("#,#0");

               // excelManager
               // .SelectRange(er + 2, ec - 3, er + 2, ec)
               // .Merge()
               // .SetFontStyle(false, false, false)
               // .SetFontSize(12)
               // .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
               // .SetRangeValue(string.Format("Ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));

               // excelManager
               // .SelectRange(er + 3, ec - 3, er + 3, ec)
               // .Merge()
               // .SetFontStyle(false, false, false)
               // .SetFontSize(12)
               // .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
               // .SetRangeValue("Thư ký");

               // excelManager
               // .SelectRange(er + 6, ec - 3, er + 6, ec)
               // .Merge()
               // .SetFontStyle(false, false, false)
               // .SetFontSize(12)
               // .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
               // .SetRangeValue(clsParameter.pThuKy);

               // excelManager
               // .SelectRange(er + 3, 3, er + 3, 4)
               // .Merge()
               // .SetFontStyle(false, false, false)
               // .SetFontSize(12)
               // .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
               // .SetRangeValue("Giám đốc");

               // excelManager
               //.SelectRange(er + 6, 3, er + 6, 4)
               //.Merge()
               //.SetFontStyle(false, false, false)
               //.SetFontSize(12)
               //.SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
               //.SetRangeValue(clsParameter.pGiamDoc);
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

        private void gvGrid_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == colSTT && e.IsGetData)
            {
                e.Value = e.ListSourceRowIndex + 1;
            }
        }
    }
}
