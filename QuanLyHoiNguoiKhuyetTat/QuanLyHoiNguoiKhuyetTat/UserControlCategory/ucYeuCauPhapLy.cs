using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;

namespace DauThau.UserControlCategory
{
    public partial class ucYeuCauPhapLy : DevExpress.XtraEditors.XtraUserControl
    {
        public ucYeuCauPhapLy()
        {
            InitializeComponent();
            try
            {
                richEditControl1.LoadDocument(Application.StartupPath + "\\vanbanphaply.doc", DocumentFormat.Doc);

            }
            catch (Exception)
            {
                XtraMessageBox.Show("Không tìm thấy file.");
            }
        }
           
    }
}
