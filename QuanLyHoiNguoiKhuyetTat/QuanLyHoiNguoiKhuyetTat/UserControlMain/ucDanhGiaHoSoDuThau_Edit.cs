using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DauThau.Class;
using DevExpress.Utils;
using System.Data.SqlClient;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucDanhGiaHoSoDuThau_Edit : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDanhGiaHoSoDuThau_Edit()
        {
            InitializeComponent();
        }

        private void ucDanhGiaHoSoDuThau_Edit_Load(object sender, EventArgs e)
        {
            LibraryDev.PermissionButton(btnControl, null);
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();
            
            try
            {
                lueGoiThau.ItemIndex = 0;
            }
            catch
            {
            }

            FormStatus = EnumFormStatus.VIEW;
            FunctionHelper.RepositoryItemSpinEdit(seDiem, clsParameter.pFormatNumber);
            CommandData();
            FunctionHelper.PermissionLockButton(btnControl);

            FormHelper.LookUpEdit_Init(lueGoiThau);
            FormHelper.LookUpEdit_Init(lueMaSP);
            FormHelper.LookUpEdit_Init(lueTenSP);
        }

        #region Variable

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        #endregion

        #region Function



        void CommandData()
        {
            string str_update = "update DAU_THAU set GIA_SUADOI=@GIA_SUADOI, TT=@TT, TT_GHICHU=@TT_GHICHU where DAUTHAU_ID=@DAUTHAU_ID ";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            da.UpdateCommand.Parameters.Add("@GIA_SUADOI", SqlDbType.Int, 5, "GIA_SUADOI");
            da.UpdateCommand.Parameters.Add("@TT", SqlDbType.Bit, 5, "TT_BTC");
            da.UpdateCommand.Parameters.Add("@TT_GHICHU", SqlDbType.NVarChar, 255, "TT_GHICHU");
            da.UpdateCommand.Parameters.Add("@DAUTHAU_ID", SqlDbType.BigInt, 10, "DAUTHAU_ID");
        }

        DataTable DsSanPhamMa()
        {
            SqlCommand cmd = new SqlCommand("sp_HoSoDuThauSP_Ma", clsConnection._conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt).Value = Convert.ToInt32(lueGoiThau.EditValue);
            cmd.Parameters.Add("@DOT_MA", SqlDbType.NVarChar).Value = clsParameter._dotMaDauThau;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable t = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(t);
            return t;
        }

        void SelectData()
        {
            dsDanhGiaHoSoDuThau1 = new DataSets.dsDanhGiaHoSoDuThau();
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu đấu thầu ...", "Vui lòng đợi giây lát");

            SqlCommand cmd = new SqlCommand(clsParameter.pStoreDanhGiaHoSoDuThau, clsConnection._conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GOITHAU_ID", SqlDbType.BigInt).Value = Convert.ToInt32(lueGoiThau.EditValue);
            cmd.Parameters.Add("@DOT_MA", SqlDbType.NVarChar).Value = clsParameter._dotMaDauThau;
            cmd.Parameters.Add("@SP_MA", SqlDbType.NVarChar).Value = lueMaSP.EditValue + string.Empty;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dsDanhGiaHoSoDuThau1.ChiTietHoSo);
            gcGrid.DataSource = dsDanhGiaHoSoDuThau1.ChiTietHoSo;

            _wait.Caption = "Đang tải sản phẩm ...";
            DataTable dtSP_MA = new DataTable();
            dtSP_MA = DsSanPhamMa();

            _wait.Caption = "Đang xét hồ sơ trúng thầu ...";
            string sp_ma = string.Empty;
            Decimal max_DiemTH;
            for (int k = 0; k < dtSP_MA.Rows.Count; k++)
            {
                _wait.Caption =string.Format("Đang xét sản phẩm {0}/{1}", k+1,dtSP_MA.Rows.Count);
                sp_ma =dtSP_MA.Rows[k][0].ToString();

                try
                {
                    max_DiemTH = Convert.ToDecimal(dsDanhGiaHoSoDuThau1.ChiTietHoSo.Compute("max(DiemTH)", "SP_MA='" + sp_ma + "' and LOAI_PL=False and VUOTGIA_KH=False and KHONGDAT_KT=False"));
                }
                catch (Exception)
                {
                    max_DiemTH = 0;
                }
                
                //Nếu sản phẩm đã được trúng thầu từ BTC có nghĩa là cột TT = 1
                //Không xét nữa .
                DataRow[] r = dsDanhGiaHoSoDuThau1.ChiTietHoSo.Select(string.Format("SP_MA='{0}' and TT=1",sp_ma));
                if (r.Length > 0) continue;

                //Xét điều kiện trúng thầu.
                for (int i = 0; i < dsDanhGiaHoSoDuThau1.ChiTietHoSo.Count; i++)
                {
                    if (dsDanhGiaHoSoDuThau1.ChiTietHoSo.Rows[i]["SP_MA"].ToString() == sp_ma
                        && Convert.ToDecimal(dsDanhGiaHoSoDuThau1.ChiTietHoSo.Rows[i]["DiemTH"]) > 0
                        && clsChangeType.change_bool(dsDanhGiaHoSoDuThau1.ChiTietHoSo.Rows[i]["LOAI_PL"]) == false
                        )
                        if (Convert.ToDecimal(dsDanhGiaHoSoDuThau1.ChiTietHoSo.Rows[i]["DiemTH"]) == max_DiemTH)
                        {
                            dsDanhGiaHoSoDuThau1.ChiTietHoSo.Rows[i]["TT"] = true;
                            //break;
                        }
                }
            }
            
            
            _wait.Close();
        }

        void Save()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu đấu thầu ...", "Vui lòng đợi giây lát");
            try
            {
                clsParameter._isLoadHoSoDauThau = true;
                da.Update(dsDanhGiaHoSoDuThau1.ChiTietHoSo);
                _wait.Close();
            }
            catch
            {
                _wait.Close();
                XtraMessageBox.Show("Dữ liệu đã được sử dụng bạn không thể cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        

        #endregion

        #region Status


        public EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.MODIFY)
                {
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    gvGrid.ActiveFilter.Clear();
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    colGIA_SUADOI.OptionsColumn.AllowEdit = colTT_BTC.OptionsColumn.AllowEdit = colTT_GHICHU.OptionsColumn.AllowEdit = true;
                    lueGoiThau.Enabled = false;
                }
                else
                {
                    colGIA_SUADOI.OptionsColumn.AllowEdit = colTT_BTC.OptionsColumn.AllowEdit = colTT_GHICHU.OptionsColumn.AllowEdit = false;
                    gvGrid.OptionsView.ShowAutoFilterRow = true;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    lueGoiThau.Enabled = true;
                    btnControl.btnModify.Enabled = gvGrid.RowCount > 0;
                }
            }
        }

        #endregion

        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            if (lueGoiThau.EditValue != null)
            {
                WaitDialogForm _wait = new WaitDialogForm("Đang tải sản phẩm ...", "Vui lòng đợi giây lát");
                string str = "SELECT DISTINCT c.SP_MA, c.SP_TEN FROM dbo.DAU_THAU a "
                     + " JOIN dbo.DM_CONGTY  b ON a.CTY_MA = b.CTY_MA "
                     + " JOIN dbo.DM_SANPHAM c ON a.SP_MA = c.SP_MA "
                     + " WHERE GOITHAU_ID =" + lueGoiThau.EditValue + " AND DOT_MA = '" + clsParameter._dotMaDauThau + "'";
                lueMaSP.Properties.DataSource = FunctionHelper.LoadDM(str);
                lueTenSP.Properties.DataSource = lueMaSP.Properties.DataSource;
                
                _wait.Close();
                btnControl.btnView.PerformClick();
            }
        }

        private void lueMaSP_EditValueChanged(object sender, EventArgs e)
        {
            if (lueMaSP.EditValue != null)
                lueTenSP.EditValue = lueMaSP.EditValue;
        }

        private void lueTenSP_EditValueChanged(object sender, EventArgs e)
        {
            if (lueTenSP.EditValue != null)
                lueMaSP.EditValue = lueTenSP.EditValue;
        }

        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            if (lueGoiThau.EditValue == null)
            {
                clsMessage.MessageInfo("Vui lòng chọn nhà thầu");
                return;
            }
            SelectData();
        }

        private void btnControl_btnEventModify_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.MODIFY;
        }

        private void btnControl_btnEventSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dsDanhGiaHoSoDuThau1.ChiTietHoSo.Rows.Count; i++)
            {
                if (clsChangeType.change_bool(dsDanhGiaHoSoDuThau1.ChiTietHoSo.Rows[i]["TT_BTC"]))
                    if ((dsDanhGiaHoSoDuThau1.ChiTietHoSo.Rows[i]["TT_GHICHU"] + string.Empty) == string.Empty)
                    {
                        clsMessage.MessageWarning("Vui lòng cập nhật ghi chú khi chọn trúng thầu.");
                        return;
                    }
            }
            Save();
            SelectData();
            this.FormStatus = EnumFormStatus.VIEW;
        }

        private void btnControl_btnEventCancel_Click(object sender, EventArgs e)
        {
            SelectData();
            this.FormStatus = EnumFormStatus.VIEW;
        }

        private void chkTT_BTC_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (_formStatus == EnumFormStatus.MODIFY)
            {
                string _ghichu = gvGrid.GetFocusedRowCellValue(colVIPHAM) +string.Empty;
                if (_ghichu != string.Empty)
                {
                    clsMessage.MessageInfo("Sản phẩm không phù hợp để trúng thầu. Vui lòng kiểm tra lại");
                    e.Cancel = true;
                }
            }
        }

        private void chkTT_BTC_CheckedChanged(object sender, EventArgs e)
        {
            if (_formStatus == EnumFormStatus.MODIFY)
            {
                CheckEdit chk = sender as CheckEdit;

                if (!chk.Checked) gvGrid.SetFocusedRowCellValue(colTT_GHICHU, string.Empty);

                gvGrid.SetRowCellValue(gvGrid.FocusedRowHandle, colTT, chk.Checked);
                //Bỏ các check trừ dòng đang chọn.
                for (int i = 0; i < gvGrid.RowCount; i++)
                {
                    if ((gvGrid.GetRowCellValue(i, colSP_MA) + string.Empty) == gvGrid.GetFocusedRowCellValue(colSP_MA).ToString())
                        if (i != gvGrid.FocusedRowHandle)
                        {
                            gvGrid.SetRowCellValue(i, colTT, false);
                            gvGrid.SetRowCellValue(i, colTT_BTC, false);
                            gvGrid.SetRowCellValue(i, colTT_GHICHU,string.Empty);
                        }
                }
            }
        }

        private void lueMaSP_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueMaSP.EditValue = null;
                lueTenSP.EditValue = null;
            }
        }

        private void lueTenSP_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                lueMaSP.EditValue = null;
                lueTenSP.EditValue = null;
            }
        }

        private void gvGrid_RowCountChanged(object sender, EventArgs e)
        {
            btnControl.btnModify.Enabled = gvGrid.RowCount > 0;
        }

        private void gvGrid_ShowingEditor(object sender, CancelEventArgs e)
        {
           
        }

        private void txtTTGhiChu_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (FormStatus == EnumFormStatus.MODIFY)
            {
                if (gvGrid.FocusedColumn == colTT_GHICHU)
                {
                    if (!clsChangeType.change_bool(gvGrid.GetFocusedRowCellValue(colTT_BTC)))
                    {
                        clsMessage.MessageInfo("Hội đồng xét trúng thầu mới cho phép cập nhật ghi chú");
                        e.Cancel = true;
                    }
                }
            }
        }

        
    }
}
