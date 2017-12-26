using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DauThau.Class;
using DauThau.Forms;

namespace DauThau.UserControlCategory
{
    public partial class ucLyLich : ucBase
    {
        public ucLyLich()
        {
            InitializeComponent();
        }

        private void ucLyLich_Load(object sender, EventArgs e)
        {

        }

        private void btnControl_btnEventClose_Click(object sender, EventArgs e)
        {
            if(closeTab != null)
            {
                closeTab();
            }
        }
    }
}
