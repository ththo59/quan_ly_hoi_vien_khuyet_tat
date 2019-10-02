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
    public partial class ucBCNhaTaiTroVaMTQ : ucBase
    {
        public ucBCNhaTaiTroVaMTQ()
        {
            InitializeComponent();
        }

        public class clsNhaTaiTroMTQ
        {
            public String NTT_NGAY { get; set; }
            public DateTime? NTT_THOIGIAN_BATDAU { get; set; }
            public DateTime? NTT_THOIGIAN_KETTHUC { get; set; }
            public string NTT_TEN { get; set; }
            public string NTT_TEN_CHUONGTRINH { get; set; }
            public string NTT_DIACHI { get; set; }
            public int? NTT_SOTIEN { get; set; }
            public string NTT_GHICHU { get; set; }
        }

        private void ucBCNhaTaiTroVaMTQ_Load(object sender, EventArgs e)
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
            List<clsNhaTaiTroMTQ> listData = new List<clsNhaTaiTroMTQ>();

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

            //ASXH
            var listASXHData = (from p in context.QL_HOATDONG_NHATAITRO
                        let asxh = p.QL_HOATDONG_ASXH
                        where deTuNgay.DateTime.Date <= asxh.ASXH_THOIGIAN_BATDAU
                             && asxh.ASXH_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                        select new clsNhaTaiTroMTQ
                        {
                            NTT_THOIGIAN_BATDAU = asxh.ASXH_THOIGIAN_BATDAU,
                            NTT_THOIGIAN_KETTHUC = asxh.ASXH_THOIGIAN_KETTHUC,
                            NTT_TEN_CHUONGTRINH = asxh.ASXH_TEN,
                            NTT_TEN = p.NTT_TEN,
                            NTT_DIACHI = p.NTT_DIACHI,
                            NTT_SOTIEN = p.NTT_SOTIEN,
                            NTT_GHICHU = p.NTT_GHICHU
                        }
                        ).ToList();
            listData.AddRange(listASXHData);

            //HNXH
            var listHNXHData = (from p in context.QL_HOATDONG_NHATAITRO
                                let asxh = p.QL_HOATDONG_HNXH
                                where deTuNgay.DateTime.Date <= asxh.HNXH_THOIGIAN_BATDAU
                                     && asxh.HNXH_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                                select new clsNhaTaiTroMTQ
                                {
                                    NTT_THOIGIAN_BATDAU = asxh.HNXH_THOIGIAN_BATDAU,
                                    NTT_THOIGIAN_KETTHUC = asxh.HNXH_THOIGIAN_KETTHUC,
                                    NTT_TEN_CHUONGTRINH = asxh.HNXH_TEN,
                                    NTT_TEN = p.NTT_TEN,
                                    NTT_DIACHI = p.NTT_DIACHI,
                                    NTT_SOTIEN = p.NTT_SOTIEN,
                                    NTT_GHICHU = p.NTT_GHICHU
                                }
                        ).ToList();
            listData.AddRange(listHNXHData);

            //HNXH
            var listKhacData = (from p in context.QL_HOATDONG_NHATAITRO
                                let asxh = p.QL_HOATDONG_KHAC
                                where deTuNgay.DateTime.Date <= asxh.KHAC_THOIGIAN_BATDAU
                                     && asxh.KHAC_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                                select new clsNhaTaiTroMTQ
                                {
                                    NTT_THOIGIAN_BATDAU = asxh.KHAC_THOIGIAN_BATDAU,
                                    NTT_THOIGIAN_KETTHUC = asxh.KHAC_THOIGIAN_KETTHUC,
                                    NTT_TEN_CHUONGTRINH = asxh.KHAC_TEN,
                                    NTT_TEN = p.NTT_TEN,
                                    NTT_DIACHI = p.NTT_DIACHI,
                                    NTT_SOTIEN = p.NTT_SOTIEN,
                                    NTT_GHICHU = p.NTT_GHICHU
                                }
                        ).ToList();
            listData.AddRange(listKhacData);

            listData = listData.OrderBy(p => p.NTT_THOIGIAN_BATDAU).ToList();
            foreach (var item in listData)
            {
                item.NTT_NGAY = item.NTT_THOIGIAN_BATDAU.Value.Date.ToString("dd/MM/yyyy") + " - " + item.NTT_THOIGIAN_KETTHUC.Value.Date.ToString("dd/MM/yyyy");
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

                excelManager.GridData2Excel(gvGrid, 7, 1, false, true, "", false, false);

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
