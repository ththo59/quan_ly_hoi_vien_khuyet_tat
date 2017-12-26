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

namespace DauThau.UserControlCategoryMain
{
    public partial class ucNhomKyThuatDiemChuan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucNhomKyThuatDiemChuan()
        {
            InitializeComponent();
        }

        private void ucNhomKyThuatDiemChuan_Load(object sender, EventArgs e)
        {
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();
            try
            {
                lueGoiThau.ItemIndex = 0;
            }
            catch
            {
            }
            lueGoiThau.ItemIndex = 0;
            CommandData();
            FormStatus = EnumFormStatus.VIEW;
            FunctionHelper.PermissionLockButton(btnControl);
        }

        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            if(lueGoiThau.EditValue!=null)
            {
            string str = "SELECT DISTINCT a.NHOM_KYTHUAT_ID,b.TEN, a.SORT_NHOM FROM dbo.DM_GOITHAU_KYTHUAT a "
                    + " JOIN dbo.DM_NHOM_KYTHUAT b ON a.NHOM_KYTHUAT_ID=b.NHOM_KYTHUAT_ID "
                    + " WHERE GOITHAU_ID ="+lueGoiThau.EditValue+" ORDER BY a.SORT_NHOM";
            lueNhomKT.DataSource = FunctionHelper.LoadDM(str);

            SelectData();
            }
        }

        #region Variable

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        #endregion

        #region Function



        void CommandData()
        {
            gvGrid._SetDefaultColorRowStyle();
            SelectData();

            //INSERT
            string _strInsert = "insert into DM_NHOM_KYTHUAT_DIEMCHUAN (NHOM_KYTHUAT_ID,DIEM_CHUAN,GOITHAU_ID)"
                + " values (@NHOM_KYTHUAT_ID, @DIEM_CHUAN, @GOITHAU_ID)";
            da.InsertCommand = new SqlCommand(_strInsert, clsConnection._conn);
            da.InsertCommand.Parameters.Add("@NHOM_KYTHUAT_ID", SqlDbType.Int, 5, "NHOM_KYTHUAT_ID");
            da.InsertCommand.Parameters.Add("@DIEM_CHUAN", SqlDbType.Int, 5, "DIEM_CHUAN");
            da.InsertCommand.Parameters.Add("@GOITHAU_ID", SqlDbType.Int, 5, "GOITHAU_ID");
            

            //UPDATE
            string str_update = "update DM_NHOM_KYTHUAT_DIEMCHUAN set NHOM_KYTHUAT_ID=@NHOM_KYTHUAT_ID, DIEM_CHUAN=@DIEM_CHUAN where ID=@ID ";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            da.UpdateCommand.Parameters.Add("@NHOM_KYTHUAT_ID", SqlDbType.Int, 5, "NHOM_KYTHUAT_ID");
            da.UpdateCommand.Parameters.Add("@DIEM_CHUAN", SqlDbType.Int, 5, "DIEM_CHUAN");
            da.UpdateCommand.Parameters.Add("@ID", SqlDbType.Int, 5, "ID");


            //DELETE
            string str_delete = "delete from DM_NHOM_KYTHUAT_DIEMCHUAN where ID=@ID";
            da.DeleteCommand = new SqlCommand(str_delete, clsConnection._conn);
            da.DeleteCommand.Parameters.Add("@ID", SqlDbType.Int, 5, "ID");
        }

        void SelectData()
        {
            ds = new DataSet();
            da.SelectCommand = new SqlCommand("select * from DM_NHOM_KYTHUAT_DIEMCHUAN where GOITHAU_ID=" +clsChangeType.change_int64(lueGoiThau.EditValue), clsConnection._conn);
            da.Fill(ds, "DM_NHOM_KYTHUAT_DIEMCHUAN");
            gcGrid.DataSource = ds.Tables["DM_NHOM_KYTHUAT_DIEMCHUAN"];
        }

        void Save()
        {
            try
            {
                da.Update(ds.Tables["DM_NHOM_KYTHUAT_DIEMCHUAN"]);
            }
            catch
            {
                XtraMessageBox.Show("Dữ liệu đã được sử dụng bạn không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        Boolean TrungTen(string value)
        {
            value = value.ToLower();
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                if (Convert.ToString(gvGrid.GetRowCellValue(i, colNHOM_KYTHUAT_ID.FieldName) + string.Empty).ToLower() == value && i != gvGrid.FocusedRowHandle)
                {
                    return true;
                }
            }
            return false;
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
                    btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = gvGrid.RowCount > 0;
                }
            }
        }

        #endregion

        #region Event Button

        private void btnControl_btnEventAdd_Click(object sender, EventArgs e)
        {
            if (lueGoiThau.EditValue == null)
            {
                clsMessage.MessageWarning("Vui lòng chọn gói thầu");
                FormStatus = EnumFormStatus.VIEW;
                return;
            }
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
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            //if (FunctionHelper.DataUsed("DOT_DAUTHAU", Convert.ToInt32(gvGrid.GetFocusedRowCellValue(colID)))) return;

            //string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, col.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
            if (gvGrid.FocusedColumn.FieldName == colNHOM_KYTHUAT_ID.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colNHOM_KYTHUAT_ID.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
                else if (TrungTen(e.Value.ToString()) == true)
                {
                    e.ErrorText = colNHOM_KYTHUAT_ID.Caption + " không được trùng.";
                    e.Valid = false;
                }
            }
            //if (gvGrid.FocusedColumn.FieldName == colDIEM_CHUAN.FieldName)
            //{
            //    if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
            //    {
            //        e.ErrorText = colDIEM_CHUAN.Caption + " không được phép rỗng.";
            //        e.Valid = false;
            //    }
            //    else if (clsChangeType.change_int(e.Value) <= 0)
            //    {
            //        e.ErrorText = colDIEM_CHUAN.Caption + " phải lớn hơn 0.";
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
            if (gvGrid.GetRowCellValue(e.RowHandle, colNHOM_KYTHUAT_ID.FieldName).ToString().Trim().Length == 0)
            {
                gvGrid.SetColumnError(gvGrid.Columns[colNHOM_KYTHUAT_ID.FieldName], colNHOM_KYTHUAT_ID.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
            if (gvGrid.GetRowCellValue(e.RowHandle, colDIEM_CHUAN.FieldName).ToString().Trim().Length == 0)
            {
                gvGrid.SetColumnError(gvGrid.Columns[colDIEM_CHUAN.FieldName], colDIEM_CHUAN.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
        }
        #endregion

        private void gvGrid_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvGrid.SetFocusedRowCellValue(colGOITHAU_ID, lueGoiThau.EditValue);
        }

    }
}
