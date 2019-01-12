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
    public partial class ucBCLyLich : ucBase
    {
        XtraReport rpt = new XtraReport();
        public ucBCLyLich()
        {
            InitializeComponent();
        }

        private void ucBCLyLich_Load(object sender, EventArgs e)
        {
            registerButtonArray(btnControl);
            rpt = new rptLyLichHoiVien();
            LibraryDev.PermissionButton(btnControl, previewBar1);
            printControl.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument(true);
            lueSearch.Properties.PopupFormMinSize = lueSearch.Size;
        }

        protected override EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.PRINT)
                {
                    try
                    {
                        rpt.Print();
                    }
                    catch (Exception)
                    {

                    }
                }
                else if (_formStatus == EnumFormStatus.CLOSE)
                {
                    if (closeTab != null)
                    {
                        closeTab();
                    }
                }
            }
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
            
    }
}
