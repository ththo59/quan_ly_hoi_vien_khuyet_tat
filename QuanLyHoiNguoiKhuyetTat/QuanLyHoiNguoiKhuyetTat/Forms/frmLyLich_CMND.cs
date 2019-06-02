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
    public partial class frmLyLich_CMND : Form
    {

        public frmLyLich_CMND(QL_HOIVIEN _hoivien, QL_HOIVIEN_IMAGE _img)
        {
            hoivien = _hoivien;
            hoivien_image = _img;
            InitializeComponent();
        }
        
        public QL_HOIVIEN hoivien;
        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        public QL_HOIVIEN_IMAGE hoivien_image;

        private void frmLyLich_CMND_Load(object sender, EventArgs e)
        {
            seCMND_Nam.Properties.MaxValue = DateTime.Now.Year ;
            seCMND_Nam.Properties.MinValue = 1900;
            seCMND_Thang.Properties.MaxValue = 12;
            seCMND_Thang.Properties.MinValue = 1;
            seCMND_Ngay.Properties.MaxValue = 31;
            seCMND_Ngay.Properties.MinValue = 1;

            _bindingData();

            FormStatus = EnumFormStatus.VIEW;
            this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.Update;
            FormStatus = EnumFormStatus.MODIFY;
        }

        #region function

        public EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.ADD)
                {
                    _clearData();
                }
                else if(_formStatus == EnumFormStatus.MODIFY)
                {

                }
                else
                {
                    _bindingData();
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                }
            }
        }
        void _closeForm()
        {
            this.Close();
        }

        private Boolean _validateControl()
        {
            dxErrorProvider1.ClearErrors();
            if (txtCMND.Text.Trim() == string.Empty)
            {
                dxErrorProvider1.SetError(txtCMND, "Dữ liệu không được trống");
                
            }

            if (txtCMND_NoiCap.Text.Trim() == string.Empty)
            {
                dxErrorProvider1.SetError(txtCMND_NoiCap, "Dữ liệu không được trống");

            }

            if(seCMND_Nam.EditValue == null || Convert.ToInt64(seCMND_Nam.EditValue) <= 0)
            {
                dxErrorProvider1.SetError(seCMND_Nam, "Dữ liệu không phù hợp");
            }

            if (dxErrorProvider1.HasErrors)
            {
                clsMessage.MessageWarning("Vui lòng nhập đầy đủ thông tin");
            }
            
            return !dxErrorProvider1.HasErrors;
        }

        void _bindingData()
        {
            _clearData();
            if (hoivien != null)
            {
                txtCMND.Text = hoivien.HV_CMND;
                if (hoivien.HV_CMND_NGAY.HasValue)
                {
                    seCMND_Ngay.EditValue = hoivien.HV_CMND_NGAY.Value.Day;
                    seCMND_Thang.EditValue = hoivien.HV_CMND_NGAY.Value.Month;
                    seCMND_Nam.EditValue = hoivien.HV_CMND_NGAY.Value.Year;
                }
                txtCMND_NoiCap.Text = hoivien.HV_CMND_NOICAP;
            }

            if(hoivien_image != null)
            {
                picMatTruoc.Image = FunctionHelper.convertBinaryToImage(hoivien_image.IMG_CMND_MATTRUOC);
                picMatSau.Image = FunctionHelper.convertBinaryToImage(hoivien_image.IMG_CMND_MATSAU);
            }
        }

        private void _setObjectEntities(ref QL_HOIVIEN item, ref QL_HOIVIEN_IMAGE img)
        {
            item.HV_CMND = txtCMND.Text;
            item.HV_CMND_NOICAP = txtCMND_NoiCap.Text;
            if (seCMND_Nam.EditValue != null && seCMND_Nam.Ex_EditValueToInt() > 0)
            {
                item.HV_CMND_NGAY = new DateTime(seCMND_Nam.Ex_EditValueToInt() ?? 1900, seCMND_Thang.Ex_EditValueToInt() ?? 1, seCMND_Ngay.Ex_EditValueToInt() ?? 1);
            }
            else
            {
                item.HV_CMND_NGAY = new Nullable<DateTime>();
            }
            img.IMG_CMND_MATTRUOC = FunctionHelper.convertImageToBinary(picMatTruoc.Image);
            img.IMG_CMND_MATSAU = FunctionHelper.convertImageToBinary(picMatSau.Image);
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


        #endregion

        private void btnControl_btnEventClose_Click(object sender, EventArgs e)
        {
            _closeForm();
        }

        private void btnChonMatTruoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (f.ShowDialog() == DialogResult.OK)
            {
                picMatTruoc.Image = Image.FromFile(f.FileName);
            }
        }

        private void btnChonMatSau_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (f.ShowDialog() == DialogResult.OK)
            {
                picMatSau.Image = Image.FromFile(f.FileName);
            }
        }

        private void btnControl_btnEventModify_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.MODIFY;
        }

        private void btnControl_btnEventSave_Click(object sender, EventArgs e)
        {
            if (_validateControl())
            {
                WaitDialogForm _wait = new WaitDialogForm("Đang lưu dữ liệu ...", "Vui lòng đợi giây lát");
                using (var _context = new QL_HOIVIEN_KTEntities())
                {
                    switch (_formStatus)
                    {
                        case EnumFormStatus.MODIFY:
                            if (hoivien == null)
                            {
                                hoivien = new QL_HOIVIEN();
                            }
                            if (hoivien_image == null)
                            {
                                hoivien_image = new QL_HOIVIEN_IMAGE();
                            }
                            _setObjectEntities(ref hoivien, ref hoivien_image);
                            break;
                        default:
                            break;
                    }
                }
                FormStatus = EnumFormStatus.VIEW;
                _wait.Close();
                _closeForm();
            }
        }

        private void btnControl_btnEventCancel_Click(object sender, EventArgs e)
        {
            _closeForm();
        }
    }
}
