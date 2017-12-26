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
    public partial class ucUser : DevExpress.XtraEditors.XtraUserControl
    {
        public ucUser()
        {
            InitializeComponent();
        }

        private void ucUser_Load(object sender, EventArgs e)
        {
            
            CommandData();
            FormStatus = EnumFormStatus.VIEW;
            gcChucNang.DataSource = FunctionHelper.LoadDM("select * from PERMISSION");
        }

       
        #region Variable

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        string _table = "USERS";
        #endregion

        #region Function


        void InsertUsers()
        {
            try
            {
                string _strInsert = "insert into USERS (USER_NAME,PASS,KHOA,FULL_NAME)"
               + " values (@USER_NAME,@PASS,@KHOA,@FULL_NAME)";
                SqlCommand cmd = new SqlCommand(_strInsert, clsConnection._conn);
                cmd.Parameters.Add("@USER_NAME", SqlDbType.NVarChar).Value = txtTenDangNhap.Text;
                cmd.Parameters.Add("@PASS", SqlDbType.NVarChar).Value =FunctionHelper.EncryptMD5(txtMatKhau.Text);
                cmd.Parameters.Add("@KHOA", SqlDbType.Bit).Value = chkKhoa.Checked;
                cmd.Parameters.Add("@FULL_NAME", SqlDbType.NVarChar).Value = txtHoTen.Text;
                cmd.ExecuteNonQuery();
                SelectData();
            }
            catch (Exception ex)
            {
                clsMessage.MessageExclamation("Hệ thống phát sinh lổi. Vui lòng kiểm tra lại." + ex.Message);
            }
           
        }

        void UpdateUsers()
        {
            try
            {
                string str_update=string.Empty;
                if(txtMatKhau.Text.Trim().Length > 0)
                  str_update = "update USERS set USER_NAME=@USER_NAME,PASS=@PASS, KHOA=@KHOA, FULL_NAME = @FULL_NAME where ID_USER=@ID_USER";
                else
                    str_update = "update USERS set USER_NAME=@USER_NAME, KHOA=@KHOA, FULL_NAME = @FULL_NAME where ID_USER=@ID_USER";

                SqlCommand cmd = new SqlCommand(str_update, clsConnection._conn);
                cmd.Parameters.Add("@USER_NAME", SqlDbType.NVarChar).Value = txtTenDangNhap.Text;
                if (txtMatKhau.Text.Trim().Length > 0)
                    cmd.Parameters.Add("@PASS", SqlDbType.NVarChar).Value = FunctionHelper.EncryptMD5(txtMatKhau.Text);
                cmd.Parameters.Add("@KHOA", SqlDbType.Bit).Value = chkKhoa.Checked;
                cmd.Parameters.Add("@FULL_NAME", SqlDbType.NVarChar).Value = txtHoTen.Text;
                cmd.Parameters.Add("@ID_USER", SqlDbType.BigInt).Value = clsChangeType.change_int64(gvGrid.GetFocusedRowCellValue(colID_USER));
                cmd.ExecuteNonQuery();
                SelectData();
            }
            catch (Exception ex)
            {
                clsMessage.MessageExclamation("Hệ thống phát sinh lổi. Vui lòng kiểm tra lại." + ex.Message);
            }
        }

        void DeleteUsers()
        {
            try
            {
                string str_delete = "delete from USERS where ID_USER=@ID_USER";
                SqlCommand cmd = new SqlCommand(str_delete, clsConnection._conn);
                cmd.Parameters.Add("@ID_USER", SqlDbType.BigInt).Value = clsChangeType.change_int64(gvGrid.GetFocusedRowCellValue(colID_USER));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                clsMessage.MessageExclamation("Hệ thống phát sinh lổi. Vui lòng kiểm tra lại." + ex.Message);
            }
        }

        void CommandData()
        {
            gvGrid._SetDefaultColorRowStyle();
            SelectData();

            //INSERT
            string _strInsert = "insert into USERS (USER_NAME,PASS,KHOA)"
                + " values (@USER_NAME,@PASS,@KHOA)";
            da.InsertCommand = new SqlCommand(_strInsert, clsConnection._conn);
            da.InsertCommand.Parameters.Add("@USER_NAME", SqlDbType.NVarChar, 50, "USER_NAME");
            da.InsertCommand.Parameters.Add("@PASS", SqlDbType.NVarChar, 50, "PASS");
            da.InsertCommand.Parameters.Add("@KHOA", SqlDbType.Bit, 10, "KHOA");
            
            //UPDATE
            string str_update = "update USERS set USER_NAME=@USER_NAME,PASS=@PASS, KHOA=@KHOA where ID_USER=@ID_USER";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            da.UpdateCommand.Parameters.Add("@USER_NAME", SqlDbType.NVarChar, 50, "USER_NAME");
            da.UpdateCommand.Parameters.Add("@PASS", SqlDbType.NVarChar, 50, "PASS");
            da.UpdateCommand.Parameters.Add("@KHOA", SqlDbType.Bit, 10, "KHOA");
            da.UpdateCommand.Parameters.Add("@ID_USER", SqlDbType.BigInt, 10, "ID_USER");


            //DELETE
            string str_delete = "delete from USERS where ID_USER=@ID_USER";
            da.DeleteCommand = new SqlCommand(str_delete, clsConnection._conn);
            da.DeleteCommand.Parameters.Add("@ID_USER", SqlDbType.BigInt, 10, "ID_USER");
        }

        void SelectData()
        {
            ds = new DataSet();
            da.SelectCommand = new SqlCommand("select * from " + _table, clsConnection._conn);
            da.Fill(ds, _table);
            gcGrid.DataSource = ds.Tables[_table];
        }

        void Save()
        {
            //try
            //{
            //    da.Update(ds.Tables[_table]);
            //}
            //catch
            //{
            //    XtraMessageBox.Show("Dữ liệu đã được sử dụng bạn không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            if (FormStatus == EnumFormStatus.ADD)
                InsertUsers();
            else if (FormStatus == EnumFormStatus.MODIFY) UpdateUsers();
        }

        Boolean TrungTen(string value)
        {
            value = value.ToLower();
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                if (Convert.ToString(gvGrid.GetRowCellValue(i, colUSER_NAME.FieldName) + string.Empty).ToLower() == value && i != gvGrid.FocusedRowHandle)
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
                    gvGrid.OptionsBehavior.Editable = false;
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvGrid.ActiveFilter.Clear();
                    txtTenDangNhap.Enabled =txtHoTen.Enabled= txtMatKhau.Enabled = chkKhoa.Enabled = true;
                    txtTenDangNhap.Focus();
                    gcGrid.Enabled = false;
                    ClearField();
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    gvGrid.ActiveFilter.Clear();
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    gvGrid.OptionsBehavior.Editable = false;
                    txtTenDangNhap.Enabled = txtHoTen.Enabled = txtMatKhau.Enabled = chkKhoa.Enabled = true;
                    txtTenDangNhap.Focus();
                    gcGrid.Enabled = false;
                }

                else
                {
                    gvGrid.OptionsBehavior.Editable = false;
                    gvGrid.OptionsView.ShowAutoFilterRow = true;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    txtTenDangNhap.Enabled = txtHoTen.Enabled = txtMatKhau.Enabled = chkKhoa.Enabled = false;
                    gcGrid.Enabled = true;
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
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colUSER_NAME.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa : \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //gvGrid.DeleteSelectedRows();
                //Save();
                DeleteUsers();
                SelectData();
            }
        }

        private void btnControl_btnEventModify_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.MODIFY;
        }

        private void btnControl_btnEventSave_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text.Trim() == string.Empty)
            {
                clsMessage.MessageInfo("Vui lòng nhập tên đăng nhập.");
                return;
            }
            else if (txtHoTen.Text.Trim() == string.Empty)
            {
                clsMessage.MessageInfo("Vui lòng nhập họ tên.");
                return;
            }
            else if (FormStatus == EnumFormStatus.ADD && txtMatKhau.Text.Trim() == string.Empty)
            {
                clsMessage.MessageInfo("Vui lòng nhập mật khẩu.");
                return;
            }
                Save();
            SelectData();
            this.FormStatus = EnumFormStatus.VIEW;
        }

        void BindingData()
        {
            if (gvGrid.RowCount > 0)
            {
                txtTenDangNhap.Text = gvGrid.GetFocusedRowCellValue(colUSER_NAME) + string.Empty;
                txtHoTen.Text = gvGrid.GetFocusedRowCellValue(colFULL_NAME) + string.Empty;
                chkKhoa.Checked = clsChangeType.change_bool(gvGrid.GetFocusedRowCellValue(colKHOA));
                txtMatKhau.Text = string.Empty;
            }
        }

        void ClearField()
        {
            txtTenDangNhap.Text = txtHoTen.Text = txtMatKhau.Text = string.Empty;
            chkKhoa.Checked = false;
        }

        #endregion

        private void gvGrid_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            BindingData();
        }

        private void gvGrid_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BindingData();
        }

       
    }
}
