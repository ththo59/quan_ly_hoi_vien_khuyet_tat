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
using DauThau.Reports;
using DauThau.UserControlCategoryMain;
using DauThau.UserControlMain;

namespace DauThau.Forms
{
    public partial class frmTapHuanChiTiet : Form
    {
        public frmTapHuanChiTiet()
        {
            InitializeComponent();
        }

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        private QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
        private BindingList<DM_NHA_TAI_TRO_CHITIET> listNguoiDungDau;
        private BindingList<DM_NHA_TAI_TRO_CHITIET> listNguoiQuanLy;

        private string constLoaiNguoiDungDau = "nguoi_dung_dau";
        private string constLoaiNguoiQuanLy = "nguoi_quan_ly";

        private void frmNhaTaiTro_Load(object sender, EventArgs e)
        {
            lueCaNhanToChuc.Properties.DataSource = FuncCategory.loadDMCaNhanToChuc();
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_NHA_TAI_TRO_LOAI, lueLoaiNhaTaiTro);
            FormStatus = EnumFormStatus.VIEW;
        }

        #region function

        void _selectData()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            context = new QL_HOIVIEN_KTEntities();
            context.DM_NHA_TAI_TRO.Load();
            gcGrid.DataSource = context.DM_NHA_TAI_TRO.Local.ToBindingList();
            _loadDataRow();
            _wait.Close();
        }

        void _loadDataRow()
        {
            Int64 id = clsChangeType.change_int64(gvGrid.GetFocusedRowCellValue(colTH_CT_ID));
            _loadDataById(id);
        }

        void _closeForm()
        {
            this.Close();
        }

        void _loadDataById(Int64 id)
        {
            context.DM_NHA_TAI_TRO.Load();
            var query_nhatt = (from p in context.DM_NHA_TAI_TRO where p.NTT_ID == id select p).FirstOrDefault();
            if(query_nhatt != null)
            {
                txtTenToChuc.Text = query_nhatt.NTT_TEN;
                txtDiaChi.Text = query_nhatt.NTT_DIACHI;
                lueLoaiNhaTaiTro.EditValue = query_nhatt.NTT_LOAI;
                lueCaNhanToChuc.EditValue = query_nhatt.NTT_CANHAN_TOCHUC;
            }

            context.DM_NHA_TAI_TRO_CHITIET.Load();
            var queryNguoiDungDau = (from p in context.DM_NHA_TAI_TRO_CHITIET where p.NTT_ID == id && p.NTT_CT_LOAI == constLoaiNguoiDungDau select p).ToList();
            listNguoiDungDau = new BindingList<DM_NHA_TAI_TRO_CHITIET>(queryNguoiDungDau);
            gcGrid_NguoiDungDau.DataSource = listNguoiDungDau;

            var queryNguoiQuanLy = (from p in context.DM_NHA_TAI_TRO_CHITIET where p.NTT_ID == id && p.NTT_CT_LOAI == constLoaiNguoiQuanLy select p).ToList();
            listNguoiQuanLy = new BindingList<DM_NHA_TAI_TRO_CHITIET>(queryNguoiQuanLy);
            gcGrid_NguoiQL.DataSource = listNguoiQuanLy;
        }

        private Boolean _validateControl()
        {

            if (txtTenToChuc.Text.Trim() == string.Empty)
            {
                clsMessage.MessageWarning("Vui lòng nhập đầy tên tổ chức");
                return false;
            }
            return true;
        }

        private void _setObjectEntities(ref DM_NHA_TAI_TRO item)
        {
            item.NTT_TEN = txtTenToChuc.Text;
            item.NTT_DIACHI = txtDiaChi.Text;
            item.NTT_CANHAN_TOCHUC = lueCaNhanToChuc.Text;
            item.NTT_LOAI = lueLoaiNhaTaiTro.Text;
        }

        void clearData()
        {
            txtTenToChuc.EditValue = txtDiaChi.EditValue = lueCaNhanToChuc.EditValue = lueLoaiNhaTaiTro.EditValue = null;
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
            gcGrid.Enabled = readOnly;
        }

        void _deleteData()
        {
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colTH_CT_HOTEN.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa: \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _saveData();
                FormStatus = EnumFormStatus.VIEW;
            }
        }

        private void _saveData()
        {
            if (_validateControl())
            {
                WaitDialogForm _wait = new WaitDialogForm("Đang lưu dữ liệu ...", "Vui lòng đợi giây lát");
                using (var _context = new QL_HOIVIEN_KTEntities())
                {
                    DM_NHA_TAI_TRO item;
                    switch (_formStatus)
                    {
                        case EnumFormStatus.ADD:

                            item = new DM_NHA_TAI_TRO();
                            _setObjectEntities(ref item);
                            _context.DM_NHA_TAI_TRO.Add(item);
                            
                            foreach (DM_NHA_TAI_TRO_CHITIET person in listNguoiDungDau)
                            {
                                person.DM_NHA_TAI_TRO = item;
                                _context.DM_NHA_TAI_TRO_CHITIET.Add(person);
                            }
                            foreach (DM_NHA_TAI_TRO_CHITIET person in listNguoiQuanLy)
                            {
                                person.DM_NHA_TAI_TRO = item;
                                _context.DM_NHA_TAI_TRO_CHITIET.Add(person);
                            }
                            break;

                        case EnumFormStatus.MODIFY:
                            Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colTH_CT_ID));
                            item = (from p in _context.DM_NHA_TAI_TRO where p.NTT_ID == id select p).FirstOrDefault();
                            if (item != null)
                            {
                                _setObjectEntities(ref item);
                            }
                            var entity = _context.DM_NHA_TAI_TRO.Find(id);
                            _context.Entry(entity).CurrentValues.SetValues(item);

                            gvGrid_NguoiDungDau.PostEditor();
                            gvGrid_NguoiDungDau.UpdateCurrentRow();

                            gvGrid_NguoiQL.PostEditor();
                            gvGrid_NguoiQL.UpdateCurrentRow();

                            //add row
                            foreach (DM_NHA_TAI_TRO_CHITIET person in listNguoiDungDau)
                            {
                                if(person.NTT_CT_ID == 0)
                                {
                                    person.DM_NHA_TAI_TRO = item;
                                    _context.DM_NHA_TAI_TRO_CHITIET.Add(person);
                                }
                            }
                            foreach (DM_NHA_TAI_TRO_CHITIET person in listNguoiQuanLy)
                            {
                                if (person.NTT_CT_ID == 0)
                                {
                                    person.DM_NHA_TAI_TRO = item;
                                    _context.DM_NHA_TAI_TRO_CHITIET.Add(person);
                                }
                            }

                            context.SaveChanges();
                            break;

                        case EnumFormStatus.DELETE:
                            Int64 deleteId = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colTH_CT_ID));
                            var entitiesNhaTaiTro = (from p in _context.DM_NHA_TAI_TRO where p.NTT_ID == deleteId select p).FirstOrDefault();
                            if (entitiesNhaTaiTro != null) { 
                                _context.DM_NHA_TAI_TRO.Remove(entitiesNhaTaiTro);
                            }

                            var entities = (from p in _context.DM_NHA_TAI_TRO_CHITIET where p.NTT_ID == deleteId select p);
                            foreach (var item_delete in entities)
                            {
                                _context.DM_NHA_TAI_TRO_CHITIET.Remove(item_delete);
                            }

                            break;
                        default:
                            break;
                    }
                    _context.SaveChanges();
                }
                FormStatus = EnumFormStatus.VIEW;
                _wait.Close();
            }
        }

        #endregion

        #region Event Button

        private void btnControl_btnEventAdd_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.ADD;
        }

        private void btnControl_btnEventCancel_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.VIEW;
        }

        private void btnControl_btnEventClose_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.CLOSE;
        }

        private void btnControl_btnEventDelete_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.DELETE;
        }

        private void btnControl_btnEventModify_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.MODIFY;
        }

        private void btnControl_btnEventSave_Click(object sender, EventArgs e)
        {
            _saveData();
        }

        #endregion

        #region Status

        public EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.ADD)
                {
                    gvGrid_NguoiQL.OptionsBehavior.Editable = true;
                    gvGrid_NguoiQL.OptionsView.ShowAutoFilterRow = false;
                    gvGrid_NguoiQL.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvGrid_NguoiQL.ActiveFilter.Clear();

                    gvGrid_NguoiDungDau.OptionsBehavior.Editable = true;
                    gvGrid_NguoiDungDau.OptionsView.ShowAutoFilterRow = false;
                    gvGrid_NguoiDungDau.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvGrid_NguoiDungDau.ActiveFilter.Clear();

                    _statusAllControl(false);
                    clearData();
                    _loadDataById(0);
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    gvGrid_NguoiQL.OptionsBehavior.Editable = true;
                    gvGrid_NguoiQL.OptionsView.ShowAutoFilterRow = false;
                    gvGrid_NguoiQL.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvGrid_NguoiQL.ActiveFilter.Clear();

                    gvGrid_NguoiDungDau.OptionsBehavior.Editable = true;
                    gvGrid_NguoiDungDau.OptionsView.ShowAutoFilterRow = false;
                    gvGrid_NguoiDungDau.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvGrid_NguoiDungDau.ActiveFilter.Clear();
                    _statusAllControl(false);
                }
                else if (_formStatus == EnumFormStatus.DELETE)
                {
                    _deleteData();
                }
                else if (_formStatus == EnumFormStatus.CLOSE)
                {
                    _closeForm();
                }
                else
                {
                    _selectData();
                    _statusAllControl(true);

                    gvGrid_NguoiQL.OptionsBehavior.Editable = false;
                    gvGrid_NguoiQL.OptionsView.ShowAutoFilterRow = true;
                    gvGrid_NguoiQL.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

                    gvGrid_NguoiDungDau.OptionsBehavior.Editable = false;
                    gvGrid_NguoiDungDau.OptionsView.ShowAutoFilterRow = true;
                    gvGrid_NguoiDungDau.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = gvGrid.RowCount > 0;

                }
            }
        }

        #endregion

        #region event Grid

        private void gvGrid_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            _loadDataRow();
        }

        #endregion

        private void gvGrid_NguoiDungDau_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvGrid_NguoiDungDau.SetFocusedRowCellValue(colNTT_CT_LOAI, constLoaiNguoiDungDau);
            if(_formStatus == EnumFormStatus.MODIFY)
            {
                Int64 id = clsChangeType.change_int64(gvGrid.GetFocusedRowCellValue(colTH_CT_ID));
                gvGrid_NguoiDungDau.SetFocusedRowCellValue(colNguoiDungDau_NTT_ID, id);
            }
        }

        private void gvGrid_NguoiDungDau_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            
        }

        private void gvGrid_NguoiQL_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            
        }

        private void gvGrid_NguoiQL_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvGrid_NguoiQL.SetFocusedRowCellValue(colQL_NTT_CT_LOAI, constLoaiNguoiQuanLy);
            if (_formStatus == EnumFormStatus.MODIFY)
            {
                Int64 id = clsChangeType.change_int64(gvGrid.GetFocusedRowCellValue(colTH_CT_ID));
                gvGrid_NguoiQL.SetFocusedRowCellValue(colQL_NTT_ID, id);
            }
        }
    }
}
