using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Data.OleDb;
using System.Data.SqlClient;
using DauThau.Class;
using DevExpress.Utils;

namespace DauThau.Forms
{
    public partial class frmExcelsManager : DevExpress.XtraEditors.XtraForm
    {
        string _maDotDauThau = string.Empty;
        public frmExcelsManager( )
        {
            InitializeComponent();
        }
        DataTable data = new DataTable();

        /// <summary>
        /// ID đơn vị tính mặc định
        /// </summary>
        const Int64 DVT_MACDINH = 123;

        Boolean LoadExcels(string filePath)
        {
            try
            {
                int k = gv.Columns.Count;
                for (int i = 0; i < k; i++)
                {
                    gv.Columns.Remove(gv.Columns[0]);
                }
                data = new DataTable();
                var fileName = string.Format("{0}", filePath);
                var connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", fileName);
                OleDbConnection con = new OleDbConnection(connectionString);
                con.Open();
                DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + dt.Rows[0]["TABLE_NAME"].ToString() + "]", con);
                DataSet ds = new DataSet();

                adapter.Fill(ds, "anyNameHere");

                data = ds.Tables["anyNameHere"];
                gc.DataSource = data;

                List<clsObject> _list = new List<clsObject>();
                foreach (DataColumn items in data.Columns)
                {
                    clsObject item = new clsObject();
                    item.TEN = items.ColumnName;
                    _list.Add(item);
                }
                lueTenThuoc.Properties.DataSource
                    =  _list;

                return true;
            }
            catch (Exception ex)
            {
                clsMessage.MessageWarning("Có lỗi trong quá trình tải file.\nError : " + ex.Message);
                return false;
            }
        }

        private void frmExcelsManager_Load(object sender, EventArgs e)
        {

        }

        public class clsObject
        {
            public string TEN { get; set;}
        }
        private void btnPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            if (f.FileName!=string.Empty)
            {
                txtPath.Text = f.FileName;
                LoadExcels(txtPath.Text);
            }
        }

        #region Function

        /// <summary>
        /// Đơn vị tính có nằm trong danh mục
        /// </summary>
        /// <returns></returns>
        Boolean KiemTraDVT(string _Ten)
        {
            if (_Ten.Trim().Length == 0)
                return false;
            DataTable t = new DataTable();
            t = FunctionHelper.LoadDM("select * from DM_DVT where TEN = N'" + _Ten + "'");
            return t.Rows.Count > 0;
        }

        /// <summary>
        /// insert đơn vị tính
        /// </summary>
        /// <param name="_tenDVT"></param>
        /// <returns></returns>
        Int64 insertDVT(string _tenDVT)
        {
            Int64 idDVT = DVT_MACDINH;
            string query = string.Format("insert into DM_DVT (TEN) values ('{0}'); SELECT SCOPE_IDENTITY()", _tenDVT) ;
            idDVT = FunctionHelper.executeQuery(query, true);
            return idDVT;
        }


        Int64 LayIdDVT(string _Ten)
        {
            DataTable t = new DataTable();
            t = FunctionHelper.LoadDM("select * from DM_DVT where TEN = N'" + _Ten + "'");
            if (t.Rows.Count > 0)
            {
                return clsChangeType.change_int(t.Rows[0]["DVT_ID"]);
            }
            
            return DVT_MACDINH;
        }

        Int32 LayIdNuocSx(string _Ten)
        {
            DataTable t = new DataTable();
            t = FunctionHelper.LoadDM("select * from DM_NUOCSX where TEN like N'" + _Ten + "'");
            if (t.Rows.Count > 0)
                return clsChangeType.change_int(t.Rows[0]["NUOCSX_ID"]);
            return 0;
        }

        Boolean KiemTraNUOCSX(string _Ten)
        {
            DataTable t = new DataTable();
            t = FunctionHelper.LoadDM("select * from DM_NUOCSX where TEN = N'" + _Ten + "'");
            return t.Rows.Count > 0;
        }

        /// <summary>
        /// Kiểm tra dữ liệu
        /// </summary>
        /// <returns></returns>
        Boolean Validation()
        {
            dxErrorProvider1.ClearErrors();


            

            //if (lueGiaKeHoach.EditValue == null)
            //    dxErrorProvider1.SetError(lueGiaKeHoach, "Giá kế hoạch không được rỗng.");

            if (gv.RowCount == 0)
            {
                clsMessage.MessageWarning("Không có dữ liệu");
                return true;
            }
            return dxErrorProvider1.HasErrors ;
        }
        
        #endregion

        void ClearEditValue()
        {
            
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {


            WaitDialogForm _wait = new WaitDialogForm("Đang tải kiểm tra dữ liệu...", "Vui lòng đợi giây lát");
            //try
            //{
            object row = null;
            string _tenVietTatGoiThau = string.Empty;
            string _maSP = string.Empty;
            if (row != null)
            {
                _tenVietTatGoiThau = ((DataRowView)row)["TEN_VIET_TAT"].ToString();
                if (_tenVietTatGoiThau == string.Empty)
                {
                    _wait.Close();
                    clsMessage.MessageWarning("Vui lòng cấu hình tên viết tắt của gói thầu.");
                    return;
                }
            }

            if (Validation())
            {
                _wait.Close();
                return;
            }


            
 


            int _countSP = 1;
            for (int i = 0; i < data.Rows.Count; i++)
            {

                _wait.Caption = string.Format("Đang nạp dữ liêu {0}/{1}", i, data.Rows.Count);

                
                _maSP = _tenVietTatGoiThau  +_countSP.ToString().PadLeft(3, '0');
                _countSP++;
                string str = "Insert into DM_SANPHAM (SP_MA, SP_TEN, SP_TENBIETDUOC,DVT_ID,SP_HAMLUONG,SP_DANGDUNG,SP_SOLUONG "
                    + " ,SP_GIAKEHOACH,SP_GOITHAU,SP_QUICACH_DONGGOI,SP_QUICACH_YEUCAU,SP_NUOCSX_ID,SP_SOTHONGTU "
                    + " , SP_SOLUONG_BH, SP_SOLUONG_DV, SP_SOLUONG_CS, SP_KHUVUC_SX, SP_GHICHU"
                    + " , SP_DACBIET, SP_NHOM_CHA, SP_NHOM_CON_I, SP_NHOM_CON_II, SP_NHOM_CON_III, SP_MA_DUONGDUNG)"
                    + "values (@SP_MA, @SP_TEN, @SP_TENBIETDUOC, @DVT_ID, @SP_HAMLUONG, @SP_DANGDUNG, @SP_SOLUONG "
                    + " ,@SP_GIAKEHOACH,@SP_GOITHAU,@SP_QUICACH_DONGGOI, @SP_QUICACH_YEUCAU, @SP_NUOCSX_ID,@SP_SOTHONGTU "
                    + " , @SP_SOLUONG_BH, @SP_SOLUONG_DV, @SP_SOLUONG_CS, @SP_KHUVUC_SX, @SP_GHICHU, @SP_DACBIET "
                    + " , @SP_NHOM_CHA, @SP_NHOM_CON_I, @SP_NHOM_CON_II, @SP_NHOM_CON_III, @SP_MA_DUONGDUNG)";

                SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                cmd.Parameters.Add("@SP_MA", SqlDbType.NVarChar).Value = _maSP;
                cmd.Parameters.Add("@SP_TEN", SqlDbType.NVarChar).Value = this.removeCharacter(data.Rows[i][lueTenThuoc.EditValue + string.Empty] + string.Empty);

                //if (lueBietDuoc.EditValue != null)
                //    cmd.Parameters.Add("@SP_TENBIETDUOC", SqlDbType.NVarChar).Value = this.removeCharacter(data.Rows[i][lueBietDuoc.EditValue + string.Empty] + string.Empty);
                //else cmd.Parameters.Add("@SP_TENBIETDUOC", SqlDbType.NVarChar).Value = DBNull.Value;

               

               

                cmd.ExecuteNonQuery();

            }
            _wait.Close();
            ClearEditValue();
        }

        /// <summary>
        /// Xóa bỏ các ký tự \n, \r, \t
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        string removeCharacter(string str)
        {
            return str.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty).Trim();
        }

        

        
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void btnXemDuLieu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}