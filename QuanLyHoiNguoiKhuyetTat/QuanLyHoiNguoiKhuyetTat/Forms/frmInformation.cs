using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DauThau.Forms
{
    public partial class frmInformation : DevExpress.XtraEditors.XtraForm
    {
        public frmInformation(String strTitle)
        {
            InitializeComponent();
            lbTitle.Text = strTitle;
        }

        private void frmInformation_Load(object sender, EventArgs e)
        {
            timer.Enabled = true;
           
        }

        int second = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            second++;
            if (second == 1)
                this.Close();
        }
    }
}