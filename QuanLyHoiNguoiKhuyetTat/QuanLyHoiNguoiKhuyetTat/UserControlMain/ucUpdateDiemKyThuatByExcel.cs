using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using DauThau.Reports;
using DauThau.Class;
using System.Data.SqlClient;
using DauThau.Forms;
using CuscLibrary.Offices;
using System.Text.RegularExpressions;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucUpdateDiemKyThuatByExcel : DevExpress.XtraEditors.XtraUserControl
    {
        public ucUpdateDiemKyThuatByExcel()
        {
            InitializeComponent();
        }

        enum chonGoiThau
        {
            TATCA_GOITHAU_THUOC = 0,
            TATCA_GOITHAU_VTYT = 1,
            THEO_GOITHAU = 3,
        }

        #region Variable

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        #endregion

        void CommandData()
        {
            //gv._SetDefaultColorRowStyle();
            //UPDATE
            string str_update = "update DAU_THAU set SP_GHICHU=@SP_GHICHU, SP_DIEM_BTC=@SP_DIEM_BTC where DAUTHAU_ID=@DAUTHAU_ID ";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            da.UpdateCommand.Parameters.Add("@SP_GHICHU", SqlDbType.NVarChar, 50, "SP_GHICHU");
            da.UpdateCommand.Parameters.Add("@SP_DIEM_BTC", SqlDbType.Int, 5, "SP_DIEM_BTC");
            da.UpdateCommand.Parameters.Add("@DAUTHAU_ID", SqlDbType.BigInt, 10, "DAUTHAU_ID");
      
        }

        Boolean _loadFirst = false;
        private void ucSanPhamTheoCty_Load(object sender, EventArgs e)
        {
            LibraryDev.PermissionButton(btnControl, null);
            _loadFirst = true;
            lueCongTy.Properties.DataSource =FunctionHelper.LoadDM("select * from DM_CONGTY where DOT_MA='"+clsParameter._dotMaDauThau+"'");
            try
            {
                lueCongTy.ItemIndex = 0;
            }
            catch
            {
            }
            //lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();
            //lueCongTy.ItemIndex = lueGoiThau.ItemIndex = 0;
            CommandData();
            this.FormStatus = EnumFormStatus.VIEW;
            FunctionHelper.PermissionLockButton(btnControl);
            btnControl.btnReport.Text = "Nạp Excel";

            FormHelper.LookUpEdit_Init(lueCongTy);
            FormHelper.LookUpEdit_Init(lueGoiThau);
        }

       
        DataTable dtCol =new DataTable();
        List<GridBand> colGridBandArray = new List<GridBand>();
        List<BandedGridColumn> listBandedGridColumn = new List<BandedGridColumn>();
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //if (colGridBandArray != null)
            //{
            //    for (int i = 0; i < colGridBandArray.Length; i++)
            //    {
            //        gvGrid.Bands.Remove(colGridBandArray[0]);
            //    }
            //}
        }
        void CreateColumn()
        {
            dsDiemKTExcel1 = new DataSets.dsDiemKTExcel();
            //dsSanPhamTheoCty1.DsSanPhamTheoCty.Clear();
            ////Clear all column exits
            //for (int i = 0; i < dtCol.Rows.Count; i++)
            //{
            //    dsSanPhamTheoCty1.DsSanPhamTheoCty.Columns.Remove(dtCol.Rows[i][0].ToString());
            //}

            dtCol = new DataTable();
            string str = "SELECT DISTINCT VIET_TAT ,SORT_NHOM, DIEM_CHUAN FROM dbo.DM_GOITHAU_KYTHUAT a "
                        + " LEFT JOIN dbo.DM_NHOM_KYTHUAT b ON a.NHOM_KYTHUAT_ID = b.NHOM_KYTHUAT_ID "
                        + " LEFT JOIN dbo.DM_NHOM_KYTHUAT_DIEMCHUAN c ON a.GOITHAU_ID = c.GOITHAU_ID AND a.NHOM_KYTHUAT_ID = c.NHOM_KYTHUAT_ID"
                        + " WHERE ";
            
            switch (Convert.ToInt32(rdSelect.EditValue))
            {
                case (Int32)chonGoiThau.TATCA_GOITHAU_THUOC:
                    str += string.Format(" a.GOITHAU_ID in ({0})", FunctionHelper.LoadListGoiThauTheoLoai((Int32)LoaiGoiThau.THUOC));
                    break;
                case (Int32)chonGoiThau.TATCA_GOITHAU_VTYT:
                    str += string.Format(" a.GOITHAU_ID in ({0})", FunctionHelper.LoadListGoiThauTheoLoai((Int32)LoaiGoiThau.VTYT));
                    break;
                case (Int32)chonGoiThau.THEO_GOITHAU:
                    str += " a.GOITHAU_ID =" + clsChangeType.change_int64(lueGoiThau.EditValue);
                    break;
                default:
                    break;
            }
            str += " ORDER BY a.SORT_NHOM";
            dtCol = FunctionHelper.LoadDM(str);
            //int k = bandYCKT.Columns.Count;
            
            //Xóa GridBand
            colGridBandArray = new List<GridBand>();
            foreach (GridBand item in gvGrid.Bands)
            {
                if (item.Name == "colGridBandTT" ||
                    item.Name == "colGridBand_SP_MA" ||
                    item.Name == "colGridBand_TenSP" || 
                    item.Name == "colGridBand_DAUTHAUID" ||
                    item.Name == "colGridBandGOITHAU_ID") 
                { 
                    continue; 
                }
                colGridBandArray.Add(item);
            }

            foreach (var item in colGridBandArray)
            {
                gvGrid.Bands.Remove(item);
            }
            
            int countBand = gvGrid.Bands.VisibleBandCount;

            //Xóa BandedGridColumn
            //Nếu không xóa sẽ in excel sai.
            listBandedGridColumn = new List<BandedGridColumn>();
            foreach (BandedGridColumn item in gvGrid.Columns)
            {
                string s = item.Caption;
                if (item.Name == "colSP_MA" ||
                    item.Name == "colSP_TEN"
                    || item.Name == "colTT" || item.Name == "colID" || item.Name == "colGoiThauID")
                {
                    continue;                
                }
                listBandedGridColumn.Add(item);
            }
            foreach (var item in listBandedGridColumn)
            {
                gvGrid.Columns.Remove(item);
            }
            //Thêm mới.
            for (int i = 0; i < dtCol.Rows.Count; i++)
            {
                GridBand colGridBand = new GridBand();
                colGridBand.AppearanceHeader.Options.UseTextOptions = true;
                colGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                colGridBand.VisibleIndex = i + countBand + 1;
                colGridBand.Caption = dtCol.Rows[i]["SORT_NHOM"] + string.Empty;
                this.gvGrid.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { colGridBand });
                //Add Band
                BandedGridColumn col = new BandedGridColumn();
                col.Caption = string.Format("({0})", i+1);//dtCol.Rows[i][0] + string.Empty;
                col.Name = dtCol.Rows[i][0] + string.Empty;
                col.FieldName = dtCol.Rows[i][0] + string.Empty;
                col.OptionsColumn.AllowEdit = false;
                col.Visible = true;
                gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { col });
                
                colGridBand.Columns.Add(col);

                //Add Column Dataset
                dsDiemKTExcel1.DiemKT.Columns.Add(dtCol.Rows[i][0].ToString(), typeof(String));
            }
            //bandYCKT.Width = 45 * bandYCKT.Columns.Count;
        }

        void GetData()
        {
            string str = "SELECT ROW_NUMBER() OVER(ORDER BY dt.SP_MA) AS TT,dt.SP_MA,DAUTHAU_ID, sp.SP_TEN,sp.SP_QUICACH_YEUCAU, sp.SP_TENBIETDUOC "
                         + " ,dt.SP_TEN_THUONGMAI, dt.DONG_GOI SP_QUICACH_DONGGOI, TONG_DIEM_KT, ISNULL(GIA_SUADOI,GIA_CHAOTHAU) GIA_CHAOTHAU "
                         + " , SP_DIEM_BTC, dt.SP_GHICHU, dvt.TEN TENDONVITINH, sp.SP_HAMLUONG, sp.SP_DANGDUNG, nsx.TEN TENNUOCSX, GOITHAU_ID "
                         + " FROM DAU_THAU dt "
                         + " JOIN DM_SANPHAM sp ON dt.SP_MA = sp.SP_MA "
                         + " LEFT JOIN DM_DVT dvt ON dvt.DVT_ID = sp.DVT_ID "
                         + " LEFT JOIN DM_NUOCSX nsx ON nsx.NUOCSX_ID = sp.SP_NUOCSX_ID " //ON nsx.NUOCSX_ID = dt.NUOCSX_ID
                         + " WHERE CTY_MA = '"+ (lueCongTy.EditValue + string.Empty) +"'";

            switch (Convert.ToInt32(rdSelect.EditValue))
            {
                case (Int32)chonGoiThau.TATCA_GOITHAU_THUOC:
                    str += string.Format(" AND GOITHAU_ID in ({0})", FunctionHelper.LoadListGoiThauTheoLoai((Int32)LoaiGoiThau.THUOC)); 
                    break;
                case (Int32)chonGoiThau.TATCA_GOITHAU_VTYT:
                    str += string.Format(" AND GOITHAU_ID in ({0})", FunctionHelper.LoadListGoiThauTheoLoai((Int32)LoaiGoiThau.VTYT)); 
                    break;
                case (Int32)chonGoiThau.THEO_GOITHAU:
                    str += " AND GOITHAU_ID =" + clsChangeType.change_int64(lueGoiThau.EditValue);
                    break;
                default:
                    break;
            }
            SqlDataAdapter d = new SqlDataAdapter(str, clsConnection._conn);
            d.Fill(dsDiemKTExcel1.DiemKT);
        }

        void BindingData()
        {
            string str = "SELECT a.DAUTHAU_ID, a.SP_MA, VIET_TAT, a.DIEM FROM dbo.DAUTHAU_CT a "
                            + " JOIN dbo.DM_NHOM_KYTHUAT_CT b ON a.NHOM_KYTHUAT_CT_ID = b.NHOM_KYTHUAT_CT_ID "
                            + " JOIN dbo.DM_GOITHAU_KYTHUAT c ON b.NHOM_KYTHUAT_CT_ID = c.NHOM_KYTHUAT_CT_ID AND a.GOITHAU_ID = c.GOITHAU_ID "
                            + " JOIN dbo.DM_NHOM_KYTHUAT d ON d.NHOM_KYTHUAT_ID = c.NHOM_KYTHUAT_ID "
                            + " WHERE CTY_MA = '" + (lueCongTy.EditValue + string.Empty) + "'";

            switch (Convert.ToInt32(rdSelect.EditValue))
            {
                case (Int32)chonGoiThau.TATCA_GOITHAU_THUOC:
                    str += string.Format(" AND a.GOITHAU_ID in ({0})", FunctionHelper.LoadListGoiThauTheoLoai((Int32)LoaiGoiThau.THUOC));
                    break;
                case (Int32)chonGoiThau.TATCA_GOITHAU_VTYT:
                    str += string.Format(" AND a.GOITHAU_ID in ({0})", FunctionHelper.LoadListGoiThauTheoLoai((Int32)LoaiGoiThau.VTYT));
                    break;
                case (Int32)chonGoiThau.THEO_GOITHAU:
                    str += " AND a.GOITHAU_ID =" + clsChangeType.change_int64(lueGoiThau.EditValue);
                    break;
                default:
                    break;
            }
            str += " ORDER BY a.SP_MA,c.SORT_NHOM";
            SqlDataAdapter d = new SqlDataAdapter(str, clsConnection._conn);
            DataTable t = new DataTable();
            d.Fill(t);

            for (int i = 0; i < dsDiemKTExcel1.DiemKT.Rows.Count; i++)
            {
                int TongDiemKT = 0;
                DataRow[] r = t.Select(string.Format("SP_MA='{0}' and DAUTHAU_ID ={1}", dsDiemKTExcel1.DiemKT.Rows[i]["SP_MA"].ToString(), dsDiemKTExcel1.DiemKT.Rows[i]["DAUTHAU_ID"].ToString()));
                foreach (DataRow item in r)
                {
                    dsDiemKTExcel1.DiemKT.Rows[i][item["VIET_TAT"].ToString()] = item["DIEM"].ToString();
                    TongDiemKT = TongDiemKT + clsChangeType.change_int(item["DIEM"]);
                }

                ////Cập nhật tổng điểm
                //dsDiemKTExcel1.DiemKT.Rows[i]["TONG_DIEM_KT"] = TongDiemKT;

                ////Nếu Có điểm của BTC thì in điểm BTC ngược lại lấy tổng điểm.
                //dsDiemKTExcel1.DiemKT.Rows[i]["SP_TONGDIEM_PRINT"] = clsChangeType.change_int(dsDiemKTExcel1.DiemKT.Rows[i]["SP_DIEM_BTC"]) > 0 ? dsDiemKTExcel1.DiemKT.Rows[i]["SP_DIEM_BTC"] : dsDiemKTExcel1.DiemKT.Rows[i]["TONG_DIEM_KT"];
            }
        }
        
       
        public EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.MODIFY)
                {
                    
                }

                else
                {
                   
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    btnControl.btnPrint.Enabled= btnControl.btnModify.Enabled = gvGrid.RowCount > 0;
                }
            }
        }

        void SelectData()
        {
            CreateColumn();
            GetData();
            BindingData();
            gcGrid.DataSource = dsDiemKTExcel1.DiemKT;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if ((lueCongTy.EditValue == null || lueGoiThau.EditValue == null) && !_loadFirst)
            {
                clsMessage.MessageWarning("Vui lòng chọn Công ty và gói thầu.");
                return;
            }
            _loadFirst = false;
            SelectData();
        }

        private void btnControl_btnEventModify_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.MODIFY;
        }

        private void btnControl_btnEventSave_Click(object sender, EventArgs e)
        {

            SelectData();
            this.FormStatus = EnumFormStatus.VIEW;
        }

        private void btnControl_btnEventCancel_Click(object sender, EventArgs e)
        {
            SelectData();
            this.FormStatus = EnumFormStatus.VIEW;
        }

        private void gv_RowCountChanged(object sender, EventArgs e)
        {
            btnControl.btnModify.Enabled = btnControl.btnPrint.Enabled = gvGrid.RowCount > 0;
        }

        private void lueCongTy_EditValueChanged(object sender, EventArgs e)
        {
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThauTheoCongTy(lueCongTy.EditValue +string.Empty);
            try
            {
                lueGoiThau.ItemIndex = 0;
            }
            catch 
            {
            }
            btnXem.PerformClick();
        }

        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            btnXem.PerformClick();
        }

        private void repUpdateDiemKT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
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
                excelManager.BandedGridHeader2Excel(view, false, 1, 1, "headerRangeName");
                excelManager.SetTitleRows();
                excelManager.SelectRange()
                           .SetFontFamily("Times New Roman");

                waitDialogForm.SetCaption(String.Format("{0} - {1}%", "Đang xuất excel ...", 50));

                excelManager.GridData2Excel(gvGrid, 2, 1, false, false, "", false, false);

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

                excelManager.SelectRange(12, 2, er, ec).AutoFitColumn();
                excelManager.SelectRange(12, 2, er, ec).SetNumberFormat("#,#0");

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

        private void btnControl_btnEventReport_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            if (f.FileName != string.Empty)
            {
                clsParameter._isLoadHoSoDauThau = true;
                try
                {
                    DataTable dataImport = ExcelHelper.ImportFile(f.FileName);
                    string strNhomKyThuat = "select * from ( "
                                 + " select distinct NHOM_KYTHUAT_ID, SORT_NHOM from dbo.DM_GOITHAU_KYTHUAT where GOITHAU_ID in ({0})"
                                 + " ) tmp order by SORT_NHOM";

                    string listGoiThau = string.Empty;
                    switch (Convert.ToInt32(rdSelect.EditValue))
                    {
                        case (Int32)chonGoiThau.TATCA_GOITHAU_THUOC:
                            listGoiThau = FunctionHelper.LoadListGoiThauTheoLoai((Int32)LoaiGoiThau.THUOC);
                            break;
                        case (Int32)chonGoiThau.TATCA_GOITHAU_VTYT:
                            listGoiThau = FunctionHelper.LoadListGoiThauTheoLoai((Int32)LoaiGoiThau.VTYT);
                            break;
                        case (Int32)chonGoiThau.THEO_GOITHAU:
                            listGoiThau = lueGoiThau.EditValue + string.Empty;
                            break;
                        default:
                            break;
                    }

                    strNhomKyThuat = string.Format(strNhomKyThuat, listGoiThau);
                    DataTable dtNhomKyThuat = FunctionHelper.LoadDM(strNhomKyThuat);
                    foreach (DataRow row in dataImport.Rows)
                    {
                        if (string.IsNullOrEmpty(row["ID"] + string.Empty) || string.IsNullOrEmpty(row["Mã SP"] + string.Empty))
                        {
                            continue;
                        }

                        #region Cập nhật điểm kỹ thuật
                        
                        foreach (DataColumn col in row.Table.Columns)
                        {
                            if (!Regex.IsMatch(col.ColumnName, @"^\d+$"))
                            {
                                continue;
                            }
                            DataRow[] rowNhomKyThuat = dtNhomKyThuat.Select("SORT_NHOM = " + col.ColumnName);
                            if (rowNhomKyThuat.Length > 0)
                            {
                                string nhomKyThuatId = rowNhomKyThuat[0]["NHOM_KYTHUAT_ID"] + string.Empty;
                                using (SqlCommand cmd = new SqlCommand())
                                {
                                    cmd.CommandText = string.Format("Update DAUTHAU_CT set DIEM = {0} where DAUTHAU_ID = {1} and CTY_MA = '{2}' "
                                        + " and GOITHAU_ID = {3} and SP_MA = '{4}' and NHOM_KYTHUAT_ID = {5}"
                                        , row[col.ColumnName]
                                        , row["ID"]
                                        , lueCongTy.EditValue + string.Empty
                                        , row["Gói thầu ID"]
                                        , row["Mã SP"]
                                        , nhomKyThuatId
                                        );
                                    cmd.Connection = clsConnection._conn;
                                    cmd.CommandType = CommandType.Text;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                clsMessage.MessageWarning(string.Format("Cột \"{0}\" không tồn tại trong nhóm kỹ thuật", col.ColumnName));
                            }

                        }

                        #endregion

                    }
                    clsMessage.MessageInfo("Cập nhật điểm kỹ thuật thành công.");
                    btnXem.PerformClick();
                }
                catch (Exception ex)
                {
                    clsMessage.MessageWarning(ex.Message);
                }
            }
        }

        private void rdSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            lueGoiThau.Enabled = Convert.ToInt32(rdSelect.EditValue) == (Int32)chonGoiThau.THEO_GOITHAU;
            btnXem.PerformClick();
        }


        
        
    }
}
