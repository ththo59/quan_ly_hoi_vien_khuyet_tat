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
using DevExpress.XtraGrid;
using DauThau.Models;
using System.Linq;
using System.Data.Entity;
using DevExpress.Utils;
using DevExpress.XtraLayout.Utils;

namespace DauThau.UserControlCategory
{
    public partial class ucHoatDongTapHuan : ucBase
    {
        private Int64 _id_loai;
        public ucHoatDongTapHuan(Int64 id_loai)
        {
            InitializeComponent();
            _id_loai = id_loai;
        }

        private void ucHoatDongHoiThaoTapHuan_Load(object sender, EventArgs e)
        {
            registerButtonArray(btnControl);

            deSearchTuNgay.Ex_FormatCustomDateEdit();
            deSearchDenNgay.Ex_FormatCustomDateEdit();
            deTuNgay.Ex_FormatCustomDateEdit();
            deDenNgay.Ex_FormatCustomDateEdit();

            seThuLaoGV.Ex_FormatCustomSpinEdit();
            seThuLaoHoTro.Ex_FormatCustomSpinEdit();
            seSoLuongNguoiThamGia.Ex_FormatCustomSpinEdit();
            seSoTienMoiNguoi.Ex_FormatCustomSpinEdit();
            seTongTien.Ex_FormatCustomSpinEdit();

            var current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var nextMonth = current.AddMonths(1);
            deSearchTuNgay.DateTime = current;
            deSearchDenNgay.DateTime = nextMonth.AddDays(-1);

            lueLoaiTapHuan.Properties.DataSource = FuncCategory.loadDMTapHuan();
            lueLoaiTapHuan.EditValue = _id_loai;

            _changeLayout((CategoryTapHuan)_id_loai);

            FormStatus = EnumFormStatus.VIEW;
        }

        #region Variable

        #endregion

        #region Function

        private void _changeLayout(CategoryTapHuan enumLoai)
        {
            switch (enumLoai)
            {
                case CategoryTapHuan.TH_TAPHUAN:
                    layThongTinGV.Visibility = layGiangVienThuLao.Visibility
                        = layNguoiHoTro.Visibility = layHoTroThuLao.Visibility = LayoutVisibility.Always;
                    break;
                case CategoryTapHuan.TH_GIAODUC:
                    break;
                case CategoryTapHuan.HUONG_DAN_THUC_TAP:
                    break;
                case CategoryTapHuan.VAN_DONG_CHINH_SACH:
                    laySoNguoiThamGia.Visibility = laySoTienTrenNguoi.Visibility = layTongTien.Visibility = LayoutVisibility.Never;
                    layNguoiHoTro.Visibility = LayoutVisibility.Always;
                    layNguoiHoTro.Text = "Người thực hiện";
                    layDiaDiem.Text = "Nơi nhận";
                    break;
                case CategoryTapHuan.TRUYEN_THONG_PHAP_LY:
                    layDonViThucHien.Visibility = LayoutVisibility.Always;
                    break;
                default:
                    break;
            }
        }

        private void _statusAllControl(Boolean readOnly)
        {

            foreach (var items in layoutEdit.Controls)
            {
                BaseEdit item = items as BaseEdit;
                SimpleButton button = items as SimpleButton;
                if (button != null)
                {
                    button.Enabled = !readOnly;
                    continue;
                }
                if (item != null)
                {
                    item.ReadOnly = readOnly;
                    item.EnterMoveNextControl = true;
                }
                else
                {
                    CheckedListBoxControl checkListBox = items as CheckedListBoxControl;
                    if (checkListBox != null)
                    {
                        checkListBox.Enabled = !readOnly;
                    }
                }
            }
            deSearchTuNgay.ReadOnly = deSearchDenNgay.ReadOnly = !readOnly;
            btnSearch.Enabled = readOnly;
            gcGrid.Enabled = readOnly;
            seTongSoNgay.ReadOnly = true;
        }

        private void _clearData()
        {
            foreach (var items in layoutEdit.Controls)
            {
                BaseEdit item = items as BaseEdit;
                if (item != null)
                {
                    item.EditValue = null;
                }
            }
        }

        private void _loadData()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            context = new QL_HOIVIEN_KTEntities();
            context.QL_HOATDONG_TAPHUAN.Load();
            var data = (from p in context.QL_HOATDONG_TAPHUAN
                        where deSearchTuNgay.DateTime.Date <= p.TH_THOIGIAN_BATDAU
                             && p.TH_THOIGIAN_BATDAU <= deSearchDenNgay.DateTime.Date
                             && p.TH_LOAI_ID == _id_loai
                        select p).ToList();
            gcGrid.DataSource = data;
            _loadDataFocusRow();
            _wait.Close();
        }

        private void _loadDataFocusRow()
        {
            _clearData();
            QL_HOATDONG_TAPHUAN item = gvGrid.GetFocusedRow() as QL_HOATDONG_TAPHUAN;
            if (item != null)
            {
                deTuNgay.EditValue = item.TH_THOIGIAN_BATDAU;
                deDenNgay.EditValue = item.TH_THOIGIAN_KETTHUC;
                seTongSoNgay.EditValue = item.TH_TONGSO_NGAY;
                txtTenChuongTrinh.EditValue = item.TH_TEN;
                txtDiaDiem.EditValue = item.TH_DIADIEM;
                txtDonViThucHien.EditValue = item.TH_DONVI_THUCHIEN;
                seSoLuongNguoiThamGia.EditValue = item.TH_SOLUONG;
                seSoTienMoiNguoi.EditValue = item.TH_SOTIEN_1NGUOI;
                txtNoiDung.EditValue = item.TH_NOIDUNG;
                txtThongTinGiangVien.EditValue = item.TH_GIANGVIEN;
                seThuLaoGV.EditValue = item.TH_GIANGVIEN_THULAO;
                txtThongTinNguoiHoTro.EditValue = item.TH_NGUOI_HOTRO;
                seThuLaoHoTro.EditValue = item.TH_NGUOI_HOTRO_THULAO;
            }
        }

        private void _setObjectEntities(ref QL_HOATDONG_TAPHUAN item)
        {
            item.TH_LOAI_ID = _id_loai;
            item.TH_THOIGIAN_BATDAU = deTuNgay.Ex_EditValueToDateTime();
            item.TH_THOIGIAN_KETTHUC = deDenNgay.Ex_EditValueToDateTime();
            item.TH_TONGSO_NGAY = seTongSoNgay.Ex_EditValueToInt();

            item.TH_TEN = txtTenChuongTrinh.Text ;
            item.TH_DIADIEM = txtDiaDiem.Text;
            item.TH_DONVI_THUCHIEN = txtDonViThucHien.Text;
            item.TH_SOLUONG = seSoLuongNguoiThamGia.Ex_EditValueToInt();
            item.TH_SOTIEN_1NGUOI = seSoTienMoiNguoi.Ex_EditValueToInt();
            item.TH_NOIDUNG = txtNoiDung.Text;
            item.TH_GIANGVIEN = txtThongTinGiangVien.Text;
            item.TH_GIANGVIEN_THULAO = seThuLaoGV.Ex_EditValueToInt();
            item.TH_NGUOI_HOTRO = txtThongTinNguoiHoTro.Text;
            item.TH_NGUOI_HOTRO_THULAO = seThuLaoHoTro.Ex_EditValueToInt();
        }

        private Boolean _validateControl()
        {
            dxErrorProvider.ClearErrors();

            if (txtTenChuongTrinh.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenChuongTrinh, "Vui lòng nhập họ tên");
            }

            if (clsChangeType.change_int(seTongSoNgay.EditValue)  <= 0)
            {
                dxErrorProvider.SetError(deDenNgay, "Từ ngày và đến ngày không phù hợp");
            }

            if (dxErrorProvider.HasErrors)
            {
                clsMessage.MessageWarning("Vui lòng nhập đầy đủ thông tin.");
            }

            return !dxErrorProvider.HasErrors;
        }

        protected override bool SaveData()
        {
            if (_validateControl())
            {
                using (var _context = new QL_HOIVIEN_KTEntities())
                {
                    QL_HOATDONG_TAPHUAN item;
                    switch (_formStatus)
                    {
                        case EnumFormStatus.ADD:
                            #region Add

                            item = new QL_HOATDONG_TAPHUAN();
                            _setObjectEntities(ref item);
                            _context.QL_HOATDONG_TAPHUAN.Add(item);

                            #endregion
                            break;
                        case EnumFormStatus.MODIFY:
                            Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colTH_ID));
                            item = (from p in _context.QL_HOATDONG_TAPHUAN where p.TH_ID == id select p).FirstOrDefault<QL_HOATDONG_TAPHUAN>();
                            if (item != null)
                            {
                                _setObjectEntities(ref item);
                            }
                            var entity = _context.QL_HOATDONG_TAPHUAN.Find(id);
                            _context.Entry(entity).CurrentValues.SetValues(item);
                            break;
                        default:
                            break;
                    }
                    _context.SaveChanges();
                }
                FormStatus = EnumFormStatus.VIEW;
            }

            return base.SaveData();
        }

        #endregion

        #region Status

        private void _deleteRow()
        {
            QL_HOATDONG_TAPHUAN item = gvGrid.GetFocusedRow() as QL_HOATDONG_TAPHUAN;
            if (item != null)
            {
                if (clsMessage.MessageYesNo(string.Format("Bạn có chắc muốn xóa: {0}", item.TH_TEN)) == DialogResult.Yes)
                {
                    Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colTH_ID));
                    QL_HOATDONG_TAPHUAN entities = (from p in context.QL_HOATDONG_TAPHUAN where p.TH_ID == id select p).FirstOrDefault();
                    context.QL_HOATDONG_TAPHUAN.Remove(entities);
                    context.SaveChanges();
                    FormStatus = EnumFormStatus.VIEW;
                }

            }

        }

        protected override EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.ADD)
                {
                    _clearData();
                    deTuNgay.Focus();
                    _statusAllControl(false);
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    deTuNgay.Focus();
                    _statusAllControl(false);
                }
                else if (_formStatus == EnumFormStatus.DELETE)
                {
                    _deleteRow();
                }
                else if (_formStatus == EnumFormStatus.PRINT)
                {
                    //_doPrintInLyLich();
                }
                else if (_formStatus == EnumFormStatus.CLOSE)
                {
                    if (closeTab != null)
                    {
                        closeTab();
                    }
                }
                else
                {
                    _loadData();
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    dxErrorProvider.ClearErrors();
                    _statusAllControl(true);
                    btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = gvGrid.RowCount > 0;
                }
            }
        }

        private void _calTongSoNgay()
        {
            if (deTuNgay.EditValue != null && deDenNgay.EditValue != null)
            {
                TimeSpan diff = deDenNgay.DateTime - deTuNgay.DateTime;
                seTongSoNgay.EditValue = diff.Days + 1;
            }
        }

        private void _calTongTien()
        {
            if(seSoLuongNguoiThamGia.EditValue != null && seSoTienMoiNguoi.EditValue != null)
            {
                seTongTien.EditValue = clsChangeType.change_int64(seSoLuongNguoiThamGia.EditValue) * clsChangeType.change_int64(seSoTienMoiNguoi.EditValue);
            }
        }

        #endregion

        #region Event Grid

        private void gvGrid_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                return;
            }
            if (gvGrid.FocusedRowHandle == GridControl.NewItemRowHandle
            && gvGrid.GetRow(GridControl.NewItemRowHandle) == null)
            {
                return;
            }
            e.Valid = true;
            //if (gvGrid.FocusedColumn.FieldName == colDANGDUNG_TEN.FieldName)
            //{
            //    if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
            //    {
            //        e.ErrorText = colDANGDUNG_TEN.Caption + " không được phép rỗng.";
            //        e.Valid = false;
            //    }
            //    else if (gvGrid._ValidationSame(colDANGDUNG_TEN,e.Value +string.Empty))
            //    {
            //        e.ErrorText = colDANGDUNG_TEN.Caption + " không được trùng.";
            //        e.Valid = false;
            //    }
            //}

        }

        private void gvGrid_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvGrid_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                return;
            }

            e.Valid = true;
            //if (gvGrid.GetRowCellValue(e.RowHandle, colDANGDUNG_TEN.FieldName).ToString().Trim().Length == 0)
            //{
            //    gvGrid.SetColumnError(gvGrid.Columns[colDANGDUNG_TEN.FieldName], colDANGDUNG_TEN.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
            //    e.Valid = false;
            //}
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _loadData();
            FormStatus = EnumFormStatus.VIEW;
        }

        private void gvGrid_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            _loadDataFocusRow();
        }

        private void deTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            _calTongSoNgay();
        }

        private void deDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            _calTongSoNgay();
        }

        private void seSoLuongNguoiThamGia_EditValueChanged(object sender, EventArgs e)
        {
            _calTongTien();
        }

        private void seSoTienMoiNguoi_EditValueChanged(object sender, EventArgs e)
        {
            _calTongTien();
        }
    }
}
