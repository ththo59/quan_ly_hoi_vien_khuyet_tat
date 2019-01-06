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
namespace DauThau.UserControlCategory
{
    public partial class ucPrint : ucBase
    {
        XtraReport rpt = new XtraReport();
        public ucPrint(XtraReport _rpt)
        {
            InitializeComponent();
            rpt = _rpt;
        }

        private void ucPrint_Load(object sender, EventArgs e)
        {
            LibraryDev.PermissionButton(btnControl, previewBar1);
            registerButtonArray(btnControl);
            printControl.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument(true);
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
                }else if(_formStatus == EnumFormStatus.CLOSE)
                {
                    this.closeTab();
                }
               
            }
        }
    }
}
