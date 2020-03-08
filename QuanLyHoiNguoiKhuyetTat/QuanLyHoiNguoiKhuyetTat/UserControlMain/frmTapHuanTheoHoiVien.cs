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
using static DauThau.Class.FuncCategory;

namespace DauThau.UserControlCategoryMain
{
    public partial class frmTapHuanTheoHoiVien : XtraForm
    {
        public frmTapHuanTheoHoiVien()
        {
            InitializeComponent();
        }

        QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
        
        public class clsBCHoatDongTheoDieuKien
        {
            public String HD_LOAI { get; set; }
            public Int64? HD_LOAI_ID { get; set; }
            public String HD_NGAY { get; set; }
            public DateTime? HD_THOIGIAN_BATDAU { get; set; }
            public DateTime? HD_THOIGIAN_KETTHUC { get; set; }
            public string HD_TEN { get; set; }
            public string HD_DIADIEM { get; set; }
            public string HD_DONVI_PHUTRACH { get; set; }
            public string HD_DONVI_TAITRO { get; set; }
            
        }

        private void ucBCHoatDongTheoDieuKien_Load(object sender, EventArgs e)
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            deTuNgay.Ex_FormatCustomDateEdit();
            deDenNgay.Ex_FormatCustomDateEdit();

            //set mặc định
            var current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var nextMonth = current.AddMonths(1);
            deTuNgay.DateTime = current;
            deDenNgay.DateTime = nextMonth.AddDays(-1);

            lueSearchHoiVien.Properties.DataSource = context.QL_HOIVIEN.ToList();
            _wait.Close();
        }

        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            List<clsBCHoatDongTheoDieuKien> listData = new List<clsBCHoatDongTheoDieuKien>();

            if (deTuNgay.EditValue == null || deDenNgay.EditValue == null)
            {
                clsMessage.MessageWarning("Vui lòng nhập điều kiện tìm kiếm");
                return;
            }else if(deTuNgay.DateTime.Date > deDenNgay.DateTime.Date)
            {
                clsMessage.MessageWarning("Thời gian tìm kiếm không phù hợp");
                return;
            }

            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
            List<QL_HOIVIEN> listHoiVien = context.QL_HOIVIEN.ToList();

            string hoiVienId = lueSearchHoiVien.EditValue + string.Empty;
            //Tập huấn
            var listDayNgheData = (from p in context.QL_HOATDONG_TAPHUAN
                                   let diadiem = p.QL_HOATDONG_TAPHUAN_DIADIEM.FirstOrDefault()
                                where deTuNgay.DateTime.Date <= p.TH_THOIGIAN_BATDAU
                                     && p.TH_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                                     && p.TH_DOITUONG_HV_ID.Contains(hoiVienId)
                                select new clsBCHoatDongTheoDieuKien
                                {
                                    HD_LOAI_ID = p.TH_LOAI_ID,
                                    HD_THOIGIAN_BATDAU = p.TH_THOIGIAN_BATDAU,
                                    HD_THOIGIAN_KETTHUC = p.TH_THOIGIAN_KETTHUC,
                                    HD_TEN = p.TH_TEN,
                                    HD_DIADIEM = diadiem.TH_DD_TEN,
                                    HD_DONVI_PHUTRACH = p.TH_DONVI_PHUTRACH,
                                    HD_DONVI_TAITRO = p.NTT_TEN,
                                }
                        ).ToList();
            listData.AddRange(listDayNgheData);

            listData = listData.OrderBy(p => p.HD_LOAI).OrderBy(p => p.HD_THOIGIAN_BATDAU).ToList();
            List<dynamicObject> listDm = FuncCategory.loadDMTapHuan();
            foreach (var item in listData)
            {
                var rowCategory = listDm.Where(p => p.ID == item.HD_LOAI_ID).FirstOrDefault();
                item.HD_LOAI = rowCategory != null ? rowCategory.NAME : "";
                item.HD_NGAY = item.HD_THOIGIAN_BATDAU.Value.Date.ToString("dd/MM/yyyy") + " - " + item.HD_THOIGIAN_KETTHUC.Value.Date.ToString("dd/MM/yyyy");
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

                excelManager.GridData2Excel(gvGrid, 7, 1, false, false, "", false, false);

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
                    .SetRangeValue("DANH SÁCH HOẠT ĐỘNG CỦA " + lueSearchHoiVien.Text);

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

        private void btnControl_btnEventClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
