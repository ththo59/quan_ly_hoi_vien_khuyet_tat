﻿using System;
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
using static DauThau.Class.FuncCategory;
using DauThau.Reports;
using DauThau.UserControlCategoryMain;
using DauThau.UserControlMain;
using DauThau.Forms;

namespace DauThau.UserControlCategory
{
    public partial class ucHoatDongViecLam : ucBase
    {
        private Int64 _id_loai;
        public ucHoatDongViecLam(Int64 id_loai)
        {
            InitializeComponent();
            _id_loai = id_loai;
        }

        List<dynamicObject> _listDM;
        public BindingList<QL_HOATDONG_VIECLAM_DOITUONG_KHAC> listDoiTuongKhongKhuyetTat = new BindingList<QL_HOATDONG_VIECLAM_DOITUONG_KHAC>();

        private void ucHoatDongViecLam_Load(object sender, EventArgs e)
        {
            registerButtonArray(btnControl);

            deSearchTuNgay.Ex_FormatCustomDateEdit();
            deSearchDenNgay.Ex_FormatCustomDateEdit();
            deTuNgay.Ex_FormatCustomDateEdit();
            deDenNgay.Ex_FormatCustomDateEdit();

 
            seThuNhapThang.Ex_FormatCustomSpinEdit();
            seSoLuongNguoiThamGia.Ex_FormatCustomSpinEdit();

            var current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var nextMonth = current.AddMonths(1);
            deSearchTuNgay.DateTime = current;
            deSearchDenNgay.DateTime = nextMonth.AddDays(-1);

            _listDM = FuncCategory.loadDMViecLam();
            lueLoaiTapHuan.Properties.DataSource = _listDM;
            lueLoaiTapHuan.EditValue = _id_loai;

            _changeLayout((CategoryViecLam)_id_loai);

            FormStatus = EnumFormStatus.VIEW;
        }

        #region Variable

        #endregion

        #region Function

        private void _print()
        {
            rptBCHoatDongViecLam rpt = new rptBCHoatDongViecLam();
            var data = (from p in context.QL_HOATDONG_VIECLAM
                        where deSearchTuNgay.DateTime.Date <= p.VL_THOIGIAN_BATDAU
                             && p.VL_THOIGIAN_BATDAU <= deSearchDenNgay.DateTime.Date
                             && p.VL_LOAI_ID == _id_loai
                        select p).ToList();
            List<clsHoatDongViecLam> lists = new List<clsHoatDongViecLam>();
            foreach (QL_HOATDONG_VIECLAM row in data)
            {
                clsHoatDongViecLam item = new clsHoatDongViecLam();
                item.VL_TEN = row.VL_TEN;
                item.VL_THOIGIAN = FunctionHelper.formatFromDateToDate(row.VL_THOIGIAN_BATDAU, row.VL_THOIGIAN_KETTHUC);
                item.VL_DIADIEM = row.VL_DIADIEM;
                item.VL_DONVI_GIOITHIEU = row.VL_DONVI_GIOITHIEU;
                item.VL_NU_TONGSO = string.Format("{0}/{1}", row.VL_SOLUONG_NU, row.VL_SOLUONG);
                item.VL_THUNHAP_THANG = row.VL_THUNHAP_THANG;
                item.VL_NOIDUNG = row.VL_NOIDUNG;
                item.VL_NOIDUNG = row.VL_NOIDUNG;
                item.VL_DOITUONG = row.VL_DOITUONG_TEN + "; " + row.VL_DOITUONG_KHAC;
                lists.Add(item);
            }
            DataTable dataPrint = FunctionHelper.ConvertToDataTable(lists);
            dataPrint.TableName = "HoatDongViecLam";

            rpt.pLeftHeader.Value = clsParameter.pHospital;
            rpt.pParentLeftHeader.Value = clsParameter.pParentHospital;
            rpt.pTitle.Value = lueLoaiTapHuan.Text.ToUpper();
            rpt.pTuNgayDenNgay.Value = FunctionHelper.formatFromDateToDate(deSearchTuNgay.DateTime, deSearchDenNgay.DateTime);
            //rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM10);
            //rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM10);

            rpt.DataSource = dataPrint;
            rpt.DataMember = "HoatDongViecLam";
            frmPrint f = new frmPrint(rpt);
            f.ShowDialog();
        }

        private void _deleteRow()
        {
            QL_HOATDONG_VIECLAM item = gvGrid.GetFocusedRow() as QL_HOATDONG_VIECLAM;
            if (item != null)
            {
                if (clsMessage.MessageYesNo(string.Format("Bạn có chắc muốn xóa: {0}", item.VL_TEN)) == DialogResult.Yes)
                {
                    Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colID));
                    var listChiTiet = (from p in context.QL_HOATDONG_VIECLAM_DOITUONG_KHAC where p.PARENT_ID == id select p);
                    foreach (var item_delete in listChiTiet)
                    {
                        context.QL_HOATDONG_VIECLAM_DOITUONG_KHAC.Remove(item_delete);
                    }

                    QL_HOATDONG_VIECLAM entities = (from p in context.QL_HOATDONG_VIECLAM where p.VL_ID == id select p).FirstOrDefault();
                    context.QL_HOATDONG_VIECLAM.Remove(entities);
                    context.SaveChanges();
                    FormStatus = EnumFormStatus.VIEW;
                }

            }
        }

        private void _changeLayout(CategoryViecLam enumLoai)
        {
            var dmloai = (from p in _listDM where p.ID == _id_loai select p).FirstOrDefault();
            string title = "";
            if(dmloai != null)
            {
                title = dmloai.NAME;
            }
            switch (enumLoai)
            {
                default:
                    break;
            }

            grpSearchTitle.Text = "Danh sách " + title.ToLower();
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
            seTongSoThang.ReadOnly = true;
            memoDoiTuong.ReadOnly = true;
            memoDoiTuongKhac.ReadOnly = true;
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
            context.QL_HOATDONG_VIECLAM.Load();
            var data = (from p in context.QL_HOATDONG_VIECLAM
                        where deSearchTuNgay.DateTime.Date <= p.VL_THOIGIAN_BATDAU
                             && p.VL_THOIGIAN_BATDAU <= deSearchDenNgay.DateTime.Date
                             && p.VL_LOAI_ID == _id_loai
                        select p).ToList();
            gcGrid.DataSource = data;

            _setFocusedRow(gvGrid, colID);
            _bindingData();
            _wait.Close();
        }

        private void _bindingData()
        {
            _clearData();
            QL_HOATDONG_VIECLAM item = gvGrid.GetFocusedRow() as QL_HOATDONG_VIECLAM;
            if (item != null)
            {
                _idRowSelected = item.VL_ID;

                deTuNgay.EditValue = item.VL_THOIGIAN_BATDAU;
                deDenNgay.EditValue = item.VL_THOIGIAN_KETTHUC;
                seTongSoNgay.EditValue = item.VL_TONGSO_NGAY;
                txtTenChuongTrinh.EditValue = item.VL_TEN;
                txtDiaDiem.EditValue = item.VL_DIADIEM;
                txtDonViThucHien.EditValue = item.VL_DONVI_GIOITHIEU;

                seSoLuongNguoiThamGia.EditValue = item.VL_SOLUONG;
                seSoLuongNu.EditValue = item.VL_SOLUONG_NU;
                seThuNhapThang.EditValue = item.VL_THUNHAP_THANG;

                memoDoiTuong.EditValue = item.VL_DOITUONG_TEN;
                memoDoiTuongId.EditValue = item.VL_DOITUONG_ID;
                memoDoiTuongKhac.EditValue = item.VL_DOITUONG_KHAC;

                _setMemoText(item);

                txtNoiDung.EditValue = item.VL_NOIDUNG;
            }
        }

        private void _setObjectEntities(ref QL_HOATDONG_VIECLAM item)
        {
            item.VL_LOAI_ID = _id_loai;
            item.VL_THOIGIAN_BATDAU = deTuNgay.Ex_EditValueToDateTime();
            item.VL_THOIGIAN_KETTHUC = deDenNgay.Ex_EditValueToDateTime();
            item.VL_TONGSO_NGAY = seTongSoNgay.Ex_EditValueToInt();
            item.VL_THUNHAP_THANG = seThuNhapThang.Ex_EditValueToInt();

            item.VL_TEN = txtTenChuongTrinh.Text ;
            item.VL_DIADIEM = txtDiaDiem.Text;
            item.VL_DONVI_GIOITHIEU = txtDonViThucHien.Text;

            item.VL_SOLUONG = seSoLuongNguoiThamGia.Ex_EditValueToInt();
            item.VL_SOLUONG_NU = seSoLuongNu.Ex_EditValueToInt();

            item.VL_DOITUONG_TEN = memoDoiTuong.Text;
            item.VL_DOITUONG_ID = memoDoiTuongId.Text;
            item.VL_DOITUONG_KHAC = memoDoiTuongKhac.Text;

            item.VL_NOIDUNG = txtNoiDung.Text;
        }

        private Boolean _validateControl()
        {
            dxErrorProvider.ClearErrors();

            if (txtTenChuongTrinh.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenChuongTrinh, "Vui lòng nhập thông tin");
            }

            if (clsChangeType.change_int(seTongSoNgay.EditValue)  <= 0)
            {
                dxErrorProvider.SetError(deDenNgay, "Từ ngày và đến ngày không phù hợp");
            }

            if (clsChangeType.change_int64(seSoLuongNguoiThamGia.EditValue) == 0)
            {
                dxErrorProvider.SetError(seSoLuongNguoiThamGia, "Vui lòng nhập thông tin");
            }

            if (clsChangeType.change_int64(seSoLuongNguoiThamGia.EditValue) < clsChangeType.change_int64(seSoLuongNu.EditValue))
            {
                dxErrorProvider.SetError(seSoLuongNu, "Số lượng nữ không phù hợp.");
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
                    QL_HOATDONG_VIECLAM item = new QL_HOATDONG_VIECLAM();
                    switch (_formStatus)
                    {
                        case EnumFormStatus.ADD:

                            #region Add

                            item = new QL_HOATDONG_VIECLAM();
                            _setObjectEntities(ref item);
                            _updateMemoData(_context, item);
                            _context.QL_HOATDONG_VIECLAM.Add(item);

                            #endregion

                            break;
                        case EnumFormStatus.MODIFY:
                            Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colID));
                            item = (from p in _context.QL_HOATDONG_VIECLAM where p.VL_ID == id select p).FirstOrDefault<QL_HOATDONG_VIECLAM>();
                            if (item != null)
                            {
                                _setObjectEntities(ref item);
                            }
                            var entity = _context.QL_HOATDONG_VIECLAM.Find(id);
                            if (entity != null)
                            {
                                _context.Entry(entity).CurrentValues.SetValues(item);
                            }
                            _updateMemoData(_context, item);
                            break;
                        default:
                            break;
                    }
                    _context.SaveChanges();

                    _idRowSelected = item.VL_ID;
                }
                FormStatus = EnumFormStatus.VIEW;
            }

            return base.SaveData();
        }

        #endregion

        #region Status

        protected override EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.ADD)
                {
                    _clearData();
                    _initMemoData();
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
                    _print();
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
                    btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = btnControl.btnPrint.Enabled = gvGrid.RowCount > 0;
                    base.permissionAccessButton(btnControl, (Int32)FunctionName.FUNC_VIECLAM);
                }
            }
        }

        private void _calTongSoNgay()
        {
            if (deTuNgay.EditValue != null && deDenNgay.EditValue != null)
            {
                TimeSpan diff = deDenNgay.DateTime - deTuNgay.DateTime;
                int soNgay = diff.Days + 1;
                int months = soNgay / 29;
                seTongSoNgay.EditValue = soNgay;
                seTongSoThang.EditValue = months;
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
            _idRowSelected = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colID));
            _bindingData();
        }

        private void deTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            _calTongSoNgay();
        }

        private void deDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            _calTongSoNgay();
        }

        private void btnSelectHoiVien_Click(object sender, EventArgs e)
        {
            frmSelectHoiVien frm = new frmSelectHoiVien();
            frm.selectNameList = memoDoiTuong.Text;
            frm.selectIdList = memoDoiTuongId.Text;
            frm.ShowDialog();

            memoDoiTuong.Text = frm.selectNameList;
            memoDoiTuongId.Text = frm.selectIdList;
            _updateStatusDoiTuong();
        }

        #region Đối tượng khác

        private void _updateStatusDoiTuong()
        {
            string[] idStringList = memoDoiTuongId.Text.Split(new[] { "; " }, StringSplitOptions.None);
            List<Int64> idList = new List<long>();
            foreach (var id in idStringList)
            {
                Int64 idConvert = clsChangeType.change_int64(id);
                if (idConvert > 0)
                {
                    idList.Add(idConvert);
                }
            }

            var hoivienList = context.QL_HOIVIEN.Where(p => idList.Contains(p.HV_ID)).OrderBy(p => p.HV_TEN).ToList();
            int count_hoiVien = hoivienList != null ? hoivienList.Count : 0;

            int count_Nam = 0;
            int count_Nu = 0;

            foreach (var item in hoivienList)
            {
                count_Nam += item.HV_GIOI_TINH == "Nam" ? 1 : 0;
                count_Nu += item.HV_GIOI_TINH == "Nữ" ? 1 : 0;
            }

            //Người không khuyết tật
            foreach (var item in listDoiTuongKhongKhuyetTat.Where(p => p.PARENT_ID != clsParameter.statusDeleted).ToList())
            {
                count_Nam += item.DTK_GIOITINH == "Nam" ? 1 : 0;
                count_Nu += item.DTK_GIOITINH == "Nữ" ? 1 : 0;
            }
            seSoLuongNguoiThamGia.EditValue = count_Nam + count_Nu;
            seSoLuongNu.EditValue = count_Nu;
        }

        private void _setMemoText(QL_HOATDONG_VIECLAM item)
        {
            var query = item.QL_HOATDONG_VIECLAM_DOITUONG_KHAC.ToList();

            listDoiTuongKhongKhuyetTat = new BindingList<QL_HOATDONG_VIECLAM_DOITUONG_KHAC>(query);
            memoDoiTuongKhac.Text = _getMemoText(listDoiTuongKhongKhuyetTat);
        }

        private string _getMemoText(BindingList<QL_HOATDONG_VIECLAM_DOITUONG_KHAC> data)
        {
            StringBuilder title = new StringBuilder();
            foreach (var item in data.Where(p => p.PARENT_ID != clsParameter.statusDeleted))
            {
                if (item.DTK_DIACHI != "")
                {
                    title.AppendFormat("{0}({1}); ", item.DTK_HO + " " + item.DTK_TEN, item.DTK_DIACHI);
                }
                else if (item.DTK_DONVI_TEN != "")
                {
                    title.AppendFormat("{0}({1}); ", item.DTK_HO + " " + item.DTK_TEN, item.DTK_DONVI_TEN);
                }
                else
                {
                    title.AppendFormat("{0}; ", item.DTK_HO + " " + item.DTK_TEN);
                }

            }
            return title.ToString();
        }

        private void _initMemoData()
        {
            listDoiTuongKhongKhuyetTat = new BindingList<QL_HOATDONG_VIECLAM_DOITUONG_KHAC>();
        }

        private void _updateMemoData(QL_HOIVIEN_KTEntities _context, QL_HOATDONG_VIECLAM item)
        {
            QL_HOATDONG_VIECLAM_DOITUONG_KHAC item_chitiet;
            foreach (var person in listDoiTuongKhongKhuyetTat)
            {
                if (person.PARENT_ID == null) //add
                {
                    person.QL_HOATDONG_VIECLAM = item;
                    _context.QL_HOATDONG_VIECLAM_DOITUONG_KHAC.Add(person);
                }
                else if (person.PARENT_ID == clsParameter.statusDeleted) //delete
                {
                    item_chitiet = (from p in _context.QL_HOATDONG_VIECLAM_DOITUONG_KHAC
                                    where p.DTK_ID == person.DTK_ID
                                    select p).FirstOrDefault();
                    if (item_chitiet != null)
                    {
                        _context.QL_HOATDONG_VIECLAM_DOITUONG_KHAC.Remove(item_chitiet);
                    }
                }
                else //modify
                {
                    var chitiet = _context.QL_HOATDONG_VIECLAM_DOITUONG_KHAC.Where(p => p.DTK_ID == person.DTK_ID).FirstOrDefault();
                    if (chitiet != null)
                    {
                        _context.Entry(chitiet).CurrentValues.SetValues(person);
                    }
                }
            }
        }

        private void btnDoiTuongKhongKT_Click(object sender, EventArgs e)
        {
            frmHoatDongViecLamDoiTuongKhac frm = new frmHoatDongViecLamDoiTuongKhac();
            frm.data = listDoiTuongKhongKhuyetTat;
            frm.ShowDialog();

            listDoiTuongKhongKhuyetTat = frm.data;
            memoDoiTuongKhac.Text = _getMemoText(listDoiTuongKhongKhuyetTat);
            _updateStatusDoiTuong();
        }

        #endregion
    }
}
