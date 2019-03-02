using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using System.Security.Cryptography;
using DevExpress.XtraGrid.Views.BandedGrid;
using CuscLibrary.Offices;
using System.ComponentModel;

namespace DauThau.Class
{
    public static class FunctionHelper
    {
        /// <summary>
        /// Kiểm tra trùng giá trị của một cột trong Grid, với giá trị input
        /// </summary>
        public static Boolean _ValidationSame(this GridView gv, GridColumn colName, string value)
        {
            value = value.ToLower();
            for (int i = 0; i < gv.RowCount; i++)
            {
                if (Convert.ToString(gv.GetRowCellValue(i, colName.FieldName) + string.Empty).ToLower() == value && i != gv.FocusedRowHandle)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Hiển thị màu cho các dòng thêm, sửa, xóa
        /// </summary>
        /// <param name="p_GridView"></param>
        public static void _SetDefaultColorRowStyle(this GridView p_GridView)
        {


            string _addedColor = "-16256";
            string _modifiedColor = "-128";
            string _deletedColor = "-64";


            // Nếu mã màu rỗng thì return
            if (String.IsNullOrEmpty(_addedColor)
                && String.IsNullOrEmpty(_modifiedColor)
                && String.IsNullOrEmpty(_deletedColor))
            {
                return;
            }

            // Set mã màu cho gridView
            p_GridView.RowStyle += (sender, e) =>
            {
                if (e.RowHandle >= 0)
                {
                    var row = p_GridView.GetDataRow(e.RowHandle) as DataRow;

                    //Row null
                    if (row == null)
                    {
                        return;
                    }

                    // Row added
                    if (row.RowState == DataRowState.Added
                        && !String.IsNullOrEmpty(_addedColor))
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml(_addedColor);
                    }
                    // Row modified
                    else if (row.RowState == DataRowState.Modified
                        && !String.IsNullOrEmpty(_modifiedColor))
                    {
                        e.Appearance.BackColor = ColorTranslator.FromHtml(_modifiedColor);
                    }
                }
            };

            // Row deleted
            if (p_GridView.FormatConditions["Deleted"] != null)
            {
                p_GridView.FormatConditions["Deleted"].Appearance.BackColor =
                    ColorTranslator.FromHtml(_deletedColor);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strConnDM"></param>
        /// <returns></returns>
        public static DataTable LoadDM(String strConnDM)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter d = new SqlDataAdapter(strConnDM, clsConnection._conn);
            d.Fill(dt);
            return dt;
        }

        /// <summary>
        /// Thực thi insert, update query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="isInsert"></param>
        /// <returns></returns>
        public static Int32 executeQuery(string query, Boolean isInsert = false)
        {
            Int32 id = 0;
            SqlCommand cmd = new SqlCommand(query, clsConnection._conn);

            if (isInsert)
            {
                return Convert.ToInt32(cmd.ExecuteScalar());
            }

            id = cmd.ExecuteNonQuery();
            return id;
        }
        /// <summary>
        /// kiểm tra gói thầu có phải là VTYT
        /// </summary>
        /// <param name="goiThauId"></param>
        /// <returns></returns>
        public static Boolean LaGoiVTYT(Int64 goiThauId)
        {
            DataTable dt = LoadDM(string.Format("select * from DM_GOITHAU where GOITHAU_ID = {0}", goiThauId));
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["BIEUMAU"] + string.Empty == "VTYT";
            }
            return false;
        }

        /// <summary>
        /// Load gói thầu
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadGoiThau()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter d = new SqlDataAdapter("select * from DM_GOITHAU where isnull(DELETED,0)=0 and DOT_MA='" + clsParameter._dotMaDauThau + "' order by STT asc", clsConnection._conn);
            d.Fill(dt);
            if (dt.Rows.Count == 0)
                clsMessage.MessageInfo("Không có gói thầu nào trong đợt đấu thầu này");
            return dt;
        }

        /// <summary>
        /// Load gói thầu theo công ty.
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadGoiThauTheoCongTy(String maCty)
        {
            try
            {
                string _list = string.Empty;
                DataTable t = LoadDM("select LIST_GOITHAU from DM_CONGTY where CTY_MA='" + maCty + "'");
                if (t.Rows.Count > 0)
                    _list = t.Rows[0][0] + string.Empty;

                DataTable dt = new DataTable();
                SqlDataAdapter d = new SqlDataAdapter(string.Format("select * from DM_GOITHAU where isnull(DELETED,0)=0 and DOT_MA='{0}' and GOITHAU_ID in ({1}) order by STT asc", clsParameter._dotMaDauThau, _list), clsConnection._conn);
                d.Fill(dt);
                if (dt.Rows.Count == 0)
                    clsMessage.MessageInfo("Không có gói thầu nào trong công ty này.");
                return dt;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static string LoadListGoiThauTheoLoai(Int32 loaiGT)
        {
            string listGoiThau = string.Empty;
            string query = string.Format("select * from DM_GOITHAU where isnull(DELETED,0)=0 and DOT_MA='{0}'", clsParameter._dotMaDauThau);
            switch (loaiGT)
            {
                case (Int32)LoaiGoiThau.THUOC:
                    query += " AND BIEUMAU is null";
                    break;
                case (Int32)LoaiGoiThau.VTYT:
                    query += " AND BIEUMAU = 'VTYT'";
                    break;
                default:
                    break;
            }
            query += " order by STT asc";
            DataTable dt = LoadDM(query);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(listGoiThau))
                    {
                        listGoiThau = dt.Rows[i]["GOITHAU_ID"] + string.Empty;
                    }
                    else
                    {
                        listGoiThau += "," + dt.Rows[i]["GOITHAU_ID"] + string.Empty;
                    }
                }
            }
            return listGoiThau;
        }
        
        /// <summary>
        /// Khóa các control nhập liệu khi khóa dữ liệu đợt đấu thầu.
        /// </summary>
        /// <param name="btnControl"></param>
        public static void PermissionLockButton(ControlsLib.ButtonsArray btnControl)
        {
            if (btnControl.btnAdd.Visible)
                btnControl.btnAdd.Visible = !clsParameter._dotKhoaDuLieu;

            if (btnControl.btnModify.Visible)
                btnControl.btnModify.Visible = !clsParameter._dotKhoaDuLieu;

            if (btnControl.btnDelete.Visible)
                btnControl.btnDelete.Visible = !clsParameter._dotKhoaDuLieu;
        }


        /// <summary>
        /// Load danh sách công ty
        /// </summary>
        /// <returns></returns>
        public static DataTable LoadCongTy()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter d = new SqlDataAdapter("select * from DM_CONGTY where DOT_MA = '" + clsParameter._dotMaDauThau + "'", clsConnection._conn);
            d.Fill(dt);
            return dt;
        }

        /// <summary>
        /// kiểm tra dữ liệu đã được sử dụng hay chưa.
        /// </summary>
        public static Boolean DataUsed(string TableName, Int32 ColID)
        {
            string str = string.Empty;
            if (TableName == "DM_DVT")
                str = "SELECT DISTINCT DM_DVT.DVT_ID FROM DM_DVT INNER JOIN DM_SANPHAM ON DM_DVT.DVT_ID = DM_SANPHAM.DVT_ID "
                    + " WHERE (((DM_DVT.DVT_ID)=" + ColID + "))";
            else if (TableName == "DM_GOITHAU")
                str = "SELECT DISTINCT DM_GOITHAU.GOITHAU_ID FROM DM_GOITHAU INNER JOIN DM_SANPHAM ON DM_GOITHAU.GOITHAU_ID = DM_SANPHAM.SP_GOITHAU "
                    + " WHERE (((DM_GOITHAU.GOITHAU_ID)=" + ColID + "))";
            else if (TableName == "DM_SANPHAM")
                str = "SELECT DISTINCT DM_SANPHAM.SP_ID FROM DM_SANPHAM INNER JOIN DAU_THAU ON DM_SANPHAM.SP_ID = DAU_THAU.SP_ID "
                    + " WHERE (((DM_SANPHAM.SP_ID)= " + ColID + "))";
            else if (TableName == "DM_NUOCSX")
                str = " SELECT DISTINCT DM_NUOCSX.NUOCSX_ID FROM DM_NUOCSX INNER JOIN DAU_THAU ON DM_NUOCSX.NUOCSX_ID = DAU_THAU.NUOCSX_ID "
                    + " WHERE (((DM_NUOCSX.NUOCSX_ID)=" + ColID + "))";
            else if (TableName == "DM_NHOM_KYTHUAT")
                str = "SELECT DISTINCT DM_NHOM_KYTHUAT.NHOM_KYTHUAT_ID "
                    + " FROM DM_NHOM_KYTHUAT INNER JOIN DM_GOITHAU_KYTHUAT ON DM_NHOM_KYTHUAT.NHOM_KYTHUAT_ID = DM_GOITHAU_KYTHUAT.NHOM_KYTHUAT_ID "
                    + " WHERE (((DM_NHOM_KYTHUAT.NHOM_KYTHUAT_ID)=" + ColID + "))";
            else if (TableName == "DM_NHOM_KYTHUAT_CT")
                str = "SELECT DISTINCT DM_NHOM_KYTHUAT_CT.NHOM_KYTHUAT_CT_ID "
                    + " FROM DM_NHOM_KYTHUAT_CT INNER JOIN DM_GOITHAU_KYTHUAT ON DM_NHOM_KYTHUAT_CT.NHOM_KYTHUAT_CT_ID = DM_GOITHAU_KYTHUAT.NHOM_KYTHUAT_CT_ID "
                    + " WHERE (((DM_NHOM_KYTHUAT_CT.NHOM_KYTHUAT_CT_ID)=" + ColID + "))";
            else if (TableName == "DM_GOITHAU_KYTHUAT")
                str = "SELECT DISTINCT DAU_THAU.GOITHAU_ID FROM DAU_THAU INNER JOIN DM_GOITHAU_KYTHUAT "
                    + " ON DAU_THAU.GOITHAU_ID = DM_GOITHAU_KYTHUAT.GOITHAU_ID"
                    + " WHERE (((DAU_THAU.GOITHAU_ID)=" + ColID + "))";
            if (str == string.Empty) return true;

            DataTable dt = new DataTable();
            SqlDataAdapter d = new SqlDataAdapter(str, clsConnection._conn);
            d.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                XtraMessageBox.Show("Dữ liệu đã được sử dụng bạn không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else return false;
        }


        /// <summary>
        /// Lấy mã sản phẩm tự tăng, Khi đạt 9999 cập nhât MaxValue =True.
        /// </summary>
        /// <returns></returns>
        public static String LayMaTuTangSanPham()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 1 * FROM CONFIG WHERE Config_name='MASANPHAM' and MaxValue = 0 ORDER BY id ASC", clsConnection._conn);
            DataTable t = new DataTable();
            da.Fill(t);
            if (t.Rows.Count > 0)
            {
                string _str = string.Empty;
                if (Convert.ToInt32(t.Rows[0]["Config_value"]) == 9999)
                    _str = "Update CONFIG set MaxValue=1 where ID= " + t.Rows[0]["ID"].ToString();
                else _str = "Update CONFIG set Config_value = Config_value + 1 where ID= " + t.Rows[0]["ID"].ToString();
                SqlCommand cmd = new SqlCommand(_str, clsConnection._conn);
                cmd.ExecuteNonQuery();
                return t.Rows[0]["Config_first"].ToString() + t.Rows[0]["Config_value"].ToString().PadLeft(4, '0');
            }
            else
            {
                //clsMessage.MessageWarning("Vui lòng cấu hình mã tự tăng của sản phẩm.");
                return string.Empty;
            }
        }

        public static void RepositoryItemSpinEdit(RepositoryItemSpinEdit se, string _format)
        {
            se.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            se.DisplayFormat.FormatString = _format;
            se.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            se.EditFormat.FormatString = _format;

        }

        public static string LayMaTuTangCongTy()
        {
            DataTable t = new DataTable();
            t = new DataTable();
            t = FunctionHelper.LoadDM("select * from config where config_name='MACTY' and Year = " + DateTime.Now.Year);
            if (t.Rows.Count > 0)
            {
                string str = string.Format("update CONFIG set Config_value = Config_value + 1 where config_name='MACTY'");
                SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                cmd.ExecuteNonQuery();
                return t.Rows[0]["Config_first"].ToString() + t.Rows[0]["Config_value"].ToString() + string.Empty;
            }
            else
            {
                string _number = DateTime.Now.Year + "001";
                string str = string.Format("update CONFIG set Config_value ={0}, Year={1}  where config_name='MACTY'", Convert.ToInt32(_number) + 1, DateTime.Now.Year);
                SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                cmd.ExecuteNonQuery();
                return "CTY" + _number;
            }
        }

        public static DataTable DsSanPhamMa(Int64 idGoiThau)
        {
            SqlCommand cmd = new SqlCommand("sp_HoSoDuThauSP_Ma", clsConnection._conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt).Value = idGoiThau;
            cmd.Parameters.Add("@DOT_MA", SqlDbType.NVarChar).Value = clsParameter._dotMaDauThau;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable t = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(t);
            return t;
        }

        public static DataSet HoSoDauThau(Int64 IdGoiThau)
        {
            #region Tải dữ liệu có sẳn

            if (clsParameter._isfirstLoadHoSoDauThau)
            {
                dataHoSoDauThau(0);
                clsParameter._isfirstLoadHoSoDauThau = false;
            }

            //Kiểm tra nếu không có cập nhật dữ liệu thì lấy dữ liệu đã được lưu trước đó.
            if (clsParameter._isLoadHoSoDauThau == false)
            {
                if (clsParameter._dataHoSoDauThau.Tables[0].Rows.Count > 0)
                {
                    if (IdGoiThau == 0)
                    {
                        return clsParameter._dataHoSoDauThau;
                    }
                    else
                    {
                        //Lọc theo gói thầu.
                        DataRow[] dr = clsParameter._dataHoSoDauThau.Tables[0].Select("GOITHAU_ID = " + IdGoiThau);
                        DataSet result = new DataSet();
                        if (dr.Length > 0)
                        {
                            result.Tables.Add(dr.CopyToDataTable());
                            result.Tables[0].TableName = "ChiTietHoSo";
                        }
                        else
                        {
                            result.Tables.Add(clsParameter._dataHoSoDauThau.Tables[0].Clone());
                            result.Tables[0].TableName = "ChiTietHoSo";
                        }
                        return result;
                    }
                }
            }
            
            #endregion

            return dataHoSoDauThau(IdGoiThau);
        }

        public static DataSet dataHoSoDauThau(Int64 IdGoiThau)
        {
            //Cập nhật lại trạng thái không cần load dữ liệu nữa chọn tất cả gói thầu
            if (IdGoiThau == 0)
            {
                clsParameter._isLoadHoSoDauThau = false;
            }

            DataSet ds = new DataSet();
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu đấu thầu ...", "Vui lòng đợi giây lát");

            SqlCommand cmd = new SqlCommand(clsParameter.pStoreDanhGiaHoSoDuThau, clsConnection._conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt).Value = IdGoiThau;
            cmd.Parameters.Add("@DOT_MA", SqlDbType.NVarChar).Value = clsParameter._dotMaDauThau;
            cmd.Parameters.Add("@SP_MA", SqlDbType.NVarChar).Value = string.Empty;
            cmd.CommandTimeout = 0;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds, "ChiTietHoSo");


            _wait.Caption = "Đang tải sản phẩm ...";
            DataTable dtSP_MA = new DataTable();
            dtSP_MA = DsSanPhamMa(IdGoiThau);

            _wait.Caption = "Đang xét hồ sơ trúng thầu ...";
            string sp_ma = string.Empty;
            Decimal max_DiemTH;
            Int32 _countRow = dtSP_MA.Rows.Count;
            for (int k = 0; k < _countRow; k++)
            {
                _wait.Caption = string.Format("Đang xét sản phẩm {0}/{1}", k + 1, _countRow);
                sp_ma = dtSP_MA.Rows[k][0].ToString();

                try
                {
                    max_DiemTH = Convert.ToDecimal(ds.Tables[0].Compute("max(DiemTH)", "SP_MA='" + sp_ma + "' and LOAI_PL=False and VUOTGIA_KH=False and KHONGDAT_KT=False"));
                }
                catch (Exception)
                {
                    max_DiemTH = 0;
                }

                //Nếu sản phẩm đã được trúng thầu từ BTC có nghĩa là cột TT = 1
                //Không xét nữa nữa.
                DataRow[] r = ds.Tables[0].Select(string.Format("SP_MA='{0}' and TT=1", sp_ma));
                if (r.Length > 0) continue;

                //Xét điều kiện trúng thầu.
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["SP_MA"].ToString() == sp_ma
                        && clsChangeType.change_decimal(ds.Tables[0].Rows[i]["DiemTH"]) > 0
                         && clsChangeType.change_bool(ds.Tables[0].Rows[i]["LOAI_PL"]) == false
                        )
                        if (Convert.ToDecimal(ds.Tables[0].Rows[i]["DiemTH"]) == max_DiemTH)
                        {
                            ds.Tables[0].Rows[i]["TT"] = true;
                            //break;
                        }
                }
            }

            if (IdGoiThau == 0)
            {
                clsParameter._dataHoSoDauThau = ds;
            }

            _wait.Close();
            return ds;
        }

        public static string formatFromDateToDate(DateTime? fromDate, DateTime? ToDate)
        {
            string strFormat = "";
            if (fromDate.HasValue)
            {
                strFormat = fromDate.Value.ToString("dd/MM/yyyy");
            }
            if (ToDate.HasValue)
            {
                strFormat+= " - " + ToDate.Value.ToString("dd/MM/yyyy");
            }
            return strFormat;
        }
        /// <summary>
        /// List to DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        public static DataTable ConvertToDataTable<TSource>(IEnumerable<TSource> source)
        {
            var props = typeof(TSource).GetProperties();

            var dt = new DataTable();
            dt.Columns.AddRange(
              props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray()
            );

            source.ToList().ForEach(
              i => dt.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt;
        }
        

        #region MD5 Security

        public static string EncryptMD5(string str)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, str);
                return hash;
            }
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }

        // Verify a hash against a string. 
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        public static void LunaticBandedGridToExcel(String Title, string RangeTime, BandedGridView table, string formatNumber)
        {
            DevExpress.Utils.WaitDialogForm waitDialogForm = new DevExpress.Utils.WaitDialogForm("Đang xuất excel ...", "Vui lòng chờ giây lát !");
            try
            {
                ExcelManager excelManager = new ExcelManager(true);

                // Print band header
                BandedGridView view = table;
                view.ExpandAllGroups();
                object[] data = new object[view.VisibleColumns.Count];
                excelManager.BandedGridHeader2Excel(view, false, 11, 1, "headerRangeName");
                excelManager.SetTitleRows();
                excelManager.SelectRange()
                           .SetFontFamily("Times New Roman");

                waitDialogForm.SetCaption(String.Format("{0} - {1}%", "Đang xuất excel ...", 50));

                excelManager.GridData2Excel(table, 12, 1, false, false, "", false, false);

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
                //excelManager
                //    .SelectRange(1, 1, 1, 1)
                //    .SetFontStyle(true, false, false)
                //    .SetFontSize(12)
                //    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                //    .SetRangeValue("Công ty cổ phần xuất nhập khẩu KIM QUYỀN");

                //excelManager
                //    .SelectRange(2, 1, 2, 1)
                //    .SetFontStyle(false, false, false)
                //    .SetFontSize(12)
                //    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                //    .SetRangeValue("Địa chỉ : P08 đường số 8, Khu đô thị mới - Hưng Phú, ");

                //excelManager
                //    .SelectRange(3, 1, 3, 1)
                //    .SetFontStyle(false, false, false)
                //    .SetFontSize(12)
                //    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                //    .SetRangeValue("P. Hưng Thạnh, Q. Cái Răng, Tp. Cần Thơ");
                //excelManager
                //   .SelectRange(4, 1, 4, 1)
                //   .SetFontStyle(false, false, false)
                //   .SetFontSize(12)
                //   .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                //   .SetRangeValue("MST: 1801318149");
                //excelManager
                //   .SelectRange(5, 1, 5, 1)
                //   .SetFontStyle(false, false, false)
                //   .SetFontSize(12)
                //   .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                //   .SetRangeValue("SĐT: 07103.737.261 - DĐ: 0932.993.081");
                //excelManager
                //   .SelectRange(6, 1, 6, 1)
                //   .SetFontStyle(false, false, false)
                //   .SetFontSize(12)
                //   .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                //   .SetRangeValue("Số TK: 1800201218555 tại NH Agribank Cần Thơ");

                //excelManager
                //    .SelectRange(8, 1, 8, ec)
                //    .Merge()
                //    .SetFontStyle(true, false, false)
                //    .SetFontSize(16)
                //    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                //    .SetRangeValue(Title);


                //if (RangeTime != string.Empty)
                //    excelManager
                //        .SelectRange(9, 1, 9, ec)
                //        .Merge()
                //        .SetFontStyle(true, false, false)
                //        .SetFontSize(12)
                //        .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                //        .SetRangeValue(RangeTime);

                excelManager.SelectRange(12, 2, er, ec).AutoFitColumn();
                excelManager.SelectRange(12, 2, er, ec).SetNumberFormat("#,#0");
                excelManager
                .SelectRange(er - 2, ec - 3, er - 2, ec - 3)
                .Merge()
                .SetFontStyle(false, false, false)
                .SetFontSize(12)
                .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                .SetRangeValue(string.Format("Ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));



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
