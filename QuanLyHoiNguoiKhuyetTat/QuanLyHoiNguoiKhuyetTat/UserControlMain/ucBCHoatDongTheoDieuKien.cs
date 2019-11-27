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
    public partial class ucBCHoatDongTheoDieuKien : ucBase
    {
        public ucBCHoatDongTheoDieuKien()
        {
            InitializeComponent();
        }

        public class clsBCHoatDongTheoDieuKien
        {
            public String HD_LOAI { get; set; }
            public String HD_NGAY { get; set; }
            public DateTime? HD_THOIGIAN_BATDAU { get; set; }
            public DateTime? HD_THOIGIAN_KETTHUC { get; set; }
            public string HD_TEN { get; set; }
            public string HD_DIADIEM { get; set; }
            public string HD_DONVI_THUCHIEN { get; set; }
            public string HD_DONVI_TAITRO { get; set; }
            public int? HD_TONGTIEN { get; set; }
            public string HD_DOITUONG { get; set; }
            public string HD_DOITUONG_KHAC { get; set; }
            public string HD_NGUOI_HOTRO { get; set; }
            public int? HD_NGUOI_HOTRO_THULAO { get; set; }
            public string HD_NGHEDAY { get; set; }
            public string HD_DAY_TU_NGUON { get; set; }
            public string HD_NOIDUNG { get; set; }
            public string HD_VV_NGUON_VAY { get; set; }
            public int? HD_VV_SOTIEN_VAY { get; set; }
            public DateTime? HD_VV_THOIGIAN_TRA { get; set; }
            public string HD_VV_PHUONGTHUC_TRA { get; set; }
        }

        private void ucBCHoatDongTheoDieuKien_Load(object sender, EventArgs e)
        {
            deTuNgay.Ex_FormatCustomDateEdit();
            deDenNgay.Ex_FormatCustomDateEdit();

            //set mặc định
            var current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var nextMonth = current.AddMonths(1);
            deTuNgay.DateTime = current;
            deDenNgay.DateTime = nextMonth.AddDays(-1);

            btnControl_btnEventView_Click(null, null);
            
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
            context = new QL_HOIVIEN_KTEntities();
            List<QL_HOIVIEN> listHoiVien = context.QL_HOIVIEN.ToList();

            //Dạy nghề
            var listDayNgheData = (from p in context.QL_HOATDONG_DAYNGHE
                                where deTuNgay.DateTime.Date <= p.DN_THOIGIAN_BATDAU
                                     && p.DN_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                                select new clsBCHoatDongTheoDieuKien
                                {
                                    HD_LOAI = "Dạy nghề",
                                    HD_THOIGIAN_BATDAU = p.DN_THOIGIAN_BATDAU,
                                    HD_THOIGIAN_KETTHUC = p.DN_THOIGIAN_KETTHUC,
                                    HD_TEN = p.DN_TEN,
                                    HD_DIADIEM = p.DN_DIADIEM,
                                    HD_DONVI_THUCHIEN = "",
                                    HD_DONVI_TAITRO = "",
                                    HD_TONGTIEN = p.DN_TONGTIEN,
                                    HD_DOITUONG = p.DN_DOITUONG_THAMGIA,
                                    HD_NGUOI_HOTRO = p.DN_NGUOI_HOTRO,
                                    HD_NGUOI_HOTRO_THULAO = 0,
                                    HD_NGHEDAY = p.DN_NGHE,
                                    HD_DAY_TU_NGUON = p.DN_DONVI_THUCHIEN,
                                    HD_NOIDUNG = p.DN_NOIDUNG
                                }
                        ).ToList();
            listData.AddRange(listDayNgheData);

            //VIEC LAM
            var listViecLamData = (from p in context.QL_HOATDONG_VIECLAM
                                where deTuNgay.DateTime.Date <= p.VL_THOIGIAN_BATDAU
                                     && p.VL_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                                select new clsBCHoatDongTheoDieuKien
                                {
                                    HD_LOAI = "Việc làm",
                                    HD_THOIGIAN_BATDAU = p.VL_THOIGIAN_BATDAU,
                                    HD_THOIGIAN_KETTHUC = p.VL_THOIGIAN_KETTHUC,
                                    HD_TEN = p.VL_TEN,
                                    HD_DIADIEM = p.VL_DIADIEM,
                                    HD_DONVI_THUCHIEN = p.VL_DONVI_GIOITHIEU,
                                    HD_DONVI_TAITRO = "",
                                    HD_TONGTIEN = 0,
                                    HD_DOITUONG = p.VL_DOITUONG_TEN,
                                    HD_DOITUONG_KHAC = p.VL_DOITUONG_KHAC,
                                    HD_NGUOI_HOTRO = "",
                                    HD_NGUOI_HOTRO_THULAO = 0,
                                    HD_NOIDUNG = p.VL_NOIDUNG
                                }
                        ).ToList();
            listData.AddRange(listViecLamData);

            //VAY VON
            var listVayVonData = (from p in context.QL_HOATDONG_VAYVON
                                   where deTuNgay.DateTime.Date <= p.VV_THOIGIAN_BATDAU
                                        && p.VV_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                                   select new clsBCHoatDongTheoDieuKien
                                   {
                                       HD_LOAI = "Vay vốn",
                                       HD_THOIGIAN_BATDAU = p.VV_THOIGIAN_BATDAU,
                                       HD_THOIGIAN_KETTHUC = p.VV_THOIGIAN_KETTHUC,
                                       HD_TEN = p.VV_TEN,
                                       HD_DIADIEM = p.VV_DIADIEM,
                                       HD_DONVI_THUCHIEN = "",
                                       HD_DONVI_TAITRO = "",
                                       HD_TONGTIEN = 0,
                                       HD_DOITUONG = p.VV_DOITUONG_TEN,
                                       HD_DOITUONG_KHAC = p.VV_DOITUONG_KHAC,
                                       HD_NOIDUNG = p.VV_NOIDUNG,

                                       HD_VV_NGUON_VAY = p.VV_NGUON_VAY,
                                       HD_VV_THOIGIAN_TRA = p.VV_THOIGIAN_TRA,
                                       HD_VV_SOTIEN_VAY = p.VV_TIEN_VAY,
                                       HD_VV_PHUONGTHUC_TRA = p.VV_PHUONGTHUC_TRA
                                   }
                        ).ToList();
            listData.AddRange(listVayVonData);

            //Hội chợ triển lãm
            var listHoiChoTrienLamData = (from p in context.QL_HOATDONG_HOICHO_TRIENLAM
                                  where deTuNgay.DateTime.Date <= p.HC_THOIGIAN_BATDAU
                                       && p.HC_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                                  select new clsBCHoatDongTheoDieuKien
                                  {
                                      HD_LOAI = "Hội chợ triễn lãm",
                                      HD_THOIGIAN_BATDAU = p.HC_THOIGIAN_BATDAU,
                                      HD_THOIGIAN_KETTHUC = p.HC_THOIGIAN_KETTHUC,
                                      HD_TEN = p.HC_TEN,
                                      HD_DIADIEM = p.HC_DIADIEM,
                                      HD_DONVI_THUCHIEN = "",
                                      HD_DONVI_TAITRO = p.HC_TAITRO_DONVI,
                                      HD_TONGTIEN = p.HC_SOTIEN_SAU_BANHANG,
                                      HD_DOITUONG = p.HC_DOITUONG_TEN,
                                      HD_DOITUONG_KHAC = p.HC_DOITUONG_KHAC,
                                      HD_NOIDUNG = p.HC_NOIDUNG
                                  }
                        ).ToList();
            listData.AddRange(listHoiChoTrienLamData);

            //Hội thảo
            var listHoiThaoData = (from p in context.QL_HOATDONG_HOITHAO
                                          where deTuNgay.DateTime.Date <= p.HT_THOIGIAN_BATDAU
                                               && p.HT_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                                          select new clsBCHoatDongTheoDieuKien
                                          {
                                              HD_LOAI = p.HT_LOAI_ID == 1 ? "Đại hội" : "",
                                              HD_THOIGIAN_BATDAU = p.HT_THOIGIAN_BATDAU,
                                              HD_THOIGIAN_KETTHUC = p.HT_THOIGIAN_KETTHUC,
                                              HD_TEN = p.HT_TEN,
                                              HD_DIADIEM = p.HT_DIADIEM,
                                              HD_DONVI_THUCHIEN = p.HT_DONVI_THUCHIEN,
                                              HD_DONVI_TAITRO = "",
                                              HD_TONGTIEN = p.HT_SOTIEN_HOTRO,
                                              HD_DOITUONG = p.HT_DOITUONG_TEN,
                                              HD_DOITUONG_KHAC = p.HT_DOITUONG_KHAC,
                                              HD_NOIDUNG = p.HT_NOIDUNG,

                                              HD_NGUOI_HOTRO = p.HT_NGUOI_HOTRO,
                                              HD_NGUOI_HOTRO_THULAO = p.HT_NGUOI_HOTRO_THULAO
                                          }
                        ).ToList();
            listData.AddRange(listHoiThaoData);

            listData = listData.OrderBy(p => p.HD_LOAI).OrderBy(p => p.HD_THOIGIAN_BATDAU).ToList();
            foreach (var item in listData)
            {
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
                    .SetRangeValue("DANH SÁCH MẠNH THƯỜNG QUÂN/ NHÀ TÀI TRỢ");

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
