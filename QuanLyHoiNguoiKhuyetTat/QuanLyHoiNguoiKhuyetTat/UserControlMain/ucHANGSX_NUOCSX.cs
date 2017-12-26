using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DauThau.Class;
using System.Data.SqlClient;
using DevExpress.Utils;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucHANGSX_NUOCSX : DevExpress.XtraEditors.XtraUserControl
    {
        public ucHANGSX_NUOCSX()
        {
            InitializeComponent();
        }

        private void ucHANGSX_NUOCSX_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = FunctionHelper.LoadDM(string.Format("select * from DM_GOITHAU where DOT_MA='{0}' and CHON_HANGSX=1", clsParameter._dotMaDauThau));
            lueGoiThau.Properties.DataSource = dt;
            if (dt.Rows.Count == 0)
                clsMessage.MessageInfo("Không có gói thầu nào cho phép chọn hãng sản xuất.");
            if (dt.Rows.Count > 0)
                lueGoiThau.ItemIndex = 0;
        }

        #region Variable

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        #endregion

        void SelectData()
        {
            ds = new DataSet();
            da.SelectCommand = new SqlCommand("select * from GOITHAU_HANGSX where GOITHAU_ID=" + clsChangeType.change_int64(lueGoiThau.EditValue), clsConnection._conn);
            da.Fill(ds, "DVT");
            gcGrid.DataSource = ds.Tables["DVT"];
        }
        
        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            SelectData();
            RowClick();
        }

        void RowClick()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            string str = "SELECT nsx.NUOCSX_ID, nsx.TEN,CASE WHEN ISNULL(gt_hsx.NUOCSX_ID,0) > 0 THEN CAST(1 AS BIT) "
                + " ELSE CAST(0 AS BIT) END CHON,gt_hsx.ID  HANGSX_NUOCSX_ID FROM dbo.DM_NUOCSX nsx "
                + " LEFT JOIN GOITHAU_HANGSX_NUOCSX gt_hsx ON nsx.NUOCSX_ID = gt_hsx.NUOCSX_ID AND gt_hsx.HANGSX like N'" + gvGrid.GetFocusedRowCellValue(colHANGSX) +string.Empty + "'";
            gc.DataSource = FunctionHelper.LoadDM(str);
            _wait.Close();
        }
        private void gvGrid_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            RowClick();
        }

        private void chkChon_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit chk = sender as CheckEdit;
                if (chk.Checked)
                {
                    string str = "insert into GOITHAU_HANGSX_NUOCSX (NUOCSX_ID,HANGSX) values (@NUOCSX_ID, @HANGSX)";
                    SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                    cmd.Parameters.Add("@NUOCSX_ID", SqlDbType.BigInt).Value = clsChangeType.change_int64(gv.GetFocusedRowCellValue(colNUOCSX_ID));
                    cmd.Parameters.Add("@HANGSX", SqlDbType.NVarChar).Value = gvGrid.GetFocusedRowCellValue(colHANGSX) +string.Empty;
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    string str = "delete from GOITHAU_HANGSX_NUOCSX where ID=@ID";
                    SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                    cmd.Parameters.Add("@ID", SqlDbType.BigInt).Value = clsChangeType.change_int64(gv.GetFocusedRowCellValue(colHANGSX_NUOCSX_ID));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                clsMessage.MessageExclamation("Có lỗi trong quá trình cập nhật." + ex.Message);
            }
            
        }
    }
}
