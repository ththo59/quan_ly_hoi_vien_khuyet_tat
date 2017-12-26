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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Linq;
using CuscLibrary.Offices;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucCongTy : DevExpress.XtraEditors.XtraUserControl
    {
        public ucCongTy()
        {
            InitializeComponent();
        }

        private void ucCongTy_Load(object sender, EventArgs e)
        {
            createColumnGoiThau();

            //lueDotDauThau.Properties.DataSource = FunctionHelper.LoadDM("select * from DOT_DAUTHAU");
            SelectData();
            cboGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();
            cboCheck.DataSource = FunctionHelper.LoadGoiThau();
            FormStatus = EnumFormStatus.VIEW;
            FunctionHelper.PermissionLockButton(btnControl);

            
        }

        /// <summary>
        /// Tạo cột gới thầu
        /// </summary>
        void createColumnGoiThau()
        {

            //List<GridBand>  colGridBandArray = new List<GridBand>();
            //foreach (GridBand item in gvGrid.Bands)
            //{
            //    if (item.Name == "gridBand1" ||
            //        item.Name == "gridBand2" ||
            //        item.Name == "gridBand3" ||
            //        item.Name == "gridBand4" ||)
            //    {
            //        continue;
            //    }
            //    colGridBandArray.Add(item);
            //}

            //foreach (var item in colGridBandArray)
            //{
            //    gvGrid.Bands.Remove(item);
            //}
            ////Xóa BandedGridColumn
            ////Nếu không xóa sẽ in excel sai.
            //List<BandedGridColumn>  listBandedGridColumn = new List<BandedGridColumn>();
            //foreach (BandedGridColumn item in gvGrid.Columns)
            //{
            //    string s = item.Caption;
            //    if (item.Name == "colSP_MA" ||
            //        item.Name == "colSP_TEN"
            //        || item.Name == "colTT" || item.Name == "colID" || item.Name == "colGoiThauID")
            //    {
            //        continue;
            //    }
            //    listBandedGridColumn.Add(item);
            //}
            //foreach (var item in listBandedGridColumn)
            //{
            //    gvGrid.Columns.Remove(item);
            //}
            int countBand = gvGrid.Bands.VisibleBandCount;
            DataTable dtCol = FunctionHelper.LoadGoiThau();
            for (int i = 0; i < dtCol.Rows.Count; i++)
            {
                //Add Band
                //BandedGridColumn col = new BandedGridColumn();
                //col.Caption = dtCol.Rows[i]["DIEN_GIAI"] + string.Empty;
                //col.AppearanceCell.TextOptions.VAlignment =DevExpress.Utils.VertAlignment.Center;
                //col.Name = dtCol.Rows[i]["GOITHAU_ID"] + string.Empty;
                //col.FieldName = dtCol.Rows[i]["GOITHAU_ID"] + string.Empty;
                //col.OptionsColumn.AllowEdit = false;
                //col.Visible = true;
                //gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { col });
                //colBandGoiThau.Columns.Add(col);

                GridBand colGridBand = new GridBand();
                colGridBand.AppearanceHeader.Options.UseTextOptions = true;
                colGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                colGridBand.VisibleIndex = i + countBand + 1;
                colGridBand.Caption = dtCol.Rows[i]["DIEN_GIAI"] + string.Empty;
                colGridBand.Width = 300;
                this.gvGrid.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { colGridBand });

                //Add Band
                BandedGridColumn col = new BandedGridColumn();
                col.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                col.Caption = string.Format("({0})", i + 1);//dtCol.Rows[i][0] + string.Empty;
                col.Name = dtCol.Rows[i]["GOITHAU_ID"] + string.Empty;
                col.FieldName = dtCol.Rows[i]["GOITHAU_ID"] + string.Empty;
                col.OptionsColumn.AllowEdit = false;
                col.Visible = true;
                gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { col });

                colGridBand.Columns.Add(col);

                //Add Column Dataset
                dtCongTy.Columns.Add(dtCol.Rows[i]["GOITHAU_ID"].ToString(), typeof(String));
            }
            //colBandCongTy.Width = 600;
            //colBandGoiThau.Width = 100 * colBandGoiThau.Columns.Count;

            colGridBand_CTY_MA.Width = 100;
            colGridBand_CTY_TEN.Width = 250;
            colGridBand_CTY_DIACHI.Width = 200;
            colGridBand_CTY_DIENTHOAI.Width = 100;
            colGridBandCTY_LOAI_PL.Width = 100;
            foreach (GridBand item in gvGrid.Bands)
            {
                if (item.Name == "colGridBand_CTY_MA" ||
                    item.Name == "colGridBand_CTY_TEN" ||
                    item.Name == "colGridBand_CTY_DIACHI" ||
                    item.Name == "colGridBand_CTY_DIENTHOAI" ||
                    item.Name == "colGridBandCTY_LOAI_PL")
                {
                    continue;
                }
                item.Width = 120;
            }

            //set dữ liệu gói thầu
            for (int i = 0; i < dtCongTy.Rows.Count; i++)
            {
                string[] listGoiThau = (dtCongTy.Rows[i]["LIST_GOITHAU"] + string.Empty).Split(',');
                foreach (String goiThauID in listGoiThau)
                {
                    dtCongTy.Rows[i][goiThauID.Trim()] = "x";
                }
            }
        }
        private void lueDotDauThau_EditValueChanged(object sender, EventArgs e)
        {
            //gcGrid.DataSource = FunctionHelper.LoadDM("select * from DM_CONGTY where DOT_MA = '"+ clsParameter._dotMaDauThau +"'");
        }

        #region Variable

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dtCongTy = new DataTable();
        #endregion

        #region Function

        void SelectData()
        {
            dtCongTy = FunctionHelper.LoadDM("select * from DM_CONGTY where DOT_MA = '" + clsParameter._dotMaDauThau + "'");
            DataTable dtCol = FunctionHelper.LoadGoiThau();
            for (int i = 0; i < dtCol.Rows.Count; i++)
            {
                //Add Column Dataset
                dtCongTy.Columns.Add(dtCol.Rows[i]["GOITHAU_ID"].ToString(), typeof(String));
            }

            //set dữ liệu gói thầu
            for (int i = 0; i < dtCongTy.Rows.Count; i++)
            {
                string[] listGoiThau = (dtCongTy.Rows[i]["LIST_GOITHAU"] + string.Empty).Split(',');
                
                foreach (String goiThauID in listGoiThau)
                {
                    if (goiThauID.Trim() != "")
                    {
                        dtCongTy.Rows[i][goiThauID.Trim()] = "x";
                    }
                }
            }

            gcGrid.DataSource = dtCongTy;
        }

        Boolean InsertData()
        {
            try
            {
                string str = "Insert into DM_CONGTY (CTY_MA,TEN, DIACHI,DIENTHOAI,FAX,EMAIL,DOT_MA, LIST_GOITHAU) values (@CTY_MA,@TEN, @DIACHI, @DIENTHOAI, @FAX, @EMAIL,@DOT_MA, @LIST_GOITHAU)";
                SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                cmd.Parameters.Add("@CTY_MA", SqlDbType.NVarChar).Value = txtMa.Text.Trim();
                cmd.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = txtTen.Text;
                cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                cmd.Parameters.Add("@DIENTHOAI", SqlDbType.NVarChar).Value = txtDienThoai.Text;
                cmd.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = txtFax.Text;
                cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@DOT_MA", SqlDbType.NVarChar).Value = clsParameter._dotMaDauThau;
                cmd.Parameters.Add("@LIST_GOITHAU", SqlDbType.NVarChar).Value = cboGoiThau.EditValue + string.Empty;
                cmd.ExecuteNonQuery();
                SelectData();

                //Cập nhật mã tự tăng.

                SqlCommand cmd1 = new SqlCommand("sp_AutoNumberCompany", clsConnection._conn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Violation of PRIMARY KEY"))
                {
                    clsMessage.MessageWarning("Mã công ty không được trùng.Vui lòng nhập mã khác.");
                }else clsMessage.MessageWarning("Có lỗi phát sinh vui lòng kiểm tra lỗi.\nError: " + ex.Message);
                return false;
            }
            
        }

        Boolean UpdateData()
        {
            try
            {
                string str = "Update DM_CONGTY set TEN=@TEN, DIACHI=@DIACHI, DIENTHOAI=@DIENTHOAI "
                    + " , FAX=@FAX, EMAIL=@EMAIL, LIST_GOITHAU = @LIST_GOITHAU, CTY_LOAI_PL = @CTY_LOAI_PL where CTY_MA=@CTY_MA ";
                SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                
                cmd.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = txtTen.Text;
                cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                cmd.Parameters.Add("@DIENTHOAI", SqlDbType.NVarChar).Value = txtDienThoai.Text;
                cmd.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = txtFax.Text;
                cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@LIST_GOITHAU", SqlDbType.NVarChar).Value = cboGoiThau.EditValue + string.Empty;
                cmd.Parameters.Add("@CTY_MA", SqlDbType.NVarChar).Value = txtMa.Text;
                cmd.Parameters.Add("@CTY_LOAI_PL", SqlDbType.Bit).Value = chkLoaiPL.Checked;
                cmd.ExecuteNonQuery();
                SelectData();

                //Cập nhật các sản phẩm của công ty
                return true;
            }
            catch (Exception ex)
            {
                clsMessage.MessageWarning("Có lỗi phát sinh vui lòng kiểm tra lỗi.\nError: " + ex.InnerException.Message);
                return false;
            }
        }

        Boolean DeleteData()
        {
            try
            {
                string str = "delete from DAU_THAU WHERE CTY_MA =@CTY_MA; delete from DAUTHAU_CT WHERE CTY_MA =@CTY_MA; delete from DM_CONGTY where CTY_MA=@CTY_MA";
                SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                cmd.Parameters.Add("@CTY_MA", SqlDbType.NVarChar).Value = txtMa.Text;
                cmd.ExecuteNonQuery();
                SelectData();
                return true;
            }
            catch (Exception ex)
            {
                clsMessage.MessageWarning("Có lỗi phát sinh vui lòng kiểm tra lỗi.\nError: " + ex.Message);
                return false;
            }
        }

        Boolean Save()
        {
            clsParameter._isLoadHoSoDauThau = true;
            if (_formStatus == EnumFormStatus.ADD)
                return InsertData();
            else if (_formStatus == EnumFormStatus.MODIFY)
                return UpdateData();
            else
               return DeleteData();

        }

        void BindingData()
        {
            if (gvGrid.RowCount > 0)
            {
                txtMa.Text = gvGrid.GetFocusedRowCellValue(colCTY_MA) + string.Empty;
                txtTen.Text = gvGrid.GetFocusedRowCellValue(colTEN) + string.Empty;
                txtDiaChi.Text = gvGrid.GetFocusedRowCellValue(colDIACHI) + string.Empty;
                txtDienThoai.Text = gvGrid.GetFocusedRowCellValue(colDIENTHOAI) + string.Empty;
                txtFax.Text = gvGrid.GetFocusedRowCellValue(colFAX) + string.Empty;
                txtEmail.Text = gvGrid.GetFocusedRowCellValue(colEMAIL) + string.Empty;
                chkLoaiPL.Checked = clsChangeType.change_bool(gvGrid.GetFocusedRowCellValue(colCTY_LOAI_PL));
                if ((gvGrid.GetFocusedRowCellValue(colLIST_GOITHAU) + string.Empty).Length == 0)
                    cboGoiThau.Text= null;
                else 
                cboGoiThau.EditValue = gvGrid.GetFocusedRowCellValue(colLIST_GOITHAU) + string.Empty;
                cboGoiThau.RefreshEditValue();
                
            }
        }

        void ClearField()
        {
            txtTen.EditValue = txtDiaChi.EditValue = txtDienThoai.EditValue = txtEmail.EditValue = txtFax.EditValue = null;
            cboGoiThau.EditValue = null;
            cboGoiThau.RefreshEditValue();
        }

        Boolean ValidateData()
        {
            dxErrorProvider1.ClearErrors();
            if (txtTen.Text.Trim() == "")
                dxErrorProvider1.SetError(txtTen, "Tên công ty không rỗng");
            
            if (txtDiaChi.Text.Trim() == "")
                dxErrorProvider1.SetError(txtDiaChi, "Địa chỉ không rỗng");
            
            if (txtDienThoai.Text.Trim() == "")
                dxErrorProvider1.SetError(txtDienThoai, "Điện thoại không rỗng");

            //if (txtEmail.Text.Trim() == "")
            //    dxErrorProvider1.SetError(txtEmail, "Email không rỗng");
            
            //if (txtFax.Text.Trim() == "")
            //    dxErrorProvider1.SetError(txtFax, "Fax không rỗng");

            if (cboGoiThau.Text.Trim() == "")
                dxErrorProvider1.SetError(cboGoiThau, "Vui lòng chọn gói thầu tham gia đấu");

            if (dxErrorProvider1.HasErrors)
                clsMessage.MessageInfo("Vui lòng nhập đầy đủ thông tin");

            return dxErrorProvider1.HasErrors;
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
                    txtTen.Enabled = txtDiaChi.Enabled = txtDienThoai.Enabled
                    = txtFax.Enabled = txtEmail.Enabled = cboGoiThau.Enabled = true;
                    txtMa.Enabled = true;
                    txtMa.Text = FunctionHelper.LayMaTuTangCongTy();
                    gcGrid.Enabled = false;
                    ClearField();
                    txtTen.Focus();
                    chkLoaiPL.Enabled = true;
                    btnSelectFile.Enabled = true;
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                     txtTen.Enabled = txtDiaChi.Enabled = txtDienThoai.Enabled
                    = txtFax.Enabled = txtEmail.Enabled = cboGoiThau.Enabled = true;
                     gcGrid.Enabled = false;
                    chkLoaiPL.Enabled = true;
                    btnSelectFile.Enabled = false;
                }

                else
                {
                    dxErrorProvider1.ClearErrors();
                    gvGrid.OptionsBehavior.Editable = false;
                    gvGrid.OptionsView.ShowAutoFilterRow = true;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    txtTen.Enabled = txtDiaChi.Enabled = txtDienThoai.Enabled
                    = txtFax.Enabled = txtEmail.Enabled = cboGoiThau.Enabled = txtMa.Enabled = false;
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = gvGrid.RowCount > 0;
                    gcGrid.Enabled = true;
                    BindingData();
                    chkLoaiPL.Enabled = false;
                    btnSelectFile.Enabled = false;
                }
            }
        }

        #endregion

        #region Event Button

        private void btnControl_btnEventAdd_Click(object sender, EventArgs e)
        {
            if (clsParameter._dotMaDauThau == string.Empty)
            {
                clsMessage.MessageInfo("Vui lòng chọn đợt đấu thầu cần thao tác");
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

            string _tencty = gvGrid.GetFocusedRowCellValue(colTEN) + string.Empty;
            string str = string.Format("Bạn có chắc muốn xóa công ty: \"{0}\".\nTất cả các thông tin đấu thầu (nếu có) của công ty này sẽ bị xóa.",_tencty);
            if (XtraMessageBox.Show(str, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
              
                Save();
                BindingData();
            }
        }

        private void btnControl_btnEventModify_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.MODIFY;
        }
        Boolean KiemTraCtyMa()
        {
            try
            {
                if (txtMa.Text.Trim().Length != 10) //!txtMa.Text.Contains("CTY" + DateTime.Now.Year) ||
                    return false;
                Int32 num = Convert.ToInt32(txtMa.Text.Substring(7));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnControl_btnEventSave_Click(object sender, EventArgs e)
        {
            if (ValidateData()) return;

            if (!KiemTraCtyMa())
            {
                clsMessage.MessageWarning("Nhập mã công ty (CTYAAAABBB) không đúng định dạng.\nAAAA: năm; BBB: số thứ thự công ty.");
                return;
            }

            if(Save())
            this.FormStatus = EnumFormStatus.VIEW;
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

        private void cboGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            string str = cboGoiThau.EditValue + string.Empty;
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
                excelManager.BandedGridHeader2Excel(view, false, 6, 1, "headerRangeName");
                excelManager.SetTitleRows();
                excelManager.SelectRange()
                           .SetFontFamily("Times New Roman");

                waitDialogForm.SetCaption(String.Format("{0} - {1}%", "Đang xuất excel ...", 50));

                excelManager.GridData2Excel(gvGrid, 7, 1, false, false, "", false, false);

                //excelManager.SelectRange(excelManager.WorkingRange.Row + excelManager.WorkingRange.Rows.Count, excelManager.WorkingRange.Column,
                //    excelManager.WorkingRange.Row + excelManager.WorkingRange.Rows.Count, excelManager.WorkingRange.Column + excelManager.WorkingRange.Columns.Count - 1);


                // Save working range
                //excelManager.MoveRange(2, 0);
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
                    .SetRangeValue("DANH MỤC CÔNG TY MUA HỒ SƠ MỜI THẦU");

                excelManager.SelectRange(10, 2, er, ec).AutoFitColumn();
                //excelManager.SelectRange(11, 2, er, ec).SetNumberFormat("#,#0");

            }
            catch (Exception ex)
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

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "(*.xml)|*.xml";
            if (file.ShowDialog() == DialogResult.OK) {
                DataSet ds = new DataSet();
                ds.ReadXml(file.FileName);
                if (ds.Tables.Contains("Company") && ds.Tables["Company"].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables["Company"];
                    string _maCty = dt.Rows[0]["CTY_MA"] + string.Empty;
                    if (_maCty == txtMa.Text)
                    {
                        txtTen.Text = dt.Rows[0]["TEN"] + string.Empty;
                        txtDiaChi.Text = dt.Rows[0]["DIACHI"] + string.Empty;
                        txtDienThoai.Text= dt.Rows[0]["DIENTHOAI"] + string.Empty;
                        txtEmail.Text = dt.Rows[0]["EMAIL"] + string.Empty;
                        txtFax.Text= dt.Rows[0]["FAX"] + string.Empty;

                        //lấy danh sách gói thầu của công ty.
                        if (ds.Tables.Contains("Tender") && ds.Tables["Tender"].Rows.Count > 0)
                        {
                            var listGoiThau = (from row in ds.Tables["Tender"].AsEnumerable()
                                                 select row.Field<string>("GOITHAU_ID")).Distinct().ToList();
                            if (listGoiThau.Count > 0)
                            {
                                string checkGoiThau = string.Empty;
                                foreach (string goithau in listGoiThau)
                                {
                                    if (string.IsNullOrEmpty(checkGoiThau))
                                    {
                                        checkGoiThau = goithau;
                                    }
                                    else
                                    {
                                        checkGoiThau = checkGoiThau + ", " + goithau;
                                    }
                                }
                                cboGoiThau.EditValue = checkGoiThau;
                                cboGoiThau.RefreshEditValue();
                            }
                        }
                    }
                    else
                    {
                        clsMessage.MessageWarning(string.Format("Mã công ty của file là [{0}] không phù hợp. Vui lòng kiểm tra lại.", _maCty));
                    }
                }
                else {
                    clsMessage.MessageWarning("Dữ liệu công ty không tồn tại. Vui lòng kiểm tra lại.");
                }
            }
        }
    }
}
