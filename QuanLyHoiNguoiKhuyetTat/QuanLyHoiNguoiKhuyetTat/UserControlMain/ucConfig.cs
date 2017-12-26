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

namespace DauThau.UserControlCategoryMain
{
    public partial class ucConfig : DevExpress.XtraEditors.XtraUserControl
    {
        public ucConfig()
        {
            InitializeComponent();
        }

        private void ucConfig_Load(object sender, EventArgs e)
        {
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
            //string _strInsert = "insert into DM_DVT (TEN)"
            //    + " values (@TEN)";
            //da.InsertCommand = new SqlCommand(_strInsert, clsConnection._conn);
            //da.InsertCommand.Parameters.Add("@TEN", SqlDbType.NVarChar, 50, "TEN");


            //UPDATE
            string str_update = "update SystemConfig set SystemConfig_Value=@SystemConfig_Value where SystemConfig_Id=@SystemConfig_Id";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            da.UpdateCommand.Parameters.Add("@SystemConfig_Value", SqlDbType.NVarChar, 250, "SystemConfig_Value");
            da.UpdateCommand.Parameters.Add("@SystemConfig_Id", SqlDbType.BigInt, 10, "SystemConfig_Id");



            //DELETE
            //string str_delete = "delete from DM_DVT where DVT_ID=@DVT_ID";
            //da.DeleteCommand = new SqlCommand(str_delete, clsConnection._conn);
            //da.DeleteCommand.Parameters.Add("@DVT_ID", SqlDbType.BigInt, 10, "DVT_ID");
        }

        void SelectData()
        {
            ds = new DataSet();
            da.SelectCommand = new SqlCommand("select * from SystemConfig", clsConnection._conn);
            da.Fill(ds, "Config");
            gcGrid.DataSource = ds.Tables["Config"];
        }

        void Save()
        {
            try
            {
                da.Update(ds.Tables["Config"]);
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
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvGrid.ActiveFilter.Clear();

                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    gvGrid.ActiveFilter.Clear();
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    colconfig_value.OptionsColumn.AllowEdit = true;
                }

                else
                {
                    gvGrid.OptionsView.ShowAutoFilterRow = true;
                    colconfig_value.OptionsColumn.AllowEdit = false;
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

        
        

        private void gvGrid_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

       
        #endregion


    }
}
