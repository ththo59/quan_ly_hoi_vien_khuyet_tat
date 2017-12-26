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
    public partial class ucGiaKeHoach : DevExpress.XtraEditors.XtraUserControl
    {
        public ucGiaKeHoach()
        {
            InitializeComponent();
        }

        private void ucGiaKeHoach_Load(object sender, EventArgs e)
        {
            lueDVT.DataSource = FunctionHelper.LoadDM("select * from DM_DVT");
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();
            try
            {
                lueGoiThau.ItemIndex = 0;
            }
            catch
            {
            }
            //lueGoiThau.EditValue =Convert.ToInt32( clsParameter._goiThauID);
            lueGridGoiThau.DataSource = lueGoiThau.Properties.DataSource;
            CommandData();
            SelectData(chkAll.Checked);
            FormStatus = EnumFormStatus.VIEW;
            FunctionHelper.PermissionLockButton(btnControl);

            FormHelper.LookUpEdit_Init(lueGoiThau);
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
            SelectData(chkAll.Checked);

            ////INSERT
            //string _strInsert = "insert into DAUTHAU_GIAKEHOACH (DOT_MA,SP_MA,GIA_KEHOACH)"
            //    + " values (@DOT_MA, @SP_MA, @GIA_KEHOACH)";
            //da.InsertCommand = new SqlCommand(_strInsert, clsConnection._conn);
            //da.InsertCommand.Parameters.Add("@DOT_MA", SqlDbType.NVarChar, 50, "DOT_MA");
            //da.InsertCommand.Parameters.Add("@SP_MA", SqlDbType.NVarChar, 50, "SP_MA");
            //da.InsertCommand.Parameters.Add("@GIA_KEHOACH", SqlDbType.Int, 8, "GIA_KEHOACH");

            ////UPDATE
            //string str_update = "update DAUTHAU_GIAKEHOACH set GIA_KEHOACH=@GIA_KEHOACH where ID=@ID";
            //da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            //da.UpdateCommand.Parameters.Add("@GIA_KEHOACH", SqlDbType.Int, 8, "GIA_KEHOACH");
            //da.UpdateCommand.Parameters.Add("@ID", SqlDbType.BigInt, 10, "ID");
            



            ////DELETE
            //string str_delete = "delete from DAUTHAU_GIAKEHOACH where ID=@ID";
            //da.DeleteCommand = new SqlCommand(str_delete, clsConnection._conn);
            //da.DeleteCommand.Parameters.Add("@ID", SqlDbType.BigInt, 10, "ID");

            //UPDATE
            string str_update = "update DM_SANPHAM set SP_GIAKEHOACH=@SP_GIAKEHOACH where SP_ID=@SP_ID";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            da.UpdateCommand.Parameters.Add("@SP_GIAKEHOACH", SqlDbType.Int, 8, "SP_GIAKEHOACH");
            da.UpdateCommand.Parameters.Add("@SP_ID", SqlDbType.BigInt, 10, "SP_ID");

            
        }

        void SelectData(Boolean IsCheckAll)
        {
            ds = new DataSet();
            string str = string.Empty;
            if (IsCheckAll)
            {
                //lueMaSanPham.DataSource = FunctionHelper.LoadDM("select * from DM_SANPHAM");
                //lueTenSanPham.DataSource = lueMaSanPham.DataSource;
                //str = "select * from DAUTHAU_GIAKEHOACH a , DM_SANPHAM b, DM_GOITHAU c "
                //    + " where a.SP_MA =b.SP_MA and b.SP_GOITHAU=c.GOITHAU_ID and a.DOT_MA='" + clsParameter._dotMaDauThau + "'";
                str = " SELECT sp.* FROM dbo.DM_SANPHAM sp , dbo.DM_GOITHAU gt "
                    + " WHERE sp.SP_GOITHAU = gt.GOITHAU_ID AND gt.DOT_MA = '"+clsParameter._dotMaDauThau+"'"; 
            }
            else
            {
                //lueMaSanPham.DataSource = FunctionHelper.LoadDM("select * from DM_SANPHAM where SP_GOITHAU =" + Convert.ToInt32(lueGoiThau.EditValue));
                //lueTenSanPham.DataSource = lueMaSanPham.DataSource;

                //str = "select * from DAUTHAU_GIAKEHOACH a , DM_SANPHAM b, DM_GOITHAU c "
                //    + " where a.SP_MA =b.SP_MA and b.SP_GOITHAU=c.GOITHAU_ID "
                //    + " and a.DOT_MA='" + clsParameter._dotMaDauThau + "'"
                //    + " and b.SP_GOITHAU=" + clsChangeType.change_int(lueGoiThau.EditValue);
                str = " SELECT sp.* FROM DM_SANPHAM sp , DM_GOITHAU gt "
                    + " WHERE sp.SP_GOITHAU = gt.GOITHAU_ID AND gt.DOT_MA = '" + clsParameter._dotMaDauThau + "'"
                    + " and sp.SP_GOITHAU=" + clsChangeType.change_int(lueGoiThau.EditValue);
            }
            da.SelectCommand = new SqlCommand(str, clsConnection._conn);
            da.Fill(ds, "DAUTHAU_GIAKEHOACH");
            gcGrid.DataSource = ds.Tables["DAUTHAU_GIAKEHOACH"];
        }

        void Save()
        {
            try
            {
                clsParameter._isLoadHoSoDauThau = true;
                da.Update(ds.Tables["DAUTHAU_GIAKEHOACH"]);
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
                if (Convert.ToString(gvGrid.GetRowCellValue(i, colSP_MA.FieldName) + string.Empty).ToLower() == value && i != gvGrid.FocusedRowHandle)
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
                    //gvGrid.OptionsBehavior.Editable = true;
                    lueGoiThau.Enabled = false;
                    colGIA_KEHOACH.OptionsColumn.AllowEdit = true;
                }

                else
                {
                    //gvGrid.OptionsBehavior.Editable = false;
                    gvGrid.OptionsView.ShowAutoFilterRow = true;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    lueGoiThau.Enabled = true;
                    colGIA_KEHOACH.OptionsColumn.AllowEdit = false;
                    btnControl.btnModify.Enabled = gvGrid.RowCount > 0;
                }
            }
        }

        #endregion

        #region Event Button

        private void btnControl_btnEventAdd_Click(object sender, EventArgs e)
        {
            if (lueGoiThau.EditValue == null)
            {
                clsMessage.MessageInfo("Vui lòng chọn gói thầu.");
                FormStatus = EnumFormStatus.VIEW;
                return;
            }
            chkAll.Checked = false;
            FormStatus = EnumFormStatus.ADD;
        }

        private void btnControl_btnEventCancel_Click(object sender, EventArgs e)
        {
            
            SelectData(chkAll.Checked);
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

            //if (FunctionHelper.DataUsed("DAUTHAU_GIAKEHOACH", Convert.ToInt32(gvGrid.GetFocusedRowCellValue(colDVT_ID)))) return;

            string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colSP_MA.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa giá kế hoạch của sản phẩm: \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                gvGrid.DeleteSelectedRows();
                Save();
                SelectData(chkAll.Checked);
            }
        }

        private void btnControl_btnEventModify_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.MODIFY;
        }

        private void btnControl_btnEventSave_Click(object sender, EventArgs e)
        {
            Save();
            SelectData(chkAll.Checked);
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
            if (gvGrid.FocusedColumn.FieldName == colSP_MA.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colSP_MA.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
                else if (TrungTen(e.Value.ToString()) == true)
                {
                    e.ErrorText = colSP_MA.Caption + " không được trùng.";
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
            if (gvGrid.GetRowCellValue(e.RowHandle, colSP_MA.FieldName).ToString().Trim().Length == 0)
            {
                gvGrid.SetColumnError(gvGrid.Columns[colSP_MA.FieldName], colSP_MA.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
        }
        #endregion

        private void gvGrid_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvGrid.SetFocusedRowCellValue(colDOT_MA, clsParameter._dotMaDauThau);
            gvGrid.SetFocusedRowCellValue(colSP_GOITHAU, lueGoiThau.EditValue);
        }

        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            if (lueGoiThau.EditValue != null)
            {
                lueMaSanPham.DataSource = FunctionHelper.LoadDM("select * from DM_SANPHAM where SP_GOITHAU =" + Convert.ToInt32(lueGoiThau.EditValue));
                lueTenSanPham.DataSource = lueMaSanPham.DataSource;
                SelectData(chkAll.Checked);
            }
        }

        private void lueMaSanPham_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (lue.EditValue != null)
            {
                gvGrid.SetFocusedRowCellValue(colSP_TEN, lue.GetColumnValue("SP_MA"));
                gvGrid.SetFocusedRowCellValue(colDVT_ID, lue.GetColumnValue("DVT_ID"));
                gvGrid.SetFocusedRowCellValue(colSP_HAMLUONG, lue.GetColumnValue("SP_HAMLUONG"));
                gvGrid.SetFocusedRowCellValue(colSP_DANGDUNG, lue.GetColumnValue("SP_DANGDUNG"));
            }
        }

        private void lueTenSanPham_EditValueChanged(object sender, EventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (lue.EditValue != null)
            {
                gvGrid.SetFocusedRowCellValue(colSP_MA, lue.GetColumnValue("SP_MA"));
                gvGrid.SetFocusedRowCellValue(colDVT_ID, lue.GetColumnValue("DVT_ID"));
                gvGrid.SetFocusedRowCellValue(colSP_HAMLUONG, lue.GetColumnValue("SP_HAMLUONG"));
                gvGrid.SetFocusedRowCellValue(colSP_DANGDUNG, lue.GetColumnValue("SP_DANGDUNG"));
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
                SelectData(chkAll.Checked);
        }

        private void gvGrid_RowCountChanged(object sender, EventArgs e)
        {
            if(_formStatus ==EnumFormStatus.VIEW)
            btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = gvGrid.RowCount > 0;
        }

        private void btnControl_btnEventClose_Click_1(object sender, EventArgs e)
        {
            this.Parent.Dispose();
        }

    }
}
