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
    public partial class frmHoatDongKhacDoiTuongKhac : Form
    {

        public frmHoatDongKhacDoiTuongKhac()
        {
            InitializeComponent();
        }

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        private QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();

        public BindingList<QL_HOATDONG_KHAC_DOITUONG_KHAC> data;
        private Int64 idRowSelected;

        private void frmHoatDongKhacDoiTuongKhac_Load(object sender, EventArgs e)
        {
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_GIOITINH, lueGioiTinh);
            FunctionHelper.dateFormat(deNgayCap_Nam, deNgayCap_Thang, deNgayCap_Ngay);
            FormStatus = EnumFormStatus.VIEW;
        }

        #region function

        void _selectData()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            gcGrid.DataSource = data.Where(p=> p.PARENT_ID != clsParameter.statusDeleted);
            _setFocusedRow();
            _bindingData();
            _wait.Close();
        }

        private void _setFocusedRow()
        {
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                Int64 id = Convert.ToInt64(gvGrid.GetRowCellValue(i, colDTK_ID));
                if (id == idRowSelected)
                {
                    gvGrid.FocusedRowHandle = i;
                    break;
                }
            }
        }
        void _bindingData()
        {
            _clearData();
            QL_HOATDONG_KHAC_DOITUONG_KHAC item = gvGrid.GetFocusedRow() as QL_HOATDONG_KHAC_DOITUONG_KHAC;
            if (item != null)
            {
                txtHo.Text = item.DTK_HO;
                txtTen.Text = item.DTK_TEN;
                txtChucVu.Text = item.DTK_CHUCVU;
                lueGioiTinh.EditValue = item.DTK_GIOITINH;
                txtEmail.Text = item.DTK_EMAIL;
                txtFace.Text = item.DTK_FACEBOOK;
                txtCMND.Text = item.DTK_CMND_SO;
                if (item.DTK_CMND_NGAYCAP.HasValue)
                {
                    deNgayCap_Ngay.EditValue = item.DTK_CMND_NGAYCAP.Value.Day;
                    deNgayCap_Thang.EditValue = item.DTK_CMND_NGAYCAP.Value.Month;
                    deNgayCap_Nam.EditValue = item.DTK_CMND_NGAYCAP.Value.Year;
                }
                txtNoiCap.Text = item.DTK_CMND_NOICAP;
                txtDiaChi.Text = item.DTK_DIACHI;
                txtSoDienThoai.Text = item.DTK_SDT;
                txtMaSoThue.Text = item.DTK_MASOTHUE;
                txtSTK.Text = item.DTK_TK_SO;
                txtTenNganHang.Text = item.DTK_TK_NGANHANG;
                txtDiaChiNganHang.Text = item.DTK_TK_DIACHI;

                txtDonVi_Ten.Text = item.DTK_DONVI_TEN;
                txtDonVi_SDT.EditValue = item.DTK_DONVI_SDT;
                txtDonVi_DiaChi.EditValue = item.DTK_DONVI_DIACHI;
                
               
            }
        }

        void _closeForm()
        {
            this.Close();
        }

        private Boolean _validateControl()
        {
            dxErrorProvider1.ClearErrors();
            if (txtHo.Text.Trim() == string.Empty)
            {
                dxErrorProvider1.SetError(txtHo, "Dữ liệu không được rỗng");
            }
            if (txtTen.Text.Trim() == string.Empty)
            {
                dxErrorProvider1.SetError(txtTen, "Dữ liệu không được rỗng");
            }
            if (lueGioiTinh.Text.Trim() == string.Empty)
            {
                dxErrorProvider1.SetError(lueGioiTinh, "Dữ liệu không được rỗng");
            }
            if (dxErrorProvider1.HasErrors)
            {
                clsMessage.MessageWarning("Vui lòng nhập đầy đủ thông tin");
                return false;
            }

            return true;
        }

        private void _setObjectEntities(ref QL_HOATDONG_KHAC_DOITUONG_KHAC item)
        {
            item.DTK_HO = txtHo.Text;
            item.DTK_TEN = txtTen.Text;
            item.DTK_CHUCVU = txtChucVu.Text;
            item.DTK_GIOITINH = lueGioiTinh.EditValue + string.Empty;
            item.DTK_EMAIL = txtEmail.Text;
            item.DTK_FACEBOOK = txtFace.Text;
            item.DTK_CMND_SO = txtCMND.Text;
            if (deNgayCap_Nam.EditValue != null)
            {
                item.DTK_CMND_NGAYCAP = new DateTime(deNgayCap_Nam.Ex_EditValueToInt() ?? 1, deNgayCap_Thang.Ex_EditValueToInt() ?? 1, deNgayCap_Ngay.Ex_EditValueToInt() ?? 0);
            }
            item.DTK_CMND_NOICAP = txtNoiCap.Text;
            item.DTK_DIACHI = txtDiaChi.Text;
            item.DTK_MASOTHUE = txtMaSoThue.Text;
            item.DTK_TK_SO = txtSTK.Text;
            item.DTK_TK_NGANHANG = txtTenNganHang.Text;
            item.DTK_TK_DIACHI = txtDiaChiNganHang.Text;

            item.DTK_DONVI_TEN = txtDonVi_Ten.Text;
            item.DTK_DONVI_DIACHI = txtDonVi_DiaChi.Text;
            item.DTK_DONVI_SDT = txtDonVi_SDT.Text;
            item.DTK_SDT = txtSoDienThoai.Text;
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

            string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colDTK_HO.FieldName).ToString();
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
                foreach (var row in data.Where(p=>p.PARENT_ID != clsParameter.statusDeleted))
                {
                    listID.Add(row.DTK_ID);
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
                    QL_HOATDONG_KHAC_DOITUONG_KHAC item;
                    switch (_formStatus)
                    {
                        case EnumFormStatus.ADD:

                            item = new QL_HOATDONG_KHAC_DOITUONG_KHAC();
                            _setObjectEntities(ref item);
                            idRowSelected = _maxID();
                            item.DTK_ID = idRowSelected;
                            data.Add(item);

                            break;

                        case EnumFormStatus.MODIFY:
                            Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colDTK_ID));
                            item = (from p in data where p.DTK_ID == id select p).FirstOrDefault();
                            if (item != null)
                            {
                                _setObjectEntities(ref item);
                            }

                            data.Where(p => p.DTK_ID == id).ToList().ForEach(p => p = item);
                            break;

                        case EnumFormStatus.DELETE:
                            Int64 deleteId = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colDTK_ID));
                            item = (from p in data where p.DTK_ID == deleteId select p).FirstOrDefault();
                            if (item != null)
                            {
                                if (item.PARENT_ID == null) {//Nếu là dòng mới thì xóa luôn
                                    data.Remove(item);
                                }
                                else
                                {
                                    data.Where(p => p.DTK_ID == deleteId).ToList().ForEach(p => p.PARENT_ID = clsParameter.statusDeleted);
                                }
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

        #region Event Button Control

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
            idRowSelected = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colDTK_ID));
            _bindingData();
        }

        #endregion

    }
}
