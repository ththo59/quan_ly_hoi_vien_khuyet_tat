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

namespace DauThau.UserControlCategory
{
    public partial class ucTinhNangKyThuat : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTinhNangKyThuat()
        {
            InitializeComponent();
        }

        #region Variable

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        #endregion

        #region Function

        void LoadBasic()
        {
            //DataTable dt = new DataTable();
            //SqlDataAdapter d = new SqlDataAdapter("select * from DM_NHOM_TIEUCHUAN", clsConnection._conn);
            //d.Fill(dt);
            //lueNhomTinhNang.DataSource = dt;

            
        }

        void CommandData()
        {
            LoadBasic();
            gvGrid._SetDefaultColorRowStyle();
            SelectData();

            //INSERT
            string _strInsert = "insert into DM_NHOM_KYTHUAT_CT (TEN)"
                + " values (@TEN)";
            da.InsertCommand = new SqlCommand(_strInsert, clsConnection._conn);
            da.InsertCommand.Parameters.Add("@TEN", SqlDbType.NVarChar, 255, "TEN");

            //UPDATE
            string str_update = "update DM_NHOM_KYTHUAT_CT set TEN=@TEN where NHOM_KYTHUAT_CT_ID=@NHOM_KYTHUAT_CT_ID";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            da.UpdateCommand.Parameters.Add("@TEN", SqlDbType.NVarChar, 255, "TEN");
            da.UpdateCommand.Parameters.Add("@NHOM_KYTHUAT_CT_ID", SqlDbType.BigInt, 10, "NHOM_KYTHUAT_CT_ID");

            //DELETE
            string str_delete = "delete from DM_NHOM_KYTHUAT_CT where NHOM_KYTHUAT_CT_ID=@NHOM_KYTHUAT_CT_ID";
            da.DeleteCommand = new SqlCommand(str_delete, clsConnection._conn);
            da.DeleteCommand.Parameters.Add("@NHOM_KYTHUAT_CT_ID", SqlDbType.BigInt, 10, "NHOM_KYTHUAT_CT_ID");
        }

        void SelectData()
        {
            ds = new DataSet();
            da.SelectCommand = new SqlCommand("select * from DM_NHOM_KYTHUAT_CT", clsConnection._conn);
            da.Fill(ds, "TINHNANG_KYTHUAT");
            gcGrid.DataSource = ds.Tables["TINHNANG_KYTHUAT"];
        }

        void Save()
        {
            try
            {
                da.Update(ds.Tables["TINHNANG_KYTHUAT"]);
            }
            catch
            {
                XtraMessageBox.Show("Dữ liệu đã được sử dụng bạn không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

                else
                {
                    gvGrid.OptionsBehavior.Editable = false;
                    gvGrid.OptionsView.ShowAutoFilterRow = true;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;

                }
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
            SelectData();
            this.FormStatus = EnumFormStatus.VIEW;
        }

        private void btnControl_btnEventClose_Click(object sender, EventArgs e)
        {

        }

        private void btnControl_btnEventDelete_Click(object sender, EventArgs e)
        {
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle || gvGrid.IsGroupRow(gvGrid.FocusedRowHandle))
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (FunctionHelper.DataUsed("DM_NHOM_KYTHUAT_CT", Convert.ToInt32(gvGrid.GetFocusedRowCellValue(colNHOM_KYTHUAT_CT_ID)))) return;

            string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colTEN.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa tính năng: \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                gvGrid.DeleteSelectedRows();
                Save();
                SelectData();
            }
        }

        private void btnControl_btnEventModify_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.MODIFY;
        }

        private void btnControl_btnEventSave_Click(object sender, EventArgs e)
        {
            Save();
            SelectData();
            this.FormStatus = EnumFormStatus.VIEW;
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
            if (gvGrid.FocusedColumn.FieldName == colTEN.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colTEN.Caption + " không được phép rỗng.";
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
            if (gvGrid.GetRowCellValue(e.RowHandle, colTEN.FieldName).ToString().Trim().Length == 0)
            {
                gvGrid.SetColumnError(gvGrid.Columns[colTEN.FieldName], colTEN.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
        }
        #endregion

        private void ucTinhNangKyThuat_Load(object sender, EventArgs e)
        {
            CommandData();
            FormStatus = EnumFormStatus.VIEW;
        }

    }
}
