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
    public partial class ucGoiThau_KyThuat : DevExpress.XtraEditors.XtraUserControl
    {
        public ucGoiThau_KyThuat()
        {
            InitializeComponent();
        }

        private void ucGoiThau_KyThuat_Load(object sender, EventArgs e)
        {

            lueGoiThau_KT.Properties.DataSource = FunctionHelper.LoadGoiThau();
            lueGoiThau_KT.ItemIndex = 0;
            lueNhomKT.DataSource = LoadDM("select * from DM_NHOM_KYTHUAT");
            lueNhomKT_CT.DataSource = LoadDM("select * from DM_NHOM_KYTHUAT_CT");
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

        DataTable LoadDM(String strConnDM)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter d = new SqlDataAdapter(strConnDM, clsConnection._conn);
            d.Fill(dt);
            return dt;
        }

        void CommandData()
        {
            gvGrid._SetDefaultColorRowStyle();
            SelectData();

            //INSERT
            string _strInsert = "insert into DM_GOITHAU_KYTHUAT (GOITHAU_ID,NHOM_KYTHUAT_ID,NHOM_KYTHUAT_CT_ID,DIEM,SORT_NHOM,SORT_CT,CHOPHEP_CHON, THUOC_PHAN)"
                + " values (@GOITHAU_ID,@NHOM_KYTHUAT_ID,@NHOM_KYTHUAT_CT_ID,@DIEM,@SORT_NHOM,@SORT_CT,@CHOPHEP_CHON, @THUOC_PHAN)";
            da.InsertCommand = new SqlCommand(_strInsert, clsConnection._conn);
            da.InsertCommand.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt, 10, "GOITHAU_ID");
            da.InsertCommand.Parameters.Add("@NHOM_KYTHUAT_ID", SqlDbType.BigInt, 10, "NHOM_KYTHUAT_ID");
            da.InsertCommand.Parameters.Add("@NHOM_KYTHUAT_CT_ID", SqlDbType.BigInt, 10, "NHOM_KYTHUAT_CT_ID");
            da.InsertCommand.Parameters.Add("@DIEM", SqlDbType.BigInt, 10, "DIEM");
            
            da.InsertCommand.Parameters.Add("@SORT_NHOM", SqlDbType.BigInt, 10, "SORT_NHOM");
            da.InsertCommand.Parameters.Add("@SORT_CT", SqlDbType.BigInt, 10, "SORT_CT");
            da.InsertCommand.Parameters.Add("@CHOPHEP_CHON", SqlDbType.Bit, 10, "CHOPHEP_CHON");
            da.InsertCommand.Parameters.Add("@THUOC_PHAN", SqlDbType.NVarChar, 50, "THUOC_PHAN");

            //UPDATE
            string str_update = "update DM_GOITHAU_KYTHUAT set NHOM_KYTHUAT_ID=@NHOM_KYTHUAT_ID, NHOM_KYTHUAT_CT_ID=@NHOM_KYTHUAT_CT_ID "
                + " , DIEM=@DIEM,SORT_NHOM=@SORT_NHOM,SORT_CT=@SORT_CT, CHOPHEP_CHON=@CHOPHEP_CHON, THUOC_PHAN=@THUOC_PHAN where GOITHAU_KYTHUAT_ID=@GOITHAU_KYTHUAT_ID";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn); 
            da.UpdateCommand.Parameters.Add("@NHOM_KYTHUAT_ID", SqlDbType.BigInt, 10, "NHOM_KYTHUAT_ID");
            da.UpdateCommand.Parameters.Add("@NHOM_KYTHUAT_CT_ID", SqlDbType.BigInt, 10, "NHOM_KYTHUAT_CT_ID");
            da.UpdateCommand.Parameters.Add("@DIEM", SqlDbType.BigInt, 10, "DIEM");
           
            da.UpdateCommand.Parameters.Add("@SORT_NHOM", SqlDbType.BigInt, 10, "SORT_NHOM");
            da.UpdateCommand.Parameters.Add("@SORT_CT", SqlDbType.BigInt, 10, "SORT_CT");
            da.UpdateCommand.Parameters.Add("@CHOPHEP_CHON", SqlDbType.Bit, 10, "CHOPHEP_CHON");
            da.UpdateCommand.Parameters.Add("@GOITHAU_KYTHUAT_ID", SqlDbType.BigInt, 10, "GOITHAU_KYTHUAT_ID");
            da.UpdateCommand.Parameters.Add("@THUOC_PHAN", SqlDbType.NVarChar, 50, "THUOC_PHAN");

            //DELETE
            string str_delete = "delete from DM_GOITHAU_KYTHUAT where GOITHAU_KYTHUAT_ID=@GOITHAU_KYTHUAT_ID";
            da.DeleteCommand = new SqlCommand(str_delete, clsConnection._conn);
            da.DeleteCommand.Parameters.Add("@GOITHAU_KYTHUAT_ID", SqlDbType.BigInt, 10, "GOITHAU_KYTHUAT_ID");
        }

        void SelectData()
        {
            ds = new DataSet();
            da.SelectCommand = new SqlCommand("select * from DM_GOITHAU_KYTHUAT where GOITHAU_ID =" + Convert.ToInt32(lueGoiThau_KT.EditValue) + " order by SORT_NHOM asc, SORT_CT asc", clsConnection._conn);
            da.Fill(ds, "DM_GOITHAU_KYTHUAT");
            gcGrid.DataSource = ds.Tables["DM_GOITHAU_KYTHUAT"];
        }

        void Save()
        {
            try
            {
                da.Update(ds.Tables["DM_GOITHAU_KYTHUAT"]);
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
                    lueGoiThau_KT.Properties.ReadOnly = true;
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    gvGrid.ActiveFilter.Clear();
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    gvGrid.OptionsBehavior.Editable = true;
                    lueGoiThau_KT.Properties.ReadOnly = true;
                }

                else
                {
                    lueGoiThau_KT.Properties.ReadOnly = false;
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
            if (lueGoiThau_KT.EditValue == null)
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

            if (FunctionHelper.DataUsed("DM_GOITHAU_KYTHUAT", Convert.ToInt32(gvGrid.GetFocusedRowCellValue(colGOITHAU_ID)))) return;

            //string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colGOITHAU_TEN.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa dòng đang chọn không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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

        private void gvGrid_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvGrid.SetFocusedRowCellValue(colGOITHAU_ID, Convert.ToInt32(lueGoiThau_KT.EditValue));
            gvGrid.SetFocusedRowCellValue(colCHOPHEP_CHON, true);
        }

        private void lueGoiThau_KT_EditValueChanged(object sender, EventArgs e)
        {
            SelectData();
        }
    }
}
