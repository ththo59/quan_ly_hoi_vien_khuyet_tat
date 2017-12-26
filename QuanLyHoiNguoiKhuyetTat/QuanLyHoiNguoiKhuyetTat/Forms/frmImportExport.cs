using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DauThau.Class;
using DevExpress.Utils;

namespace DauThau.Forms
{
    public partial class frmImportExport : DevExpress.XtraEditors.XtraForm
    {
        public frmImportExport(Boolean IsExport)
        {
            InitializeComponent();
            
        }

        DataTable dt; 
        private void frmImportExport_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            SqlDataAdapter d = new SqlDataAdapter("select * from SYS_IN_OUT order by STT asc", clsConnection._conn);
            d.Fill(dt);
            lueExport.Properties.DataSource = dt;
            lueExport.ItemIndex = 0;
        }

        void ExportMaCty(string path)
        {
            DataTable t = new DataTable();
            SqlDataAdapter d = new SqlDataAdapter("select CTY_MA from DM_CONGTY", clsConnection._conn);
            d.Fill(t);
            t.TableName = "DM_CONGTY_MA";
            string FileName = path + "\\DM_CONGTY_MA.xml";
            t.WriteXml(FileName);
        }

        #region Hãng sản xuất

        void ExportGOITHAU_HANGSX(string path)
        {
            DataTable t = new DataTable();
            string str = "SELECT gthsx.* FROM dbo.GOITHAU_HANGSX gthsx, dbo.DM_GOITHAU gt"
                       + " WHERE gt.GOITHAU_ID = gthsx.GOITHAU_ID AND gt.DOT_MA ='" + clsParameter._dotMaDauThau + "'";
            SqlDataAdapter d = new SqlDataAdapter(str, clsConnection._conn);
            d.Fill(t);
            t.TableName = "GOITHAU_HANGSX";
            string FileName = path + "\\GOITHAU_HANGSX.xml";
            t.WriteXml(FileName);
        }

        void ExportGOITHAU_HANGSX_NUOCSX(string path)
        {
            DataTable t = new DataTable();
            string str = "SELECT * FROM dbo.GOITHAU_HANGSX_NUOCSX "
                        + " WHERE HANGSX in "
                        + " (SELECT gthsx.HANGSX FROM dbo.GOITHAU_HANGSX gthsx, dbo.DM_GOITHAU gt "
                        + " WHERE gt.GOITHAU_ID = gthsx.GOITHAU_ID AND gt.DOT_MA = '" + clsParameter._dotMaDauThau + "')";
            SqlDataAdapter d = new SqlDataAdapter(str, clsConnection._conn);
            d.Fill(t);
            t.TableName = "GOITHAU_HANGSX_NUOCSX";
            string FileName = path + "\\GOITHAU_HANGSX_NUOCSX.xml";
            t.WriteXml(FileName);
        }

        #endregion
        

        void ExportAll()
        {
            folderBrowserDialog1.ShowDialog();
            WaitDialogForm _wait = new WaitDialogForm("Đang tải xuất dữ liệu...", "Vui lòng đợi giây lát");
            try
            {
                

                if (folderBrowserDialog1.SelectedPath != string.Empty)
                {
                    //ExportMaCty(folderBrowserDialog1.SelectedPath);
                    //ExportGOITHAU_HANGSX(folderBrowserDialog1.SelectedPath);
                    //ExportGOITHAU_HANGSX_NUOCSX(folderBrowserDialog1.SelectedPath);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        _wait.Caption = "Đang tải xuất dữ liệu " + dt.Rows[i]["CAPTION"].ToString() + " ...";

                        string str = "select * from " + dt.Rows[i]["NAME"].ToString();

                        if (dt.Rows[i]["NAME"].ToString() == "DM_GOITHAU")
                            str = "select * from DM_GOITHAU where DOT_MA = '" + clsParameter._dotMaDauThau + "'";
                        else if (dt.Rows[i]["NAME"].ToString() == "DM_SANPHAM")
                            str = "SELECT sp.SP_ID, sp.SP_GOITHAU, sp.SP_MA, sp.SP_TEN, sp.SP_TENBIETDUOC, sp.DVT_ID, sp.SP_SOLUONG, sp.SP_QUICACH_YEUCAU "
                            + " ,sp.SP_QUICACH_DONGGOI, sp.SP_QUICACH_GHICHU, sp.SP_HAMLUONG, sp.SP_DANGDUNG, sp.SP_NUOCSX_ID "
                            + " ,sp.SP_QUICACH_YEUCAU, sp.SP_GIAKEHOACH "
                            + " FROM DM_SANPHAM sp, DM_GOITHAU gt "
                            + " WHERE sp.SP_GOITHAU= gt.GOITHAU_ID AND gt.DOT_MA='" + clsParameter._dotMaDauThau + "'";
                        else if (dt.Rows[i]["NAME"].ToString() == "DM_GOITHAU_KYTHUAT")
                        {
                            str = "SELECT kt.* FROM DM_GOITHAU_KYTHUAT kt, DM_GOITHAU gt WHERE gt.GOITHAU_ID= kt.GOITHAU_ID AND gt.DOT_MA='" + clsParameter._dotMaDauThau + "'";
                        }
                        else if (dt.Rows[i]["NAME"].ToString() == "SystemConfig")
                        {
                            str = "SELECT SystemConfig_Id, SystemConfig_Parameter, SystemConfig_Description, SystemConfig_Value, SystemConfig_Type FROM SystemConfig where SystemConfig_Parameter ='GiaTriBaoLanh'";
                        }
                        DataTable t = new DataTable();
                        SqlDataAdapter d = new SqlDataAdapter(str, clsConnection._conn);
                        d.Fill(t);
                        t.TableName = dt.Rows[i]["NAME"] + string.Empty;
                        string FileName = folderBrowserDialog1.SelectedPath + "\\" + dt.Rows[i]["NAME"].ToString() + ".xml";

                        t.WriteXml(FileName);

                    }
                    _wait.Close();
                    frmInformation f = new frmInformation("Tạo file thành công");
                    f.ShowDialog();
                }
                _wait.Close();
                
            }
            catch (Exception ex)
            {
                _wait.Close();
                clsMessage.MessageWarning("Có lỗi trong quá trình xuất dữ liệu.\nError : "+ ex.Message);
            }
            
            
        }

        Boolean KiemTraDuLieuXuat()
        {
            string str = "select * FROM dbo.GOITHAU_HANGSX a "
                    + " LEFT JOIN dbo.GOITHAU_HANGSX_NUOCSX b ON a.HANGSX=b.HANGSX "
                    + " WHERE b.NUOCSX_ID IS null";
            DataTable t= FunctionHelper.LoadDM(str);
            return t.Rows.Count > 0;
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraDuLieuXuat())
                {
                    clsMessage.MessageWarning("Có ít nhất 1 hãng sản xuất chưa cấu hình nước sản xuất. Vui lòng kiểm tra lại.");
                    return;
                }
                if (chkAll.Checked)
                {
                    ExportAll();
                    return;
                }
                //DataTable dt = new DataTable();
                //SqlDataAdapter d = new SqlDataAdapter("select * from " + lueExport.EditValue, clsConnection._conn);
                //d.Fill(dt);
                //dt.TableName = lueExport.EditValue +string.Empty;
                //saveFileDialog.FileName = lueExport.EditValue + ".xml";
                //saveFileDialog.Filter = "XML |*.xml";
                ////DialogResult r = saveFileDialog.ShowDialog();
                //if (saveFileDialog.ShowDialog() ==System.Windows.Forms.DialogResult.OK)
                //{
                //    if (saveFileDialog.FileName != string.Empty)
                //    {
                //        dt.WriteXml(saveFileDialog.FileName);
                //        frmInformation f = new frmInformation("Tạo file thành công");
                //        f.ShowDialog();
                //    }
                //}
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Xuất file không thành công. Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            lueExport.Enabled = !chkAll.Checked;
        }
        
        

       
        

        #region Function

        
        #endregion

       
        
    }
}