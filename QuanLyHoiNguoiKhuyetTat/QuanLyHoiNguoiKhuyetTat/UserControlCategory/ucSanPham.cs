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
using DauThau.Reports;
using DauThau.UserControlCategoryMain;
using CuscLibrary.Offices;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraReports.UI;

namespace DauThau.UserControlCategory
{
    public partial class ucSanPham : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSanPham()
        {
            InitializeComponent();
        }

        private void ucSanPham_Load(object sender, EventArgs e)
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

      
        void LoadBasic()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter d = new SqlDataAdapter("select * from DM_DVT", clsConnection._conn);
            d.Fill(dt);
            lueDVT.DataSource = dt;
            
            DataTable dt2 = new DataTable();
            SqlDataAdapter d2 = new SqlDataAdapter("select * from DM_NUOCSX", clsConnection._conn);
            d2.Fill(dt2);
            lueNUOCSX.DataSource = dt2;

            
            lueGoiThau.DataSource = FunctionHelper.LoadGoiThau();
            
            lueGoiThauFilter.Properties.DataSource = FunctionHelper.LoadGoiThau();
            try
            {
                lueGoiThauFilter.ItemIndex = 0;
            }
            catch
            {
            }
        }

        void CommandData()
        {
            LoadBasic();
            gvGrid._SetDefaultColorRowStyle();
            SelectData();

            //INSERT
            string _strInsert = "insert into DM_SANPHAM (SP_MA,SP_TEN,DVT_ID,SP_HAMLUONG,SP_DANGDUNG, SP_GOITHAU, SP_TENBIETDUOC,SP_QUICACH_YEUCAU,SP_QUICACH_DONGGOI, SP_NUOCSX_ID, SP_SOTHONGTU)"
                + " values (@SP_MA,@SP_TEN,@DVT_ID,@SP_HAMLUONG,@SP_DANGDUNG,@SP_GOITHAU, @SP_TENBIETDUOC, @SP_QUICACH_YEUCAU, @SP_QUICACH_DONGGOI, @SP_NUOCSX_ID, @SP_SOTHONGTU)";
            da.InsertCommand = new SqlCommand(_strInsert, clsConnection._conn);
            da.InsertCommand.Parameters.Add("@SP_MA", SqlDbType.NVarChar, 255, "SP_MA");
            da.InsertCommand.Parameters.Add("@SP_TEN", SqlDbType.NVarChar, 255, "SP_TEN");
            da.InsertCommand.Parameters.Add("@DVT_ID", SqlDbType.BigInt, 5, "DVT_ID");
            da.InsertCommand.Parameters.Add("@SP_HAMLUONG", SqlDbType.NVarChar, 255, "SP_HAMLUONG");
            da.InsertCommand.Parameters.Add("@SP_DANGDUNG", SqlDbType.NVarChar, 255, "SP_DANGDUNG");
            da.InsertCommand.Parameters.Add("@SP_GOITHAU", SqlDbType.BigInt, 5, "SP_GOITHAU");
            da.InsertCommand.Parameters.Add("@SP_TENBIETDUOC", SqlDbType.NVarChar, 255, "SP_TENBIETDUOC");
            da.InsertCommand.Parameters.Add("@SP_QUICACH_YEUCAU", SqlDbType.NVarChar, 255, "SP_QUICACH_YEUCAU");
            da.InsertCommand.Parameters.Add("@SP_QUICACH_DONGGOI", SqlDbType.NVarChar, 255, "SP_QUICACH_DONGGOI");
            da.InsertCommand.Parameters.Add("@SP_NUOCSX_ID", SqlDbType.BigInt, 5, "SP_NUOCSX_ID");
            da.InsertCommand.Parameters.Add("@SP_SOTHONGTU", SqlDbType.NVarChar, 255, "SP_SOTHONGTU");
            //UPDATE
            string str_update = "update DM_SANPHAM set SP_MA=@SP_MA, SP_TEN=@SP_TEN, DVT_ID=@DVT_ID, SP_HAMLUONG=@SP_HAMLUONG "
                + " , SP_DANGDUNG=@SP_DANGDUNG,SP_GOITHAU=@SP_GOITHAU, SP_TENBIETDUOC=@SP_TENBIETDUOC, SP_QUICACH_YEUCAU =@SP_QUICACH_YEUCAU "
                + " , SP_QUICACH_DONGGOI=@SP_QUICACH_DONGGOI, SP_NUOCSX_ID=@SP_NUOCSX_ID, SP_SOTHONGTU=@SP_SOTHONGTU "
                + " where SP_ID=@SP_ID";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            
            da.UpdateCommand.Parameters.Add("@SP_MA", SqlDbType.NVarChar, 255, "SP_MA");
            da.UpdateCommand.Parameters.Add("@SP_TEN", SqlDbType.NVarChar, 255, "SP_TEN");
            da.UpdateCommand.Parameters.Add("@DVT_ID", SqlDbType.BigInt, 5, "DVT_ID");
            da.UpdateCommand.Parameters.Add("@SP_HAMLUONG", SqlDbType.NVarChar, 255, "SP_HAMLUONG");
            da.UpdateCommand.Parameters.Add("@SP_DANGDUNG", SqlDbType.NVarChar, 255, "SP_DANGDUNG");
            da.UpdateCommand.Parameters.Add("@SP_GOITHAU", SqlDbType.BigInt, 5, "SP_GOITHAU");
            da.UpdateCommand.Parameters.Add("@SP_TENBIETDUOC", SqlDbType.NVarChar, 255, "SP_TENBIETDUOC");
            da.UpdateCommand.Parameters.Add("@SP_QUICACH_YEUCAU", SqlDbType.NVarChar, 255, "SP_QUICACH_YEUCAU");
            da.UpdateCommand.Parameters.Add("@SP_QUICACH_DONGGOI", SqlDbType.NVarChar, 255, "SP_QUICACH_DONGGOI");
            da.UpdateCommand.Parameters.Add("@SP_NUOCSX_ID", SqlDbType.BigInt, 10, "SP_NUOCSX_ID");
            da.UpdateCommand.Parameters.Add("@SP_SOTHONGTU", SqlDbType.NVarChar, 255, "SP_SOTHONGTU");
            da.UpdateCommand.Parameters.Add("@SP_ID", SqlDbType.BigInt, 5, "SP_ID");



            //DELETE
            string str_delete = "delete from DM_SANPHAM where SP_ID=@SP_ID";
            da.DeleteCommand = new SqlCommand(str_delete, clsConnection._conn);
            da.DeleteCommand.Parameters.Add("@SP_ID", SqlDbType.BigInt, 5, "SP_ID");
        }

        void SelectData()
        {
            string str = "";
            if(chkAll.Checked)
               str= "SELECT * FROM DM_SANPHAM sp, DM_GOITHAU gt "
                + " WHERE sp.SP_GOITHAU=gt.GOITHAU_ID AND isnull(gt.DELETED,0)=0 "
                + " and DOT_MA='"+clsParameter._dotMaDauThau+"'";
            else 
                str= "SELECT * FROM DM_SANPHAM sp, DM_GOITHAU gt "
                + " WHERE sp.SP_GOITHAU=gt.GOITHAU_ID AND isnull(gt.DELETED,0)=0 "
                + " and DOT_MA='"+clsParameter._dotMaDauThau+"'"
                + " and gt.GOITHAU_ID = " + clsChangeType.change_int(lueGoiThauFilter.EditValue);
            ds = new DataSet();
            da.SelectCommand = new SqlCommand(str, clsConnection._conn);
            da.Fill(ds, "SANPHAM");
            gcGrid.DataSource = ds.Tables["SANPHAM"];
        }

        void Save()
        {
            try
            {
                clsParameter._isLoadHoSoDauThau = true;
                da.Update(ds.Tables["SANPHAM"]);
            }
            catch
            {
                XtraMessageBox.Show("Lưu dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    groupGoiThau.Enabled = false;
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    gvGrid.ActiveFilter.Clear();
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    gvGrid.OptionsBehavior.Editable = true;
                    groupGoiThau.Enabled = false;
                }

                else
                {
                    gvGrid.OptionsBehavior.Editable = false;
                    gvGrid.OptionsView.ShowAutoFilterRow = true;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = gvGrid.RowCount > 0;
                    groupGoiThau.Enabled = true;
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
            
            if (FunctionHelper.DataUsed("DM_SANPHAM", Convert.ToInt32(gvGrid.GetFocusedRowCellValue(colSP_ID)))) return;

            string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colSP_TEN.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa sản phẩm: \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                gvGrid.DeleteSelectedRows();
                Save();
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
            if (gvGrid.FocusedColumn.FieldName == colSP_MA.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colSP_MA.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
                else if (gvGrid._ValidationSame(colSP_MA,e.Value +string.Empty))
                {
                    e.ErrorText = colSP_MA.Caption + " không được trùng.";
                    e.Valid = false;
                }
            }
            if (gvGrid.FocusedColumn.FieldName == colSP_TEN.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colSP_TEN.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
                
            }

            if (gvGrid.FocusedColumn.FieldName == colSP_DVT.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value +string.Empty))
                {
                    e.ErrorText = colSP_DVT.Caption + " không được phép rỗng.";
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

            if (gvGrid.GetRowCellValue(e.RowHandle, colSP_TEN.FieldName).ToString().Trim().Length == 0)
            {
                gvGrid.SetColumnError(gvGrid.Columns[colSP_TEN.FieldName], colSP_TEN.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
            if ((gvGrid.GetRowCellValue(e.RowHandle, colSP_DVT.FieldName) +string.Empty).Trim().Length == 0)
            {
                gvGrid.SetColumnError(gvGrid.Columns[colSP_DVT.FieldName], colSP_DVT.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
            if ((gvGrid.GetRowCellValue(e.RowHandle, colSP_GOITHAU.FieldName) + string.Empty).Trim().Length == 0)
            {
                gvGrid.SetColumnError(gvGrid.Columns[colSP_GOITHAU.FieldName], colSP_GOITHAU.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
        }
        #endregion

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            SelectData();
            lueGoiThauFilter.Enabled = !chkAll.Checked;
        }

        private void gvGrid_RowCountChanged(object sender, EventArgs e)
        {
            if(FormStatus==EnumFormStatus.VIEW)
            btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = gvGrid.RowCount > 0;
        }

        private void lueGoiThauFilter_EditValueChanged(object sender, EventArgs e)
        {
            SelectData();

            if (FunctionHelper.LaGoiVTYT(Convert.ToInt64(lueGoiThauFilter.EditValue)))
            {
                colBandTENSP.Caption = "Tên vật tư tiêu hao";
                colBanDANG_BAO_CHE.Visible = colBandHAM_LUONG.Visible
                    = colBandTEN_BIET_DUOC.Visible
                = false;

                colBandQUICACH.Visible = colBandKHUVUC_SX.Visible
                    = colBandTIEU_CHUAN_KYTHAT.Visible
               = true;
            }
            else
            {
                colBandTENSP.Caption = "Tên sản phẩm";
                colBanDANG_BAO_CHE.Visible = colBandHAM_LUONG.Visible
                   = colBandTEN_BIET_DUOC.Visible
               = true;

                colBandTIEU_CHUAN_KYTHAT.Visible = colBandQUICACH.Visible = colBandKHUVUC_SX.Visible = false;
            }
        }

        private void btnControl_btnEventPrint_Click(object sender, EventArgs e)
        {
            string str;
            //if (chkAll.Checked)
            //    str = "SELECT sp.*, dvt.TEN DVT_TEN, gt.TEN GOITHAU_TEN FROM DM_SANPHAM sp "
            //        + " LEFT JOIN dbo.DM_GOITHAU gt ON gt.GOITHAU_ID = sp.SP_GOITHAU "
            //        + " LEFT JOIN dbo.DM_DVT dvt ON dvt.DVT_ID=sp.DVT_ID "
            //        + " WHERE isnull(gt.DELETED,0)=0 "
            //        + " and DOT_MA='" + clsParameter._dotMaDauThau + "'";
            //else
            str = "SELECT sp.*, dvt.TEN DVT_TEN, gt.TEN GOITHAU_TEN, sx.TEN NUOCSX_TEN FROM DM_SANPHAM sp "
                + " LEFT JOIN DM_GOITHAU gt ON gt.GOITHAU_ID = sp.SP_GOITHAU "
                + " LEFT JOIN DM_NUOCSX sx ON sx.NUOCSX_ID = sp.SP_NUOCSX_ID "
                + " LEFT JOIN DM_DVT dvt ON dvt.DVT_ID=sp.DVT_ID "
                + " WHERE isnull(gt.DELETED,0)=0 "
                + " and DOT_MA='" + clsParameter._dotMaDauThau + "'"
                + " and gt.GOITHAU_ID = " + clsChangeType.change_int(lueGoiThauFilter.EditValue)
                + " order by sp.SP_MA asc";
            DataTable dt = new DataTable();
            da.SelectCommand = new SqlCommand(str, clsConnection._conn);
            da.Fill(dt);
            XtraReport _rpt = new XtraReport();
            if (FunctionHelper.LaGoiVTYT(Convert.ToInt64(lueGoiThauFilter.EditValue)))
            {
                rptDsSanPham_VTYT rpt = new rptDsSanPham_VTYT();
                rpt.DataSource = dt;
                rpt.DataMember = "SANPHAM";
                _rpt = rpt;
            }
            else 
            {
                rptDsSanPham rpt = new rptDsSanPham();
                rpt.DataSource = dt;
                rpt.DataMember = "SANPHAM";
                _rpt = rpt;
            }
            
            frmPrint f = new frmPrint(_rpt);
            f.ShowDialog();
        }

        private void btnControl_btnEventExcel_Click(object sender, EventArgs e)
        {
            DevExpress.Utils.WaitDialogForm waitDialogForm = new DevExpress.Utils.WaitDialogForm("Đang xuất excel ...", "Vui lòng chờ giây lát !");
            try
            {
                ExcelManager excelManager = new ExcelManager(true);

                // Print band header
                BandedGridView view = gvGrid;
                view.ExpandAllGroups();
                object[] data = new object[view.VisibleColumns.Count];
                excelManager.BandedGridHeader2Excel(view, false, 7, 1, "headerRangeName");
                excelManager.SetTitleRows();
                excelManager.SelectRange()
                           .SetFontFamily("Times New Roman");

                waitDialogForm.SetCaption(String.Format("{0} - {1}%", "Đang xuất excel ...", 50));

                excelManager.GridData2Excel(gvGrid, 8, 1, false, false, "", false, false);

                excelManager.SelectRange(excelManager.WorkingRange.Row + excelManager.WorkingRange.Rows.Count, excelManager.WorkingRange.Column,
                    excelManager.WorkingRange.Row + excelManager.WorkingRange.Rows.Count, excelManager.WorkingRange.Column + excelManager.WorkingRange.Columns.Count - 1);


                // Save working range
                excelManager.MoveRange(2, 0);
                //int maxCol = 12;
                //int xtraCol = 2;

                int sr = excelManager.WorkingRange.Row + 1;
                int sc = excelManager.WorkingRange.Column;
                int er = excelManager.WorkingRange.Row + 1;
                int ec = excelManager.WorkingRange.Column + excelManager.WorkingRange.Columns.Count - 1;

                //excelManager.SelectRange(8, 1, 8, maxCol).SetRowHeight("", 45);

                ////Dòng Title
                excelManager
                    .SelectRange(1, 1, 1, 1)
                    .SetFontStyle(true, false, false)
                    .SetFontSize(12)
                    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                    .SetRangeValue(clsParameter.pParentHospital);

                excelManager
                    .SelectRange(2, 1, 2, 1)
                    .SetFontStyle(false, false, false)
                    .SetFontSize(12)
                    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                    .SetRangeValue(clsParameter.pHospital);

                excelManager
                    .SelectRange(4, 1, 4, ec)
                    .Merge()
                    .SetFontStyle(true, false, false)
                    .SetFontSize(16)
                    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                    .SetRangeValue("DANH SÁCH SẢN PHẨM");

                //excelManager
                //    .SelectRange(6, 1, 6, ec)
                //    .Merge()
                //    .SetFontStyle(true, true, false)
                //    .SetFontSize(16)
                //    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                //    .SetRangeValue(clsParameter.pQuyetDinh);             

                excelManager.SelectRange(12, 2, er, ec).AutoFitColumn();
                excelManager.SelectRange(12, 2, er, ec).SetNumberFormat("#,#0");

                excelManager
                .SelectRange(5, ec - 3, 5, ec)
                .Merge()
                .SetFontStyle(false, false, false)
                .SetFontSize(12)
                .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                .SetRangeValue(string.Format("Ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));

               // excelManager
               // .SelectRange(er + 3, ec - 3, er + 3, ec)
               // .Merge()
               // .SetFontStyle(false, false, false)
               // .SetFontSize(12)
               // .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
               // .SetRangeValue("Thư ký");

               // excelManager
               // .SelectRange(er + 6, ec - 3, er + 6, ec)
               // .Merge()
               // .SetFontStyle(false, false, false)
               // .SetFontSize(12)
               // .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
               // .SetRangeValue(clsParameter.pThuKy);

               // excelManager
               // .SelectRange(er + 3, 3, er + 3, 4)
               // .Merge()
               // .SetFontStyle(false, false, false)
               // .SetFontSize(12)
               // .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
               // .SetRangeValue("Giám đốc");

               // excelManager
               //.SelectRange(er + 6, 3, er + 6, 4)
               //.Merge()
               //.SetFontStyle(false, false, false)
               //.SetFontSize(12)
               //.SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
               //.SetRangeValue(clsParameter.pGiamDoc);
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi trong quá trình xuất Excel.\nVui lòng kiểm tra lại biểu mẫu hoặc tài liệu đang mở.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Marshal.ReleaseComObject(excelSheet);
                //Marshal.ReleaseComObject(excelBook);
                //Marshal.ReleaseComObject(books);
                //Marshal.ReleaseComObject(excel);

                waitDialogForm.Close();
            }
        }

       
    }
}
