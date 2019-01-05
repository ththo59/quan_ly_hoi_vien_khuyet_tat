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
using DevExpress.XtraEditors.Controls;
using System.Data.Entity;
using DauThau.Reports;
using DauThau.UserControlCategoryMain;
using DevExpress.XtraGrid;
using System.IO;
using System.Drawing.Imaging;

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
            //btnControl.btnReport.Image = btnControl.btnPrint.Image;
            btnControl.btnReport.Text = "Đơn xin nhập hội";
            btnControl.btnPrint.Text = "In lý lịch";
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

            //Tab Suc khoe
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_KHUYETTAT_MUCDO, lueMucDoKT);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_KHUYETTAT_NGUYENNHAN, lueNguyenNhanKT);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_KHUYETTAT_TINHTRANG, lueTinhTrangKT);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_PHUONGTIEN_DILAI, luePhuongTienDiLai);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TINHTRANG_HONNHAN, lueTinhTrangHonNhan);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_GIOITINH, lueGioiTinhCon1);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_GIOITINH, lueGioiTinhCon2);

            //Tab dụng cụ hỗ trợ chế độ chính sách
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_DUNGCU_HOTRO, lueDungCuHoTro);
            seTienBTXHHangThang.Ex_FormatCustomSpinEdit();

            //Tab nơi ở chăm sóc bản thân
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_NOI_SINH_SONG, lueNoiSinhSong);
            chkListNha.Ex_SetDataSource(CategoryEntitiesTable.DM_NOI_O_NHA.Ex_ToString());
            chkListSongVoi.Ex_SetDataSource(CategoryEntitiesTable.DM_NOI_O_SONG_VOI.Ex_ToString());
            chkListChamSocBanThan.Ex_SetDataSource(CategoryEntitiesTable.DM_CHAMSOC_BANTHAN.Ex_ToString());

            //Viec lam nhu cau
            seThuNhapTB.Ex_FormatCustomSpinEdit();
            chkListNhuCau.Ex_SetDataSource(CategoryEntitiesTable.DM_NHUCAU.Ex_ToString());
            chkListThanhVienHoi.Ex_SetDataSource(CategoryEntitiesTable.DM_THANHVIEN_HOI.Ex_ToString());

            repLueGioiTinh.DataSource = FuncCategory.loadDMGioiTinh();
            deNgaySinh.Ex_FormatCustomDateEdit();
            deNgayKhuyetTat.Ex_FormatCustomDateEdit();
            deNgayCapCMND.Ex_FormatCustomDateEdit();

            deNgaySinhCon1.Ex_FormatCustomDateEdit();
            deNgaySinhCon2.Ex_FormatCustomDateEdit();
            
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
                    _statusAllControl(false);
                }
                else if (_formStatus == EnumFormStatus.DELETE)
                {
                    _deleteRow();
                }
                else if (_formStatus == EnumFormStatus.PRINT)
                {
                    _doPrintInLyLich();
                }
                else if (_formStatus == EnumFormStatus.REPORT)
                {
                    //in đơn xin gia nhập hội
                    _doPrintGiaNhapHoi();
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
                    btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = gvGrid.RowCount > 0;
                }
            }
        }

        #region function

        private void _statusAllControl(Boolean readOnly)
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
                        SimpleButton button = items as SimpleButton;
                        if(button != null)
                        {
                            button.Enabled = !readOnly;
                            continue;
                        }
                        if (item != null)
                        {
                            item.ReadOnly = readOnly;
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
                }
            }

            seTuoi.ReadOnly = true;
            seTongThoiGianKT.ReadOnly = true;
            lueThanhPho.ReadOnly = lueQuan.ReadOnly = !readOnly;
            gcGrid.Enabled = readOnly;
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

            //lueTinhTrangKT.setDefaultFirstItems();
            //lueMucDoKT.setDefaultFirstItems();
            //luePhuongTienDiLai.setDefaultFirstItems();
            //lueNguyenNhanKT.setDefaultFirstItems();
            //lueTinhTrangHonNhan.setDefaultFirstItems();
        }

        private void _setDefaultLookupedit(LookUpEdit lue)
        {
            lue.setDefaultFirstItems();
        }

        private Boolean _validateControl()
        {
            dxErrorProvider.ClearErrors();

            if (txtHoTen.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtHoTen, "Vui lòng nhập họ tên");
            }

            if (lueThuongTru_Quan.EditValue == null)
            {
                dxErrorProvider.SetError(lueThuongTru_Quan, "Vui lòng nhập thông tin");
            }

            if (dxErrorProvider.HasErrors)
            {
                clsMessage.MessageWarning("Vui lòng nhập đầy đủ thông tin.");
            }

            return !dxErrorProvider.HasErrors;
        }

        private void _loadDataFocusRow()
        {
            _clearData();
            QL_HOIVIEN item = gvGrid.GetFocusedRow() as QL_HOIVIEN;
            if (item != null)
            {
                btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = true;

                //Thông tin cá nhân
                txtHoTen.Text = item.HV_TEN;
                pictureAvatar.Image = convertBinaryToImage(item.HV_IMAGE);
                lueGioiTinh.EditValue = item.HV_GIOI_TINH;
                lueDanToc.EditValue = item.HV_DAN_TOC;
                deNgaySinh.EditValue = item.HV_NGAY_SINH;
                lueTonGiao.EditValue = item.HV_TON_GIAO;
                lueNgheNghiep.EditValue = item.HV_NGHE_NGHIEP;
                lueTrinhDoVanHoa.EditValue = item.HV_TRINHDO_VANHOA;
                lueTrinhDoChuyenMon.EditValue = item.HV_TRINHDO_CHUYENMON;
                txtCMND.Text = item.HV_CMND;
                deNgayCapCMND.EditValue = item.HV_CMND_NGAY;
                txtNoiCapCMND.Text = item.HV_CMND_NOICAP;
                deNgayKhuyetTat.EditValue = item.HV_KHUYETTAT_NGAY;
                lueChucVuHoi.EditValue = item.HV_CHUCVU;

                lueThuongTru_TP.EditValue = item.HV_THUONGTRU_TP;
                lueThuongTru_Quan.EditValue = item.HV_THUONGTRU_QUAN;
                lueThuongTru_Phuong.EditValue = item.HV_THUONGTRU_PHUONG;
                txtThuongTru_KhuVuc.Text = item.HV_THUONGTRU_KHUVUC;
                txtThuongTru_Duong.EditValue = item.HV_THUONGTRU_DUONG;

                lueTamTru_TP.EditValue = item.HV_TAMTRU_TP;
                lueTamTru_Quan.EditValue = item.HV_TAMTRU_QUAN;
                lueTamTru_Phuong.EditValue = item.HV_TAMTRU_PHUONG;
                txtTamTru_KhuVuc.Text = item.HV_TAMTRU_KHUVUC;
                txtTamTru_Duong.EditValue = item.HV_TAMTRU_DUONG;

                txtDienThoai.Text = item.HV_DIENTHOAI;
                txtEmail.Text = item.HV_EMAIL;
                txtDiaChiCoQuan.Text = item.HV_DIACHI_COQUAN;

                //Tab sức khỏe - hôn nhân
                lueTinhTrangKT.EditValue = item.HV_KT_TINHTRANG;
                txtTinhTrangKTChiTiet.Text = item.HV_KT_TINHTRANG_CHITIET;
                txtKhuyetTatKhac.Text = item.HV_KT_KHAC;
                lueMucDoKT.EditValue = item.HV_KT_MUCDO;
                luePhuongTienDiLai.EditValue = item.HV_PHUONGTIEN_DILAI;
                txtTinhTrangSucKhoe.Text = item.HV_TINHTRANG_SUCKHOE;
                lueNguyenNhanKT.EditValue = item.HV_KT_NGUYENNHAN;

                txtNguyenNhanChiTiet.Text = item.HV_KT_NGUYENNHAN_CHITIET;
                lueTinhTrangHonNhan.EditValue = item.HV_TINHTRANG_HONNHAN;
                txtVoChong.Text = item.HV_VOCHONG;
                seSoCon.EditValue = item.HV_SOCON;
                txtCon1.Text = item.HV_CON1_TEN;
                deNgaySinhCon1.EditValue = item.HV_CON1_NGAYSINH;
                lueGioiTinhCon1.EditValue = item.HV_CON1_GIOITINH;
                txtHocTruong1.EditValue = item.HV_CON1_HOCTRUONG;

                txtCon2.Text = item.HV_CON2_TEN;
                deNgaySinhCon2.EditValue = item.HV_CON2_NGAYSINH;
                lueGioiTinhCon2.EditValue = item.HV_CON2_GIOITINH;
                txtHocTruong2.EditValue = item.HV_CON2_HOCTRUONG;

                txtPhongTraoTheThao.Text = item.HV_PHONGTRAO_THETHAO;
                txtPhongTraoMongMuon.Text = item.HV_PHONGTRAO_MONGMUON;
                txtNguyenVong.Text = item.HV_NGUYENVONG;

                //Tab chinh sách hỗ trợ
                lueDungCuHoTro.EditValue = item.HV_DUNGCU_HOTRO;
                deDCHT_ThoiGianNhan.EditValue = item.HV_DCHT_THOIDIEM_NHAN;
                txtDCHT_ToChuc.EditValue = item.HV_DCHT_TU_TOCHUC;
                txtDCHT_TinhTrang.EditValue = item.HV_DCHT_TINHTRANG;

                chkNhanBHXH_HangThang.EditValue = item.HV_BTXH_NHAN_HANGTHANG??false;
                seTienBTXHHangThang.EditValue = item.HV_BTXH_TIEN_HANGTHANG;
                txtBTXHKhac.EditValue = item.HV_BTXH_KHAC;
                chkNhanBHYTMienPhi.EditValue = item.HV_BHYT_MIENPHI??false;

                chkNhanGiayCNXacDinhMucDoKT.EditValue = item.HV_GIAY_CHUNGNHAN_KT??false;
                chkNhanQDCongNhanMucDoKT.EditValue = item.HV_QUYETDINH_CONGNHAN_KT??false;
                chkGiaDinhDienChinhSach.EditValue = item.HV_GIADINH_CHINHSACH??false;

                txtTheKT.Text = item.HV_THE_KHUYETTAT;

                //Nơi ở chăm sóc bản thân
                lueNoiSinhSong.EditValue = item.HV_NOI_SINH_SONG;
                txtDieuKienSongKhac.EditValue = item.HV_DIEUKIEN_SONG_KHAC;
                chkListNha.Ex_SetEditValueToString(item.HV_NHA);
                chkListSongVoi.Ex_SetEditValueToString(item.HV_SONG_VOI);
                txtSongVoiNguoiKhac.EditValue = item.HV_SONG_VOI_CHITIET;
                chkListChamSocBanThan.Ex_SetEditValueToString(item.HV_CHAMSOC_BANTHAN);
                txtHoTroCuaNguoiKhac.EditValue = item.HV_HOTRO_BOI_NGUOIKHAC;

                //Nhu cau viec lam
                txtCongViecDangLam.EditValue = item.HV_VIECLAM;
                seThuNhapTB.EditValue = item.HV_VIECLAM_THUNHAP;
                chkTreDiHoc.EditValue = item.HV_TRE_DIHOC??false;
                chkListNhuCau.Ex_SetEditValueToString(item.HV_NHUCAU);
                chkListThanhVienHoi.Ex_SetEditValueToString(item.HV_THANHVIEN_HOI);
            }
        }

        byte[] convertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        Image convertBinaryToImage(byte[] data)
        {
            if(data == null)
            {
                return Properties.Resources.noavatar;
            }
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        private void _setObjectEntities(ref QL_HOIVIEN item)
        {
            //Thông tin cá nhân
            item.HV_TEN = txtHoTen.Text;
            item.HV_IMAGE = convertImageToBinary(pictureAvatar.Image);
            item.HV_GIOI_TINH = lueGioiTinh.EditValue + string.Empty;
            item.HV_DAN_TOC = lueDanToc.EditValue + string.Empty;
            item.HV_NGAY_SINH = deNgaySinh.Ex_EditValueToDateTime();
            item.HV_TON_GIAO = lueTonGiao.EditValue + string.Empty;
            item.HV_NGHE_NGHIEP = lueNgheNghiep.EditValue + string.Empty;
            item.HV_TRINHDO_VANHOA = lueTrinhDoVanHoa.EditValue + string.Empty;
            item.HV_TRINHDO_CHUYENMON = lueTrinhDoChuyenMon.EditValue + string.Empty;

            item.HV_CMND = txtCMND.Text;
            item.HV_CMND_NGAY = deNgayCapCMND.Ex_EditValueToDateTime();
            item.HV_CMND_NOICAP = txtNoiCapCMND.Text;

            item.HV_KHUYETTAT_NGAY = deNgayKhuyetTat.Ex_EditValueToDateTime();
            item.HV_CHUCVU = lueChucVuHoi.EditValue + string.Empty;

            item.HV_THUONGTRU_TP = lueThuongTru_TP.EditValue + string.Empty;
            item.HV_THUONGTRU_QUAN = lueThuongTru_Quan.EditValue + string.Empty;
            item.HV_THUONGTRU_PHUONG = lueThuongTru_Phuong.EditValue + string.Empty;
            item.HV_THUONGTRU_KHUVUC = txtThuongTru_KhuVuc.Text;
            item.HV_THUONGTRU_DUONG = txtThuongTru_Duong.Text;

            item.HV_TAMTRU_TP = lueTamTru_TP.EditValue + string.Empty;
            item.HV_TAMTRU_QUAN = lueTamTru_Quan.EditValue + string.Empty;
            item.HV_TAMTRU_PHUONG = lueTamTru_Phuong.EditValue + string.Empty;
            item.HV_TAMTRU_KHUVUC = txtTamTru_KhuVuc.Text;
            item.HV_TAMTRU_DUONG = txtTamTru_Duong.Text;

            item.HV_DIENTHOAI = txtDienThoai.Text;
            item.HV_EMAIL = txtEmail.Text;
            item.HV_DIACHI_COQUAN = txtDiaChiCoQuan.Text;

            //Tab sức khỏe
            item.HV_KT_TINHTRANG = lueTinhTrangKT.EditValue + string.Empty;
            item.HV_KT_TINHTRANG_CHITIET = txtTinhTrangKTChiTiet.Text;
            item.HV_KT_KHAC = txtKhuyetTatKhac.Text;
            item.HV_KT_MUCDO = lueMucDoKT.EditValue + string.Empty;
            item.HV_PHUONGTIEN_DILAI = luePhuongTienDiLai.EditValue + string.Empty;
            item.HV_TINHTRANG_SUCKHOE = txtTinhTrangSucKhoe.Text;
            item.HV_KT_NGUYENNHAN = lueNguyenNhanKT.EditValue + string.Empty;
            item.HV_KT_NGUYENNHAN_CHITIET = txtNguyenNhanChiTiet.Text;

            item.HV_TINHTRANG_HONNHAN = lueTinhTrangHonNhan.EditValue + string.Empty;
            item.HV_VOCHONG = txtVoChong.Text;
            item.HV_SOCON = seSoCon.Ex_EditValueToInt();
            item.HV_CON1_TEN = txtCon1.Text;
            item.HV_CON1_NGAYSINH = deNgaySinhCon1.Ex_EditValueToDateTime();
            item.HV_CON1_GIOITINH = lueGioiTinhCon1.EditValue + string.Empty;
            item.HV_CON1_HOCTRUONG = txtHocTruong1.Text;

            item.HV_CON2_TEN = txtCon2.Text;
            item.HV_CON2_NGAYSINH = deNgaySinhCon2.Ex_EditValueToDateTime();
            item.HV_CON2_GIOITINH = lueGioiTinhCon2.EditValue + string.Empty;
            item.HV_CON2_HOCTRUONG = txtHocTruong2.Text;

            item.HV_PHONGTRAO_THETHAO = txtPhongTraoTheThao.Text;
            item.HV_PHONGTRAO_MONGMUON = txtPhongTraoMongMuon.Text;
            item.HV_NGUYENVONG = txtNguyenVong.Text;

            //Tab chinh sách hỗ trợ
             item.HV_DUNGCU_HOTRO = lueDungCuHoTro.EditValue + string.Empty;
            item.HV_DCHT_THOIDIEM_NHAN = deDCHT_ThoiGianNhan.Ex_EditValueToDateTime();
            item.HV_DCHT_TU_TOCHUC = txtDCHT_ToChuc.EditValue + string.Empty;
            item.HV_DCHT_TINHTRANG = txtDCHT_TinhTrang.EditValue + string.Empty;

            item.HV_BTXH_NHAN_HANGTHANG = Convert.ToBoolean(chkNhanBHXH_HangThang.EditValue);
            item.HV_BTXH_TIEN_HANGTHANG = seTienBTXHHangThang.Ex_EditValueToInt() ;
            item.HV_BTXH_KHAC = txtBTXHKhac.EditValue + string.Empty;
            item.HV_BHYT_MIENPHI = Convert.ToBoolean(chkNhanBHYTMienPhi.EditValue);

            item.HV_GIAY_CHUNGNHAN_KT = Convert.ToBoolean(chkNhanGiayCNXacDinhMucDoKT.EditValue);
            item.HV_QUYETDINH_CONGNHAN_KT = Convert.ToBoolean(chkNhanQDCongNhanMucDoKT.EditValue);
            item.HV_GIADINH_CHINHSACH = Convert.ToBoolean(chkGiaDinhDienChinhSach.EditValue);

            txtTheKT.Text = item.HV_THE_KHUYETTAT;

            //tab nơi ở chăm sóc bản thân
            item.HV_NOI_SINH_SONG = lueNoiSinhSong.EditValue + string.Empty;
            item.HV_DIEUKIEN_SONG_KHAC = txtDieuKienSongKhac.EditValue + string.Empty ;
            item.HV_NHA = chkListNha.Ex_GetEditValueToString();
            item.HV_SONG_VOI = chkListSongVoi.Ex_GetEditValueToString();
            item.HV_SONG_VOI_CHITIET = txtSongVoiNguoiKhac.EditValue + string.Empty ;
            item.HV_CHAMSOC_BANTHAN = chkListChamSocBanThan.Ex_GetEditValueToString();
            item.HV_HOTRO_BOI_NGUOIKHAC = txtHoTroCuaNguoiKhac.EditValue + string.Empty;

            //Tab Nhu cầu - công việc
            item.HV_VIECLAM = txtCongViecDangLam.EditValue + string.Empty;
            item.HV_VIECLAM_THUNHAP = seThuNhapTB.Ex_EditValueToInt();
            item.HV_TRE_DIHOC = Convert.ToBoolean(chkTreDiHoc.EditValue);
            item.HV_NHUCAU = chkListNhuCau.Ex_GetEditValueToString();
            item.HV_THANHVIEN_HOI = chkListThanhVienHoi.Ex_GetEditValueToString();
        }

        private void _loadData()
        {
            context = new QL_HOIVIEN_KTEntities();
            context.QL_HOIVIEN.Load();
            string quan = lueQuan.EditValue + string.Empty;
            string thanhpho = lueThanhPho.EditValue + string.Empty;
            var dmHoiVien = (from p in context.QL_HOIVIEN
                             where p.HV_THUONGTRU_TP == thanhpho
                             && p.HV_THUONGTRU_QUAN == quan
                             select p).ToList();
            gcGrid.DataSource = dmHoiVien;
            _loadDataFocusRow();
        }

        private void _deleteRow()
        {
            QL_HOIVIEN item = gvGrid.GetFocusedRow() as QL_HOIVIEN;
            if(item != null)
            {
                if (clsMessage.MessageYesNo(string.Format("Bạn có chắc muốn xóa: {0}", item.HV_TEN)) == DialogResult.Yes)
                {
                    Int64 HV_ID = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colHV_ID));
                    QL_HOIVIEN entities = (from p in context.QL_HOIVIEN where p.HV_ID == HV_ID select p).FirstOrDefault();
                    context.QL_HOIVIEN.Remove(entities);
                    context.SaveChanges();
                    FormStatus = EnumFormStatus.VIEW;
                }
                    
            }
            
        }

        private void _doPrintGiaNhapHoi()
        {
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                clsMessage.MessageWarning("Vui lòng chọn dòng dữ liệu.");
                return;
            }
            rptBM_DonGiaNhapHoi rpt = new rptBM_DonGiaNhapHoi();
            Int64 hv_id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colHV_ID));
            var hoivien = (from p in context.QL_HOIVIEN where p.HV_ID == hv_id select p).ToList();
            DataTable dt = FunctionHelper.ConvertToDataTable(hoivien);
            dt.TableName = "HOI_VIEN";
            frmPrint frm = new frmPrint(rpt);
            rpt.DataSource = dt;
            rpt.DataMember = "HOI_VIEN";
            frm.ShowDialog();
        }
        private void _doPrintInLyLich()
        {
            if (gvGrid.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                clsMessage.MessageWarning("Vui lòng chọn dòng dữ liệu.");
                return;
            }
            rptLyLichHoiVien rpt = new rptLyLichHoiVien();
            Int64 hv_id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colHV_ID));
            var hoivien = (from p in context.QL_HOIVIEN where p.HV_ID == hv_id select p).ToList();
            DataTable dt = FunctionHelper.ConvertToDataTable(hoivien);
            dt.TableName = "HOI_VIEN";
            frmPrint frm = new frmPrint(rpt);
            rpt.DataSource = dt;
            rpt.DataMember = "HOI_VIEN";
            frm.ShowDialog(); 
        }

        protected override bool SaveData()
        {
            if (_validateControl())
            {
                using (var _context = new QL_HOIVIEN_KTEntities())
                {
                    QL_HOIVIEN item;
                    switch (_formStatus)
                    {
                        case EnumFormStatus.ADD:
                            #region Add

                            item = new QL_HOIVIEN();
                            _setObjectEntities(ref item);
                            _context.QL_HOIVIEN.Add(item);

                            #endregion
                            break;
                        case EnumFormStatus.MODIFY:
                            Int64 HV_ID = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colHV_ID));
                            item = (from p in _context.QL_HOIVIEN where p.HV_ID == HV_ID select p).FirstOrDefault<QL_HOIVIEN>();
                            if (item != null)
                            {
                                _setObjectEntities(ref item);
                            }
                            var entity = _context.QL_HOIVIEN.Find(HV_ID);
                            _context.Entry(entity).CurrentValues.SetValues(item);
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

        #endregion

        #region LookupEdit

        private void lueThanhPho_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMHuyen(lueQuan, lueThanhPho.EditValue + string.Empty);
        }

        private void lueThuongTru_TP_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMHuyen(lueThuongTru_Quan, lueThuongTru_TP.EditValue + string.Empty);
        }

        private void lueTamTru_TP_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMHuyen(lueTamTru_Quan, lueTamTru_TP.EditValue + string.Empty);
        }

        private void lueThuongTru_Quan_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMXa(lueThuongTru_Phuong, lueThuongTru_Quan.EditValue + string.Empty);
        }

        private void lueTamTru_Quan_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMXa(lueTamTru_Phuong, lueTamTru_Quan.EditValue + string.Empty);
        }

        private void lueQuan_EditValueChanged(object sender, EventArgs e)
        {
            _loadData();
        }

        private void repLueGioiTinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                lue.EditValue = null;
            }
        }

        #endregion

        #region gvGrid

        private void gvGrid_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            _loadDataFocusRow();
        }

        #endregion


        private void deNgaySinh_EditValueChanged(object sender, EventArgs e)
        {
            DateEdit date = sender as DateEdit;
            DateTime? de = date.Ex_EditValueToDateTime();
            seTuoi.EditValue = de.HasValue ? DateTime.Now.Date.Year - de.Value.Year : new Nullable<Int64>();
        }

        private void deNgayKhuyetTat_EditValueChanged(object sender, EventArgs e)
        {
            DateEdit date = sender as DateEdit;
            DateTime? de = date.Ex_EditValueToDateTime();
            seTongThoiGianKT.EditValue = de.HasValue ? DateTime.Now.Date.Year - de.Value.Year : new Nullable<Int64>();
        }

       
        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if(f.ShowDialog() == DialogResult.OK)
            {
                pictureAvatar.Image = Image.FromFile(f.FileName);
            }
        }
    }
}
