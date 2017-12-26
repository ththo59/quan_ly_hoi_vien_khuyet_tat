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
    }
}
