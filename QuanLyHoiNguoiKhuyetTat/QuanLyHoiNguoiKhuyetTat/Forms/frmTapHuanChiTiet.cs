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
    public partial class frmTapHuanChiTiet : Form
    {

        public frmTapHuanChiTiet(int loai_id)
        {
            InitializeComponent();
            _loai_id = loai_id;
        }

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        private QL_HOIVIEN_KTEntities context = new QL_HOIVIEN_KTEntities();
        public BindingList<QL_HOATDONG_TAPHUAN_CHITIET> data;
        private Int64 idRowSelected;

        const Int64 constIdDeleted = -1;

        private int _loai_id;

        private void frmNhaTaiTro_Load(object sender, EventArgs e)
        {
            deNgayCap_Nam.Properties.MaxValue = DateTime.Now.Year;
            deNgayCap_Thang.Properties.MaxValue = 12;
            deNgayCap_Thang.Properties.MinValue = 1;
            deNgayCap_Ngay.Properties.MaxValue = 31;
            deNgayCap_Ngay.Properties.MinValue = 1;
            seThuLao.Ex_FormatCustomSpinEdit();
            seChiPhiKhac.Ex_FormatCustomSpinEdit();

            _changeLayout((CategoryTapHuanChiTietLoai)_loai_id);
            FormStatus = EnumFormStatus.VIEW;
        }

        #region function

        void _changeLayout(CategoryTapHuanChiTietLoai enumLoai)
        {
            switch (enumLoai)
            {
                case CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN:
                    layPrintBanCamKet.Visibility = layPrintBanHopDong.Visibility = LayoutVisibility.Never;
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH:
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU:
                    break;
                case CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN:
                    break;
                case CategoryTapHuanChiTietLoai.DOITUONG_KHONG_KHUYETTAT:
                    layPrintBanCamKet.Visibility = layPrintBanHopDong.Visibility = LayoutVisibility.Never;
                    layGroupVanBan.Visibility = layGroupThuLao.Visibility = LayoutVisibility.Never;
                    break;
                default:
                    break;
            }
        }
        void _selectData()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            gcGrid.DataSource = data.Where(p=> p.TH_ID != constIdDeleted);
            _setFocusedRow();
            _bindingData();
            _wait.Close();
        }

        private void _setFocusedRow()
        {
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                Int64 id = Convert.ToInt64(gvGrid.GetRowCellValue(i, colTH_CT_ID));
                if (id == idRowSelected)
                {
                    gvGrid.FocusedRowHandle = i;
                    break;
                }
            }
        }
        void _bindingData()
        {
            _clearData();
            QL_HOATDONG_TAPHUAN_CHITIET item = gvGrid.GetFocusedRow() as QL_HOATDONG_TAPHUAN_CHITIET;
            if (item != null)
            {
                txtHoTen.Text = item.TH_CT_HOTEN;
                txtChucVu.Text = item.TH_CT_CHUCVU;
                txtEmail.Text = item.TH_CT_EMAIL;
                txtFace.Text = item.TH_CT_FACEBOOK;
                txtCMND.Text = item.TH_CT_CMND_SO;
                if (item.TH_CT_CMND_NGAYCAP.HasValue)
                {
                    deNgayCap_Ngay.EditValue = item.TH_CT_CMND_NGAYCAP.Value.Day;
                    deNgayCap_Thang.EditValue = item.TH_CT_CMND_NGAYCAP.Value.Month;
                    deNgayCap_Nam.EditValue = item.TH_CT_CMND_NGAYCAP.Value.Year;
                }
                txtNoiCap.Text = item.TH_CT_CMND_NOICAP;
                txtDiaChi.Text = item.TH_CT_DIACHI;
                txtSoDienThoai.Text = item.TH_CT_SDT;
                txtMaSoThue.Text = item.TH_CT_MASOTHUE;
                txtSTK.Text = item.TH_CT_TK_SO;
                txtTenNganHang.Text = item.TH_CT_TK_NGANHANG;
                txtDiaChiNganHang.Text = item.TH_CT_TK_DIACHI;

                txtDonVi_Ten.Text = item.TH_CT_DONVI_TEN;
                txtDonVi_SDT.EditValue = item.TH_CT_DONVI_SDT;
                txtDonVi_DiaChi.EditValue = item.TH_CT_DONVI_DIACHI;
                
                txtLinkTOR.Text = item.TH_CT_LINK_TOR;
                txtLinkCV.Text = item.TH_CT_LINK_CV;
                txtLinkHopDong.EditValue = item.TH_CT_LINK_HOPDONG;
                txtLinkBanCamKet.EditValue = item.TH_CT_LINK_BANCAMKET;

                seThuLao.EditValue = item.TH_CT_THULAO;
                seChiPhiKhac.EditValue = item.TH_CT_CHIPHIKHAC;
                txtDienGiai.Text = item.TH_CT_DIENGIAI;
            }
        }

        void _closeForm()
        {
            this.Close();
        }

        private Boolean _validateControl()
        {

            if (txtHoTen.Text.Trim() == string.Empty)
            {
                clsMessage.MessageWarning("Vui lòng nhập đầy tên tổ chức");
                return false;
            }
            return true;
        }

        private void _setObjectEntities(ref QL_HOATDONG_TAPHUAN_CHITIET item)
        {
            item.TH_CT_LOAI = _loai_id;
            item.TH_CT_HOTEN = txtHoTen.Text;
            item.TH_CT_CHUCVU = txtChucVu.Text;
            item.TH_CT_EMAIL = txtEmail.Text;
            item.TH_CT_FACEBOOK = txtFace.Text;
            item.TH_CT_CMND_SO = txtCMND.Text;
            if (deNgayCap_Nam.EditValue != null)
            {
                item.TH_CT_CMND_NGAYCAP = new DateTime(deNgayCap_Nam.Ex_EditValueToInt() ?? 1, deNgayCap_Thang.Ex_EditValueToInt() ?? 1, deNgayCap_Ngay.Ex_EditValueToInt() ?? 0);
            }
            item.TH_CT_CMND_NOICAP = txtNoiCap.Text;
            item.TH_CT_DIACHI = txtDiaChi.Text;
            item.TH_CT_MASOTHUE = txtMaSoThue.Text;
            item.TH_CT_TK_SO = txtSTK.Text;
            item.TH_CT_TK_NGANHANG = txtTenNganHang.Text;
            item.TH_CT_TK_DIACHI = txtDiaChiNganHang.Text;

            item.TH_CT_DONVI_TEN = txtDonVi_Ten.Text;
            item.TH_CT_DONVI_DIACHI = txtDonVi_DiaChi.Text;
            item.TH_CT_DONVI_SDT = txtDonVi_SDT.Text;
            item.TH_CT_SDT = txtSoDienThoai.Text;

            
            item.TH_CT_LINK_TOR = txtLinkTOR.Text;
            item.TH_CT_LINK_CV = txtLinkCV.Text;
            item.TH_CT_LINK_HOPDONG = txtLinkHopDong.Text;
            item.TH_CT_LINK_BANCAMKET = txtLinkBanCamKet.Text;

            item.TH_CT_THULAO = seThuLao.Ex_EditValueToInt();
            item.TH_CT_CHIPHIKHAC = seChiPhiKhac.Ex_EditValueToInt();
            item.TH_CT_DIENGIAI = txtDienGiai.Text;
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
                else
                {
                    CheckedListBoxControl checkListBox = items as CheckedListBoxControl;
                    if (checkListBox != null)
                    {
                        checkListBox.Enabled = !readOnly;
                    }
                }
            }
            gcGrid.Enabled = readOnly;
        }

        void _deleteData()
        {
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                XtraMessageBox.Show("Bạn chưa chọn dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            string Ten = gvGrid.GetRowCellValue(gvGrid.FocusedRowHandle, colTH_CT_HOTEN.FieldName).ToString();
            if (XtraMessageBox.Show("Bạn có chắc muốn xóa: \"" + Ten + "\"  không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _saveData();
                FormStatus = EnumFormStatus.VIEW;
            }
        }

        private Int64 _maxID()
        {
            List<Int64> listID = new List<Int64>();
            Int64 max_TH_CT_ID = 1;
            if (data.Count > 0)
            {
                foreach (var row in data.Where(p=>p.TH_ID != constIdDeleted))
                {
                    listID.Add(row.TH_CT_ID);
                }
                max_TH_CT_ID = listID.Max() + 1;
            }
            return max_TH_CT_ID;
        }

        private void _saveData()
        {
            if (_validateControl())
            {
                WaitDialogForm _wait = new WaitDialogForm("Đang lưu dữ liệu ...", "Vui lòng đợi giây lát");
                using (var _context = new QL_HOIVIEN_KTEntities())
                {
                    QL_HOATDONG_TAPHUAN_CHITIET item;
                    switch (_formStatus)
                    {
                        case EnumFormStatus.ADD:

                            item = new QL_HOATDONG_TAPHUAN_CHITIET();
                            _setObjectEntities(ref item);
                            idRowSelected = _maxID();
                            item.TH_CT_ID = idRowSelected;
                            data.Add(item);

                            break;

                        case EnumFormStatus.MODIFY:
                            Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colTH_CT_ID));
                            item = (from p in data where p.TH_CT_ID == id select p).FirstOrDefault();
                            if (item != null)
                            {
                                _setObjectEntities(ref item);
                            }

                            data.Where(p => p.TH_CT_ID == id).ToList().ForEach(p => p = item);
                            break;

                        case EnumFormStatus.DELETE:
                            Int64 deleteId = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colTH_CT_ID));
                            item = (from p in data where p.TH_CT_ID == deleteId select p).FirstOrDefault();
                            if (item != null)
                            {
                                if (item.TH_ID == null) {//Nếu là dòng mới thì xóa luôn
                                    data.Remove(item);
                                }
                                else
                                {
                                    data.Where(p => p.TH_CT_ID == deleteId).ToList().ForEach(p => p.TH_ID = -1);
                                }
                            }

                            break;
                        default:
                            break;
                    }
                    _context.SaveChanges();
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
                else if (_formStatus == EnumFormStatus.DELETE)
                {
                    _deleteData();
                }
                else if (_formStatus == EnumFormStatus.CLOSE)
                {
                    _closeForm();
                }
                else
                {
                    _selectData();
                    _statusAllControl(true);

                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = gvGrid.RowCount > 0;

                }
            }
        }

        #endregion

        #region event Grid

        private void gvGrid_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            idRowSelected = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colTH_CT_ID));
            _bindingData();
        }

        #endregion

        #region Event button other

        private void btnLinkTOR_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkTOR.Text);
        }

        private void btnLinkCV_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkCV.Text);
        }

        private void btnLinkHopDong_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkHopDong.Text);
        }

        private void btnLinkBanCamKet_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkBanCamKet.Text);
        }


        #endregion

        private void btnXuatBanHopDong_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
            {
                clsMessage.MessageWarning("Chưa có thông tin tập huấn viên chính. Vui lòng kiểm tra lại.");
                return;
            }

            var dataPrint = new Dictionary<string, string>()
            {
                {"bDiaChi", txtDiaChi.Text},
                {"bDienThoai", txtSoDienThoai.Text},
                {"bChucVu", txtChucVu.Text},
                {"bTenTaiKhoan", txtHoTen.Text},

                {"bSoTaiKhoan", txtSTK.Text},
                {"bNganHang", txtTenNganHang.Text},
                {"bDiaChiNganHang", txtDiaChiNganHang.Text},
                {"bMaSoThue", txtMaSoThue.Text}
            };

            string fileName = "";
            switch ((CategoryTapHuanChiTietLoai)_loai_id)
            {
                case CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN:
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH:
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU:
                    fileName = "THV_hop_dong_thue.doc";
                    break;
                case CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN:
                    fileName = "PDV_hop_dong_thue.doc";
                    break;
                case CategoryTapHuanChiTietLoai.DOITUONG_KHONG_KHUYETTAT:
                    layGroupVanBan.Visibility = layGroupThuLao.Visibility = LayoutVisibility.Never;
                    break;
                default:
                    break;
            }

            if(fileName == "")
            {
                clsMessage.MessageInfo("Biểu mẫu chưa được cấu hình. Vui lòng kiểm tra lại");
                return;
            }

            ExportHelper.exportWord(dataPrint, fileName);
        }

        private void btnXuatBanCamKet_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == "")
            {
                clsMessage.MessageWarning("Chưa có thông tin tập huấn viên chính. Vui lòng kiểm tra lại.");
                return;
            }
            var dataPrint = new Dictionary<string, string>()
            {
                {"TH_CT_HOTEN", txtHoTen.Text},
                {"TH_CT_CMND_SO", txtCMND.Text},
                {"TH_CT_CMND_NGAYCAP", string.Format("{0}/{1}/{2}", deNgayCap_Ngay.Text, deNgayCap_Thang.Text, deNgayCap_Nam.Text)},
                {"TH_CT_CMND_NOICAP", txtNoiCap.Text },

                {"TH_CT_DIACHI", txtDiaChi.Text},
                {"TH_CT_DONVI_DIACHI", txtDonVi_DiaChi.Text},

            };
            string fileName = "";
            switch ((CategoryTapHuanChiTietLoai)_loai_id)
            {
                case CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN:
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH:
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU:
                    fileName = "THV_ban_cam_ket.doc";
                    break;
                case CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN:
                    fileName = "PDV_ban_cam_ket.doc";
                    break;
                case CategoryTapHuanChiTietLoai.DOITUONG_KHONG_KHUYETTAT:
                    layGroupVanBan.Visibility = layGroupThuLao.Visibility = LayoutVisibility.Never;
                    break;
                default:
                    break;
            }

            if (fileName == "")
            {
                clsMessage.MessageInfo("Biểu mẫu chưa được cấu hình. Vui lòng kiểm tra lại");
                return;
            }
            ExportHelper.exportWord(dataPrint, fileName);
        }
    }
}
