using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DauThau.Models;
using DauThau.Class;

namespace DauThau.UserControlCategory
{
    public partial class ucBase : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBase()
        {
            InitializeComponent();
        }

        protected EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        protected QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
        public delegate void deletegateCloseTabCurrent();
        public deletegateCloseTabCurrent closeTab;
    }
}
