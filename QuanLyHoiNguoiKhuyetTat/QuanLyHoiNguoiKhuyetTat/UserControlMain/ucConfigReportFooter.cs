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
using System.Linq;
using System.Collections;
using DevExpress.XtraEditors.Controls;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucConfigReportFooter : DevExpress.XtraEditors.XtraUserControl
    {
        public ucConfigReportFooter()
        {
            InitializeComponent();
        }

        private void ucHangSX_Load(object sender, EventArgs e)
        {
            foreach (LoaiBaoCao val in Enum.GetValues(typeof(LoaiBaoCao)))
            {
                CheckedListBoxItem item = new CheckedListBoxItem();
                item.Description = val.GetDescriptionExtension();
                item.Value = val.GetNameExtension();
                chkListBieuMau.Items.Add(item);
            }
            CommandData();
            FormStatus = EnumFormStatus.VIEW;
        }

        void LoadBieuMau(Boolean showAll = true)
        {
            chkListBieuMau.Items.Clear();
            string list = string.Empty;
            if (!showAll)
            {
                DataTable dt = FunctionHelper.LoadDM(string.Format("select * from SystemConfig where SystemConfig_Type= N'{0}'", loaiCauHinh.Type_Report.GetNameExtension()));
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list += dt.Rows[i]["SystemConfig_Parameter"] + string.Empty;
                }
            }
            foreach (LoaiBaoCao val in Enum.GetValues(typeof(LoaiBaoCao)))
            {
                if (list.Contains(val.GetNameExtension()))
                {
                    continue;
                }
                CheckedListBoxItem item = new CheckedListBoxItem();
                item.Description = val.GetDescriptionExtension();
                item.Value = val.GetNameExtension();
                chkListBieuMau.Items.Add(item);
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
        }

        void SelectData()
        {
            ds = new DataSet();
            string strConn = string.Format("select * from SystemConfig where SystemConfig_Type= N'{0}'", loaiCauHinh.Type_Report.GetNameExtension());
            da.SelectCommand = new SqlCommand(strConn, clsConnection._conn);
            da.Fill(ds, "SystemConfig");
            gcGrid.DataSource = ds.Tables["SystemConfig"];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getListItemFromCheckList()
        {
            string list = string.Empty;
            foreach (CheckedListBoxItem item in chkListBieuMau.Items)
            {
                if (item.CheckState == CheckState.Checked)
                {
                    if (list == string.Empty)
                    {
                        list = item.Value + string.Empty;
                    }
                    else
                    {
                        list += ";" + item.Value;
                    }
                }
            }
            return list;
        }

        void Save()
        {
            try
            {
                if (this.FormStatus == EnumFormStatus.ADD)
                {
                    string strInsert = "Insert into SystemConfig (SystemConfig_Parameter, SystemConfig_Description, SystemConfig_Value, SystemConfig_Type) "
                     + " values (@SystemConfig_Parameter, @SystemConfig_Description, @SystemConfig_Value, @SystemConfig_Type)";

                    SqlCommand cmd = new SqlCommand(strInsert, clsConnection._conn);
                    cmd.Parameters.Add("@SystemConfig_Parameter", SqlDbType.NVarChar).Value = this.getListItemFromCheckList();
                    cmd.Parameters.Add("@SystemConfig_Description", SqlDbType.NVarChar).Value = txtTitle.Text;
                    cmd.Parameters.Add("@SystemConfig_Value", SqlDbType.NVarChar).Value = txtValue.Text;
                    cmd.Parameters.Add("@SystemConfig_Type", SqlDbType.NVarChar).Value = loaiCauHinh.Type_Report.GetNameExtension();
                    cmd.ExecuteNonQuery();
                }
                else if(this.FormStatus ==EnumFormStatus.MODIFY)
                {
                    string str = "Update SystemConfig set SystemConfig_Parameter = @SystemConfig_Parameter "
                        + " ,SystemConfig_Description = @SystemConfig_Description, SystemConfig_Value = @SystemConfig_Value"
                     + " where SystemConfig_Id = @SystemConfig_Id";

                    SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                    cmd.Parameters.Add("@SystemConfig_Parameter", SqlDbType.NVarChar).Value = this.getListItemFromCheckList();
                    cmd.Parameters.Add("@SystemConfig_Description", SqlDbType.NVarChar).Value = txtTitle.Text;
                    cmd.Parameters.Add("@SystemConfig_Value", SqlDbType.NVarChar).Value = txtValue.Text;
                    cmd.Parameters.Add("@SystemConfig_Id", SqlDbType.BigInt).Value = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colSystemConfig_Id));
                    cmd.ExecuteNonQuery();
                }
                else if (this.FormStatus == EnumFormStatus.DELETE)
                {
                    string str = "Delete from  SystemConfig where SystemConfig_Id = @SystemConfig_Id";

                    SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                    cmd.Parameters.Add("@SystemConfig_Id", SqlDbType.BigInt).Value = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colSystemConfig_Id));
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show("Lưu dữ liệu không thành công.\n Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                if (_formStatus == EnumFormStatus.ADD )
                {
                    LoadBieuMau(false);
                    gcGrid.Enabled = false;
                    chkListBieuMau.Enabled = txtTitle.Enabled = txtValue.Enabled = true;
                }
                else if(_formStatus == EnumFormStatus.MODIFY){
                    gcGrid.Enabled = false;
                    chkListBieuMau.Enabled = txtTitle.Enabled = txtValue.Enabled = true;
                }
                else
                {
                    LoadBieuMau();
                    gcGrid.Enabled = true;
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = gvGrid.RowCount > 0;
                    chkListBieuMau.Enabled = txtTitle.Enabled = txtValue.Enabled = false;

                    if (gvGrid.RowCount > 0)
                    {
                        RowClick();
                    }
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

       


        private void btnControl_btnEventDelete_Click(object sender, EventArgs e)
        {
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colSystemConfig_Id.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa dòng đang chọn ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                FormStatus = EnumFormStatus.DELETE;
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
            if (gvGrid.GetRowCellValue(e.RowHandle, colSystemConfig_Id.FieldName).ToString().Trim().Length == 0)
            {
                gvGrid.SetColumnError(gvGrid.Columns[colSystemConfig_Id.FieldName], colSystemConfig_Id.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
        }
        #endregion

        private void gvGrid_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

        }

        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            SelectData();
        }

        void RowClick()
        {
            txtTitle.Text = gvGrid.GetFocusedRowCellValue(colSystemConfig_Description) + string.Empty;
            txtValue.Text = gvGrid.GetFocusedRowCellValue(colSystemConfig_Value) + string.Empty;
            string list = gvGrid.GetFocusedRowCellValue(colSystemConfig_Parameter) + string.Empty;
            String[] listArray = list.Split(';');
            foreach (CheckedListBoxItem item in chkListBieuMau.Items)
            {
                if (list.Contains(item.Value + string.Empty))
                {
                    item.CheckState = CheckState.Checked;
                }
                else
                {
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void gcGrid_Click(object sender, EventArgs e)
        {
            RowClick();
        }

        private void gvGrid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            RowClick();
        }

    }
}
