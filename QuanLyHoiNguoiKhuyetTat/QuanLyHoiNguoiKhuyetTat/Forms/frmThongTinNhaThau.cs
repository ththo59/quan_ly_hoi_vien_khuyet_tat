using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DauThau.Class;
using DevExpress.Utils;

namespace DauThau.Forms
{
    public partial class frmThongTinNhaThau : DevExpress.XtraEditors.XtraForm
    {
        public frmThongTinNhaThau()
        {
            InitializeComponent();
        }

        private void frmThongTinNhaThau_Load(object sender, EventArgs e)
        {
            DataTable t = new DataTable();
            t = FunctionHelper.LoadDM("select * from DM_CONGTY");
            if (t.Rows.Count > 0)
            {
                txtTen.Text = t.Rows[0]["TEN"] + string.Empty;
                txtDiaChi.Text = t.Rows[0]["DIACHI"] + string.Empty;
                txtDienThoai.Text = t.Rows[0]["DIENTHOAI"] + string.Empty;
                txtFax.Text = t.Rows[0]["FAX"] + string.Empty;
                txtEmail.Text = t.Rows[0]["EMAIL"] + string.Empty;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Boolean Validation()
        {
            if (txtTen.Text == string.Empty)
                dxErrorProvider.SetError(txtTen, "Vui lòng nhập Tên nhà thầu");
            if(txtDiaChi.Text ==string.Empty)
                dxErrorProvider.SetError(txtDiaChi, "Vui lòng nhập địa chỉ");
            if (txtDienThoai.Text == string.Empty)
                dxErrorProvider.SetError(txtDienThoai, "Vui lòng nhập điện thoại liên lạc");
            return dxErrorProvider.HasErrors;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (Validation())
                return;

            SqlCommand cmd;
            
            cmd = new SqlCommand("delete from DM_CONGTY", clsConnection._conn);
            cmd.ExecuteNonQuery();
            
            cmd = new SqlCommand("insert into DM_CONGTY (CTY_MA,TEN,DIACHI,DIENTHOAI,FAX,EMAIL) values (@CTY_MA,@TEN,@DIACHI,@DIENTHOAI,@FAX,@EMAIL)", clsConnection._conn);
            cmd.Parameters.Add("@CTY_MA", SqlDbType.NVarChar).Value = "CTY0001";
            cmd.Parameters.Add("@TEN", SqlDbType.NVarChar).Value = txtTen.Text;
            cmd.Parameters.Add("@DIACHI", SqlDbType.NVarChar).Value = txtDiaChi.Text;
            cmd.Parameters.Add("@DIENTHOAI", SqlDbType.NVarChar).Value = txtDienThoai.Text;
            cmd.Parameters.Add("@FAX", SqlDbType.NVarChar).Value = txtFax.Text;
            cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = txtEmail.Text;
            cmd.ExecuteNonQuery();
            clsParameter._maCongTy = "CTY0001";
            XtraMessageBox.Show("Lưu thông tin thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnThoat.PerformClick();
        }

       
    }
}