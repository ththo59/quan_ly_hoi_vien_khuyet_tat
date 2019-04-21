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
using static DauThau.Class.FuncCategory;
using DauThau.Reports;
using DauThau.UserControlCategoryMain;
using DauThau.UserControlMain;

namespace DauThau.UserControlCategory
{
    public partial class ucHoatDongASXH : ucBase
    {
        private Int64 _id_loai;
        public ucHoatDongASXH(Int64 id_loai)
        {
            InitializeComponent();
            _id_loai = id_loai;
        }

        List<dynamicObject> _listDMASXH;
        private void ucHoatDongASXH_Load(object sender, EventArgs e)
        {
            registerButtonArray(btnControl);

            deSearchTuNgay.Ex_FormatCustomDateEdit();
            deSearchDenNgay.Ex_FormatCustomDateEdit();
            deTuNgay.Ex_FormatCustomDateEdit();
            deDenNgay.Ex_FormatCustomDateEdit();

 
            seTongSoTien.Ex_FormatCustomSpinEdit();
            seSoLuongNguoiThamGia.Ex_FormatCustomSpinEdit();

            var current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var nextMonth = current.AddMonths(1);
            deSearchTuNgay.DateTime = current;
            deSearchDenNgay.DateTime = nextMonth.AddDays(-1);

            _listDMASXH = FuncCategory.loadDMASXH();
            lueLoaiTapHuan.Properties.DataSource = _listDMASXH;
            lueLoaiTapHuan.EditValue = _id_loai;

            _changeLayout((CategoryASXH)_id_loai);

            FormStatus = EnumFormStatus.VIEW;
        }

        #region Variable

        #endregion

        #region Function

        private void _print()
        {
            rptBCHoatDongASXH rpt = new rptBCHoatDongASXH();
            var data = (from p in context.QL_HOATDONG_ASXH
                        where deSearchTuNgay.DateTime.Date <= p.ASXH_THOIGIAN_BATDAU
                             && p.ASXH_THOIGIAN_BATDAU <= deSearchDenNgay.DateTime.Date
                             && p.ASXH_LOAI_ID == _id_loai
                        select p).ToList();
            List<clsHoatDongASXH> lists = new List<clsHoatDongASXH>();
            foreach (QL_HOATDONG_ASXH row in data)
            {
                clsHoatDongASXH item = new clsHoatDongASXH();
                item.ASXH_TEN = row.ASXH_TEN;
                item.ASXH_THOIGIAN = FunctionHelper.formatFromDateToDate(row.ASXH_THOIGIAN_BATDAU, row.ASXH_THOIGIAN_KETTHUC);
                item.ASXH_DIADIEM = row.ASXH_DIADIEM;
                item.ASXH_DONVI_THUCHIEN = row.ASXH_DONVI_THUCHIEN;
                item.ASXH_SOLUONG = row.ASXH_SOLUONG;
                item.ASXH_TONGSO_TIEN = row.ASXH_TONGSO_TIEN;
                item.ASXH_NOIDUNG = row.ASXH_NOIDUNG;
                item.ASXH_DOITUONG = row.ASXH_DOITUONG_TEN + "; " + row.ASXH_DOITUONG_KHAC;
                lists.Add(item);
            }
            DataTable dataPrint = FunctionHelper.ConvertToDataTable(lists);
            dataPrint.TableName = "HoatDongASXH";

            rpt.pLeftHeader.Value = clsParameter.pHospital;
            rpt.pParentLeftHeader.Value = clsParameter.pParentHospital;
            rpt.pTitle.Value = lueLoaiTapHuan.Text.ToUpper();
            rpt.pTuNgayDenNgay.Value = FunctionHelper.formatFromDateToDate(deSearchTuNgay.DateTime, deSearchDenNgay.DateTime);
            //rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM10);
            //rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM10);

            rpt.DataSource = dataPrint;
            rpt.DataMember = "HoatDongASXH";
            frmPrint f = new frmPrint(rpt);
            f.ShowDialog();
        }

        private void _deleteRow()
        {
            QL_HOATDONG_ASXH item = gvGrid.GetFocusedRow() as QL_HOATDONG_ASXH;
            if (item != null)
            {
                if (clsMessage.MessageYesNo(string.Format("Bạn có chắc muốn xóa: {0}", item.ASXH_TEN)) == DialogResult.Yes)
                {
                    Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colID));
                    QL_HOATDONG_ASXH entities = (from p in context.QL_HOATDONG_ASXH where p.ASXH_ID == id select p).FirstOrDefault();
                    context.QL_HOATDONG_ASXH.Remove(entities);
                    context.SaveChanges();
                    FormStatus = EnumFormStatus.VIEW;
                }

            }

        }

        private void _changeLayout(CategoryASXH enumLoai)
        {
            var dmloai = (from p in _listDMASXH where p.ID == _id_loai select p).FirstOrDefault();
            string title = "";
            if(dmloai != null)
            {
                title = dmloai.NAME;
            }
            switch (enumLoai)
            {
                case CategoryASXH.TANG_DUNG_CU_TRO_GIUP:
                    grpSearchTitle.Text = "Danh sách tặng dụng cụ trợ giúp";
                    return;
                case CategoryASXH.HO_TRO_HOI_VIEN_KHO_KHAN:
                    grpSearchTitle.Text = "Danh sách hỗ trợ học viên khó khăn";
                    return;
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
            txtDoiTuong.ReadOnly = true;
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
            context.QL_HOATDONG_ASXH.Load();
            var data = (from p in context.QL_HOATDONG_ASXH
                        where deSearchTuNgay.DateTime.Date <= p.ASXH_THOIGIAN_BATDAU
                             && p.ASXH_THOIGIAN_BATDAU <= deSearchDenNgay.DateTime.Date
                             && p.ASXH_LOAI_ID == _id_loai
                        select p).ToList();
            gcGrid.DataSource = data;
            _loadDataFocusRow();
            _wait.Close();
        }

        private void _loadDataFocusRow()
        {
            _clearData();
            QL_HOATDONG_ASXH item = gvGrid.GetFocusedRow() as QL_HOATDONG_ASXH;
            if (item != null)
            {
                deTuNgay.EditValue = item.ASXH_THOIGIAN_BATDAU;
                deDenNgay.EditValue = item.ASXH_THOIGIAN_KETTHUC;
                seTongSoNgay.EditValue = item.ASXH_TONGSO_NGAY;
                txtTenChuongTrinh.EditValue = item.ASXH_TEN;
                txtDiaDiem.EditValue = item.ASXH_DIADIEM;
                txtDonViThucHien.EditValue = item.ASXH_DONVI_THUCHIEN;

                seSoLuongNguoiThamGia.EditValue = item.ASXH_SOLUONG;
                seTongSoTien.EditValue = item.ASXH_TONGSO_TIEN;

                txtDoiTuong.EditValue = item.ASXH_DOITUONG_TEN;
                txtDoiTuongId.EditValue = item.ASXH_DOITUONG_ID;
                txtDoiTuongKhac.EditValue = item.ASXH_DOITUONG_KHAC;

                txtNoiDung.EditValue = item.ASXH_NOIDUNG;
            }
        }

        private void _setObjectEntities(ref QL_HOATDONG_ASXH item)
        {
            item.ASXH_LOAI_ID = _id_loai;
            item.ASXH_THOIGIAN_BATDAU = deTuNgay.Ex_EditValueToDateTime();
            item.ASXH_THOIGIAN_KETTHUC = deDenNgay.Ex_EditValueToDateTime();
            item.ASXH_TONGSO_NGAY = seTongSoNgay.Ex_EditValueToInt();
            item.ASXH_TONGSO_TIEN = seTongSoTien.Ex_EditValueToInt();

            item.ASXH_TEN = txtTenChuongTrinh.Text ;
            item.ASXH_DIADIEM = txtDiaDiem.Text;
            item.ASXH_DONVI_THUCHIEN = txtDonViThucHien.Text;
            item.ASXH_SOLUONG = seSoLuongNguoiThamGia.Ex_EditValueToInt();
            item.ASXH_DOITUONG_TEN = txtDoiTuong.Text;
            item.ASXH_DOITUONG_ID = txtDoiTuongId.Text;
            item.ASXH_DOITUONG_KHAC = txtDoiTuongKhac.Text;

            item.ASXH_NOIDUNG = txtNoiDung.Text;
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
                    QL_HOATDONG_ASXH item;
                    switch (_formStatus)
                    {
                        case EnumFormStatus.ADD:

                            #region Add

                            item = new QL_HOATDONG_ASXH();
                            _setObjectEntities(ref item);
                            _context.QL_HOATDONG_ASXH.Add(item);

                            #endregion

                            break;
                        case EnumFormStatus.MODIFY:
                            Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colID));
                            item = (from p in _context.QL_HOATDONG_ASXH where p.ASXH_ID == id select p).FirstOrDefault<QL_HOATDONG_ASXH>();
                            if (item != null)
                            {
                                _setObjectEntities(ref item);
                            }
                            var entity = _context.QL_HOATDONG_ASXH.Find(id);
                            if (entity != null)
                            {
                                _context.Entry(entity).CurrentValues.SetValues(item);
                            }
                            
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

        private void btnSelectHoiVien_Click(object sender, EventArgs e)
        {
            frmSelectHoiVien frm = new frmSelectHoiVien();
            frm.selectNameList = txtDoiTuong.Text;
            frm.selectIdList = txtDoiTuongId.Text;
            frm.ShowDialog();

            txtDoiTuong.Text = frm.selectNameList;
            txtDoiTuongId.Text = frm.selectIdList;
        }
    }
}
