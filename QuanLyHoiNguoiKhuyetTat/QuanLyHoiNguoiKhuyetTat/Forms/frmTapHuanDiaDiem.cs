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
using DauThau.Models;
using System.Linq;
using System.Data.Entity;
using DevExpress.Utils;
using DevExpress.XtraLayout.Utils;
using DauThau.Reports;
using DauThau.UserControlCategoryMain;
using DauThau.UserControlMain;

namespace DauThau.Forms
{
    public partial class frmTapHuanDiaDiem : Form
    {

        public frmTapHuanDiaDiem()
        {
            InitializeComponent();
        }

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        private QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
        public QL_HOATDONG_TAPHUAN_DIADIEM data;

        const Int64 constIdDeleted = -1;

        private void frmNhaTaiTro_Load(object sender, EventArgs e)
        {

            FormStatus = EnumFormStatus.VIEW;
        }

        #region function

        void _closeForm()
        {
            this.Close();
        }

        private Boolean _validateControl()
        {

            if (txtDiaDiem_Ten.Text.Trim() == string.Empty)
            {
                dxErrorProvider1.SetError(txtDiaDiem_Ten, "Dữ liệu không được trống");
                return false;
            }
            if (dxErrorProvider1.HasErrors)
            {
                clsMessage.MessageWarning("Vui lòng nhập đầy đủ thông tin");
                return false;
            }

            return true;
        }

        void _bindingData()
        {
            _clearData();
            if (data != null)
            {
                txtDiaDiem_Ten.Text = data.TH_DD_TEN;
                txtDiaDiem_DiaChi.Text = data.TH_DD_DIACHI;
                txtDiaDiem_MST.Text = data.TH_DD_MST;
                txtDiaDiem_SDT.Text = data.TH_DD_SDT;
                txtDiaDiem_STK.Text = data.TH_DD_STK;
                txtDiaDiem_TenNganHang.Text = data.TH_DD_TEN_NGANHANG;
                txtLinkHopDong.Text = data.TH_DD_LINK_HOPDONG;
            }
        }

        private void _setObjectEntities(ref QL_HOATDONG_TAPHUAN_DIADIEM item)
        {
            item.TH_DD_TEN = txtDiaDiem_Ten.Text;
            item.TH_DD_DIACHI = txtDiaDiem_DiaChi.Text;
            item.TH_DD_MST = txtDiaDiem_MST.Text;
            item.TH_DD_SDT = txtDiaDiem_SDT.Text;
            item.TH_DD_STK = txtDiaDiem_STK.Text;
            item.TH_DD_TEN_NGANHANG = txtDiaDiem_TenNganHang.Text;
            item.TH_DD_LINK_HOPDONG = txtLinkHopDong.Text;
        }

        private void _clearData()
        {
            foreach (var items in layoutEdit.Controls)
            {
                BaseEdit item = items as BaseEdit;
                if (item != null)
                {
                    item.EditValue = null;
                }
            }
        }

        private void _statusAllControl(Boolean readOnly)
        {

            foreach (var items in layoutEdit.Controls)
            {
                BaseEdit item = items as BaseEdit;
                SimpleButton button = items as SimpleButton;
                if (button != null)
                {
                    button.Enabled = !readOnly;
                    continue;
                }
                if (item != null)
                {
                    item.ReadOnly = readOnly;
                    item.EnterMoveNextControl = true;
                }
                
            }
        }


        private void _saveData()
        {
            if (_validateControl())
            {
                WaitDialogForm _wait = new WaitDialogForm("Đang lưu dữ liệu ...", "Vui lòng đợi giây lát");
                using (var _context = new QL_HOIVIEN_KTEntities())
                {
                    switch (_formStatus)
                    {
                        case EnumFormStatus.ADD:

                            data = new QL_HOATDONG_TAPHUAN_DIADIEM();
                            _setObjectEntities(ref data);
                            break;

                        case EnumFormStatus.MODIFY:

                            _setObjectEntities(ref data);

                            break;

                        case EnumFormStatus.DELETE:
                            data.TH_DD_ID = constIdDeleted;
                            break;
                        default:
                            break;
                    }
                }
                FormStatus = EnumFormStatus.VIEW;
                _wait.Close();
            }
        }

        #endregion

        #region Event Button Control

        private void btnControl_btnEventAdd_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.ADD;
        }

        private void btnControl_btnEventCancel_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.VIEW;
        }

        private void btnControl_btnEventClose_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.CLOSE;
        }

        private void btnControl_btnEventDelete_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.DELETE;
        }

        private void btnControl_btnEventModify_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.MODIFY;
        }

        private void btnControl_btnEventSave_Click(object sender, EventArgs e)
        {
            _saveData();
        }

        #endregion

        #region Status

        public EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.ADD)
                {
                    _statusAllControl(false);
                    _clearData();
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    _statusAllControl(false);
                }
                
                else if (_formStatus == EnumFormStatus.CLOSE)
                {
                    _closeForm();
                }
                else
                {
                    _statusAllControl(true);
                    _bindingData();
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                }
            }
        }

        #endregion

        #region Event button other

        private void btnLinkHopDong_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkHopDong.Text);
        }


        #endregion


    }
}
