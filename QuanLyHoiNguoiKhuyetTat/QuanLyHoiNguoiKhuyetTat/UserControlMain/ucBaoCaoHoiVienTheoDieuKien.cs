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
    public partial class ucBaoCaoHoiVienTheoDieuKien : ucBase
    {
        public ucBaoCaoHoiVienTheoDieuKien()
        {
            InitializeComponent();
        }

        private void ucBaoCaoHoiVienTheoDieuKien_Load(object sender, EventArgs e)
        {
            btnControl_btnEventView_Click(null, null);
            foreach (var item in grpDisplayColumn.Controls)
            {
                CheckEdit chk = item as CheckEdit;
                if(item != null)
                {
                    chk.Checked = true;
                    chk.CheckedChanged += new System.EventHandler(this.DisplayColumn_CheckedChanged);
                }
            }

            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_GIOITINH, repLueGioiTinh);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_DANTOC, repLueDanToc);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_TONGIAO, repLueTonGiao);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_NGHE_NGHIEP, repLueNgheNghiep);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_TRINH_DO_HOC_VAN, repLueTrinhDoVanHoa);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_TRINH_DO_CHUYEN_MON, repLueTrinhDoChuyenMon);

            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_CHUCVU_HOI, repLueChucVu);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_XA, repLueThuongTru_Phuong);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_HUYEN, repLueThuongTru_Quan);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_TINH, repLueThuongTru_ThanhPho);

            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_XA, repLueTamTru_Phuong);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_HUYEN, repLueTamTru_Quan);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_TINH, repLueTamTru_ThanhPho);

            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_KHUYETTAT_MUCDO, repLueMucDo);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_KHUYETTAT_TINHTRANG, repLueKTTinhTrang);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_KHUYETTAT_NGUYENNHAN, repLueKTNguyenNhan);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_PHUONGTIEN_DILAI, repLuePhuongTienDiLai);
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_TINHTRANG_HONNHAN, repLueHonNhan);

        }

        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            context = new QL_HOIVIEN_KTEntities();
            context.QL_HOIVIEN.Load();
            var data = (from p in context.QL_HOIVIEN
                        select p).ToList();
            gcGrid.DataSource = data;
            _wait.Close();
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

        private void DisplayColumn_CheckedChanged(object sender, EventArgs e)
        {
            bandDanToc.Visible = chkDanToc.Checked;
            bandNgaySinh.Visible = chkNgaySinh.Checked;
            bandTonGiao.Visible = chkTonGiao.Checked;
            bandNgheNghiep.Visible = chkNgheNghiep.Checked;
            bandNamKhuyetTat.Visible = chkNamKhuyetTat.Checked;
            bandChucVuTrongHoi.Visible = chkChucVuTrongHoi.Checked;

            bandTrinhDoVanHoa.Visible = chkTrinhDoVanHoa.Checked;
            bandTrinhDoChuyenMon.Visible = chkTrinhDoChuyeMon.Checked;

            bandCMND.Visible = chkCMND.Checked;
            bandDiaChiThuongTru.Visible = chkDiaChiThuongTru.Checked;
            bandDiaChiTamTru.Visible = chkDiaChiTamTru.Checked;
            bandThongTinLienHe.Visible = chkThongTinLienHe.Checked;
            bandSucKhoe.Visible = chkSucKhoe.Checked;
            bandHonNhan.Visible = chkHonNhan.Checked;
            bandHoatDong.Visible = chkHoatdong.Checked;

            bandDungCuHoTro.Visible = chkDungCuHoTro.Checked;
            bandChinhSach.Visible = chkChinhSach.Checked;
            bandNoiO.Visible = chkNoiO.Checked;
            bandCongViec.Visible = chkCongViec.Checked;
        }

        #region Filter

        void clearFilter(ButtonPressedEventArgs e, BandedGridColumn col)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                gvGrid.Columns[col.FieldName].ClearFilter();
            }
        }

        private void repLueGioiTinh_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_GIOI_TINH);
        }

        private void repLueDanToc_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_DAN_TOC);
        }

        private void repLueTonGiao_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_TONGIAO);
        }

        #endregion

        private void repLueNgheNghiep_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_NGHE_NGHIEP);
        }

        private void repLueTrinhDoVanHoa_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_TRINHDO_VANHOA);
        }

        private void repLueTrinhDoChuyenMon_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_TRINHDO_CHUYENMON);
        }

        private void repLueChucVu_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_CHUCVU);
        }


        private void repLueThuongTru_Phuong_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_THUONGTRU_PHUONG);
        }

        private void repLueThuongTru_Quan_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_THUONGTRU_QUAN);
        }

        private void repLueThuongTru_ThanhPho_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_THUONGTRU_TP);
        }

        private void repLueTamTru_Phuong_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_TAMTRU_PHUONG);
        }

        private void repLueTamTru_Quan_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_TAMTRU_QUAN);
        }

        private void repLueTamTru_ThanhPho_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_TAMTRU_TP);
        }

        private void repLueMucDo_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_KT_MUCDO);
        }

        private void repLueKTNguyenNhan_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_KT_NGUYENNHAN);
        }

        private void repLueKTTinhTrang_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_KT_TINHTRANG);
        }

        private void repLuePhuongTienDiLai_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_PHUONGTIEN_DILAI);
        }

        private void repLueHonNhan_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            clearFilter(e, colHV_TINHTRANG_HONNHAN);
        }
    }
}
