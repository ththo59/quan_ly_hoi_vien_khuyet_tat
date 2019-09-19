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
    public partial class ucBCTreKTVaConNKT : ucBase
    {
        public ucBCTreKTVaConNKT()
        {
            InitializeComponent();
        }

        public class clsTreKTVaConNKT
        {
            public int STT { get; set; }
            public string HV_HO { get; set; }
            public string HV_TEN { get; set; }
            public string HV_NAMSINH_NAM { get; set; }
            public string HV_NAMSINH_NU { get; set; }
            public string HV_CHA_ME { get; set; }
            public string HV_TAMTRU_DIACHI { get; set; }
            public string HV_HOAN_CANH { get; set; }
            public string HV_DOI_TUONG { get; set; }
            public string HV_DIENTHOAI { get; set; }
            public string HV_GHICHU { get; set; }
        }

        private void ucBCTreKTVaConNKT_Load(object sender, EventArgs e)
        {
            btnControl_btnEventView_Click(null, null);
        }

        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            context = new QL_HOIVIEN_KTEntities();
            context.QL_HOIVIEN.Load();
            int stt = 1;
            var data = (from p in context.QL_HOIVIEN
                        where (p.HV_NGAY_SINH.HasValue ? DateTime.Now.Year - p.HV_NGAY_SINH.Value.Year : 0) <= 15
                        select p).ToList();
            List<clsTreKTVaConNKT> listData = new List<clsTreKTVaConNKT>();
            
            foreach (QL_HOIVIEN item in data)
            {
                clsTreKTVaConNKT row = new clsTreKTVaConNKT();
                row.STT = stt++;
                row.HV_HO = item.HV_HO;
                row.HV_TEN = item.HV_TEN;
                row.HV_NAMSINH_NAM = item.HV_GIOI_TINH == "Nam" ? (item.HV_NGAY_SINH.HasValue ? item.HV_NGAY_SINH.Value.Year.ToString() : "") : "";
                row.HV_NAMSINH_NU = item.HV_GIOI_TINH == "Nữ" ? (item.HV_NGAY_SINH.HasValue ? item.HV_NGAY_SINH.Value.Year.ToString() : "") : "";
                row.HV_CHA_ME = item.HV_SONG_VOI_CHITIET;
                row.HV_HOAN_CANH = "";
                row.HV_TAMTRU_DIACHI = item.HV_TAMTRU_DIACHI;
                row.HV_DIENTHOAI = item.HV_DIENTHOAI;
                row.HV_DOI_TUONG = "TKT";
                row.HV_GHICHU = item.HV_GHICHU;
                listData.Add(row);
            }

            gcGrid.DataSource = listData;
            _wait.Close();
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
                excelManager.BandedGridHeader2Excel(view, false, 6, 1, "headerRangeName");
                excelManager.SetTitleRows();
                excelManager.SelectRange()
                           .SetFontFamily("Times New Roman");

                waitDialogForm.SetCaption(String.Format("{0} - {1}%", "Đang xuất excel ...", 50));

                excelManager.GridData2Excel(gvGrid, 8, 1, false, false, "", false, false);

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
                    .SetRangeValue("DANH SÁCH HỘI VIÊN");

                excelManager.SelectRange(11, 2, er, ec).AutoFitColumn();
                //excelManager.SelectRange(11, 2, er, ec).SetNumberFormat("#,#0");

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

    }
}
