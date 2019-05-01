using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DauThau.Class;
using DevExpress.XtraGrid;
using System.Data.Entity;
using DevExpress.Utils;
using DauThau.Models;
using System.Linq;

namespace DauThau.UserControlCategory
{
    public partial class ucUser : ucBase
    {
        public ucUser()
        {
            InitializeComponent();
        }

        private void ucUser_Load(object sender, EventArgs e)
        {
            initData();
            base.registerButtonArray(btnControl);
            repLueFucnName.DataSource = FuncCategory.loadFunctionName();
            FormStatus = EnumFormStatus.VIEW;
        }


        #region Function

        void initData()
        {
            gvGrid._SetDefaultColorRowStyle();
        }
        
        void _clearData()
        {
            txtUSER_FULLNAME.EditValue = txtUSER_PASS.EditValue = txtUSER_NAME.EditValue = null;
            chkUSER_LOCK.Checked = false;
            gcChucNang.DataSource = null;
        }

        void _statusAllControl(bool isEnable)
        {
            txtUSER_NAME.Enabled = txtUSER_FULLNAME.Enabled = txtUSER_PASS.Enabled = chkUSER_LOCK.Enabled = isEnable;
            gcGrid.Enabled = gcChucNang.Enabled = !isEnable;
        }

        void _selectData()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            context = new QL_HOIVIEN_KTEntities();
            context.QL_USERS.Load();
            gcGrid.DataSource = context.QL_USERS.Local.ToBindingList();

            _loadUserPermission();
            _wait.Close();
        }

        void _loadUserPermission()
        {
            context = new QL_HOIVIEN_KTEntities();
            Int64 userId = clsChangeType.change_int64(gvGrid.GetFocusedRowCellValue(colUSER_ID));
            context.QL_USERS_PERMISSION.Load();
            gcChucNang.DataSource = context.QL_USERS_PERMISSION.Local.ToBindingList().Where(p => p.USER_ID == userId);
        }

        void _deleteData()
        {
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colUSER_FULLNAME.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa: \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SaveData();
            }
        }

        void _cancelData()
        {
            _selectData();
            FormStatus = EnumFormStatus.VIEW;
        }

        private Boolean _validateControl()
        {
            dxErrorValidate.ClearErrors();

            if (txtUSER_FULLNAME.Text.Trim() == string.Empty)
            {
                dxErrorValidate.SetError(txtUSER_FULLNAME, "Vui lòng nhập họ tên");
            }

            if (txtUSER_NAME.Text.Trim() == string.Empty)
            {
                dxErrorValidate.SetError(txtUSER_NAME, "Vui lòng nhập tên đăng nhập");
            }
            

            if (dxErrorValidate.HasErrors)
            {
                clsMessage.MessageWarning("Vui lòng nhập đầy đủ thông tin.");
            }

            return !dxErrorValidate.HasErrors;
        }

        private void _setObjectEntities(ref QL_USERS item)
        {
            item.USER_NAME = txtUSER_NAME.Text;
            item.USER_FULLNAME = txtUSER_FULLNAME.Text;
            item.USER_PASS = txtUSER_PASS.Text;
            item.USER_LOCK = chkUSER_LOCK.Checked;
        }

        private void _loadDataFocusRow()
        {
            _clearData();
            QL_USERS item = gvGrid.GetFocusedRow() as QL_USERS;
            if (item != null)
            {
                txtUSER_NAME.EditValue = item.USER_NAME;
                txtUSER_FULLNAME.EditValue = item.USER_FULLNAME;
                txtUSER_PASS.EditValue = item.USER_PASS;
                chkUSER_LOCK.EditValue = item.USER_LOCK;
            }

            _loadUserPermission();
        }

        protected override bool SaveData()
        {
            if (_validateControl())
            {
                WaitDialogForm _wait = new WaitDialogForm("Đang lưu dữ liệu ...", "Vui lòng đợi giây lát");
                using (var _context = new QL_HOIVIEN_KTEntities())
                {
                    QL_USERS item;
                    switch (_formStatus)
                    {
                        case EnumFormStatus.ADD:

                            item = new QL_USERS();
                            _setObjectEntities(ref item);
                            _context.QL_USERS.Add(item);

                            var listFunc = FuncCategory.loadFunctionName();
                            foreach (var func in listFunc)
                            {
                                QL_USERS_PERMISSION per = new QL_USERS_PERMISSION();
                                per.PER_NAME = Convert.ToInt32(func.ID);
                                per.PER_VIEW = true;
                                per.PER_ADD = false;
                                per.PER_MODIFY = false;
                                per.PER_DELETE = false;
                                per.PER_PRINT = false;
                                per.QL_USERS = item;
                                _context.QL_USERS_PERMISSION.Add(per);
                            }

                            break;

                        case EnumFormStatus.MODIFY:
                            Int64 userId = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colUSER_ID));
                            item = (from p in _context.QL_USERS where p.USER_ID == userId select p).FirstOrDefault<QL_USERS>();
                            if (item != null)
                            {
                                _setObjectEntities(ref item);
                            }
                            var entity = _context.QL_USERS.Find(userId);
                            _context.Entry(entity).CurrentValues.SetValues(item);

                            gvChucNang.PostEditor();
                            gvChucNang.UpdateCurrentRow();
                            context.SaveChanges();
                            break;

                        case EnumFormStatus.DELETE:
                            Int64 deleteId = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colUSER_ID));
                            var entitiesPermission = (from p in _context.QL_USERS_PERMISSION where p.USER_ID == deleteId select p);
                            foreach (var per in entitiesPermission)
                            {
                                _context.QL_USERS_PERMISSION.Remove(per);
                            }

                            QL_USERS entities = (from p in _context.QL_USERS where p.USER_ID == deleteId select p).FirstOrDefault();
                            _context.QL_USERS.Remove(entities);

                            break;
                        default:
                            break;
                    }
                    _context.SaveChanges();
                }
                FormStatus = EnumFormStatus.VIEW;
                _wait.Close();
            }

            return base.SaveData();
        }

        #endregion

        #region Event Button


        void ClearField()
        {
            txtUSER_NAME.Text = txtUSER_FULLNAME.Text = txtUSER_PASS.Text = string.Empty;
            chkUSER_LOCK.Checked = false;
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
                    _statusAllControl(true);
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    _statusAllControl(true);
                    gcChucNang.Enabled = true;
                }
                else if (_formStatus == EnumFormStatus.DELETE)
                {
                    _deleteData();
                }
                else if (_formStatus == EnumFormStatus.CANCEL)
                {
                    _cancelData();
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
                    _selectData();
                    _statusAllControl(false);
                    dxErrorValidate.ClearErrors();
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;

                }
            }
        }

        #endregion

        #region Event Grid

        private void gvGrid_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            e.Valid = true;
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                return;
            }

            if (gvGrid.FocusedRowHandle == GridControl.NewItemRowHandle
            && gvGrid.GetRow(GridControl.NewItemRowHandle) == null)
            {
                return;
            }


            if (gvGrid.FocusedColumn.FieldName == colUSER_FULLNAME.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colUSER_FULLNAME.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
                else if (gvGrid._ValidationSame(colUSER_FULLNAME, e.Value + string.Empty))
                {
                    e.ErrorText = colUSER_FULLNAME.Caption + " không được trùng.";
                    e.Valid = false;
                }
            }

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
            if ((gvGrid.GetRowCellValue(e.RowHandle, colUSER_FULLNAME.FieldName) + string.Empty).Trim().Length == 0)
            {
                gvGrid.SetColumnError(gvGrid.Columns[colUSER_FULLNAME.FieldName], colUSER_FULLNAME.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
        }
        #endregion

        private void gvGrid_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            _loadDataFocusRow();
        }

        private void gvGrid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            _loadDataFocusRow();
        }
    }
}
