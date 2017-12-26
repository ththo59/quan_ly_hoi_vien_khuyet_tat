using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DauThau.Class;
using DevExpress.XtraGrid;
using System.Data.SqlClient;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucHangSX : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHangSX()
        {
            InitializeComponent();
        }

        private void ucHangSX_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = FunctionHelper.LoadDM(string.Format("select * from DM_GOITHAU where DOT_MA='{0}' and CHON_HANGSX=1", clsParameter._dotMaDauThau));
            lueGoiThau.Properties.DataSource = dt;
            if (dt.Rows.Count == 0)
                clsMessage.MessageInfo("Không có gói thầu nào cho phép chọn hãng sản xuất.");
            if (dt.Rows.Count > 0)
                lueGoiThau.ItemIndex = 0;
            CommandData();
            FormStatus = EnumFormStatus.VIEW;
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
            string _strInsert = "insert into GOITHAU_HANGSX (GOITHAU_ID,HANGSX)"
                + " values (@GOITHAU_ID,@HANGSX)";
            da.InsertCommand = new SqlCommand(_strInsert, clsConnection._conn);
            da.InsertCommand.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt, 10, "GOITHAU_ID");
            da.InsertCommand.Parameters.Add("@HANGSX", SqlDbType.NVarChar, 100, "HANGSX");

            //UPDATE
            string str_update = "update GOITHAU_HANGSX set HANGSX=@HANGSX where ID=@ID";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            da.UpdateCommand.Parameters.Add("@HANGSX", SqlDbType.NVarChar, 100, "HANGSX");
            da.UpdateCommand.Parameters.Add("@ID", SqlDbType.BigInt, 10, "ID");



            //DELETE
            string str_delete = "delete from GOITHAU_HANGSX where ID=@ID";
            da.DeleteCommand = new SqlCommand(str_delete, clsConnection._conn);
            da.DeleteCommand.Parameters.Add("@ID", SqlDbType.BigInt, 10, "ID");
        }

        void SelectData()
        {
            ds = new DataSet();
            da.SelectCommand = new SqlCommand("select * from GOITHAU_HANGSX where GOITHAU_ID=" + clsChangeType.change_int64(lueGoiThau.EditValue), clsConnection._conn);
            da.Fill(ds, "DVT");
            gcGrid.DataSource = ds.Tables["DVT"];
        }

        void Save()
        {
            try
            {
                da.Update(ds.Tables["DVT"]);
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
                if (Convert.ToString(gvGrid.GetRowCellValue(i, colHANGSX.FieldName) + string.Empty).ToLower() == value && i != gvGrid.FocusedRowHandle)
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
                    lueGoiThau.Enabled = false;
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    gvGrid.ActiveFilter.Clear();
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    gvGrid.OptionsBehavior.Editable = true;
                    lueGoiThau.Enabled = false;
                }

                else
                {
                    gvGrid.OptionsBehavior.Editable = false;
                    lueGoiThau.Enabled = true;
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

       


        private void btnControl_btnEventDelete_Click(object sender, EventArgs e)
        {
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string str = "SELECT count(*) FROM dbo.GOITHAU_HANGSX a, dbo.GOITHAU_HANGSX_NUOCSX b "
                        + " WHERE a.HANGSX=b.HANGSX AND a.HANGSX LIKE N'" + gvGrid.GetFocusedRowCellValue(colHANGSX) + "'";
            DataTable t = FunctionHelper.LoadDM(str);
            if(clsChangeType.change_int(t.Rows[0][0]) > 0)
            {
                clsMessage.MessageWarning("Hãng sản xuất đã có dữ liệu các nước sản xuất. Không thể xóa");
                return;
            }
            //if (FunctionHelper.DataUsed("DM_DVT", Convert.ToInt32(gvGrid.GetFocusedRowCellValue(colDVT_ID)))) return;

            string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colHANGSX.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa đơn vị tính: \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
            if (gvGrid.FocusedColumn.FieldName == colHANGSX.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colHANGSX.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
                else if (TrungTen(e.Value.ToString()) == true)
                {
                    e.ErrorText = colHANGSX.Caption + " không được trùng.";
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
            if (gvGrid.GetRowCellValue(e.RowHandle, colHANGSX.FieldName).ToString().Trim().Length == 0)
            {
                gvGrid.SetColumnError(gvGrid.Columns[colHANGSX.FieldName], colHANGSX.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
        }
        #endregion

        private void gvGrid_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvGrid.SetFocusedRowCellValue(colGOITHAU_ID, lueGoiThau.EditValue);
        }

        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            SelectData();
        }

    }
}
