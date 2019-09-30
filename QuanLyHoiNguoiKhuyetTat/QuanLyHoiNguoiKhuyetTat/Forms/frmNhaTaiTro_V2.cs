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
    public partial class frmNhaTaiTro_V2 : Form
    {
        public frmNhaTaiTro_V2(int loaiHoatDongId)
        {
            InitializeComponent();
            _loaiHoatDongId = loaiHoatDongId;
        }

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        private QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();

        public BindingList<QL_HOATDONG_NHATAITRO> data;
        private Int64 idRowSelected;
        private Int64 _loaiHoatDongId;

        private void frmNhaTaiTro_V2_Load(object sender, EventArgs e)
        {
            lueCaNhanToChuc.Properties.DataSource = FuncCategory.loadDMCaNhanToChuc();
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_NHA_TAI_TRO_LOAI, lueLoaiNhaTaiTro);
            seSoTien.Ex_FormatCustomSpinEdit();

            FormStatus = EnumFormStatus.VIEW;
        }

        #region function

        List<QL_HOATDONG_NHATAITRO> _getData()
        {
            CategoryHoatDong enumLoai = (CategoryHoatDong)_loaiHoatDongId;
            var query = new List<QL_HOATDONG_NHATAITRO>();

            switch (enumLoai)
            {
                case CategoryHoatDong.ASXH:
                    query = data.Where(p => p.ASXH_ID != clsParameter.statusDeleted).ToList();
                    break;
                case CategoryHoatDong.HNXH:
                    query = data.Where(p => p.HNXH_ID != clsParameter.statusDeleted).ToList();
                    break;
                case CategoryHoatDong.KHAC:
                    query = data.Where(p => p.KHAC_ID != clsParameter.statusDeleted).ToList();
                    break;
                default:
                    break;
            }
            return query;
        }

        void _selectData()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            CategoryHoatDong enumLoai = (CategoryHoatDong)_loaiHoatDongId;
            switch (enumLoai)
            {
                case CategoryHoatDong.ASXH:
                    gcGrid.DataSource = data.Where(p => p.ASXH_ID != clsParameter.statusDeleted);
                    break;
                case CategoryHoatDong.HNXH:
                    gcGrid.DataSource = data.Where(p => p.HNXH_ID != clsParameter.statusDeleted);
                    break;
                case CategoryHoatDong.KHAC:
                    gcGrid.DataSource = data.Where(p => p.KHAC_ID != clsParameter.statusDeleted);
                    break;
                default:
                    break;
            }
            
            _setFocusedRow();
            _bindingData();
            _wait.Close();
        }

        private void _setFocusedRow()
        {
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                Int64 id = Convert.ToInt64(gvGrid.GetRowCellValue(i, colNTT_ID));
                if (id == idRowSelected)
                {
                    gvGrid.FocusedRowHandle = i;
                    break;
                }
            }
        }
        

        void _closeForm()
        {
            this.Close();
        }

        private Boolean _validateControl()
        {
            dxErrorProvider1.ClearErrors();
            if (txtTenToChuc.Text.Trim() == string.Empty)
            {
                dxErrorProvider1.SetError(txtTenToChuc, "Dữ liệu không được rỗng");
            }
            if (lueCaNhanToChuc.Text.Trim() == string.Empty)
            {
                dxErrorProvider1.SetError(lueCaNhanToChuc, "Dữ liệu không được rỗng");
            }
            if (dxErrorProvider1.HasErrors)
            {
                clsMessage.MessageWarning("Vui lòng nhập đầy đủ thông tin");
                return false;
            }

            return true;
        }

        void _bindingData()
        {
            _clearData();
            QL_HOATDONG_NHATAITRO item = gvGrid.GetFocusedRow() as QL_HOATDONG_NHATAITRO;
            if (item != null)
            {
                txtTenToChuc.Text = item.NTT_TEN;
                lueCaNhanToChuc.EditValue = item.NTT_CANHAN_TOCHUC;
                txtDiaChi.Text = item.NTT_DIACHI;
                lueLoaiNhaTaiTro.EditValue = item.NTT_LOAI;
                seSoTien.EditValue = item.NTT_SOTIEN;
                memoGhiChu.Text = item.NTT_GHICHU;

                //Người đại diện
                txtNTT_NDD_HOTEN.Text = item.NTT_NDD_HOTEN;
                txtNTT_NDD_CHUCVU.Text = item.NTT_NDD_CHUCVU;
                txtNTT_NDD_EMAIL.Text = item.NTT_NDD_EMAIL;
                txtNTT_NDD_SDT.Text = item.NTT_NDD_SDT;
            }

        }
        private void _setObjectEntities(ref QL_HOATDONG_NHATAITRO item)
        {
            item.NTT_TEN = txtTenToChuc.Text;
            item.NTT_CANHAN_TOCHUC = lueCaNhanToChuc.Text;
            item.NTT_DIACHI = txtDiaChi.Text;
            item.NTT_LOAI = lueLoaiNhaTaiTro.EditValue + string.Empty;
            item.NTT_SOTIEN = seSoTien.Ex_EditValueToInt() ;
            item.NTT_GHICHU = memoGhiChu.Text;

            //Người đại diện
            item.NTT_NDD_HOTEN = txtNTT_NDD_HOTEN.Text;
            item.NTT_NDD_CHUCVU = txtNTT_NDD_CHUCVU.Text ;
            item.NTT_NDD_EMAIL = txtNTT_NDD_EMAIL.Text ;
            item.NTT_NDD_SDT = txtNTT_NDD_SDT.Text;
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

            string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colNTT_TEN.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa: \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _saveData();
                FormStatus = EnumFormStatus.VIEW;
            }
        }

        private Int64 _maxID()
        {
            List<Int64> listID = new List<Int64>();
            Int64 max_DTK_ID = 1;
            if (data.Count > 0)
            {
                var query = _getData();
                foreach (var row in query)
                {
                    listID.Add(row.NTT_ID);
                }
                max_DTK_ID = listID.Max() + 1;
            }
            return max_DTK_ID;
        }

        private void _saveData()
        {
            if (_validateControl())
            {
                WaitDialogForm _wait = new WaitDialogForm("Đang lưu dữ liệu ...", "Vui lòng đợi giây lát");
                using (var _context = new QL_HOIVIEN_KTEntities())
                {
                    QL_HOATDONG_NHATAITRO item;
                    switch (_formStatus)
                    {
                        case EnumFormStatus.ADD:

                            item = new QL_HOATDONG_NHATAITRO();
                            _setObjectEntities(ref item);
                            idRowSelected = _maxID();
                            item.NTT_ID = idRowSelected;
                            data.Add(item);

                            break;

                        case EnumFormStatus.MODIFY:
                            Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colNTT_ID));
                            item = (from p in data where p.NTT_ID == id select p).FirstOrDefault();
                            if (item != null)
                            {
                                _setObjectEntities(ref item);
                            }

                            data.Where(p => p.NTT_ID == id).ToList().ForEach(p => p = item);
                            break;

                        case EnumFormStatus.DELETE:
                            Int64 deleteId = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colNTT_ID));
                            item = (from p in data where p.NTT_ID == deleteId select p).FirstOrDefault();
                            CategoryHoatDong enumLoai = (CategoryHoatDong)_loaiHoatDongId;
                            switch (enumLoai)
                            {
                                case CategoryHoatDong.ASXH:
                                    if (item != null)
                                    {
                                        if (item.ASXH_ID == null)
                                        {//Nếu là dòng mới thì xóa luôn
                                            data.Remove(item);
                                        }
                                        else
                                        {
                                            data.Where(p => p.NTT_ID == deleteId).ToList().ForEach(p => p.ASXH_ID = clsParameter.statusDeleted);
                                        }
                                    }
                                    break;
                                case CategoryHoatDong.HNXH:
                                    if (item != null)
                                    {
                                        if (item.HNXH_ID == null)
                                        {//Nếu là dòng mới thì xóa luôn
                                            data.Remove(item);
                                        }
                                        else
                                        {
                                            data.Where(p => p.NTT_ID == deleteId).ToList().ForEach(p => p.HNXH_ID = clsParameter.statusDeleted);
                                        }
                                    }
                                    break;
                                case CategoryHoatDong.KHAC:
                                    if (item != null)
                                    {
                                        if (item.KHAC_ID == null)
                                        {//Nếu là dòng mới thì xóa luôn
                                            data.Remove(item);
                                        }
                                        else
                                        {
                                            data.Where(p => p.NTT_ID == deleteId).ToList().ForEach(p => p.KHAC_ID = clsParameter.statusDeleted);
                                        }
                                    }
                                    break;
                                default:
                                    break;
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
                    _statusAllControl(false);
                    _clearData();
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
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

                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = gvGrid.RowCount > 0;

                }
            }
        }

        #endregion

        #region event Grid

        private void gvGrid_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            _bindingData();
        }

        #endregion
    }
}
