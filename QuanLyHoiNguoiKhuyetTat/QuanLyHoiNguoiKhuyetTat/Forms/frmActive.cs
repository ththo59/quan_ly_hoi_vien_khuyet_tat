using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DauThau.Class;
using System.Net;
using System.Net.NetworkInformation;

namespace DauThau.Forms
{
    public partial class frmActive : DevExpress.XtraEditors.XtraForm
    {
        public frmActive()
        {
            InitializeComponent();
        }

        private void btActive_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Xml files (*.xml)|*.xml";
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DataSet ds = new DataSet();
                ds.ReadXml(f.FileName);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtKey.Text =  ds.Tables[0].Rows[0]["col1"] + string.Empty;
                    txtBV.Text = LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col2"] + string.Empty);
                    dtNgay.DateTime = Convert.ToDateTime(LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col9"] + string.Empty));
                    txtSoNgay.Text = LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col3"] + string.Empty);
                    string _permission = LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col4"] + string.Empty);
                    string _encrypt = LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col5"] + string.Empty);
                    string _unactive = LibraryDev.Decrypt(LibraryDev._key, ds.Tables[0].Rows[0]["col6"] + string.Empty);
                    chkPrint.Checked = _permission.Contains("print");
                    chkUpdate.Checked = _permission.Contains("update");
                    if (_unactive == "active")
                    {
                        clsMessage.MessageExclamation("Key kích hoạt không hợp lệ. Vui lòng kiểm tra lại.");
                        return;
                    }

                    if (_encrypt!= txtKey.Text)
                    {
                        clsMessage.MessageExclamation("Key kích hoạt không hợp lệ. Vui lòng kiểm tra lại.");
                        return;
                    }
                    LibraryDev.Active(ds, f.FileName, txtAddress.Text);
                    clsMessage.MessageInfo("Kích hoạt thành công. Vui lòng khởi động lại chương trình.");
                    Application.Exit();
                }
            }
        }

        

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmActive_Load(object sender, EventArgs e)
        {
            try
            {
                dtNgay.EditValue = null;
                dtNgayEnd.EditValue = null;
                txtAddress.Text = LibraryDev.GetMACAddress();
                DataTable t = new DataTable();
                t = LibraryDev.ActiveEvent();
                if (t.Rows.Count > 0)
                {
                    txtBV.Text = t.Rows[0]["Hospital"] + String.Empty;
                    txtKey.Text = t.Rows[0]["Key"] + String.Empty;
                    txtSoNgay.Text = t.Rows[0]["Time"] + String.Empty;
                    dtNgay.DateTime = Convert.ToDateTime(t.Rows[0]["Day"] + String.Empty);
                    dtNgayEnd.DateTime = Convert.ToDateTime(t.Rows[0]["DayEnd"] + String.Empty);
                    chkPrint.Checked = (t.Rows[0]["Permission"] + String.Empty).Contains("print");
                    chkUpdate.Checked = (t.Rows[0]["Permission"] + String.Empty).Contains("update");
                    chkExcel.Checked = (t.Rows[0]["Permission"] + String.Empty).Contains("excel");
                    chkForever.Checked = (t.Rows[0]["Permission"] + String.Empty).Contains("forever");
                }
            }
            catch (Exception)
            {
                
            }
            
            //btActive.Enabled = !(t.Rows.Count > 0);
        }

        private void txtBV_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void btnDeleteKey_Click(object sender, EventArgs e)
        {
            LibraryDev.DeleteActive();
        }
    }
}