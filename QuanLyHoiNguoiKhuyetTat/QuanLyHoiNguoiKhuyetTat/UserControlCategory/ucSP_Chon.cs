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

namespace DauThau.UserControlCategory
{
    public partial class ucSP_Chon : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSP_Chon()
        {
            InitializeComponent();
        }

        void LoadBasic()
        {
            WaitDialogForm Wait = new WaitDialogForm("Đang tải đơn vị tính ...", "Đang tải dữ liệu");
            DataTable dt = new DataTable();
            SqlDataAdapter d = new SqlDataAdapter("select * from DM_DVT", clsConnection._conn);
            d.Fill(dt);
            lueDVT.DataSource = dt;

           

            //DataTable dt3 = new DataTable();
            //SqlDataAdapter d3 = new SqlDataAdapter("select * from DM_GOITHAU", clsConnection._conn);
            //d3.Fill(dt3);
            //lueGoiThau.DataSource = dt3;
            Wait.Close();
        }

        void LoadSelect()
        {
            WaitDialogForm Wait = new WaitDialogForm("Đang tải sản phẩm gói thầu ...", "Vui lòng đợi giây lát");
            string _str = "select sp.SP_ID, sp.SP_MA, sp.SP_TEN, sp.DVT_ID, sp.SP_DANGDUNG, sp.SP_HAMLUONG, dt.DAUTHAU_ID, dt.CHON from DM_SANPHAM sp"
                + " left join DAU_THAU dt on dt.SP_ID = sp.SP_ID where sp.SP_GOITHAU =" + clsParameter._goiThauID;
            SqlDataAdapter da = new SqlDataAdapter(_str, clsConnection._conn);

            DataTable t = new DataTable();
            //t.Columns.Add("CHON", typeof(Boolean));

            da.Fill(t);
            //for (int i = 0; i < t.Rows.Count; i++)
            //{
            //    Wait.Caption = i + "/" + t.Rows.Count;
            //    if (clsChangeType.change_int(t.Rows[i]["CoChon"]) > 0)
            //        t.Rows[i][colCHON.FieldName] = true;
            //}
            gcGrid.DataSource = t;
            Wait.Close();
        }
        private void ucSP_Chon_Load(object sender, EventArgs e)
        {
            LoadBasic();
            LoadSelect();
        }

        private void gvGrid_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colCHON)
            {
                Boolean _chon = Convert.ToBoolean(e.Value);
            }
        }

        private void gvGrid_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            
        }

        private void chkChon_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit chk = sender as CheckEdit;

                Boolean _chon = chk.Checked; //Convert.ToBoolean(chkChon.ValueChecked);
                if (_chon)
                {
                    SqlCommand cmd = new SqlCommand("insert into DAU_THAU (SP_ID,SP_MA,GOITHAU_ID,NGAY,CHON,CTY_MA) values (@SP_ID,@SP_MA,@GOITHAU_ID,@NGAY,@CHON,@CTY_MA)", clsConnection._conn);
                    cmd.Parameters.Add("@SP_ID", SqlDbType.BigInt).Value = Convert.ToInt32(gvGrid.GetFocusedRowCellValue(colSP_ID));
                    cmd.Parameters.Add("@SP_MA", SqlDbType.NVarChar).Value = gvGrid.GetFocusedRowCellValue(colSP_MA) + string.Empty;
                    cmd.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt).Value = clsParameter._goiThauID;
                    cmd.Parameters.Add("@NGAY", SqlDbType.Date).Value = DateTime.Now.Date;
                    cmd.Parameters.Add("@CHON", SqlDbType.Bit).Value = true;
                    cmd.Parameters.Add("@CTY_MA", SqlDbType.NVarChar).Value = clsParameter._maCongTy;
                    cmd.ExecuteNonQuery();
                }
                else 
                {
                    SqlCommand cmd ;
                    cmd = new SqlCommand("delete from DAU_THAU where SP_MA = @SP_MA", clsConnection._conn);
                    cmd.Parameters.Add("@SP_MA", SqlDbType.NVarChar).Value = gvGrid.GetFocusedRowCellValue(colSP_MA) + string.Empty;
                    //cmd.Parameters.Add("@DAUTHAU_ID", SqlDbType.BigInt).Value = clsChangeType.change_int(gvGrid.GetFocusedRowCellValue(colDAUTHAU_ID));
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("delete from DAUTHAU_CT where SP_MA = @SP_MA", clsConnection._conn);
                    cmd.Parameters.Add("@SP_MA", SqlDbType.NVarChar).Value = gvGrid.GetFocusedRowCellValue(colSP_MA) + string.Empty;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Vui lòng chọn sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
