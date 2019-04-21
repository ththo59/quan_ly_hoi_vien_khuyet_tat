using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DauThau.UserControlCategory
{
    public partial class ucSkin : ucBase
    {
        public ucSkin()
        {
            InitializeComponent();
        }

        private void ucSkin_Load(object sender, EventArgs e)
        {
            DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(glcSkins, true);
        }
    }
}
