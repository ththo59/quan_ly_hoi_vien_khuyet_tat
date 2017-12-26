using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DauThau.Class;

namespace DauThau.Forms
{
    public partial class frmCreateKey : DevExpress.XtraEditors.XtraForm
    {
        public frmCreateKey()
        {
            InitializeComponent();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCreateKey_Click(object sender, EventArgs e)
        {
            SaveFileDialog _save = new SaveFileDialog();
            _save.Filter ="Xml files (*.xml)|*.xml";
            _save.FileName = "KeyTender.xml";
            if (_save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string _p = (chkPrint.Checked ? "print" : string.Empty) + (chkUpdate.Checked ? "update" : string.Empty)
                    + (chkExcel.Checked ? "excel" : string.Empty) + (chkForever.Checked ? "excel" : string.Empty);

                string _BV = LibraryDev.Encrypt(LibraryDev._key, txtBV.Text);
                string _Time = LibraryDev.Encrypt(LibraryDev._key, txtSoNgay.Text);
                string _Day = LibraryDev.Encrypt(LibraryDev._key, dtNgay.DateTime +string.Empty);
                string _DayEnd = LibraryDev.Encrypt(LibraryDev._key, dtNgay.DateTime.AddDays(Convert.ToDouble(txtSoNgay.Text)) + String.Empty);
                string _Permission = LibraryDev.Encrypt(LibraryDev._key, _p);
                string _encrypt = LibraryDev.Encrypt(LibraryDev._key, txtKey.Text);
                string _active = LibraryDev.Encrypt(LibraryDev._key, "unactive");

                DataSet ds = new DataSet();
                ds.Tables.Add("ActiveSoftWin7");

                ds.Tables[0].Columns.Add("col1", typeof(String));//Key
                ds.Tables[0].Columns.Add("col2", typeof(String));//bệnh viện
                ds.Tables[0].Columns.Add("col3", typeof(String));//thời gian su dung
                ds.Tables[0].Columns.Add("col4", typeof(String));//quyền
                ds.Tables[0].Columns.Add("col5", typeof(String));//Encrypt
                ds.Tables[0].Columns.Add("col6", typeof(String));//Active
                ds.Tables[0].Columns.Add("col9", typeof(String));//Day
                ds.Tables[0].Columns.Add("col10", typeof(String));//Day_End

                DataRow r = ds.Tables[0].NewRow();
                r["col1"] = txtKey.Text;
                r["col2"] = _BV;
                r["col3"] = _Time;
                r["col4"] = _Permission;
                r["col5"] = _encrypt;
                r["col6"] = _active;
                r["col9"] = _Day;
                r["col10"] = _DayEnd;

                ds.Tables[0].Rows.Add(r);

                ds.Tables[0].WriteXml(_save.FileName);
                clsMessage.MessageInfo("Tạo key thành công.");
            }
        }

        private void frmCreateKey_Load(object sender, EventArgs e)
        {
            dtNgay.DateTime = DateTime.Now.Date;
        }
    }
}