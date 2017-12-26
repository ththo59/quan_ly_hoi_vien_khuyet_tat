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
    public partial class frmExcelsManagerAdditional : DevExpress.XtraEditors.XtraForm
    {
        string _maDotDauThau = string.Empty;
        public frmExcelsManagerAdditional(string _DotDauThau)
        {
            InitializeComponent();
            _maDotDauThau = _DotDauThau;
        }
        DataTable data = new DataTable();
        
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
                    lueGiaKH.Properties.DataSource = lueMaSP.Properties.DataSource
                    = lueSoLuong_DV.Properties.DataSource = lueSoLuong_BH.Properties.DataSource
                    = lueSoLuong_CS.Properties.DataSource = lueThongTu.Properties.DataSource 
                    = lueSPDacBiet.Properties.DataSource
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

       

        Int32 LayIdDVT(string _Ten)
        {
            DataTable t = new DataTable();
            t = FunctionHelper.LoadDM("select * from DM_DVT where TEN like N'" + _Ten + "'");
            if(t.Rows.Count > 0)
            return clsChangeType.change_int(t.Rows[0]["DVT_ID"]);
            return 0;
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

       
        
        #endregion

        void ClearEditValue()
        {
            lueSoLuong_DV.EditValue = lueSoLuong_BH.EditValue = lueSoLuong_CS.EditValue = lueGiaKH.EditValue
            = lueSPDacBiet.EditValue = lueSoLuong_DV.EditValue = null;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            CapNhatBoSung();
        }

        void CapNhatBoSung()
        {

            if (lueMaSP.EditValue == null)
            {
                clsMessage.MessageWarning("Vui lòng chọn mã sản phẩm!");
                return;
            }

            WaitDialogForm _wait = new WaitDialogForm("Đang tải kiểm tra dữ liệu...", "Vui lòng đợi giây lát");
            
            if (lueGiaKH.EditValue != null)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    if (clsChangeType.change_decimal(data.Rows[i][lueGiaKH.EditValue + string.Empty]) <= 0)
                    {
                        _wait.Close();
                        string _str = string.Format("Sản phẩm {0} có giá KH <= 0. Vui lòng kiểm tra lại.", data.Rows[i][lueMaSP.EditValue + string.Empty]);
                        clsMessage.MessageWarning(_str);
                        return;
                    }
                }
            }

            try
            {
                //Tao chuoi ket noi voi thong so tuong ung.
                StringBuilder _strUpdate = new StringBuilder();
                _strUpdate.Append("Update DM_SANPHAM set ");

                if (lueGiaKH.EditValue != null) _strUpdate.Append(" SP_GIAKEHOACH=@SP_GIAKEHOACH ");

                if (lueSoLuong_CS.EditValue != null)
                {
                    if (_strUpdate.ToString().IndexOf("=") > 0) _strUpdate.Append(" ,SP_SOLUONG_CS=@SP_SOLUONG_CS ");
                    else _strUpdate.Append(" SP_SOLUONG_CS=@SP_SOLUONG_CS ");
                }

                if (lueSoLuong_BH.EditValue != null)
                {
                    if (_strUpdate.ToString().IndexOf("=") > 0) _strUpdate.Append(" ,SP_SOLUONG_BH=@SP_SOLUONG_BH ");
                    else _strUpdate.Append(" SP_SOLUONG_BH=@SP_SOLUONG_BH ");
                }

                if (lueSoLuong_DV.EditValue != null)
                {
                    if (_strUpdate.ToString().IndexOf("=") > 0) _strUpdate.Append(" ,SP_SOLUONG_DV=@SP_SOLUONG_DV ");
                    else _strUpdate.Append(" SP_SOLUONG_DV=@SP_SOLUONG_DV ");
                }

                if (lueThongTu.EditValue != null)
                {
                    if (_strUpdate.ToString().IndexOf("=") > 0) _strUpdate.Append(" ,SP_SOTHONGTU=@SP_SOTHONGTU ");
                    else _strUpdate.Append(" SP_SOTHONGTU=@SP_SOTHONGTU ");
                }

                if (lueSPDacBiet.EditValue != null)
                {
                    if (_strUpdate.ToString().IndexOf("=") > 0) _strUpdate.Append(" ,SP_DACBIET=@SP_DACBIET ");
                    else _strUpdate.Append(" SP_DACBIET=@SP_DACBIET ");
                }

                _strUpdate.Append(" where SP_MA=@SP_MA");

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    //Luu du lieu
                    _wait.Caption = string.Format("Đang tải cập nhật {0}/{1}", i + 1, data.Rows.Count);
                    if ((data.Rows[i][lueMaSP.EditValue + string.Empty] + string.Empty).Trim() == "")
                        continue;

                    SqlCommand cmd = new SqlCommand(_strUpdate.ToString(), clsConnection._conn);
                    if(lueGiaKH.EditValue!=null)
                        cmd.Parameters.Add("@SP_GIAKEHOACH", SqlDbType.Decimal).Value = clsChangeType.change_decimal(data.Rows[i][lueGiaKH.EditValue + string.Empty]);
                    if (lueSoLuong_CS.EditValue != null)
                        cmd.Parameters.Add("@SP_SOLUONG_CS", SqlDbType.BigInt).Value = clsChangeType.change_int64(data.Rows[i][lueSoLuong_CS.EditValue + string.Empty]);
                    if(lueSoLuong_BH.EditValue!=null)
                        cmd.Parameters.Add("@SP_SOLUONG_BH", SqlDbType.BigInt).Value = clsChangeType.change_int64(data.Rows[i][lueSoLuong_BH.EditValue + string.Empty]);
                    if (lueSoLuong_DV.EditValue != null)
                        cmd.Parameters.Add("@SP_SOLUONG_DV", SqlDbType.BigInt).Value = clsChangeType.change_int64(data.Rows[i][lueSoLuong_DV.EditValue + string.Empty]);
                    if (lueThongTu.EditValue != null)
                        cmd.Parameters.Add("@SP_SOTHONGTU", SqlDbType.NVarChar).Value = data.Rows[i][lueThongTu.EditValue + string.Empty] + string.Empty;
                    if (lueSPDacBiet.EditValue != null)
                    {
                        if(!String.IsNullOrEmpty(data.Rows[i][lueSPDacBiet.EditValue + string.Empty] + string.Empty))
                            cmd.Parameters.Add("@SP_DACBIET", SqlDbType.Bit).Value = 1;
                        else
                            cmd.Parameters.Add("@SP_DACBIET", SqlDbType.Bit).Value = 0;
                    }
                        
                    if (lueMaSP.EditValue != null)
                        cmd.Parameters.Add("@SP_MA", SqlDbType.NVarChar).Value = data.Rows[i][lueMaSP.EditValue + string.Empty] + string.Empty;

                    cmd.ExecuteNonQuery();
                }
                _wait.Close();
            }
            catch (Exception ex)
            {
                _wait.Close();
                clsMessage.MessageWarning("Cập nhật dữ liệu không thành công.\n" + ex.Message);
            }
            
        }

        #region Event Button

        
        private void lueBietDuoc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueSoLuong_DV.EditValue = null;
            }
        }

        

        
        #endregion
        
        

        private void btnXemDuLieu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void lueSoThongTu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lue.EditValue = null;
            }
        }

        private void lueSoLuong_CS_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lue.EditValue = null;
            }
        }

        private void lueSoLuong_BH_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lue.EditValue = null;
            }
        }

        private void lueThongTu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lue.EditValue = null;
            }
        }

        private void lueGiaKH_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lue.EditValue = null;
            }
        }

        private void lueSoLuong_DV_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lue.EditValue = null;
            }
        }

        private void lueSPDacBiet_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lue.EditValue = null;
            }
        }
    }
}