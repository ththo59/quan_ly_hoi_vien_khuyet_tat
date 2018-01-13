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
using System.Collections;

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

            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TINH, lueThanhPho);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TINH, lueThuongTru_TP);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TINH, lueTamTru_TP);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_GIOITINH, lueGioiTinh);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_DANTOC, lueDanToc);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TONGIAO, lueTonGiao);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_NGHE_NGHIEP, lueNgheNghiep);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TRINH_DO_HOC_VAN, lueTrinhDoVanHoa);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TRINH_DO_CHUYEN_MON, lueTrinhDoChuyenMon);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_CHUCVU_HOI, lueChucVuHoi);

            deNgaySinh.Ex_FormatCustomDateEdit();
            deNgayKhuyetTat.Ex_FormatCustomDateEdit();
            deNgayCapCMND.Ex_FormatCustomDateEdit();

            FormStatus = EnumFormStatus.VIEW;
            _wait.Close();
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
                    _setDefaultValue();
                    _statusAllControl(false);
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {

                }
                else if (_formStatus == EnumFormStatus.DELETE)
                {

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
                    _loadData();
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    dxErrorProvider.ClearErrors();
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

        private void _setDefaultValue()
        {
            _setDefaultLookupedit(lueGioiTinh);
            _setDefaultLookupedit(lueDanToc);
            _setDefaultLookupedit(lueTonGiao);
            _setDefaultLookupedit(lueNgheNghiep);
            _setDefaultLookupedit(lueTrinhDoVanHoa);
            _setDefaultLookupedit(lueTrinhDoChuyenMon);
            _setDefaultLookupedit(lueTrinhDoVanHoa);
            _setDefaultLookupedit(lueChucVuHoi);
            _setDefaultLookupedit(lueThuongTru_TP);
            _setDefaultLookupedit(lueTamTru_TP);
        }

        private void _setDefaultLookupedit(LookUpEdit lue)
        {
            lue.setDefaultFirstItems();
        }

        private Boolean _validateControl()
        {
            dxErrorProvider.ClearErrors();
            if(txtHoTen.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtHoTen, "Vui lòng nhập họ tên");
            }

            return !dxErrorProvider.HasErrors;
        }

        protected override bool SaveData()
        {
            if (_validateControl())
            {
                using (var _context = new QL_HOIVIEN_KTEntities())
                {
                    switch (_formStatus)
                    {
                        case EnumFormStatus.ADD:
                            QL_HOIVIEN item = new QL_HOIVIEN();
                            item.HV_TEN = txtHoTen.Text;
                            item.HV_GIOI_TINH = lueGioiTinh.Ex_EditValueToInt64();
                            item.HV_DAN_TOC = lueDanToc.Ex_EditValueToInt64();
                            item.HV_NGAY_SINH = deNgaySinh.Ex_EditValueToDateTime();
                            item.HV_TON_GIAO_ID = lueTonGiao.Ex_EditValueToInt64();
                            item.HV_NGHE_NGHIEP_ID = lueNgheNghiep.Ex_EditValueToInt64();
                            item.HV_TRINHDO_VANHOA_ID = lueTrinhDoVanHoa.Ex_EditValueToInt64();
                            item.HV_TRINHDO_CHUYENMON_ID = lueTrinhDoChuyenMon.Ex_EditValueToInt64();

                            item.HV_CMND = txtCMND.Text;
                            item.HV_CMND_NGAY = deNgayCapCMND.Ex_EditValueToDateTime();
                            item.HV_CMND_NOICAP = txtNoiCapCMND.Text;

                            item.HV_KHUYETTAT_NGAY = deNgayKhuyetTat.Ex_EditValueToDateTime();

                            item.HV_THUONGTRU_TP = lueThuongTru_TP.Ex_EditValueToInt64();
                            item.HV_THUONGTRU_QUAN = lueThuongTru_Quan.Ex_EditValueToInt64();
                            item.HV_THUONGTRU_PHUONG = lueThuongTru_Phuong.Ex_EditValueToInt64();
                            item.HV_THUONGTRU_KHUVUC = txtThuongTru_KhuVuc.Text;
                            item.HV_THUONGTRU_DUONG = txtThuongTru_KhuVuc.Text;

                            item.HV_TAMTRU_TP = lueTamTru_TP.Ex_EditValueToInt64();
                            item.HV_TAMTRU_QUAN = lueTamTru_Quan.Ex_EditValueToInt64();
                            item.HV_TAMTRU_PHUONG = lueTamTru_Phuong.Ex_EditValueToInt64();
                            item.HV_TAMTRU_KHUVUC = txtTamTru_KhuVuc.Text;
                            item.HV_TAMTRU_DUONG = txtTamTru_KhuVuc.Text;

                            item.HV_DIENTHOAI = txtDienThoai.Text;
                            item.HV_EMAIL = txtEmail.Text;
                            item.HV_DIACHI_COQUAN = txtDiaChiCoQuan.Text;

                            _context.QL_HOIVIEN.Add(item);
                            break;
                        case EnumFormStatus.MODIFY:
                            break;
                        case EnumFormStatus.DELETE:
                            break;
                        default:
                            break;
                    }
                    _context.SaveChanges();
                }
                FormStatus = EnumFormStatus.VIEW;
            }

            return base.SaveData();
        }
        
        private void _loadData()
        {
            var dmHoiVien = (from p in context.QL_HOIVIEN select p).ToList();
            gcGrid.DataSource = dmHoiVien;
        }

        #endregion

        #region LookupEdit

        private void lueThanhPho_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMHuyen(lueQuan, clsChangeType.change_int64(lueThanhPho.EditValue));
        }

        private void lueThuongTru_TP_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMHuyen(lueThuongTru_Quan, clsChangeType.change_int64(lueThuongTru_TP.EditValue));
        }

        private void lueTamTru_TP_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMHuyen(lueTamTru_Quan, clsChangeType.change_int64(lueTamTru_TP.EditValue));
        }

        private void lueThuongTru_Quan_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMXa(lueThuongTru_Phuong, clsChangeType.change_int64(lueThuongTru_Quan.EditValue));
        }

        private void lueTamTru_Quan_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMXa(lueTamTru_Phuong, clsChangeType.change_int64(lueTamTru_Quan.EditValue));
        }

        #endregion
    }
}
