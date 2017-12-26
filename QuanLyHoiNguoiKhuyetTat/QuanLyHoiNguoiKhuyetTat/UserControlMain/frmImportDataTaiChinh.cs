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
    public partial class frmImportDataTaiChinh : Form
    {
        public frmImportDataTaiChinh()
        {
            InitializeComponent();
        }

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
            DataSet t;
            _ctyMa = string.Empty;
            clsParameter._isLoadHoSoDauThau = true;
            #region Công ty

            
            t = new DataSet();
            t.ReadXml(txtPath.Text);
            if (t.Tables.Count != 3 || !t.Tables.Contains("Company") || !t.Tables.Contains("Tender") || !t.Tables.Contains("TenderDetail"))
            {
                _wait.Close();
                clsMessage.MessageWarning("Dữ liệu nạp không phù hợp. Vui lòng kiểm tra lại.");
                return;
            }

            _wait.Caption = "Đang xử lý dữ liệu Company ...";
            if (t.Tables["Company"].Rows.Count > 0)
            {
                _ctyMa = t.Tables["Company"].Rows[0]["CTY_MA"] + string.Empty;
            }
            else
            {
                _wait.Close();
                clsMessage.MessageWarning("Không có dữ liệu nhập liệu.\nVui lòng kiểm tra lại.");
                return;
            }

            #endregion

            #region Thông tin đấu thầu

            _wait.Caption = "Đang xử lý dữ liệu Tender ...";
            string TenGoiThau = string.Empty;
            string _list =string.Empty;
            if (t.Tables["Tender"].Rows.Count > 0)
            {
                _wait.Close();

                if (!t.Tables["Tender"].Columns.Contains("GIA_KEKHAI_BYT") || !t.Tables["Tender"].Columns.Contains("GIA_CHAOTHAU"))
                {
                    clsMessage.MessageWarning("Dữ liệu không phù hợp với file tài chính. Vui lòng kiểm tra lại.");
                    return;
                }
                DataTable duLieuDauThau = FunctionHelper.LoadDM("SELECT * FROM DAU_THAU WHERE CTY_MA ='" + _ctyMa + "'");

                //Kiểm tra các sản phẩm trong bảng tài chính có tồn tại trong bảng kỹ thuật đã nạp.
                string _maSP = string.Empty;
                string _tenThuongMai = string.Empty;
                for (int i = 0; i < t.Tables["Tender"].Rows.Count; i++)
                {
                    _maSP = t.Tables["Tender"].Rows[i]["SP_MA"] + string.Empty;
                    _tenThuongMai = t.Tables["Tender"].Rows[i]["SP_TEN_THUONGMAI"] + string.Empty;
                    
                    //xóa ký tự đặc biệt '
                    _tenThuongMai = _tenThuongMai.Replace("'", "''");

                    DataRow[] r = duLieuDauThau.Select(string.Format("SP_MA = '{0}' and SP_TEN_THUONGMAI = '{1}'", _maSP, _tenThuongMai));
                    if (r.Count() == 0)
                    {
                        clsMessage.MessageWarning(string.Format("Sản phẩm: {0} - {1} không tồn tại trong bảng điểm kỹ thuật.\n Vui lòng kiểm tra lại.", _maSP, _tenThuongMai));
                        return;
                    }
                }

                if (!UpdateTender(t.Tables["Tender"], _ctyMa))
                    return;
            }
            
            _wait.Close();
           
            clsMessage.MessageInfo("Cập nhật điểm tài chính thành công!");
            #endregion

        }

        Boolean UpdateTender(DataTable t, string _maCty)
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang xử lý dữ liệu Tender ...", "Vui lòng đợi giây lát");
            try
            {
                for (int i = 0; i < t.Rows.Count; i++) //for (int i = 0; i < t.Rows.Count; i++)
                {
                    _wait.Caption = string.Format("Đang xử lý dữ liệu Tender : {0}/{1} ...", i + 1, t.Rows.Count);

                    string str = "Update DAU_THAU set GIA_KEKHAI_BYT = @GIA_KEKHAI_BYT, GIA_CHAOTHAU=@GIA_CHAOTHAU"
                        + " where CTY_MA = @CTY_MA and SP_MA = @SP_MA and SP_TEN_THUONGMAI = @SP_TEN_THUONGMAI";
                    SqlCommand cmd = new SqlCommand(str, clsConnection._conn);

                    // Giải mã dữ liệu
                    string sGiaKeKhai_BYT = clsEncryption.decode(t.Rows[i]["GIA_KEKHAI_BYT"] + string.Empty);
                    string sGiaChaoThau = clsEncryption.decode(t.Rows[i]["GIA_CHAOTHAU"] + string.Empty);

                    //index comma giá kê khai BYT
                    int indexSimpleComma = sGiaKeKhai_BYT.IndexOf(",");
                    if (indexSimpleComma > 0)
                    {
                        sGiaKeKhai_BYT = sGiaKeKhai_BYT.Substring(0, indexSimpleComma);
                    }

                    //index comma giá chào thầu
                    indexSimpleComma = sGiaChaoThau.IndexOf(",");
                    if (indexSimpleComma > 0)
                    {
                        sGiaChaoThau = sGiaChaoThau.Substring(0, indexSimpleComma);
                    }

                    string _tenThuongMai = t.Rows[i]["SP_TEN_THUONGMAI"] + string.Empty;
                    string _SPMa = t.Rows[i]["SP_MA"] + string.Empty;
                    Int32 _giaKeKhai_BYT = Convert.ToInt32(sGiaKeKhai_BYT);
                    Int32 _giaChaoThau = Convert.ToInt32(sGiaChaoThau);
                    cmd.Parameters.Add("@GIA_KEKHAI_BYT", SqlDbType.Int).Value = _giaKeKhai_BYT;
                    cmd.Parameters.Add("@GIA_CHAOTHAU", SqlDbType.Int).Value = _giaChaoThau;
                    cmd.Parameters.Add("@CTY_MA", SqlDbType.NVarChar).Value = _ctyMa;
                    cmd.Parameters.Add("@SP_MA", SqlDbType.NVarChar).Value = _SPMa;
                    cmd.Parameters.Add("@SP_TEN_THUONGMAI", SqlDbType.NVarChar).Value = _tenThuongMai;
                    int rowUpdate = cmd.ExecuteNonQuery();
                    if (rowUpdate == 0)
                    {
                        _wait.Close();
                        clsMessage.MessageWarning(string.Format("Sản phẩm [{0}] của công ty [{1}] không cập nhật được giá tài chính.\n Vui lòng kiểm tra lại.", _SPMa, _ctyMa));
                        return false;
                    }
                }
                _wait.Close();
                return true;
            }
            catch (Exception ex)
            {
                _wait.Close();
                clsMessage.MessageInfo("Có lỗi trong lúc nạp đấu thầu. Vui lòng kiểm tra lỗi.\nError : " + ex.Message);
                return false;
            }
        }


        private void frmImportData_Load(object sender, EventArgs e)
        {

        }
    }
}
