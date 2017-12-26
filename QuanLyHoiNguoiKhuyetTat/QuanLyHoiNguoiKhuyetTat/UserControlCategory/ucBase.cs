using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DauThau.UserControlCategory
{
    public partial class ucBase : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBase()
        {
            InitializeComponent();
        }

        public delegate void deletegateCloseTabCurrent();
        public deletegateCloseTabCurrent closeTab;
    }
}
