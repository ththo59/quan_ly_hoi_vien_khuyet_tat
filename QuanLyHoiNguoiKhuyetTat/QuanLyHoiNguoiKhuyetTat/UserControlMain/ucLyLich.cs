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
using DauThau.Models;
using System.Linq;

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
            FuncCategory.loadDMTinh(lueThanhPho);
            
        }

        private void btnControl_btnEventClose_Click(object sender, EventArgs e)
        {
            if(closeTab != null)
            {
                closeTab();
            }
        }

        private void lueThanhPho_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMHuyen(lueQuan, Convert.ToInt64(lueThanhPho.EditValue));
        }
    }
}
