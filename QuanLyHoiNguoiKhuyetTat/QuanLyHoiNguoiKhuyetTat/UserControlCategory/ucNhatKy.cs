using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DauThau.Class;
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using System.Linq;
using System.Data.Entity;
using DevExpress.Utils;
using DauThau.Models;

namespace DauThau.UserControlCategory
{
    public partial class ucNhatKy : ucBase
    {
        public ucNhatKy()
        {
            InitializeComponent();
        }

        private void ucDMNhuCau_Load(object sender, EventArgs e)
        {
            initData();
            registerButtonArray(btnControl);

            FormStatus = EnumFormStatus.VIEW;
        }

        #region Function

        void initData()
        {
            gvGrid._SetDefaultColorRowStyle();
        }

        void _selectData()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            context = new QL_HOIVIEN_KTEntities();
            context.QL_NHATKY.Load();
            gcGrid.DataSource = context.QL_NHATKY.Local.ToBindingList();
            _wait.Close();
        }


        void _cancelData()
        {
            _selectData();
            this.FormStatus = EnumFormStatus.VIEW;
        }

        protected override bool SaveData()
        {
            return base.SaveData();
        }
        #endregion

        #region Status


        protected override EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.ADD)
                {
                    gvGrid.OptionsBehavior.Editable = true;
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvGrid.ActiveFilter.Clear();
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    gvGrid.ActiveFilter.Clear();
                    gvGrid.OptionsView.ShowAutoFilterRow = false;
                    gvGrid.OptionsBehavior.Editable = true;
                }
                else if (_formStatus == EnumFormStatus.CANCEL)
                {
                    _cancelData();
                }
                else if (_formStatus == EnumFormStatus.CLOSE)
                {
                    if (closeTab != null)
                    {
                        closeTab();
                    }
                }
                else
                {
                    _selectData();
                    gvGrid.OptionsBehavior.Editable = false;
                    gvGrid.OptionsView.ShowAutoFilterRow = true;
                    gvGrid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;

                }
            }
        }


        #endregion

        private void btnControl_btnEventView_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.VIEW;
        }
    }
}
