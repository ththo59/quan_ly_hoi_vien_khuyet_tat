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
using DevExpress.Utils;
using DevExpress.XtraLayout;
using DevExpress.XtraTab;

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
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            registerButtonArray(btnControl);
            FuncCategory.loadDMTinh(lueThanhPho);
            FormStatus = EnumFormStatus.VIEW;
            _wait.Close();
        }

        private void lueThanhPho_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMHuyen(lueQuan, Convert.ToInt64(lueThanhPho.EditValue));
        }

        protected override EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.ADD)
                {
                    _clearData();
                    _statusAllControl(false);
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    
                }
                else if (_formStatus == EnumFormStatus.DELETE)
                {

                }else if (_formStatus == EnumFormStatus.CLOSE)
                {
                    if (closeTab != null)
                    {
                        closeTab();
                    }
                }
                else
                {
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    _statusAllControl(true);
                }
            }
        }

        #region function

        private void _statusAllControl(Boolean disable)
        {
            foreach (XtraTabPage tabPages in tabControlMain.TabPages)
            {
                foreach (Control layouts in tabPages.Controls)
                {
                    LayoutControl layout = layouts as LayoutControl;
                    if(layout == null)
                    {
                        continue;
                    }
                    foreach (var items in layout.Controls)
                    {
                        BaseEdit item = items as BaseEdit;
                        if (item != null)
                        {
                            item.ReadOnly = disable;
                        }
                        else
                        {
                            CheckedListBoxControl checkListBox = items as CheckedListBoxControl;
                            if (checkListBox != null)
                            {
                                checkListBox.Enabled = !disable;
                            }
                        }
                    }
                }
            }
        }

        private void _clearData()
        {
            foreach (XtraTabPage tabPages in tabControlMain.TabPages)
            {
                foreach (Control layouts in tabPages.Controls)
                {
                    LayoutControl layout = layouts as LayoutControl;
                    if (layout == null)
                    {
                        continue;
                    }
                    foreach (var items in layout.Controls)
                    {
                        BaseEdit item = items as BaseEdit;
                        if (item != null)
                        {
                            item.EditValue = null;
                        }
                    }
                }
            }
        }

        #endregion


    }
}
