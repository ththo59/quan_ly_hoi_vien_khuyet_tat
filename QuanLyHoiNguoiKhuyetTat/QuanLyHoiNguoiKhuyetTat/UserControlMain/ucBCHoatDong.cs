using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System.Diagnostics;
using DauThau.Class;
using DauThau.Reports;

namespace DauThau.UserControlCategory
{
    public partial class ucBCHoatDong : DevExpress.XtraEditors.XtraUserControl
    {
        XtraReport rpt = new XtraReport();
        public ucBCHoatDong()
        {
            InitializeComponent();
        }

        private void ucBCHoatDong_Load(object sender, EventArgs e)
        {
            rpt = new rptHoatDong();
            LibraryDev.PermissionButton(btnControl, previewBar1);
            printControl.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument(true);
            lueSearch.Properties.PopupFormMinSize = lueSearch.Size;
        }

        private void StartProcess(string path)
        {
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = path;
                proc.Start();
                proc.WaitForInputIdle();
            }
            catch (Exception)
            {
                // SimpleMessage.ShowSimpleMessage(ex, "In danh sách dự trù");
            }
        }

        private void btnControl_btnEventPrint_Click(object sender, EventArgs e)
        {
            try
            {
                rpt.Print();
            }
            catch (Exception)
            {

            }
        }
    }
}
