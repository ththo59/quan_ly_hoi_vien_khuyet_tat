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
using DevExpress.Utils;
using DauThau.Models;
using System.Linq;
using System.Data.Entity;

namespace DauThau.UserControlCategory
{
    public partial class ucDmXa : ucBase
    {
        public ucDmXa()
        {
            InitializeComponent();
        }

        private void ucDmXa_Load(object sender, EventArgs e)
        {
            registerButtonArray(btnControl);
            initData();
            FormStatus = EnumFormStatus.VIEW;
        }

        #region Variable

        #endregion

        #region Function

        void initData()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            gvGrid._SetDefaultColorRowStyle();
            repLueTinh.DataSource = (from p in context.DM_TINH select p).ToList();
            repLueHuyen.DataSource = (from p in context.DM_HUYEN select p).ToList();
            _wait.Close();
        }

        void SelectData()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            //Reload data
            context = new QL_HOIVIEN_KTEntities();
            context.DM_XA.Load();
            gcGrid.DataSource = context.DM_XA.Local.ToBindingList();
            _wait.Close();
        }

        protected override bool SaveData()
        {
            try
            {
                WaitDialogForm _wait = new WaitDialogForm("Đang lưu dữ liệu ...", "Vui lòng đợi giây lát");
                gvGrid.PostEditor();
                gvGrid.UpdateCurrentRow();
                context.SaveChanges();
                FormStatus = EnumFormStatus.VIEW;
                _wait.Close();
            }
            catch
            {
                XtraMessageBox.Show("Dữ liệu đã được sử dụng bạn không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return base.SaveData();
        }

        Boolean TrungTen(string value)
        {
            value = value.ToLower();
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                if (Convert.ToString(gvGrid.GetRowCellValue(i, colXA_TEN.FieldName) + string.Empty).ToLower() == value && i != gvGrid.FocusedRowHandle)
                {
                    return true;
                }
            }
            return false;
        }

        void deleteRow()
        {
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colXA_TEN.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa: \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                gvGrid.DeleteSelectedRows();
                FormStatus = EnumFormStatus.SAVE;
            }
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
                    gvGrid.OptionsBehavior.Editable = true;
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvGrid.ActiveFilter.Clear();

                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    gvGrid.ActiveFilter.Clear();
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    gvGrid.OptionsBehavior.Editable = true;
                }
                else if(_formStatus == EnumFormStatus.DELETE)
                {
                    deleteRow();
                }
                else if(_formStatus == EnumFormStatus.SAVE)
                {
                    SaveData();
                }
                else if(_formStatus == EnumFormStatus.CANCEL)
                {
                    SelectData();
                    this.FormStatus = EnumFormStatus.VIEW;
                }else if(_formStatus == EnumFormStatus.CLOSE)
                {
                    closeTab();
                }
                else
                {
                    SelectData();
                    gvGrid.OptionsBehavior.Editable = false;
                    gvGrid.OptionsView.ShowAutoFilterRow = true;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;

                }
            }
        }

        #endregion

        #region Event Button

 
        //private void btnControl_btnEventDelete_Click(object sender, EventArgs e)
        //{
        //    if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
        //    {
        //        XtraMessageBox.Show("Bạn chưa chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
        //        return;
        //    }

        //    string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colTINH.FieldName).ToString();
        //    if (XtraMessageBox.Show("Bạn có chắc muốn xóa đơn vị tính: \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //    {
        //        gvGrid.DeleteSelectedRows();
        //        Save();
        //        SelectData();
        //    }
        //}

        //private void btnControl_btnEventSave_Click(object sender, EventArgs e)
        //{
        //    Save();
        //    SelectData();
        //    this.FormStatus = EnumFormStatus.VIEW;
        //}
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
            if (gvGrid.FocusedColumn.FieldName == colXA_TEN.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colXA_TEN.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
                else if (gvGrid._ValidationSame(colXA_TEN,e.Value +string.Empty))
                {
                    e.ErrorText = colXA_TEN.Caption + " không được trùng.";
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
            
            if (gvGrid.GetRowCellValue(e.RowHandle, colXA_TEN.FieldName) + string.Empty == "")
            {
                gvGrid.SetColumnError(gvGrid.Columns[colXA_TEN.FieldName], colXA_TEN.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
        }
        #endregion
    }
}
