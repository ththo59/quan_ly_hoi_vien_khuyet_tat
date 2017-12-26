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

namespace DauThau.UserControlCategory
{
    public partial class ucGoiThau : DevExpress.XtraEditors.XtraUserControl
    {
        public ucGoiThau()
        {
            InitializeComponent();
        }

        private void ucGoiThau_Load(object sender, EventArgs e)
        {
            CommandData();
            FormStatus = EnumFormStatus.VIEW;
            FunctionHelper.PermissionLockButton(btnControl);
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
            SelectData(chkDeleted.Checked);

            //INSERT
            string _strInsert = "insert into DM_GOITHAU (TEN,DOT_MA,CHON_HANGSX,BIEUMAU,DIEMKT, STT, TEN_VIET_TAT, DIEN_GIAI)"
                + " values (@TEN,@DOT_MA,@CHON_HANGSX,@BIEUMAU,@DIEMKT, @STT, @TEN_VIET_TAT, @DIEN_GIAI)";
            da.InsertCommand = new SqlCommand(_strInsert, clsConnection._conn);
            da.InsertCommand.Parameters.Add("@TEN", SqlDbType.NVarChar, 255, "TEN");
            da.InsertCommand.Parameters.Add("@DOT_MA", SqlDbType.NVarChar, 255, "DOT_MA");
            da.InsertCommand.Parameters.Add("@CHON_HANGSX", SqlDbType.Bit, 2, "CHON_HANGSX");
            da.InsertCommand.Parameters.Add("@BIEUMAU", SqlDbType.NVarChar, 255, "BIEUMAU");
            da.InsertCommand.Parameters.Add("@DIEMKT", SqlDbType.Int, 5, "DIEMKT");
            da.InsertCommand.Parameters.Add("@STT", SqlDbType.Int, 5, "STT");
            da.InsertCommand.Parameters.Add("@TEN_VIET_TAT", SqlDbType.NVarChar, 255, "TEN_VIET_TAT");
            da.InsertCommand.Parameters.Add("@DIEN_GIAI", SqlDbType.NVarChar, 255, "DIEN_GIAI");

            //UPDATE
            string str_update = "update DM_GOITHAU set TEN=@TEN, DELETED=@DELETED, CHON_HANGSX=@CHON_HANGSX,BIEUMAU=@BIEUMAU" 
                + " , DIEMKT=@DIEMKT, STT=@STT, TEN_VIET_TAT=@TEN_VIET_TAT, DIEN_GIAI=@DIEN_GIAI where GOITHAU_ID=@GOITHAU_ID";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            da.UpdateCommand.Parameters.Add("@TEN", SqlDbType.NVarChar, 255, "TEN");
            da.UpdateCommand.Parameters.Add("@DELETED", SqlDbType.Bit, 2, "DELETED");
            da.UpdateCommand.Parameters.Add("@CHON_HANGSX", SqlDbType.Bit, 2, "CHON_HANGSX");
            da.UpdateCommand.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt, 10, "GOITHAU_ID");
            da.UpdateCommand.Parameters.Add("@BIEUMAU", SqlDbType.NVarChar, 255, "BIEUMAU");
            da.UpdateCommand.Parameters.Add("@DIEMKT", SqlDbType.Int, 5, "DIEMKT");
            da.UpdateCommand.Parameters.Add("@STT", SqlDbType.Int, 5, "STT");
            da.UpdateCommand.Parameters.Add("@TEN_VIET_TAT", SqlDbType.NVarChar, 255, "TEN_VIET_TAT");
            da.UpdateCommand.Parameters.Add("@DIEN_GIAI", SqlDbType.NVarChar, 255, "DIEN_GIAI");
            //DELETE
            string str_delete = "delete from DM_GOITHAU where GOITHAU_ID=@GOITHAU_ID";
            da.DeleteCommand = new SqlCommand(str_delete, clsConnection._conn);
            da.DeleteCommand.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt, 10, "GOITHAU_ID");
        }

        void SelectData(Boolean isDeleted)
        {
            string str ="";
            if(isDeleted) str ="select * from DM_GOITHAU where DOT_MA='"+clsParameter._dotMaDauThau+"' order by STT asc";
            else str = "select * from DM_GOITHAU where (DELETED is null or DELETED=0) and DOT_MA='" + clsParameter._dotMaDauThau + "' order by STT asc";
            ds = new DataSet();
            da.SelectCommand = new SqlCommand(str, clsConnection._conn);
            da.Fill(ds, "GOITHAU");
            gcGrid.DataSource = ds.Tables["GOITHAU"];
        }

        void Save()
        {
            try
            {
                clsParameter._isLoadHoSoDauThau = true;
                da.Update(ds.Tables["GOITHAU"]);
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
                    chkDeleted.Enabled = false;
                    colTEN.OptionsColumn.AllowEdit = true;
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvGrid.ActiveFilter.Clear();
                    colDELETED.Visible = false;
                    colCHON_HANGSX.OptionsColumn.AllowEdit = colBIEUMAU.OptionsColumn.AllowEdit 
                        = colDIEMKT.OptionsColumn.AllowEdit 
                        = colSTT.OptionsColumn.AllowEdit
                        = colDIEN_GIAI.OptionsColumn.AllowEdit
                        = colTEN_VIET_TAT.OptionsColumn.AllowEdit
                        = true;
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    chkDeleted.Enabled = false;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    gvGrid.ActiveFilter.Clear();
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    colTEN.OptionsColumn.AllowEdit = true;
                    colCHON_HANGSX.OptionsColumn.AllowEdit = colBIEUMAU.OptionsColumn.AllowEdit
                        = colSTT.OptionsColumn.AllowEdit = colDIEN_GIAI.OptionsColumn.AllowEdit
                        = colTEN_VIET_TAT.OptionsColumn.AllowEdit
                        = colDIEMKT.OptionsColumn.AllowEdit = true;
                    colDELETED.Visible = false;
                }
                else if (_formStatus == EnumFormStatus.DELETE)
                {
                    chkDeleted.Enabled = false;
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.Delete;
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    colTEN.OptionsColumn.AllowEdit = false;
                    colCHON_HANGSX.OptionsColumn.AllowEdit = colBIEUMAU.OptionsColumn.AllowEdit
                        = colSTT.OptionsColumn.AllowEdit = colDIEN_GIAI.OptionsColumn.AllowEdit
                        = colTEN_VIET_TAT.OptionsColumn.AllowEdit
                        = colDIEMKT.OptionsColumn.AllowEdit = false;
                    colDELETED.OptionsColumn.AllowEdit = true;
                    colDELETED.Visible = true;
                }
                else
                {
                    chkDeleted.Enabled = true;
                    colDELETED.Visible = false;
                    colTEN.OptionsColumn.AllowEdit = false;
                    colCHON_HANGSX.OptionsColumn.AllowEdit = colBIEUMAU.OptionsColumn.AllowEdit
                        = colSTT.OptionsColumn.AllowEdit = colDIEN_GIAI.OptionsColumn.AllowEdit
                        = colTEN_VIET_TAT.OptionsColumn.AllowEdit
                        = colDIEMKT.OptionsColumn.AllowEdit = false;
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
            FormStatus = EnumFormStatus.ADD;
        }

        private void btnControl_btnEventCancel_Click(object sender, EventArgs e)
        {
            SelectData(chkDeleted.Checked);
            this.FormStatus = EnumFormStatus.VIEW;
        }

        private void btnControl_btnEventClose_Click(object sender, EventArgs e)
        {

        }

        private void btnControl_btnEventDelete_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.DELETE;
            //if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            //{
            //    XtraMessageBox.Show("Bạn chưa chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //    return;
            //}

            //if (FunctionHelper.DataUsed("DM_GOITHAU", Convert.ToInt32(gvGrid.GetFocusedRowCellValue(colGOITHAU_ID)))) return;
            
            //string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colTEN.FieldName).ToString();
            //if (XtraMessageBox.Show("Bạn có chắc muốn xóa đơn vị tính: \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            //{
            //    gvGrid.DeleteSelectedRows();
            //    Save();
            //    SelectData();
            //}
        }

        private void btnControl_btnEventModify_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.MODIFY;
        }

        private void btnControl_btnEventSave_Click(object sender, EventArgs e)
        {
            Save();
            SelectData(chkDeleted.Checked);
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
                else if (gvGrid._ValidationSame(colTEN,e.Value+string.Empty))
                {
                    e.ErrorText = colTEN.Caption + " không được trùng.";
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

        private void gcGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (_formStatus == EnumFormStatus.DELETE)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colTEN.FieldName).ToString();
                    if (XtraMessageBox.Show("Bạn có chắc muốn xóa gói thầu: \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        gvGrid.DeleteSelectedRows();
                    }
                }
            }
        }

        private void chkDeleted_CheckedChanged(object sender, EventArgs e)
        {
            SelectData(chkDeleted.Checked);
        }

        private void gvGrid_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvGrid.SetFocusedRowCellValue(colDOT_MA, clsParameter._dotMaDauThau);
            gvGrid.SetFocusedRowCellValue(colDELETED, false);
            gvGrid.SetFocusedRowCellValue(colCHON_HANGSX, false);
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chk_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (gvGrid.FocusedColumn == colCHON_HANGSX)
            {
                string str = "SELECT COUNT(*) FROM dbo.DM_GOITHAU gt, dbo.GOITHAU_HANGSX hsx "
                            + " WHERE gt.GOITHAU_ID = hsx.GOITHAU_ID and gt.GOITHAU_ID=" + clsChangeType.change_int64(gvGrid.GetFocusedRowCellValue(colGOITHAU_ID));
                DataTable t = FunctionHelper.LoadDM(str);
                if (clsChangeType.change_int(t.Rows[0][0]) > 0)
                {
                    clsMessage.MessageWarning("Gói thầu đã có hãng sản xuất không thể bỏ chọn.");
                    e.Cancel = true;
                }
            }
        }

       

       

       
    }
}
