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
    public partial class frmExcelsImportCQLD : DevExpress.XtraEditors.XtraForm
    {
        string _maDotDauThau = string.Empty;

        public frmExcelsImportCQLD(string _DotDauThau)
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
                lueSTT.Properties.DataSource = lueTenThuoc.Properties.DataSource = lueTenHoatChat.Properties.DataSource
                    = lueDonViTinh.Properties.DataSource = lueCoSoSanXuat.Properties.DataSource = lueHamLuongNongDo.Properties.DataSource
                    = lueCSNK_KeKhai.Properties.DataSource = lueThongTinCV_NgayCong.Properties.DataSource = lueGiaKeKhai.Properties.DataSource
                    = lueSDK_GPNK.Properties.DataSource  = lueQuyCachDongGoi.Properties.DataSource
                    = lueNgayKeKhai.Properties.DataSource 
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
            this.lueTenHoatChat.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(lueEditDeleteButtonClick);
        }

        private void lueEditDeleteButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lue.EditValue = null;
            }
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
        /// Kiểm tra dữ liệu
        /// </summary>
        /// <returns></returns>
        Boolean Validation()
        {
            dxErrorProvider1.ClearErrors();
            string msgError = "Vui lòng chọn dữ liệu.";

            if (lueSTT.EditValue==null)
                dxErrorProvider1.SetError(lueSTT, msgError);
            
            if (lueDonViTinh.EditValue == null)
                dxErrorProvider1.SetError(lueDonViTinh, msgError);

            if (lueSDK_GPNK.EditValue == null)
                dxErrorProvider1.SetError(lueSDK_GPNK, msgError);

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
            lueTenThuoc.EditValue = lueTenHoatChat.EditValue = lueDonViTinh.EditValue = lueCoSoSanXuat.EditValue
            = lueHamLuongNongDo.EditValue = lueThongTinCV_NgayCong.EditValue = lueCSNK_KeKhai.EditValue = lueSTT.EditValue
            = lueNgayKeKhai.EditValue = lueQuyCachDongGoi.EditValue
            = lueGiaKeKhai.EditValue =lueSDK_GPNK.EditValue = null;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải kiểm tra dữ liệu...", "Vui lòng đợi giây lát");
            //try
            //{

            if (Validation())
            {
                _wait.Close();
                return;
            }

            int _countSP = 1;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                _wait.Caption = string.Format("Đang nạp dữ liêu {0}/{1}", i, data.Rows.Count);

                if (this.removeCharacter(data.Rows[i][lueSTT.EditValue + string.Empty] + string.Empty) == "" ||
                    this.removeCharacter(data.Rows[i][lueDonViTinh.EditValue + string.Empty] + string.Empty) == "")
                {
                    continue;
                }
                
                _countSP++;
                string str = "Insert into DM_SANPHAM_CQLD (SP_STT, SP_TEN, SP_TENHOATCHAT ,SP_NONGDO_HAMLUONG ,SP_SDK_GPKD"
                    + " ,SP_QUYCACH_DONGGOI, SP_DVT, SP_CSSX, SP_CSNK_KEKHAI, SP_THONGTIN_CONGVAN, SP_GIA_KEKHAI, SP_NGAY_KEKHAI, SP_MAU) "
                    + "values (@SP_STT, @SP_TEN, @SP_TENHOATCHAT, @SP_NONGDO_HAMLUONG, @SP_SDK_GPKD, @SP_QUYCACH_DONGGOI, @SP_DVT "
                    + " ,@SP_CSSX,@SP_CSNK_KEKHAI, @SP_THONGTIN_CONGVAN, @SP_GIA_KEKHAI,@SP_NGAY_KEKHAI, @SP_MAU)";

                SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                cmd.Parameters.Add("@SP_STT", SqlDbType.BigInt).Value = Convert.ToInt64(this.removeCharacter(data.Rows[i][lueSTT.EditValue + string.Empty] + string.Empty));

                if (lueTenThuoc.EditValue != null)
                    cmd.Parameters.Add("@SP_TEN", SqlDbType.NVarChar).Value = this.removeCharacter(data.Rows[i][lueTenThuoc.EditValue + string.Empty] + string.Empty);
                else cmd.Parameters.Add("@SP_TEN", SqlDbType.NVarChar).Value = DBNull.Value;

                if (lueTenHoatChat.EditValue != null)
                    cmd.Parameters.Add("@SP_TENHOATCHAT", SqlDbType.NVarChar).Value = this.removeCharacter(data.Rows[i][lueTenHoatChat.EditValue + string.Empty] + string.Empty);
                else cmd.Parameters.Add("@SP_TENHOATCHAT", SqlDbType.NVarChar).Value = DBNull.Value;

                if (lueHamLuongNongDo.EditValue != null)
                    cmd.Parameters.Add("@SP_NONGDO_HAMLUONG", SqlDbType.NVarChar).Value = this.removeCharacter(data.Rows[i][lueHamLuongNongDo.EditValue + string.Empty] + string.Empty);
                else cmd.Parameters.Add("@SP_NONGDO_HAMLUONG", SqlDbType.NVarChar).Value = DBNull.Value;

                if (lueSDK_GPNK.EditValue != null)
                    cmd.Parameters.Add("@SP_SDK_GPKD", SqlDbType.NVarChar).Value = this.removeCharacter(data.Rows[i][lueSDK_GPNK.EditValue + string.Empty] + string.Empty);
                else cmd.Parameters.Add("@SP_SDK_GPKD", SqlDbType.NVarChar).Value = DBNull.Value;

                if (lueQuyCachDongGoi.EditValue != null)
                    cmd.Parameters.Add("@SP_QUYCACH_DONGGOI", SqlDbType.NVarChar).Value = this.removeCharacter(data.Rows[i][lueQuyCachDongGoi.EditValue + string.Empty] + string.Empty);
                else cmd.Parameters.Add("@SP_QUYCACH_DONGGOI", SqlDbType.NVarChar).Value = DBNull.Value;


                if (lueDonViTinh.EditValue != null)
                    cmd.Parameters.Add("@SP_DVT", SqlDbType.NVarChar).Value = this.removeCharacter(data.Rows[i][lueDonViTinh.EditValue + string.Empty] + string.Empty);
                else cmd.Parameters.Add("@SP_DVT", SqlDbType.NVarChar).Value = DBNull.Value;

                if (lueCoSoSanXuat.EditValue != null)
                    cmd.Parameters.Add("@SP_CSSX", SqlDbType.NVarChar).Value = this.removeCharacter(data.Rows[i][lueCoSoSanXuat.EditValue + string.Empty] + string.Empty);
                else cmd.Parameters.Add("@SP_CSSX", SqlDbType.NVarChar).Value = DBNull.Value;

                if (lueCSNK_KeKhai.EditValue != null)
                    cmd.Parameters.Add("@SP_CSNK_KEKHAI", SqlDbType.NVarChar).Value = this.removeCharacter(data.Rows[i][lueCSNK_KeKhai.EditValue + string.Empty] + string.Empty);
                else cmd.Parameters.Add("@SP_CSNK_KEKHAI", SqlDbType.NVarChar).Value = DBNull.Value;

                if (lueThongTinCV_NgayCong.EditValue != null)
                    cmd.Parameters.Add("@SP_THONGTIN_CONGVAN", SqlDbType.NVarChar).Value = this.removeCharacter(data.Rows[i][lueThongTinCV_NgayCong.EditValue + string.Empty] + string.Empty);
                else cmd.Parameters.Add("@SP_THONGTIN_CONGVAN", SqlDbType.NVarChar).Value = DBNull.Value;

                if (lueGiaKeKhai.EditValue != null) {
                    string giaKeKhai = (data.Rows[i][lueGiaKeKhai.EditValue + string.Empty] + string.Empty);
                    giaKeKhai = giaKeKhai.Replace(" ", "");
                    giaKeKhai = giaKeKhai.Replace(",", "");
                    if(giaKeKhai != "")
                    {
                        cmd.Parameters.Add("@SP_GIA_KEKHAI", SqlDbType.Decimal).Value = Convert.ToDecimal(giaKeKhai);
                    }else
                    {
                        cmd.Parameters.Add("@SP_GIA_KEKHAI", SqlDbType.Decimal).Value = DBNull.Value;
                    }
                }else cmd.Parameters.Add("@SP_GIA_KEKHAI", SqlDbType.Decimal).Value = DBNull.Value;


                if (lueNgayKeKhai.EditValue != null)
                {
                    string ngayKeKhai = this.removeCharacter(data.Rows[i][lueNgayKeKhai.EditValue + string.Empty] + string.Empty);
                    if (ngayKeKhai.Trim() != "")
                    {
                        cmd.Parameters.Add("@SP_NGAY_KEKHAI", SqlDbType.Date).Value = Convert.ToDateTime(ngayKeKhai);
                    }
                    else cmd.Parameters.Add("@SP_NGAY_KEKHAI", SqlDbType.Date).Value = DBNull.Value;
                }
                else cmd.Parameters.Add("@SP_NGAY_KEKHAI", SqlDbType.Date).Value = DBNull.Value;

                cmd.Parameters.Add("@SP_MAU", SqlDbType.NVarChar).Value = rdMau.EditValue + string.Empty;

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
            try
            {
                if (clsMessage.MessageYesNo("Bạn có chắc muốn xóa dữ liệu của gói thầu đang chọn") == System.Windows.Forms.DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand(string.Format("delete from DM_SANPHAM_CQLD where SP_MAU = '{0}'", rdMau.EditValue + string.Empty), clsConnection._conn);
                    cmd.ExecuteScalar();
                    clsMessage.MessageInfo("Xóa dữ liệu thành công.");
                }
            }
            catch (Exception)
            {
                clsMessage.MessageExclamation("Dữ liệu đã được sử dụng bạn không thể xóa.");
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}