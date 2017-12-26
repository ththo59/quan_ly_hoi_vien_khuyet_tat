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
using System.Text.RegularExpressions;

namespace DauThau.Forms
{
    public partial class frmExcelImportTenderData : DevExpress.XtraEditors.XtraForm
    {
        string _maDotDauThau = string.Empty;
        public frmExcelImportTenderData(string _DotDauThau)
        {
            InitializeComponent();
            _maDotDauThau = _DotDauThau;
        }

        DataTable data = new DataTable();


        Boolean LoadExcels(string filePath)
        {
            try
            {
                Int32 goiThau_ID = Convert.ToInt32(lueGoiThau.EditValue);

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

                int index = 0;
                if (goiThau_ID == 50) index = 1;
                OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [" + dt.Rows[index]["TABLE_NAME"].ToString() + "]", con);
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
                    lueSPMa.Properties.DataSource = lueTenThuongMai.Properties.DataSource = lueNuocSX.Properties.DataSource
                    = lueQuiCachDongGoi.Properties.DataSource = lueHangSX.Properties.DataSource
                    = lueGPNK.Properties.DataSource = luePhanLoai.Properties.DataSource
                    = lueGiaKeKhai.Properties.DataSource = lueGiaChaoThau.Properties.DataSource
                     = lueCongTy.Properties.DataSource = lueDiaChi.Properties.DataSource
                    = lueDienThoai.Properties.DataSource = lueFax.Properties.DataSource 
                    = lueKyThuat01.Properties.DataSource = lueDiem01.Properties.DataSource
                    = lueKyThuat02.Properties.DataSource = lueDiem02.Properties.DataSource
                    = lueKyThuat03.Properties.DataSource = lueDiem03.Properties.DataSource
                    = lueKyThuat04.Properties.DataSource = lueDiem04.Properties.DataSource
                    = lueKyThuat05.Properties.DataSource = lueDiem05.Properties.DataSource
                    = lueKyThuat06.Properties.DataSource = lueDiem06.Properties.DataSource
                    = lueKyThuat07.Properties.DataSource = lueDiem07.Properties.DataSource
                    = lueKyThuat08.Properties.DataSource = lueDiem08.Properties.DataSource
                    = lueKyThuat09.Properties.DataSource = lueDiem09.Properties.DataSource
                    = lueKyThuat10.Properties.DataSource = lueDiem10.Properties.DataSource
                    = lueKyThuat11.Properties.DataSource = lueDiem11.Properties.DataSource
                    = lueKyThuat12.Properties.DataSource = lueDiem12.Properties.DataSource
                    = lueKyThuat13.Properties.DataSource = lueDiem13.Properties.DataSource
                    = lueKyThuat14.Properties.DataSource = lueDiem14.Properties.DataSource
                    = lueKyThuat15.Properties.DataSource = lueDiem15.Properties.DataSource
                    = lueTongDiemKT.Properties.DataSource
                    =  _list;


               
                if (goiThau_ID == 50 || goiThau_ID == 51 || goiThau_ID == 52)
                {
                    #region G1, G2, G3
                    
                    lueSPMa.EditValue = "F2";
                    lueTenThuongMai.EditValue = "th«ng tin nhµ thÇu";

                    lueHangSX.EditValue = "F10";
                    lueNuocSX.EditValue = "F11";
                    lueQuiCachDongGoi.EditValue = "F12";
                    lueGPNK.EditValue = "F13";
                    luePhanLoai.EditValue = "F14";

                    lueGiaKeKhai.EditValue = "F46";
                    lueGiaChaoThau.EditValue = "F47";

                    lueCongTy.EditValue = "F48";
                    lueDiaChi.EditValue = "F49";
                    lueDienThoai.EditValue = "F50";
                    lueFax.EditValue = "F51";

                    lueKyThuat01.EditValue = "F15";
                    lueDiem01.EditValue = "F16";

                    lueKyThuat02.EditValue = "F17";
                    lueDiem02.EditValue = "F18";

                    lueKyThuat03.EditValue = "F19";
                    lueDiem03.EditValue = "F20";

                    lueKyThuat04.EditValue = "F21";
                    lueDiem04.EditValue = "F22";

                    lueKyThuat05.EditValue = "F23";
                    lueDiem05.EditValue = "F24";

                    lueKyThuat06.EditValue = "F25";
                    lueDiem06.EditValue = "F26";

                    lueKyThuat07.EditValue = "F27";
                    lueDiem07.EditValue = "F28";

                    lueKyThuat08.EditValue = "F29";
                    lueDiem08.EditValue = "F30";

                    lueKyThuat09.EditValue = "F31";
                    lueDiem09.EditValue = "F32";

                    lueKyThuat10.EditValue = "F33";
                    lueDiem10.EditValue = "F34";

                    lueKyThuat11.EditValue = "F35";
                    lueDiem11.EditValue = "F36";

                    lueKyThuat12.EditValue = "F37";
                    lueDiem12.EditValue = "F38";

                    lueKyThuat13.EditValue = "F39";
                    lueDiem13.EditValue = "F40";

                    lueKyThuat14.EditValue = "F41";
                    lueDiem14.EditValue = "F42";

                    lueKyThuat15.EditValue = "F43";
                    lueDiem15.EditValue = "F44";

                    lueTongDiemKT.EditValue = "F45";

                    #endregion
                }else
                {
                    #region G4
                    lueSPMa.EditValue = "F2";
                    lueTenThuongMai.EditValue = "th«ng tin nhµ thÇu";
                    lueHangSX.EditValue = "F9";
                    lueNuocSX.EditValue = "F10";
                    lueQuiCachDongGoi.EditValue = "F11";
                    //lueGPNK.EditValue = "F14";
                    //luePhanLoai.EditValue = "F15";

                    //lueGiaKeKhai.EditValue = "F36";
                    lueGiaChaoThau.EditValue = "F37";

                    lueCongTy.EditValue = "F38";
                    lueDiaChi.EditValue = "F39";
                    lueDienThoai.EditValue = "F40";
                    lueFax.EditValue = "F41";

                    lueKyThuat01.EditValue = "F12";
                    lueDiem01.EditValue = "F13";

                    lueKyThuat02.EditValue = "F14";
                    lueDiem02.EditValue = "F15";

                    lueKyThuat03.EditValue = "F16";
                    lueDiem03.EditValue = "F17";

                    lueKyThuat04.EditValue = "F18";
                    lueDiem04.EditValue = "F19";

                    lueKyThuat05.EditValue = "F20";
                    lueDiem05.EditValue = "F21";

                    lueKyThuat06.EditValue = "F22";
                    lueDiem06.EditValue = "F23";

                    lueKyThuat07.EditValue = "F24";
                    lueDiem07.EditValue = "F25";

                    lueKyThuat08.EditValue = "F26";
                    lueDiem08.EditValue = "F27";

                    lueKyThuat09.EditValue = "F28";
                    lueDiem09.EditValue = "F29";

                    lueKyThuat10.EditValue = "F30";
                    lueDiem10.EditValue = "F31";

                    lueKyThuat11.EditValue = "F32";
                    lueDiem11.EditValue = "F33";

                    lueKyThuat12.EditValue = "F34";
                    lueDiem12.EditValue = "F35";

                    //lueKyThuat13.EditValue = "F40";
                    //lueDiem13.EditValue = "F41";

                    //lueKyThuat14.EditValue = "F42";
                    //lueDiem14.EditValue = "F43";

                    //lueKyThuat15.EditValue = "F44";
                    //lueDiem15.EditValue = "F45";

                    lueTongDiemKT.EditValue = "F36";
                    #endregion
                }

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
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();

            FormHelper.LookUpEdit_Init(lueGoiThau);
        }

        public class clsObject
        {
            public string TEN { get; set;}
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (lueGoiThau.Text == "")
            {
                clsMessage.MessageWarning("Vui lòng chọn gói thầu.");
                return;
            }

            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            if (f.FileName!=string.Empty)
            {
                txtPath.Text = f.FileName;
                LoadExcels(txtPath.Text);
            }
        }

        #region Function

        Boolean KiemTraGoiThauDaImport()
        {
            DataTable t = new DataTable();
            t = FunctionHelper.LoadDM("select * from DM_SANPHAM where SP_GOITHAU = " + lueGoiThau.EditValue + "");
            return t.Rows.Count > 0;
        }

        /// <summary>
        /// Kiểm tra dữ liệu
        /// </summary>
        /// <returns></returns>
        Boolean Validation()
        {
            dxErrorProvider1.ClearErrors();

            if (lueGoiThau.EditValue == null)
                dxErrorProvider1.SetError(lueGoiThau, "Gói thầu không được rỗng.");

            if(lueSPMa.EditValue==null)
                dxErrorProvider1.SetError(lueSPMa, "Mã sản phẩm không được rỗng.");
            
            if (lueTenThuongMai.EditValue == null)
                dxErrorProvider1.SetError(lueTenThuongMai, "Đơn vị tính không được rỗng.");

            if (lueGiaKeKhai.EditValue == null && Convert.ToInt64(lueGoiThau.EditValue) != 53)
                dxErrorProvider1.SetError(lueGiaKeKhai, "Giá kê khai không được rỗng.");

            if (lueGiaChaoThau.EditValue == null)
                dxErrorProvider1.SetError(lueGiaChaoThau, "Giá chào thầu không được rỗng.");

            if (lueGoiThau.EditValue == null)
                dxErrorProvider1.SetError(lueGoiThau, "Giá chào thầu không được rỗng.");

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
            lueSPMa.EditValue = lueTenThuongMai.EditValue = lueNuocSX.EditValue
                    = lueQuiCachDongGoi.EditValue = lueHangSX.EditValue
                    = lueGPNK.EditValue = luePhanLoai.EditValue
                    = lueGiaKeKhai.EditValue = lueGiaChaoThau.EditValue
                     = lueCongTy.EditValue = lueDiaChi.EditValue
                    = lueDienThoai.EditValue = lueFax.EditValue
                    = lueKyThuat01.EditValue = lueDiem01.EditValue
                    = lueKyThuat02.EditValue = lueDiem02.EditValue
                    = lueKyThuat03.EditValue = lueDiem03.EditValue
                    = lueKyThuat04.EditValue = lueDiem04.EditValue
                    = lueKyThuat05.EditValue = lueDiem05.EditValue
                    = lueKyThuat06.EditValue = lueDiem06.EditValue
                    = lueKyThuat07.EditValue = lueDiem07.EditValue
                    = lueKyThuat08.EditValue = lueDiem08.EditValue
                    = lueKyThuat09.EditValue = lueDiem09.EditValue
                    = lueKyThuat10.EditValue = lueDiem10.EditValue
                    = lueKyThuat11.EditValue = lueDiem11.EditValue
                    = lueKyThuat12.EditValue = lueDiem12.EditValue
                    = lueKyThuat13.EditValue = lueDiem13.EditValue
                    = lueKyThuat14.EditValue = lueDiem14.EditValue
                    = lueKyThuat15.EditValue = lueDiem15.EditValue
                    = lueTongDiemKT.EditValue
                    = null;

            txtPath.EditValue = null;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
           

            if (txtPath.Text == "")
            {
                clsMessage.MessageWarning("Vui lòng chọn file excel.");
                return;
            }

            WaitDialogForm _wait = new WaitDialogForm("Đang tải kiểm tra dữ liệu...", "Vui lòng đợi giây lát");
            //try
            //{
            object row = lueGoiThau.Properties.GetDataSourceRowByKeyValue(lueGoiThau.EditValue);
            string _tenVietTatGoiThau = string.Empty;
            if (row != null)
            {

            }

            if (Validation())
            {
                _wait.Close();
                clsMessage.MessageWarning("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            
            string _maCty = string.Empty;
            Int64 _goiThau_ID = Convert.ToInt64(lueGoiThau.EditValue);
            DataTable dtGoiThau = FunctionHelper.LoadDM("select * from DM_GOITHAU  where GOITHAU_ID = " + _goiThau_ID);
            string tenVietTatGoiThau = dtGoiThau.Rows[0]["TEN_VIET_TAT"] + string.Empty;
            DataTable dtSP = FunctionHelper.LoadDM(string.Format("select * from DM_SANPHAM"));
            Boolean _checkCongTy = false;
            int _numProduct = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                _wait.Caption = string.Format("Đang nạp dữ liêu {0}/{1}", i, data.Rows.Count);
                //Tìm dòng dữ liệu bắt đầu chứa mã sản phẩm
                DataRow _row = data.Rows[i];
                string _maSP = _row[lueSPMa.EditValue + string.Empty] + string.Empty;
                if (!_maSP.Contains(tenVietTatGoiThau)) //Kiểm tra sản phẩm có thuộc gói thầu đang chọn.
                {
                    continue;
                }

                //không xét các sản phẩm không nhập tên thương mại
                string _tenThuongMai = removeCharacter(_row[lueTenThuongMai.EditValue + string.Empty]);
                if (string.IsNullOrEmpty(_tenThuongMai))
                {
                    continue;
                }

                SqlCommand cmd;


                //Nạp thông tin công ty (insert 1 lần cho 1 file)
                string _tenCTY = _row[lueCongTy.EditValue + string.Empty] + string.Empty;
                if (string.IsNullOrEmpty(_tenCTY))
                {
                    _wait.Close();
                    clsMessage.MessageError(string.Format("Sản phẩm [{0}] dòng tên công ty rỗng. Vui lòng kiểm tra lại", _maSP));
                    return;
                }

                #region Công ty

                if (!_checkCongTy)
                {
                    DataTable dtCty = FunctionHelper.LoadDM(string.Format("select * from DM_CONGTY where TEN = N'{0}'", _tenCTY));
                    if (dtCty.Rows.Count == 0 && _maCty == string.Empty)
                    {
                        string strCty = "Insert into DM_CONGTY (CTY_MA,TEN, DIACHI,DIENTHOAI,FAX,DOT_MA) values (@CTY_MA, @TEN, @DIACHI, @DIENTHOAI, @FAX,@DOT_MA)";
                        cmd = new SqlCommand(strCty, clsConnection._conn);
                        _maCty = FunctionHelper.LayMaTuTangCongTy();
                        cmd.Parameters.Add("@CTY_MA", SqlDbType.NVarChar).Value = _maCty;
                        cmd.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = _tenCTY;
                        cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = _row[lueDiaChi.EditValue + string.Empty] + string.Empty;
                        cmd.Parameters.Add("@DIENTHOAI", SqlDbType.NVarChar).Value = _row[lueDienThoai.EditValue + string.Empty] + string.Empty;
                        cmd.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = _row[lueFax.EditValue + string.Empty] + string.Empty;
                        cmd.Parameters.Add("@DOT_MA", SqlDbType.NVarChar).Value = clsParameter._dotMaDauThau;
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        _maCty = dtCty.Rows[0]["CTY_MA"] + string.Empty;
                    }

                    //Kiểm tra công ty đã nạp gói thầu chưa
                    string query = string.Format("select top 1 * from DAU_THAU where CTY_MA = '{0}' and GOITHAU_ID = {1}", _maCty, _goiThau_ID);
                    DataTable t = FunctionHelper.LoadDM(query);
                    if (t.Rows.Count > 0)
                    {
                        _wait.Hide();
                        if (clsMessage.MessageYesNo(string.Format("Dữ liệu công ty [{0}] đã nạp. Bạn có muốn nạp lại?", _tenCTY)) == DialogResult.Yes)
                        {
                            //Xóa dữ liệu cũ
                            query = string.Format("delete from DAUTHAU_CT where CTY_MA = '{0}' and GOITHAU_ID = {1} ; delete from DAU_THAU where CTY_MA = '{0}' and GOITHAU_ID = {1}", _maCty, _goiThau_ID);
                            SqlCommand cmdDelete = new SqlCommand(query, clsConnection._conn);
                            cmdDelete.ExecuteNonQuery();
                            _wait.Show();
                        }
                        else
                        {
                            return;
                        }
                    }

                    _checkCongTy = true;
                }

                #endregion

                #region Đấu thầu

                string strDauThau = "Insert into DAU_THAU (CTY_MA, NGAY, GOITHAU_ID, SP_ID, SP_MA, SP_TEN_THUONGMAI "
                    + " , HANGSX, NUOCSX_ID, DONG_GOI, SP_SODK_VISA, PHANLOAI, GIA_CHAOTHAU, GIA_KEKHAI_BYT, TONG_DIEM_KT)"
                    + " values (@CTY_MA, @NGAY, @GOITHAU_ID, @SP_ID, @SP_MA, @SP_TEN_THUONGMAI "
                    + " ,@HANGSX, @NUOCSX_ID, @DONG_GOI, @SP_SODK_VISA, @PHANLOAI, @GIA_CHAOTHAU, @GIA_KEKHAI_BYT, @TONG_DIEM_KT) "
                    + " ; Select Scope_Identity()";

                cmd = new SqlCommand(strDauThau, clsConnection._conn);
                cmd.Parameters.Add("@CTY_MA", SqlDbType.NVarChar).Value = _maCty;
                cmd.Parameters.Add("@NGAY", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt).Value = _goiThau_ID;

                DataRow[] rowSP = dtSP.Select(string.Format("SP_MA = '{0}'", _maSP));
                if (rowSP.Length == 0)
                {
                    _wait.Close();
                    clsMessage.MessageExclamation(string.Format("Sản phẩm [{0}] không tìm thấy. Vui lòng kiểm tra lại", _maSP));
                    continue;
                    //return;
                }
                cmd.Parameters.Add("@SP_ID", SqlDbType.BigInt).Value = Convert.ToInt64(rowSP[0]["SP_ID"]);
                cmd.Parameters.Add("@SP_MA", SqlDbType.NVarChar).Value = _maSP;
                cmd.Parameters.Add("@SP_TEN_THUONGMAI", SqlDbType.NVarChar).Value = _tenThuongMai;

                if (lueHangSX.EditValue != null)
                    cmd.Parameters.Add("@HANGSX", SqlDbType.NVarChar).Value = removeCharacter(_row[lueHangSX.EditValue + string.Empty]);
                else cmd.Parameters.Add("@HANGSX", SqlDbType.NVarChar).Value = DBNull.Value;

                if (lueNuocSX.EditValue != null)
                {
                    string _tenNuocSX = _row[lueHangSX.EditValue + string.Empty] + string.Empty;
                    Int64 _nuocSX_ID = 0;
                    DataTable dtNuocSX = FunctionHelper.LoadDM(string.Format("select * from DM_NUOCSX where TEN = N'{0}'", _tenNuocSX));
                    if (dtNuocSX.Rows.Count == 0)
                    {
                        //tạo nuocs sản xuất mới.
                        string queryNuocSX = string.Format("insert into DM_NUOCSX (TEN) values ('{0}'); Select Scope_Identity() ", _tenNuocSX);
                        SqlCommand cmdNuocSX = new SqlCommand(queryNuocSX, clsConnection._conn);
                        _nuocSX_ID = Convert.ToInt64(cmdNuocSX.ExecuteScalar());
                    }
                    else
                    {
                        _nuocSX_ID = Convert.ToInt64(dtNuocSX.Rows[0]["NUOCSX_ID"]);
                    }
                    cmd.Parameters.Add("@NUOCSX_ID", SqlDbType.BigInt).Value = _nuocSX_ID;
                }
                else cmd.Parameters.Add("@NUOCSX_ID", SqlDbType.BigInt).Value = DBNull.Value;

                if (lueQuiCachDongGoi.EditValue != null)
                    cmd.Parameters.Add("@DONG_GOI", SqlDbType.NVarChar).Value = removeCharacter(_row[lueQuiCachDongGoi.EditValue + string.Empty]);
                else cmd.Parameters.Add("@DONG_GOI", SqlDbType.NVarChar).Value = DBNull.Value;

                if (lueGPNK.EditValue != null)
                    cmd.Parameters.Add("@SP_SODK_VISA", SqlDbType.NVarChar).Value = removeCharacter(_row[lueGPNK.EditValue + string.Empty]);
                else cmd.Parameters.Add("@SP_SODK_VISA", SqlDbType.NVarChar).Value = DBNull.Value;

                if (luePhanLoai.EditValue != null)
                    cmd.Parameters.Add("@PHANLOAI", SqlDbType.NVarChar).Value = removeCharacter(_row[luePhanLoai.EditValue + string.Empty]);
                else cmd.Parameters.Add("@PHANLOAI", SqlDbType.NVarChar).Value = DBNull.Value;

                if (lueGiaChaoThau.EditValue != null)
                {
                    string sGiaChaoThau = _row[lueGiaChaoThau.EditValue + string.Empty] +string.Empty;
                    if(sGiaChaoThau.Trim() == "")
                    {
                        _wait.Close();
                        clsMessage.MessageExclamation(string.Format("sản phẩm [{0}], giá chào thầu rỗng.", _maSP));
                        return;
                    }
                    cmd.Parameters.Add("@GIA_CHAOTHAU", SqlDbType.BigInt).Value = Convert.ToInt64(sGiaChaoThau);
                }
                else cmd.Parameters.Add("@GIA_CHAOTHAU", SqlDbType.BigInt).Value = DBNull.Value;

                if (lueGiaKeKhai.EditValue != null && _goiThau_ID != 53)
                {
                    string sGiaKeKhai = _row[lueGiaKeKhai.EditValue + string.Empty] + string.Empty;
                    if (sGiaKeKhai.Trim() == "")
                    {
                        _wait.Close();
                        clsMessage.MessageExclamation(string.Format("sản phẩm [{0}], giá kê khai rỗng.", _maSP));
                        return;
                    }
                    cmd.Parameters.Add("@GIA_KEKHAI_BYT", SqlDbType.BigInt).Value = Convert.ToInt64(sGiaKeKhai);
                }
                else cmd.Parameters.Add("@GIA_KEKHAI_BYT", SqlDbType.BigInt).Value = DBNull.Value;

                if(lueTongDiemKT.EditValue != null)
                {
                    cmd.Parameters.Add("@TONG_DIEM_KT", SqlDbType.BigInt).Value = Convert.ToInt64(_row[lueTongDiemKT.EditValue + string.Empty]);
                }
                else
                {
                    cmd.Parameters.Add("@TONG_DIEM_KT", SqlDbType.BigInt).Value = DBNull.Value;
                }

                Int64 idDauThau = Convert.ToInt64(cmd.ExecuteScalar());

                #endregion

                #region Điểm KT

                //nạp điểm kỹ thuật
                if (lueKyThuat01.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat01, lueDiem01, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                        
                }
                if (lueKyThuat02.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat02, lueDiem02, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                }

                if (lueKyThuat03.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat03, lueDiem03, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                }
                if (lueKyThuat04.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat04, lueDiem04, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                }
                if (lueKyThuat05.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat05, lueDiem05, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                }
                if (lueKyThuat06.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat06, lueDiem06, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                }
                if (lueKyThuat07.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat07, lueDiem07, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                }
                if (lueKyThuat08.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat08, lueDiem08, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                }
                if (lueKyThuat09.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat09, lueDiem09, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                }
                if (lueKyThuat10.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat10, lueDiem10, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                }
                if (lueKyThuat11.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat11, lueDiem11, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                }
                if (lueKyThuat12.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat12, lueDiem12, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                }
                if (lueKyThuat13.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat13, lueDiem13, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }

                }
                if (lueKyThuat14.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat14, lueDiem14, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                }
                if (lueKyThuat15.EditValue != null)
                {
                    if (!insertTenderDetail(_row, lueKyThuat15, lueDiem15, idDauThau, _maCty, _goiThau_ID, _maSP))
                    {
                        _wait.Close();
                        return;
                    }
                }
                #endregion

                _numProduct++;
            }

            if(_numProduct == 0)
            {
                clsMessage.MessageInfo(string.Format("Có {0} sản phẩm được nạp. Vui lòng kiểm tra có chọn đúng gói thầu.", _numProduct));
            }else
            clsMessage.MessageInfo(string.Format("Có {0} sản phẩm được nạp.", _numProduct));

            _wait.Close();
            ClearEditValue();
        }

        public Boolean insertTenderDetail(DataRow _row, LookUpEdit lueKyThuat, LookUpEdit lueDiem,  Int64 idDauThau, string _maCty, Int64 _goiThau_ID, string _maSP)
        {
            string queryDauThauCT = "insert into DAUTHAU_CT (DAUTHAU_ID, CTY_MA, GOITHAU_ID, SP_MA, NHOM_KYTHUAT_CT_ID, DIEM)"
                        + " values (@DAUTHAU_ID, @CTY_MA, @GOITHAU_ID, @SP_MA, @NHOM_KYTHUAT_CT_ID, @DIEM) ";
            SqlCommand cmdDauThauCT = new SqlCommand(queryDauThauCT, clsConnection._conn);
            cmdDauThauCT.Parameters.Add("@DAUTHAU_ID", SqlDbType.BigInt).Value = idDauThau;
            cmdDauThauCT.Parameters.Add("@CTY_MA", SqlDbType.NVarChar).Value = _maCty;
            cmdDauThauCT.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt).Value = _goiThau_ID;
            cmdDauThauCT.Parameters.Add("@SP_MA", SqlDbType.NVarChar).Value = _maSP;

            int nhomKyThuat_ID = 0;
            //Tên nhóm kỹ thuật Luôn lấy dòng đầu tiên
            string strNhomKyThuat = removeCharacter(data.Rows[0][lueKyThuat.EditValue + string.Empty]);
            strNhomKyThuat = convertToUnSignUnicode(strNhomKyThuat).Trim().ToLower();
            strNhomKyThuat = removeFirstCharacterSpecial(strNhomKyThuat);

            //xóa số và dấu chấm tên nhóm KT
            string query = "select distinct b.NHOM_KYTHUAT_ID, b.TEN from DM_GOITHAU_KYTHUAT a"
                        + " join DM_NHOM_KYTHUAT b on a.NHOM_KYTHUAT_ID = b.NHOM_KYTHUAT_ID"
                        + " where a.GOITHAU_ID = " + _goiThau_ID;

            DataTable dtNhomKT = FunctionHelper.LoadDM(query);
            for (int k = 0; k < dtNhomKT.Rows.Count; k++)
            {
                string tenNhomKT = convertToUnSignUnicode(dtNhomKT.Rows[k]["TEN"] + string.Empty).Trim().ToLower();
                tenNhomKT = removeFirstCharacterSpecial(tenNhomKT);
                
                //Xóa hết các khoảng trắng trong chuỗi.
                tenNhomKT = tenNhomKT.Replace(" ", string.Empty);

                if (strNhomKyThuat.Contains(tenNhomKT))
                {
                    nhomKyThuat_ID = Convert.ToInt32(dtNhomKT.Rows[k]["NHOM_KYTHUAT_ID"] + string.Empty);
                    break;
                }

            }

            if (nhomKyThuat_ID == 0)
            {
                clsMessage.MessageExclamation(string.Format("Nhóm [{0}]\nSản phẩm [{1}] không tìm thấy ID phù hợp.\nVui lòng kiểm tra lại.", data.Rows[0][lueKyThuat.EditValue + string.Empty] +string.Empty, _maSP));
                return false;
            }

            //tìm ID nhóm kỹ thuật chi tiết
            string strNhomKyThuatCT = removeCharacter(_row[lueKyThuat.EditValue + string.Empty]);
            strNhomKyThuatCT = convertToUnSignUnicode(strNhomKyThuatCT).Trim().ToLower();
            strNhomKyThuatCT = removeFirstCharacterSpecial(strNhomKyThuatCT);

            //if(strNhomKyThuatCT == "")
            //{
            //    if (chkChoPhepNhomKT_CT_Rong.Checked)
            //    {
            //        return true;
            //    }else
            //    {
            //        clsMessage.MessageExclamation(string.Format("Nhóm chi tiết của cột [{0}] của sản phẩm [{1}] rỗng.\nVui lòng kiểm tra lại."
            //            , data.Rows[0][lueKyThuat.EditValue + string.Empty] + string .Empty, _maSP));
            //        return false;
            //    }
            //}

            query = string.Format("select distinct b.NHOM_KYTHUAT_CT_ID , b.DIEN_GIAI as TEN from DM_GOITHAU_KYTHUAT a "
                + " join DM_NHOM_KYTHUAT_CT b on a.NHOM_KYTHUAT_CT_ID = b.NHOM_KYTHUAT_CT_ID "
                + " where a.GOITHAU_ID = {0} and a.NHOM_KYTHUAT_ID = {1}", _goiThau_ID, nhomKyThuat_ID);
            DataTable dtNhomKT_CT = FunctionHelper.LoadDM(query);
            Int32 nhomKyThuatCT_ID = 0;
            Int32 numTimesNhomKyThuatCT_ID = 0;
            for (int k = 0; k < dtNhomKT_CT.Rows.Count; k++)
            {
                string tenNhomKT_CT = convertToUnSignUnicode(dtNhomKT_CT.Rows[k]["TEN"] + string.Empty).Trim().ToLower();
                tenNhomKT_CT = removeFirstCharacterSpecial(tenNhomKT_CT); ;

                if (strNhomKyThuatCT == tenNhomKT_CT)
                {
                    nhomKyThuatCT_ID = Convert.ToInt32(dtNhomKT_CT.Rows[k]["NHOM_KYTHUAT_CT_ID"] + string.Empty);
                    numTimesNhomKyThuatCT_ID++;
                }

            }

            if (numTimesNhomKyThuatCT_ID > 1)
            {
                clsMessage.MessageExclamation(string.Format("Nhóm chi tiết [{0}]\nSản phẩm [{1}] tìm thầy nhiều ID chi tiết kỹ thuật.\nVui lòng kiểm tra lại.", _row[lueKyThuat.EditValue + string.Empty] +string.Empty, _maSP));
                return false;
            }

            if (nhomKyThuatCT_ID == 0)
            {
                clsMessage.MessageExclamation(string.Format("Nhóm [{0}]\nNhóm chi tiết [{1}]\nSản phẩm [{2}] không tìm thấy ID chi tiết kỹ thuật.\nVui lòng kiểm tra lại."
                    , data.Rows[0][lueKyThuat.EditValue + string.Empty] + string.Empty
                    , _row[lueKyThuat.EditValue + string.Empty] + string.Empty
                    , _maSP));
                return false;
            }
            cmdDauThauCT.Parameters.Add("@NHOM_KYTHUAT_CT_ID", SqlDbType.Int).Value = nhomKyThuatCT_ID;
            cmdDauThauCT.Parameters.Add("@DIEM", SqlDbType.Int).Value = clsChangeType.change_int(_row[lueDiem.EditValue + string.Empty]);
            cmdDauThauCT.ExecuteNonQuery();
            return true;
        }

        public static string convertToUnSignUnicode(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        /// <summary>
        /// Xóa bỏ các ký tự \n, \r, \t
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        string removeCharacter(object obj)
        {
            string str = obj + string.Empty;
            return str.Replace("\n", String.Empty).Replace("\t", String.Empty).Replace("\r", String.Empty).Trim();
        }


        #region Event Button

        private void lueSoThongTu_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                luePhanLoai.EditValue = null;
            }
        }

        private void lueSoLuongBH_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueFax.EditValue = null;
            }
        }

        private void lueSoLuongCS_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueKyThuat01.EditValue = null;
            }
        }

        

        private void lueGiaKeHoach_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueGiaKeKhai.EditValue = null;
            }
        }

        private void lueKhuVucSX_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueDienThoai.EditValue = null;
            }
        }

        private void lueBietDuoc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueTenThuongMai.EditValue = null;
            }
        }

        private void lueHamLuongSP_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueHangSX.EditValue = null;
            }
        }

        private void lueDangDung_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueNuocSX.EditValue = null;
            }
        }

        private void lueQuiCach_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueGiaChaoThau.EditValue = null;
            }
        }

        private void lueNuocSX_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueCongTy.EditValue = null;
            }
        }

        private void lueTieuChuanKT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueDiaChi.EditValue = null;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lueGoiThau.EditValue == null)
            {
                clsMessage.MessageWarning("Vui lòng chọn gói thầu.");
                return;
            }
            try
            {
                DataTable t = FunctionHelper.LoadDM("select * from DAU_THAU where GOITHAU_ID =" + clsChangeType.change_int(lueGoiThau.EditValue));
                if (t.Rows.Count > 0)
                {
                    clsMessage.MessageExclamation("Dữ liệu đã được sử dụng bạn không thể xóa.");
                    return;
                }
                if (clsMessage.MessageYesNo("Bạn có chắc muốn xóa dữ liệu của gói thầu đang chọn") == System.Windows.Forms.DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("delete from DM_SANPHAM where SP_GOITHAU=" + clsChangeType.change_int(lueGoiThau.EditValue), clsConnection._conn);
                    cmd.ExecuteScalar();
                    clsMessage.MessageInfo("Xóa dữ liệu của gói thầu \"" + lueGoiThau.Text + "\" thành công.");
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

        #endregion


        /// <summary>
        /// Xóa các ký tự đặc biệt ở đầu chuỗi
        /// </summary>
        /// <returns></returns>
        public string removeFirstCharacterSpecial(string ten)
        {
            string[] stringArray = { ")", ".", "+", "/" , "-"};
            //Xét 10 ký tự đầu tiên
            int max_check = 10;
            int lenght_check = ten.Length > max_check ? max_check : ten.Length;
            string ten_check = ten.Substring(0, lenght_check);
            
            //Tìm vị trí các ký tự đặc biệt
            int pos = -1;
            foreach (string character in stringArray)
            {
                pos = ten_check.LastIndexOf(character);
                if (pos >= 0)
                {
                    break;
                }
            }

            if (pos >= 0)
            {
                ten = ten.Substring(pos + 1).Trim();
            }

            //xóa bỏ dấu chấm cuối câu
            if (ten.LastIndexOf(".") > 0)
            {
                ten = ten.Substring(0, ten.Length - 1);
            }

            ten = ten.Replace(" ", string.Empty);
            ten = ten.Replace(",", string.Empty);
            ten = ten.Replace("*", string.Empty);
            //Bỏ dấu chấm cuối cùng
            if (ten.LastIndexOf(".") > 0)
            {
                ten = ten.Substring(0, ten.Length - 1);
            }
            return ten;
        }

        private void btnConvertUnicode_Click(object sender, EventArgs e)
        {
            string query = "select * from DM_NHOM_KYTHUAT_CT";
            
            
            DataTable dt = FunctionHelper.LoadDM(query);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string ten = (dt.Rows[i]["TEN"] + string.Empty).Trim();

                ten = removeFirstCharacterSpecial(ten);

                Int32 nhomKyThuat_CT_ID = Convert.ToInt32(dt.Rows[i]["NHOM_KYTHUAT_CT_ID"]);
                ten = convertToUnSignUnicode(ten);
                string queryUpdate = string.Format("update DM_NHOM_KYTHUAT_CT set DIEN_GIAI = '{0}' where NHOM_KYTHUAT_CT_ID = {1}",ten, nhomKyThuat_CT_ID);
                SqlCommand cmd = new SqlCommand(queryUpdate, clsConnection._conn);
                cmd.ExecuteNonQuery();

            }

            clsMessage.MessageInfo("Cập nhật thành công.");
        }
    }
}