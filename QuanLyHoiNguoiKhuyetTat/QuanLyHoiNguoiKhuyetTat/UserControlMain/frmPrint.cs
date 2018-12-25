using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace DauThau.UserControlCategoryMain
{
    public partial class frmPrint : XtraForm
    {
        XtraReport rpt = new XtraReport();
        public frmPrint(XtraReport _rpt)
        {
            InitializeComponent();
            rpt = _rpt;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            printControl.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument(true);
        }

        private void btnControl_btnEventPrint_Click(object sender, EventArgs e)
        {
            try
            {
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.Print();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnControl_btnEventClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
