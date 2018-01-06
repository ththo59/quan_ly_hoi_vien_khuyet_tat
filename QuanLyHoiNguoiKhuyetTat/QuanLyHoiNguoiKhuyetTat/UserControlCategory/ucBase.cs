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
using ControlsLib;

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

        virtual protected EnumFormStatus FormStatus { get; set; }

        public void registerButtonArray(ButtonsArray btnControl)
        {
            btnControl.btnEventAdd_Click += new System.EventHandler(this.btnControl_btnEventAdd_Click);
            btnControl.btnEventModify_Click += new System.EventHandler(this.btnControl_btnEventModify_Click);
            btnControl.btnEventDelete_Click += new System.EventHandler(this.btnControl_btnEventDelete_Click);
            btnControl.btnEventCancel_Click += new System.EventHandler(this.btnControl_btnEventCancel_Click);
            btnControl.btnEventClose_Click += new System.EventHandler(this.btnControl_btnEventClose_Click);
            btnControl.btnEventSave_Click += new System.EventHandler(this.btnControl_btnEventSave_Click);
        }

        protected void btnControl_btnEventClose_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.CLOSE;
        }

        protected void btnControl_btnEventAdd_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.ADD;
        }

        protected void btnControl_btnEventModify_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.MODIFY;
        }

        protected void btnControl_btnEventDelete_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.DELETE;
        }

        protected void btnControl_btnEventCancel_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.CANCEL;
        }
        protected void btnControl_btnEventSave_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.SAVE;
        }
    }
}
