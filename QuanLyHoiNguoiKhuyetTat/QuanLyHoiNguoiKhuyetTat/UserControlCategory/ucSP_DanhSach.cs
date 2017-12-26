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

namespace DauThau.UserControlCategory
{
    public partial class ucSP_DanhSach : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSP_DanhSach()
        {
            InitializeComponent();
        }

        DataTable LoadDM(String strConnDM)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter d = new SqlDataAdapter(strConnDM, clsConnection._conn);
            d.Fill(dt);
            return dt;
        }

        private void ucSP_DanhSach_Load(object sender, EventArgs e)
        {
           lueGoiThau.DataSource = LoadDM("select * from DM_GOITHAU");
           lueNuocSX.DataSource = LoadDM("select * from DM_NUOCSX");
            string str = "SELECT DAU_THAU.GOITHAU_ID, DAU_THAU.SP_MA, DM_SANPHAM.SP_TEN, DAU_THAU.SP_TEN_THUONGMAI, DAU_THAU.HANGSX, "
            + " DAU_THAU.NUOCSX_ID, DAU_THAU.NUOCLD_ID, DAU_THAU.SP_SODK_VISA, DAU_THAU.GIA_CHAOTHAU, Sum(DM_GOITHAU_KYTHUAT.DIEM) AS TONGDIEM "
            + " FROM DM_SANPHAM INNER JOIN ((DAU_THAU INNER JOIN DAUTHAU_CT ON DAU_THAU.SP_MA = DAUTHAU_CT.SP_MA) "
            + " INNER JOIN DM_GOITHAU_KYTHUAT ON (DAUTHAU_CT.NHOM_KYTHUAT_CT_ID = DM_GOITHAU_KYTHUAT.NHOM_KYTHUAT_CT_ID) " 
            + " AND (DAUTHAU_CT.GOITHAU_ID = DM_GOITHAU_KYTHUAT.GOITHAU_ID)) ON DM_SANPHAM.SP_ID = DAU_THAU.SP_ID "
            + " GROUP BY DAU_THAU.GOITHAU_ID, DAU_THAU.SP_MA, DM_SANPHAM.SP_TEN, DAU_THAU.SP_TEN_THUONGMAI, "
            + " DAU_THAU.HANGSX, DAU_THAU.NUOCSX_ID, DAU_THAU.NUOCLD_ID, DAU_THAU.SP_SODK_VISA, DAU_THAU.GIA_CHAOTHAU "
            + " HAVING (((DAU_THAU.SP_TEN_THUONGMAI) Is Not Null))" ;
           gcGrid.DataSource = LoadDM(str);
        }
    }
}
