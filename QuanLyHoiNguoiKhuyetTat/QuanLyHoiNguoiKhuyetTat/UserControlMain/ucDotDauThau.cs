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
    public partial class ucDotDauThau : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDotDauThau()
        {
            InitializeComponent();
        }

        private void ucDotDauThau_Load(object sender, EventArgs e)
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
            //gvGrid._SetDefaultColorRowStyle();
            SelectData();

            //INSERT
            string _strInsert = "insert into DOT_DAUTHAU (DOT_MA,MO_NGAY,GIA_DANHGIA,DIEN_GIAI,KHOA, DANGSUDUNG)"
                + " values (@DOT_MA,@MO_NGAY,@GIA_DANHGIA,@DIEN_GIAI,@KHOA, @DANGSUDUNG)";
            da.InsertCommand = new SqlCommand(_strInsert, clsConnection._conn);
            da.InsertCommand.Parameters.Add("@DOT_MA", SqlDbType.NVarChar, 50, "DOT_MA");
            da.InsertCommand.Parameters.Add("@MO_NGAY", SqlDbType.DateTime, 10, "MO_NGAY");
            da.InsertCommand.Parameters.Add("@GIA_DANHGIA", SqlDbType.Int, 10, "GIA_DANHGIA");
            da.InsertCommand.Parameters.Add("@DIEN_GIAI", SqlDbType.NVarChar, 255, "DIEN_GIAI");
            da.InsertCommand.Parameters.Add("@KHOA", SqlDbType.Bit, 5, "KHOA");
            da.InsertCommand.Parameters.Add("@DANGSUDUNG", SqlDbType.Bit, 5, "DANGSUDUNG");

            //UPDATE
            string str_update = "update DOT_DAUTHAU set DOT_MA=@DOT_MA, MO_NGAY=@MO_NGAY, GIA_DANHGIA=@GIA_DANHGIA, DIEN_GIAI=@DIEN_GIAI, KHOA=@KHOA, DANGSUDUNG=@DANGSUDUNG where ID=@ID ";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            da.UpdateCommand.Parameters.Add("@DOT_MA", SqlDbType.NVarChar, 50, "DOT_MA");
            da.UpdateCommand.Parameters.Add("@MO_NGAY", SqlDbType.DateTime, 10, "MO_NGAY");
            da.UpdateCommand.Parameters.Add("@GIA_DANHGIA", SqlDbType.Int, 10, "GIA_DANHGIA");
            da.UpdateCommand.Parameters.Add("@DIEN_GIAI", SqlDbType.NVarChar, 255, "DIEN_GIAI");
            da.UpdateCommand.Parameters.Add("@KHOA", SqlDbType.Bit, 5, "KHOA");
            da.UpdateCommand.Parameters.Add("@DANGSUDUNG", SqlDbType.Bit, 5, "DANGSUDUNG");
            da.UpdateCommand.Parameters.Add("@ID", SqlDbType.BigInt, 10, "ID");


            //DELETE
            string str_delete = "delete from DOT_DAUTHAU where ID=@ID";
            da.DeleteCommand = new SqlCommand(str_delete, clsConnection._conn);
            da.DeleteCommand.Parameters.Add("@ID", SqlDbType.BigInt, 10, "ID");
        }

        void SelectData()
        {
            ds = new DataSet();
            da.SelectCommand = new SqlCommand("select * from DOT_DAUTHAU", clsConnection._conn);
            da.Fill(ds, "DOT_DAUTHAU");
            gcGrid.DataSource = ds.Tables["DOT_DAUTHAU"];
        }

        void Save()
        {
            try
            {
                da.Update(ds.Tables["DOT_DAUTHAU"]);
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
                if (Convert.ToString(gvGrid.GetRowCellValue(i, colDOT_MA.FieldName) + string.Empty).ToLower() == value && i != gvGrid.FocusedRowHandle)
                {
                    return true;
                }
            }
            return false;
        }

        String LayMaDauThau()
        {
            return DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2, '0') + string.Empty;
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
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            //if (FunctionHelper.DataUsed("DOT_DAUTHAU", Convert.ToInt32(gvGrid.GetFocusedRowCellValue(colID)))) return;

            string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colDOT_MA.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa đợt đấu thầu: \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
            Boolean _dangSD = false;
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                if (clsChangeType.change_bool(gvGrid.GetRowCellValue(i, colDANGSUDUNG)))
                {
                    string strKhoaDuLieu= string.Empty;
                    clsParameter._dotMaDauThau = gvGrid.GetRowCellValue(i, colDOT_MA) + string.Empty;
                    clsParameter._dotKhoaDuLieu = clsChangeType.change_bool(gvGrid.GetRowCellValue(i, colKHOA));
                    clsParameter._dotNgayMoThau = Convert.ToDateTime(gvGrid.GetRowCellValue(i, colMO_NGAY));
                    
                    if (clsParameter._dotKhoaDuLieu) strKhoaDuLieu = ", đang khóa dữ liệu";
                    
                    clsParameter._barStaticLogin.Caption = string.Format("Xin chào, {0}.Bạn đang thao tác đợt đấu thầu : mã {1}, mở ngày {2:dd/MM/yyyy}{3}", clsParameter._username, clsParameter._dotMaDauThau, clsParameter._dotNgayMoThau,strKhoaDuLieu); 
                    _dangSD = true;
                    break;
                }
            }

            if (!_dangSD)
            {
                clsMessage.MessageWarning("Vui lòng chọn đợt đấu thầu đang sử dụng");
                return;
            }

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
            if (gvGrid.FocusedColumn.FieldName == colDOT_MA.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colDOT_MA.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
                else if (TrungTen(e.Value.ToString()) == true)
                {
                    e.ErrorText = colDOT_MA.Caption + " không được trùng.";
                    e.Valid = false;
                }
            }
            if (gvGrid.FocusedColumn.FieldName == colMO_NGAY.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value +string.Empty))
                {
                    e.ErrorText = colMO_NGAY.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
            }
            //if (gvGrid.FocusedColumn.FieldName == colGIA_DANHGIA.FieldName)
            //{

            //        if (Convert.ToInt32(e.Value) <= 0)
            //        {
            //            e.ErrorText = colGIA_DANHGIA.Caption + " phải lớn hơn 0.";
            //            e.Valid = false;
            //        }
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
            if (gvGrid.GetRowCellValue(e.RowHandle, colDOT_MA.FieldName).ToString().Trim().Length == 0)
            {
                gvGrid.SetColumnError(gvGrid.Columns[colDOT_MA.FieldName], colDOT_MA.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
            if (TrungTen(gvGrid.GetRowCellValue(e.RowHandle, colDOT_MA.FieldName).ToString()))
            {
                gvGrid.SetColumnError(gvGrid.Columns[colDOT_MA.FieldName], colDOT_MA.Caption + " không được trùng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }

            if (gvGrid.GetRowCellValue(e.RowHandle, colMO_NGAY.FieldName).ToString().Trim().Length == 0)
            {
                gvGrid.SetColumnError(gvGrid.Columns[colMO_NGAY.FieldName], colMO_NGAY.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
            //if (gvGrid.GetRowCellValue(e.RowHandle, colGIA_DANHGIA.FieldName).ToString().Trim().Length == 0)
            //{
            //    gvGrid.SetColumnError(gvGrid.Columns[colGIA_DANHGIA.FieldName], colGIA_DANHGIA.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
            //    e.Valid = false;
            //}
        }
        #endregion

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
           CheckEdit chk = sender as CheckEdit;
           if (gvGrid.FocusedColumn == colDANGSUDUNG)
           {
               for (int i = 0; i < gvGrid.RowCount; i++)
               {
                   if (gvGrid.FocusedRowHandle != i)
                   {
                       gvGrid.SetRowCellValue(i, colDANGSUDUNG, false);
                   }
               }
           }
        }

        private void gvGrid_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            gvGrid.SetFocusedRowCellValue(colDOT_MA, LayMaDauThau());
        }

    }
}
