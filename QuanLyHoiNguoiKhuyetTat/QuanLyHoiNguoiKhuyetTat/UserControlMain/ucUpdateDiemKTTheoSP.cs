using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DauThau.Class;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Data.SqlClient;
using DauThau.Forms;
using DevExpress.Utils;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucUpdateDiemKTTheoSP : DevExpress.XtraEditors.XtraUserControl
    {
        public ucUpdateDiemKTTheoSP()
        {
            InitializeComponent();
        }

        private void ucUpdateDiemKT_Load(object sender, EventArgs e)
        {
            lueCongTy.Properties.DataSource = FunctionHelper.LoadDM("select * from DM_CONGTY where DOT_MA='" + clsParameter._dotMaDauThau + "'");
            try
            {
                lueCongTy.ItemIndex = 0;
            }
            catch
            {
            }

            FormHelper.LookUpEdit_Init(lueGoiThau);
            FormHelper.LookUpEdit_Init(lueCongTy);
        }

        private void lueCongTy_EditValueChanged(object sender, EventArgs e)
        {
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThauTheoCongTy(lueCongTy.EditValue + string.Empty);
            try
            {
                lueGoiThau.ItemIndex = 0;
            }
            catch
            {
            }
            btnXem.PerformClick();
        }

        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            btnXem.PerformClick();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang hiển thị dữ liệu ...", "Vui lòng đợi giây lát");
            string _maCty = lueCongTy.EditValue + string.Empty;
            Int64 _goiThauID = Convert.ToInt64(lueGoiThau.EditValue);
            string _strConnect = "select dt.DAUTHAU_ID, sp.SP_MA, sp.SP_TEN from DAU_THAU dt"
                    + " join DM_SANPHAM sp on sp.SP_MA = dt.SP_MA"
                    + " where dt.CTY_MA = '" + _maCty + "' and dt.GOITHAU_ID = " + _goiThauID
                    + " order by sp.SP_TEN";
            DataTable dt = FunctionHelper.LoadDM(_strConnect);
            gcSanPham.DataSource = dt;
            dtDiemKyThuat = new DataTable();
            RowClick();
            _wait.Close();
        }

        DataTable dtDiemKyThuat = new DataTable();
        Int64 _dauThauID = 0;
        Int64 _goiThauID = 0;
        private void gvSanPham_Click(object sender, EventArgs e)
        {
            RowClick();
        }

        void RowClick()
        {
            if (gvSanPham.RowCount > 0)
            {
                if (dtDiemKyThuat.Rows.Count > 0) { btnLuu.PerformClick(); }

                _dauThauID = Convert.ToInt64(gvSanPham.GetFocusedRowCellValue(colDAU_THAU_ID));
                _goiThauID = Convert.ToInt64(lueGoiThau.EditValue);
                dtDiemKyThuat = new DataTable();
                CreateColumn();
                gcDiemKT.DataSource = dtDiemKyThuat;
            }
        }
        /// <summary>
        /// Tạo cột tự động theo gói thầu.
        /// </summary>
        void CreateColumn()
        {
            DataTable dtCol = new DataTable();
            //string str = "SELECT DISTINCT VIET_TAT ,SORT_NHOM, DIEM_CHUAN FROM dbo.DM_GOITHAU_KYTHUAT a "
            //            + " LEFT JOIN dbo.DM_NHOM_KYTHUAT b ON a.NHOM_KYTHUAT_ID = b.NHOM_KYTHUAT_ID "
            //            + " LEFT JOIN dbo.DM_NHOM_KYTHUAT_DIEMCHUAN c ON a.GOITHAU_ID = c.GOITHAU_ID AND a.NHOM_KYTHUAT_ID = c.NHOM_KYTHUAT_ID"
            //            + " WHERE a.GOITHAU_ID =" + clsChangeType.change_int64(lueGoiThau.EditValue) + " ORDER BY a.SORT_NHOM";

            string str = "select ct.NHOM_KYTHUAT_CT_ID, ct.DIEM from DAUTHAU_CT ct"
                        + " join DM_GOITHAU_KYTHUAT kt on kt.NHOM_KYTHUAT_CT_ID = ct.NHOM_KYTHUAT_CT_ID"
                        + " where DAUTHAU_ID = " + _dauThauID + " and kt.GOITHAU_ID = " + _goiThauID + " order by kt.SORT_NHOM";
            dtCol = FunctionHelper.LoadDM(str);
            int k = bandYCKT.Columns.Count;

            //Xóa các cột động trong band
            for (int i = 0; i < k; i++)
            {
                bandYCKT.Columns.Remove(bandYCKT.Columns[0]);
            }

            DataRow _rowDiemKT = dtDiemKyThuat.NewRow();
            Int64 _tongDiemKT = 0;
            //Thêm mới.
            for (int i = 0; i < dtCol.Rows.Count; i++)
            {
                //Add Band
                BandedGridColumn col = new BandedGridColumn();
                col.Caption = string.Format("({0})", i + 1);//dtCol.Rows[i][0] + string.Empty;
                col.Name = dtCol.Rows[i]["NHOM_KYTHUAT_CT_ID"] + string.Empty;
                col.FieldName = dtCol.Rows[i]["NHOM_KYTHUAT_CT_ID"] + string.Empty;
                col.OptionsColumn.AllowEdit = true;
                col.Visible = true;
                gvDiemKT.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { col });
                this.bandYCKT.Columns.Add(col);
                
                //Add Column Dataset
                dtDiemKyThuat.Columns.Add(dtCol.Rows[i][0].ToString(), typeof(String));

                _rowDiemKT[dtCol.Rows[i]["NHOM_KYTHUAT_CT_ID"] + string.Empty] = dtCol.Rows[i]["DIEM"] + string.Empty;

                _tongDiemKT += Convert.ToInt64(dtCol.Rows[i]["DIEM"] + string.Empty);
            }
            bandYCKT.Width = 45 * bandYCKT.Columns.Count;
            dtDiemKyThuat.Columns.Add("TONG_DIEM_KT", typeof(String));
            _rowDiemKT["TONG_DIEM_KT"] = _tongDiemKT;
            dtDiemKyThuat.Rows.Add(_rowDiemKT);

            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            clsParameter._isLoadHoSoDauThau = true;
            Int64 _tongDiemKT = 0;
            for (int i = 0; i < dtDiemKyThuat.Columns.Count; i++)
            {
                string _NHOM_KYTHUAT_CT_ID = dtDiemKyThuat.Columns[i].ColumnName;
                if (_NHOM_KYTHUAT_CT_ID != "TONG_DIEM_KT")
                {
                    _tongDiemKT += Convert.ToInt64(dtDiemKyThuat.Rows[0][i]);
                    string str = string.Format("update DAUTHAU_CT set DIEM={0} where DAUTHAU_ID = {1} and NHOM_KYTHUAT_CT_ID = {2}"
                        , dtDiemKyThuat.Rows[0][i]
                        ,_dauThauID
                        , _NHOM_KYTHUAT_CT_ID);
                    SqlCommand cmd = new SqlCommand(str, clsConnection._conn);
                    cmd.ExecuteNonQuery();

                    //Cap nhat tong diem
                    str = string.Format("update DAU_THAU set TONG_DIEM_KT = {0} where DAUTHAU_ID = {1}", _tongDiemKT, _dauThauID);
                    cmd = new SqlCommand(str, clsConnection._conn);
                    cmd.ExecuteNonQuery();
                }
            }
            frmInformation f = new frmInformation("Lưu dữ liệu thành công.");
            f.ShowDialog();
        }

        private void gvDiemKT_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int _tongDiemKT = 0;
            for (int i = 0; i < dtDiemKyThuat.Columns.Count; i++)
            {
                string colName = dtDiemKyThuat.Columns[i].ColumnName;
                if (colName != "TONG_DIEM_KT")
                {
                    _tongDiemKT += Convert.ToInt32(dtDiemKyThuat.Rows[0][i]);
                }
            }
            if (_tongDiemKT > 100)
            {
                clsMessage.MessageWarning("Tổng điểm > 100. Vui lòng kiểm tra lại.");                
                return;
            }
            dtDiemKyThuat.Rows[0]["TONG_DIEM_KT"] = _tongDiemKT;
        }

        private void gvDiemKT_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            e.Valid = true;
            string _nhomKyThuat_CT_ID = gvDiemKT.FocusedColumn.FieldName;
            string strConect = string.Format("select NHOM_KYTHUAT_ID from dbo.DM_GOITHAU_KYTHUAT" 
                    + " where GOITHAU_ID = {0} and NHOM_KYTHUAT_CT_ID = {1}",
                    _goiThauID, 
                    _nhomKyThuat_CT_ID);
            DataTable dt = FunctionHelper.LoadDM(strConect);
            if (dt.Rows.Count > 0)
            {
                string _nhomKyThuat_ID = dt.Rows[0]["NHOM_KYTHUAT_ID"] + string.Empty;
                strConect = string.Format("select distinct DIEM from dbo.DM_GOITHAU_KYTHUAT "
                        + " where GOITHAU_ID = {0} AND nhom_kythuat_id = {1} and CHOPHEP_CHON = 1",
                    _goiThauID, _nhomKyThuat_ID);
                dt = FunctionHelper.LoadDM(strConect);
                StringBuilder diemKT = new StringBuilder();
                Boolean hasError = true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if(dt.Rows[i]["DIEM"] + string.Empty == e.Value + string.Empty){
                        hasError = false;
                    }
                    diemKT.AppendLine(dt.Rows[i]["DIEM"] + string.Empty);
                }

                if (hasError)
                {
                    e.Valid = false;
                    e.ErrorText = "Vui lòng nhập một trong các giá trị: "+ Environment.NewLine + diemKT;
                }
            }
            else
            {
                e.Valid = false;
                e.ErrorText = "Không xác định được điểm của nhóm kỹ thuật.";
            }
        }
    }
}
