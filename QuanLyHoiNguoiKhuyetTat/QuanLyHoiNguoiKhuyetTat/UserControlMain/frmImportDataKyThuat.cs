using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using System.Data.SqlClient;
using DauThau.Class;
using DevExpress.XtraEditors;

namespace DauThau.UserControlCategoryMain
{
    public partial class frmImportDataKyThuat : Form
    {
        public frmImportDataKyThuat()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Điếm số dòng của tender detail, sau mỗi lần nạp công ty
        /// </summary>
        int numRowTenderDetail = 0;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            DialogResult r = f.ShowDialog();
            if (r == System.Windows.Forms.DialogResult.OK) {
                txtPath.Text = f.FileName;
                btnNap.Enabled = true;
            }else {
                btnNap.Enabled = false;
            }
        }

        /// <summary>
        /// Kiểm tra công ty có tồn tại trong danh sách đợt đấu thầu.
        /// </summary>
        /// <param name="_maCty"></param>
        /// <returns></returns>
        Boolean TonTaiMaCongTy(string _maCty)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from DM_CONGTY where CTY_MA='" + _maCty + "' and DOT_MA='"+clsParameter._dotMaDauThau+"'", clsConnection._conn);
            DataTable t = new DataTable();
            da.Fill(t);
            return t.Rows.Count > 0;

        }

        /// <summary>
        /// Kiểm tra công ty đã nhập dữ liệu.
        /// </summary>
        /// <returns></returns>
        Boolean DaNhapDuLieu(string _maCty)
        {
            string str = string.Format("select * from DM_CONGTY cty, DAU_THAU dt where cty.CTY_MA =  dt.CTY_MA and cty.CTY_MA='{0}' and cty.DOT_MA='{1}'", _maCty, clsParameter._dotMaDauThau);
            SqlDataAdapter da = new SqlDataAdapter(str, clsConnection._conn);
            DataTable t = new DataTable();
            da.Fill(t);
            return t.Rows.Count > 0;
        }

        string _ctyMa;
        private void btnNap_Click(object sender, EventArgs e)
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");

            // Khởi tạo giá trị ban đầu.
            DataSet t;
            _ctyMa = string.Empty;
            clsParameter._isLoadHoSoDauThau = true;
            numRowTenderDetail = 0;

            #region Công ty

            
            t = new DataSet();
            t.ReadXml(txtPath.Text);
            if (t.Tables.Count != 3 || !t.Tables.Contains("Company") || !t.Tables.Contains("Tender") || !t.Tables.Contains("TenderDetail"))
            {
                _wait.Close();
                clsMessage.MessageWarning("Dữ liệu nạp không phù hợp. Vui lòng kiểm tra lại.");
                return;
            }

            if (t.Tables["Tender"].Columns.Contains("GIA_KEKHAI_BYT") || t.Tables["Tender"].Columns.Contains("GIA_CHAOTHAU"))
            {
                _wait.Close();
                clsMessage.MessageWarning("Dữ liệu không phù hợp với file kỹ thuật. Vui lòng kiểm tra lại.");
                return;
            }

            _wait.Caption = "Đang xử lý dữ liệu Company ...";
            if (t.Tables["Company"].Rows.Count > 0)
            {
                _ctyMa = t.Tables["Company"].Rows[0]["CTY_MA"] + string.Empty;
                //Không tồn tại mã công ty.
                if (!TonTaiMaCongTy(t.Tables["Company"].Rows[0]["CTY_MA"].ToString()))
                {
                    _wait.Close();
                    string str = string.Format("Công ty Mã : \"{0}\", Tên : \"{1}\" không tồn tại trong danh sách đợt đấu thầu này. Vui lòng nhập thông tin công ty này.", t.Tables[0].Rows[0]["CTY_MA"].ToString().ToUpper(), t.Tables[0].Rows[0]["TEN"].ToString().ToUpper());
                    clsMessage.MessageWarning(str);
                    return;
                }

                //InsertCompany(t.Tables[0]);

                if (DaNhapDuLieu(t.Tables["Company"].Rows[0]["CTY_MA"].ToString()))
                {
                    _wait.Hide();
                    // clsMessage.MessageWarning("Công ty : \"" + t.Tables["Company"].Rows[0]["TEN"].ToString().ToUpper() + "\" đã được nhập trong đợt đấu thầu này.\nVui lòng kiểm tra lại.");
                    if(clsMessage.MessageYesNo("Công ty đã được nạp dữ liệu! Bạn có muốn nạp tiếp dữ liệu không?") == DialogResult.No)
                    {
                        _wait.Close();
                        return;
                    }
                    _wait.Show();
                }
                
            }
            else
            {
                _wait.Close();
                clsMessage.MessageWarning("Không có dữ liệu nhập liệu.\nVui lòng kiểm tra lại.");
                return;
            }

            #endregion

            //Nếu nạp sản phẩm lần 2, kiểm tra từng sản phẩm có tồn tại trong lần nạp trước hay chưa
            for (int i = 0; i < t.Tables["Tender"].Rows.Count; i++)
            {
                string _maSP = t.Tables["Tender"].Rows[i]["SP_MA"] + string.Empty;
                string query = string.Format("select SP_MA from DAU_THAU where CTY_MA = '{0}' and SP_MA = '{1}'", _ctyMa, _maSP);
                DataTable dt = FunctionHelper.LoadDM(query);
                if(dt.Rows.Count > 0)
                {
                    _wait.Close();
                    clsMessage.MessageWarning(string.Format("Dữ liệu sản phẩm ({0}) đã tồn tại. Vui lòng kiểm tra lại.", _maSP));
                    return;
                }
            }

            #region Thông tin đấu thầu

            _wait.Caption = "Đang xử lý dữ liệu Tender ...";
            //t = new DataSet();
            string TenGoiThau = string.Empty;
            //t.ReadXml(txtPath.Text + "\\Tender.xml");
            string _list =string.Empty;
            if (t.Tables["Tender"].Rows.Count > 0)
            {
                _wait.Close();
                

                DataTable dt = FunctionHelper.LoadDM("SELECT * FROM DM_CONGTY WHERE CTY_MA ='" + _ctyMa + "'");
                if (dt.Rows.Count > 0)
                {
                    DataTable dv = t.Tables["Tender"].DefaultView.ToTable(true, "GOITHAU_ID");
                    _list = (dt.Rows[0]["LIST_GOITHAU"] + string.Empty);//.Split(',');
                    for (int i = 0; i < dv.Rows.Count; i++)
                    {
                        if (!_list.Contains(dv.Rows[i][0]+string.Empty))
                        {
                            if(TenGoiThau==string.Empty)
                                TenGoiThau = "\n" + FunctionHelper.LoadDM("SELECT * FROM DM_GOITHAU WHERE GOITHAU_ID =" + dv.Rows[i][0] + string.Empty).Rows[0]["TEN"] + string.Empty;
                            else TenGoiThau = TenGoiThau + "\n" + FunctionHelper.LoadDM("SELECT * FROM DM_GOITHAU WHERE GOITHAU_ID =" + dv.Rows[i][0] + string.Empty).Rows[0]["TEN"] + string.Empty;
                        }
                    }
                }

                if (TenGoiThau != string.Empty)
                {
                    if (clsMessage.MessageYesNo(string.Format("Công ty có dữ liệu của gói thầu : {0} \nNhưng không đăng ký mua.\nBạn có chắc muốn nạp dữ liệu (chỉ nạp những gói đã mua).", TenGoiThau)) == DialogResult.No)
                        return;
                }
                
                //DataSet dtDetail = new DataSet();
                //dtDetail.ReadXml(txtPath.Text + "\\TenderDetail.xml");

                if (!InsertTender(t.Tables["Tender"], _list, t.Tables["TenderDetail"]))
                    return;
            }

            //_wait.Caption = "Đang xử lý dữ liệu TenderDetail ...";
            //DataSet dtDetail = new DataSet();
            //dtDetail.ReadXml(txtPath.Text + "\\TenderDetail.xml");
            //if (t.Tables[0].Rows.Count > 0)
            //    InsertTenderDetail(t.Tables[0],_list);
            
            _wait.Close();
           
            clsMessage.MessageInfo("Nạp dữ liệu kỹ thuật thành công!");
            #endregion

        }

        void InsertCompany(DataTable t)
        {
            try
            {
                _ctyMa = FunctionHelper.LayMaTuTangCongTy();
                string str = "Insert into DM_CONGTY (DOT_MA,CTY_MA,TEN,DIACHI, DIENTHOAI, FAX, EMAIL) "
                    + " values (@DOT_MA, @CTY_MA, @TEN, @DIACHI, @DIENTHOAI, @FAX, @EMAIL)";
                SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                cmd.Parameters.Add("@DOT_MA", SqlDbType.NVarChar).Value = clsParameter._dotMaDauThau;
                cmd.Parameters.Add("@CTY_MA", SqlDbType.NVarChar).Value = _ctyMa; //t.Rows[0]["CTY_MA"] + string.Empty;
                cmd.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = t.Rows[0]["TEN"] + string.Empty;
                cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = t.Rows[0]["DIACHI"] + string.Empty;
                cmd.Parameters.Add("@DIENTHOAI", SqlDbType.NVarChar).Value = t.Rows[0]["DIENTHOAI"] + string.Empty;
                cmd.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = t.Rows[0]["FAX"] + string.Empty;
                cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = t.Rows[0]["EMAIL"] + string.Empty;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                clsMessage.MessageWarning("Trùng mã công ty. Vui lòng kiểm tra lại.");
            }
           
        }

  
        Boolean InsertTender(DataTable t, string list, DataTable dtDetail)
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang nạp Tender ...", "Vui lòng đợi giây lát");
            try
            {
                DataRow[] r = t.Select("GOITHAU_ID in (" + list + ")");
                if (r.Count() == 0)
                {
                    _wait.Close();
                    clsMessage.MessageInfo("Không có dữ liệu của gói thầu đăng ký.");
                    return false;
                }

                for (int i = 0; i < r.Count(); i++) //for (int i = 0; i < t.Rows.Count; i++)
                {
                    //comment lại vì chỉ hiển thị chổ tender detail thôi.
                    //_wait.Caption = string.Format("Đang nạp Tender : {0}/{1} ...", i + 1, t.Rows.Count);
                    DataRow row = r[i];
                    string str = "Insert into DAU_THAU (NGAY,GOITHAU_ID,SP_ID,SP_MA,SP_TEN_THUONGMAI, SP_SODK_VISA "
                        + " , CTY_MA, HANG_SUDUNG,NUOCSX_ID,NUOCLD_ID,HANGSX,DONG_GOI,TONG_DIEM_KT "
                        + " , TEN_CTY_KEKHAI, SO_CV_KEKHAI, NGAY_KEKHAI, ICH"
                        + " , KHUVUC_SX, STT, SO_DOT_CQLD, SOLUONG_DUTHAU, SP_DIACHI_SX ) "
                        + " values (@NGAY, @GOITHAU_ID, @SP_ID, @SP_MA, @SP_TEN_THUONGMAI, @SP_SODK_VISA "
                        + " , @CTY_MA, @HANG_SUDUNG,@NUOCSX_ID,@NUOCLD_ID,@HANGSX,@DONG_GOI,@TONG_DIEM_KT "
                        + " , @TEN_CTY_KEKHAI, @SO_CV_KEKHAI, @NGAY_KEKHAI, @ICH"
                        + " , @KHUVUC_SX, @STT, @SO_DOT_CQLD, @SOLUONG_DUTHAU, @SP_DIACHI_SX)"
                        + " ; Select Scope_Identity()";
                    SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                    cmd.Parameters.Add("@NGAY", SqlDbType.DateTime).Value = Convert.ToDateTime(row["NGAY"]);
                    cmd.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt).Value = Convert.ToInt64(row["GOITHAU_ID"] + string.Empty);
                    cmd.Parameters.Add("@SP_ID", SqlDbType.BigInt).Value = Convert.ToInt64(row["SP_ID"]);
                    cmd.Parameters.Add("@SP_MA", SqlDbType.NVarChar).Value = row["SP_MA"] + string.Empty;
                    cmd.Parameters.Add("@SP_TEN_THUONGMAI", SqlDbType.NVarChar).Value = row["SP_TEN_THUONGMAI"] + string.Empty;
                    cmd.Parameters.Add("@SP_SODK_VISA", SqlDbType.NVarChar).Value = row["SP_SODK_VISA"] + string.Empty;
                    cmd.Parameters.Add("@CTY_MA", SqlDbType.NVarChar).Value = _ctyMa; 
                    //Nạp kỹ thuật không nạp giá BYT, giá chào thầu.
                    //cmd.Parameters.Add("@GIA_KEKHAI_BYT", SqlDbType.Int).Value = clsChangeType.change_int(r[i]["GIA_KEKHAI_BYT"]);
                    //cmd.Parameters.Add("@GIA_CHAOTHAU", SqlDbType.Int).Value = clsChangeType.change_int(r[i]["GIA_CHAOTHAU"]);
                    cmd.Parameters.Add("@HANG_SUDUNG", SqlDbType.Int).Value = clsChangeType.change_int(row["HANG_SUDUNG"]);
                    cmd.Parameters.Add("@NUOCSX_ID", SqlDbType.Int).Value = clsChangeType.change_int(row["NUOCSX_ID"]);
                    cmd.Parameters.Add("@NUOCLD_ID", SqlDbType.Int).Value = clsChangeType.change_int(row["NUOCLD_ID"]);
                    cmd.Parameters.Add("@HANGSX", SqlDbType.NVarChar).Value = row["HANGSX"] + string.Empty;
                    cmd.Parameters.Add("@DONG_GOI", SqlDbType.NVarChar).Value = row["DONG_GOI"] + string.Empty;
                    cmd.Parameters.Add("@TONG_DIEM_KT", SqlDbType.Int).Value = row["TONG_DIEM_KT"] + string.Empty;

                    //16-08-2014
                    cmd.Parameters.Add("@TEN_CTY_KEKHAI", SqlDbType.NVarChar).Value = row["TEN_CTY_KEKHAI"] + string.Empty;
                    cmd.Parameters.Add("@SO_CV_KEKHAI", SqlDbType.NVarChar).Value = row["SO_CV_KEKHAI"] + string.Empty;
                    if (!string.IsNullOrEmpty(row["NGAY_KEKHAI"] + string.Empty))
                        cmd.Parameters.Add("@NGAY_KEKHAI", SqlDbType.DateTime).Value = Convert.ToDateTime(row["NGAY_KEKHAI"] + string.Empty);
                    else cmd.Parameters.Add("@NGAY_KEKHAI", SqlDbType.DateTime).Value = new DateTime(1900,1,1);
                    cmd.Parameters.Add("@ICH", SqlDbType.NVarChar).Value = row["ICH"] + string.Empty;

                    //Bổ sung ngày 19/10/2016
                    cmd.Parameters.Add("@KHUVUC_SX", SqlDbType.NVarChar).Value = DataTableHelper.convertRowDataToString(row, "KHUVUC_SX");
                    cmd.Parameters.Add("@STT", SqlDbType.NVarChar).Value = DataTableHelper.convertRowDataToString(row, "STT");
                    cmd.Parameters.Add("@SO_DOT_CQLD", SqlDbType.NVarChar).Value = DataTableHelper.convertRowDataToString(row, "SO_DOT_CQLD");
                    cmd.Parameters.Add("@SOLUONG_DUTHAU", SqlDbType.Int).Value = clsChangeType.change_int(DataTableHelper.convertRowDataToString(row, "SOLUONG_DUTHAU"));
                    cmd.Parameters.Add("@SP_DIACHI_SX", SqlDbType.NVarChar).Value = DataTableHelper.convertRowDataToString(row, "SP_DIACHI_SX");
                    //cmd.ExecuteNonQuery();

                        //Lấy giá trị tự tăng.
                    Int64 idDauThau = Convert.ToInt64(cmd.ExecuteScalar());
                    InsertTenderDetail(dtDetail, list, Convert.ToInt64(row["DAUTHAU_ID"] + string.Empty), idDauThau);
                }
                _wait.Close();
                return true;
            }
            catch (Exception ex)
            {
                _wait.Close();
                clsMessage.MessageInfo("Có lỗi trong lúc nạp đấu thầu. Vui lòng kiểm tra lỗi.\nError : "+ ex.Message);
                return false;
            }
        }

        Boolean InsertTenderDetail(DataTable dt, string list, Int64 _idDauThauChild, Int64 _idDauThauIdentity)
        {
            //_idDauThauChild : Để lọc ra các chi tiết con tương ứng
            //_idDauThauIdentity : Id tự tăng của bảng cha đấu thầu
            WaitDialogForm _wait = new WaitDialogForm("Đang nạp TenderDetail ...", "Vui lòng đợi giây lát");
            try
            {
                string strFilter = "GOITHAU_ID in (" + list + ") and DAUTHAU_ID = " + _idDauThauChild;
                //DataRow[] r = t.Select(strFilter);

                dt.DefaultView.RowFilter = strFilter;
                DataTable dtFiltered = dt.DefaultView.ToTable();
                DataRow[] r = dtFiltered.Select();

                if (r.Count() == 0)
                {
                    _wait.Close();
                    clsMessage.MessageInfo("Không có dữ liệu của gói thầu đăng ký.");
                    return false;
                }
                //Cập nhật lại tổng điểm KT: vì trường hợp dữ liệu 
                Int32 _tongDiemKT = 0; 
                for (int i = 0; i < r.Count(); i++) //for (int i = 0; i < t.Rows.Count; i++)
                {
                    _wait.Caption = string.Format("Đang nạp TenderDetail : {0}/{1} ...", numRowTenderDetail++, dt.Rows.Count);
                    string str = "Insert into DAUTHAU_CT (CTY_MA, GOITHAU_ID,SP_MA,NHOM_KYTHUAT_CT_ID, DIEM,DAUTHAU_ID) "
                        + " values (@CTY_MA, @GOITHAU_ID, @SP_MA, @NHOM_KYTHUAT_CT_ID, @DIEM, @DAUTHAU_ID)";
                    SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                    cmd.Parameters.Add("@CTY_MA", SqlDbType.NVarChar).Value = _ctyMa;
                    cmd.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt).Value = Convert.ToInt64(r[i]["GOITHAU_ID"] + string.Empty);
                    cmd.Parameters.Add("@SP_MA", SqlDbType.NVarChar).Value = r[i]["SP_MA"] + string.Empty;
                    cmd.Parameters.Add("@NHOM_KYTHUAT_CT_ID", SqlDbType.Int).Value = Convert.ToInt32(r[i]["NHOM_KYTHUAT_CT_ID"] + string.Empty);
                    cmd.Parameters.Add("@DIEM", SqlDbType.Int).Value = Convert.ToInt32(r[i]["DIEM"]);
                    cmd.Parameters.Add("@DAUTHAU_ID", SqlDbType.BigInt).Value = _idDauThauIdentity;
                    _tongDiemKT += Convert.ToInt32(r[i]["DIEM"]);
                    cmd.ExecuteNonQuery();
                }
                
                string _updateDauThau = string.Format("update DAU_THAU set TONG_DIEM_KT ={0} where DAUTHAU_ID= {1} ", _tongDiemKT, _idDauThauIdentity);
                SqlCommand cmdUpdate = new SqlCommand(_updateDauThau, clsConnection._conn);
                cmdUpdate.ExecuteNonQuery();

                _wait.Close();
                return true;
            }
            catch (Exception ex)
            {
                _wait.Close();
                clsMessage.MessageInfo("Có lỗi trong lúc nạp đấu thầu chi tiết. Vui lòng kiểm tra lỗi.\nError : " + ex.Message);
                return false;
            }
            
            
        }

        private void frmImportData_Load(object sender, EventArgs e)
        {

        }
    }
}
