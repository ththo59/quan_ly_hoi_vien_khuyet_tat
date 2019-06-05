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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace DauThau.UserControlCategory
{
    public partial class ucBase : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBase()
        {
            InitializeComponent();
        }

        protected Int64 _idRowSelected;
        protected EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        protected QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();


        public delegate void deletegateCloseTabCurrent();
        public deletegateCloseTabCurrent closeTab;

        virtual protected EnumFormStatus FormStatus { get; set; }

        virtual protected Boolean SaveData() { return true; }

        public void registerButtonArray(ButtonsArray btnControl)
        {
            btnControl.btnEventAdd_Click += new System.EventHandler(this.btnControl_btnEventAdd_Click);
            btnControl.btnEventModify_Click += new System.EventHandler(this.btnControl_btnEventModify_Click);
            btnControl.btnEventDelete_Click += new System.EventHandler(this.btnControl_btnEventDelete_Click);
            btnControl.btnEventCancel_Click += new System.EventHandler(this.btnControl_btnEventCancel_Click);
            btnControl.btnEventClose_Click += new System.EventHandler(this.btnControl_btnEventClose_Click);
            btnControl.btnEventSave_Click += new System.EventHandler(this.btnControl_btnEventSave_Click);
            btnControl.btnEventPrint_Click += new System.EventHandler(this.btnControl_btnEventPrint_Click);
            btnControl.btnEventReport_Click += new System.EventHandler(this.btnControl_btnEventReport_Click);
        }

        protected void _setFocusedRow(GridView gvGrid, GridColumn colID)
        {
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                Int64 id = Convert.ToInt64(gvGrid.GetRowCellValue(i, colID));
                if (id == _idRowSelected)
                {
                    gvGrid.FocusedRowHandle = i;
                    break;
                }
            }
        }

        public void permissionAccessButton(ButtonsArray btnControl, Int32 enumFunc)
        {
            var query = (from p in context.QL_USERS_PERMISSION where p.PER_NAME == enumFunc && p.USER_ID == clsParameter._userId select p).FirstOrDefault();
            if(query != null)
            {
                if (btnControl.btnAdd.Enabled)
                {
                    btnControl.btnAdd.Enabled = query.PER_ADD ?? false;
                }
                if (btnControl.btnModify.Enabled)
                {
                    btnControl.btnModify.Enabled = query.PER_MODIFY ?? false;
                }
                if (btnControl.btnDelete.Enabled)
                {
                    btnControl.btnDelete.Enabled = query.PER_DELETE ?? false;
                }
                if (btnControl.btnPrint.Enabled)
                {
                    btnControl.btnPrint.Enabled = query.PER_PRINT ?? false;
                }
                return;
            }

            btnControl.btnAdd.Enabled = btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = btnControl.btnPrint.Enabled = false;
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
            SaveData();
        }
        protected void btnControl_btnEventPrint_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.PRINT;
        }
        protected void btnControl_btnEventReport_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.REPORT;
        }
        
    }
}
