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
using DevExpress.Utils;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucSPUuDai : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSPUuDai()
        {
            InitializeComponent();
        }

        private void ucLoaiPhapLy_Load(object sender, EventArgs e)
        {
            LibraryDev.PermissionButton(btnControl, null);
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();
            try
            {
                lueGoiThau.ItemIndex = 0;
            }
            catch
            {
            }
            FormStatus = EnumFormStatus.VIEW;
            CommandData();
            FunctionHelper.PermissionLockButton(btnControl);

            FormHelper.LookUpEdit_Init(lueGoiThau);
        }

        #region Variable

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        #endregion

        void CommandData()
        {
            string str_update = "update DAU_THAU set SP_UUDAI=@SP_UUDAI, SP_UUDAI_GHICHU=@SP_UUDAI_GHICHU where DAUTHAU_ID=@DAUTHAU_ID ";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            da.UpdateCommand.Parameters.Add("@SP_UUDAI", SqlDbType.Bit, 2, "SP_UUDAI");
            da.UpdateCommand.Parameters.Add("@SP_UUDAI_GHICHU", SqlDbType.NVarChar, 255, "SP_UUDAI_GHICHU");
            da.UpdateCommand.Parameters.Add("@DAUTHAU_ID", SqlDbType.BigInt, 10, "DAUTHAU_ID");
        }

        void SelectData()
        {
            ds.Clear();
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu đấu thầu ...", "Vui lòng đợi giây lát");

            SqlCommand cmd = new SqlCommand("sp_EditSPUuDai", clsConnection._conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt).Value = Convert.ToInt32(lueGoiThau.EditValue);
            cmd.Parameters.Add("@DOT_MA", SqlDbType.NVarChar).Value = clsParameter._dotMaDauThau;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "SP_UUDAI");
            gcGrid.DataSource = ds.Tables["SP_UUDAI"];
            _wait.Close();
        }

        #region Status


        public EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.MODIFY)
                {
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    gvGrid.ActiveFilter.Clear();
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    colSP_UUDAI.OptionsColumn.AllowEdit  = true;
                    colSP_UUDAI_GHICHU.OptionsColumn.AllowEdit = true;
                    lueGoiThau.Enabled = false;
                }
                else
                {
                    colSP_UUDAI.OptionsColumn.AllowEdit = false;
                    gvGrid.OptionsView.ShowAutoFilterRow = true;
                    colSP_UUDAI_GHICHU.OptionsColumn.AllowEdit = false;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    lueGoiThau.Enabled = true;
                    btnControl.btnModify.Enabled = gvGrid.RowCount > 0;
                }
            }
        }

        #endregion

        void Save()
        {
            try
            {
                clsParameter._isLoadHoSoDauThau = true;
                da.Update(ds.Tables["SP_UUDAI"]);
            }
            catch
            {
                XtraMessageBox.Show("Dữ liệu đã được sử dụng bạn không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnControl_btnEventCancel_Click(object sender, EventArgs e)
        {
            SelectData();
            this.FormStatus = EnumFormStatus.VIEW;
        }

        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            if (lueGoiThau.EditValue == null)
            {
                clsMessage.MessageInfo("Vui lòng chọn nhà thầu");
                return;
            }
            SelectData();
        }

        private void gvGrid_RowCountChanged(object sender, EventArgs e)
        {
            btnControl.btnModify.Enabled = gvGrid.RowCount > 0;
        }

        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            btnControl.btnView.PerformClick();
        }

        private void chkPL_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chkPL_EditValueChanged(object sender, EventArgs e)
        {
            if (FormStatus == EnumFormStatus.MODIFY)
            {
                CheckEdit chk = sender as CheckEdit;
                if (!chk.Checked)
                {
                    gvGrid.SetFocusedRowCellValue(colSP_UUDAI_GHICHU, string.Empty);
                    gvGrid.SetFocusedRowCellValue(colSP_UUDAI, false);
                }
            }
        }

        private void txtGhiChu_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (FormStatus == EnumFormStatus.MODIFY)
            {
                if (gvGrid.FocusedColumn == colSP_UUDAI_GHICHU)
                {
                    if (!clsChangeType.change_bool(gvGrid.GetFocusedRowCellValue(colSP_UUDAI)))
                    {
                        clsMessage.MessageInfo("Chọn loại pháp lý mới cho phép cập nhật ghi chú");
                        e.Cancel = true;
                    }
                }
            }
        }

        

    }
}
