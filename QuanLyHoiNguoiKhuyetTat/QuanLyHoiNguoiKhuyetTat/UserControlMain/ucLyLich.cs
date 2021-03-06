﻿using System;
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
using System.Threading.Tasks;
using System.Threading;

namespace DauThau.UserControlCategory
{
    public partial class ucLyLich : ucBase
    {
        public ucLyLich()
        {
            InitializeComponent();
        }

        private BindingList<QL_HOIVIEN_HOIPHI> _listHoiPhi = new BindingList<QL_HOIVIEN_HOIPHI>();
        private BindingList<QL_HOIVIEN_CON> _listCon = new BindingList<QL_HOIVIEN_CON>();
        private BindingList<QL_HOIVIEN_THANHVIENHOI> _listThanhVienHoi = new BindingList<QL_HOIVIEN_THANHVIENHOI>();

        private QL_HOIVIEN _hoiVien = new QL_HOIVIEN();
        private QL_HOIVIEN_IMAGE _hoiVienImage = new QL_HOIVIEN_IMAGE();
        private QL_HOIVIEN _hoiVien_cu = new QL_HOIVIEN();

        private Boolean _first_load_data = true;

        private void ucLyLich_Load(object sender, EventArgs e)
        {
            
            registerButtonArray(btnControl);
            //btnControl.btnReport.Image = btnControl.btnPrint.Image;
            btnControl.btnReport.Text = "Đơn gia nhập hội";
            btnControl.btnPrint.Text = "In lý lịch";

            FormStatus = EnumFormStatus.VIEW;

            //show data after 1 second
            Task.Factory.StartNew(() => Thread.Sleep(clsParameter.secondWait))
            .ContinueWith((t) =>
            {
                _initDisplay();   
            }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        #region function

        public override void tabPage_VisibleChanged(object sender, EventArgs e)
        {
            XtraTabPage tab = sender as XtraTabPage;
            if (tab.CanFocus && !_first_load_data)
            {
                _loadCategory();
            }
            
        }

        private void _loadCategory()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải danh mục ...", "Vui lòng đợi giây lát");

            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TINH, lueThanhPho);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TINH, lueThuongTru_TP);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TINH, lueTamTru_TP);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_GIOITINH, lueGioiTinh);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_DANTOC, lueDanToc);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TONGIAO, lueTonGiao);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_NGHE_NGHIEP, lueNgheNghiep);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TRINH_DO_HOC_VAN, lueTrinhDoHocVan);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TRINH_DO_CHUYEN_MON, lueTrinhDoChuyenMon);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_CHUCVU_HOI, lueChucVuHoi);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_DOITUONG, lueDoiTuong);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_NGOAINGU, lueNgoaiNgu);

            //Tab Suc khoe
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_KHUYETTAT_MUCDO, lueMucDoKT);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_KHUYETTAT_NGUYENNHAN, lueNguyenNhanKT);

            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_PHUONGTIEN_DILAI, luePhuongTienDiLai);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TINHTRANG_HONNHAN, lueTinhTrangHonNhan);

            //Tab dụng cụ hỗ trợ chế độ chính sách
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_DUNGCU_HOTRO, lueDungCuHoTro);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TCXH_HANG_THANG, lueTCXH_HangThang);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_NOI_SINH_SONG, lueNoiSinhSong);

            string strNha = chkListNha.Ex_GetEditValueToString();
            chkListNha.Ex_SetDataSource(CategoryEntitiesTable.DM_NOI_O_NHA.Ex_ToString());
            chkListNha.Ex_SetEditValueToString(strNha);

            string strSongVoi = chkListSongVoi.Ex_GetEditValueToString();
            chkListSongVoi.Ex_SetDataSource(CategoryEntitiesTable.DM_NOI_O_SONG_VOI.Ex_ToString());
            chkListSongVoi.Ex_SetEditValueToString(strSongVoi);

            string strChamSocBanThan = chkListChamSocBanThan.Ex_GetEditValueToString();
            chkListChamSocBanThan.Ex_SetDataSource(CategoryEntitiesTable.DM_CHAMSOC_BANTHAN.Ex_ToString());
            chkListChamSocBanThan.Ex_SetEditValueToString(strChamSocBanThan);

            string tinhTrangKT_Value = checkTinhTrangKT.EditValue + string.Empty;
            checkTinhTrangKT.Ex_SetDataSource(CategoryEntitiesTable.DM_KHUYETTAT_TINHTRANG.Ex_ToString());
            checkTinhTrangKT.EditValue = tinhTrangKT_Value;
            checkTinhTrangKT.RefreshEditValue();

            //string strNhuCau = chkListNhuCau.Ex_GetEditValueToString();
            //chkListNhuCau.Ex_SetDataSource(CategoryEntitiesTable.DM_NHUCAU.Ex_ToString());
            //chkListNhuCau.Ex_SetEditValueToString(strNhuCau);

            repThanhVienHoi.Ex_SetDataSource(CategoryEntitiesTable.DM_THANHVIEN_HOI.Ex_ToString());
            FuncCategory.loadCategoryForRepositoryItemLookUpEditByName(CategoryEntitiesTable.DM_GIOITINH, repCon_lueGioTinh);

            _wait.Close();
        }

        private void _initDisplay()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");

            _loadCategory();

            seTienTCXHHangThang.Ex_FormatCustomSpinEdit();
            //Tab nơi ở chăm sóc bản thân

            //Viec lam nhu cau
            seThuNhapTB.Ex_FormatCustomSpinEdit();

            repLueGioiTinh.DataSource = FuncCategory.loadDMGioiTinh();

            FunctionHelper.dateFormat(deNgaySinh_Nam, deNgaySinh_Thang, deNgaySinh_Ngay);
            FunctionHelper.dateFormat(deDCHT_ThoiGianNhan_Nam, deDCHT_ThoiGianNhan_Thang, deDCHT_ThoiGianNhan_Ngay);
            FunctionHelper.dateFormat(seVaoHoi_Nam, seVaoHoi_Thang, seVaoHoi_Ngay);
            FunctionHelper.dateFormat(seKhuyetTat_Nam, null, null);

            seTienTCXHHangThang.EditValueChanged += new System.EventHandler(this.number_EditValueChanged);
            seSoCon.EditValueChanged += new System.EventHandler(this.number_EditValueChanged);
            seThuNhapTB.EditValueChanged += new System.EventHandler(this.number_EditValueChanged);

            _first_load_data = false;
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
                    gvHoiPhi.OptionsBehavior.Editable = true;
                    gvHoiPhi.OptionsView.ShowAutoFilterRow = false;
                    gvHoiPhi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvHoiPhi.ActiveFilter.Clear();

                    gvCon.OptionsBehavior.Editable = true;
                    gvCon.OptionsView.ShowAutoFilterRow = false;
                    gvCon.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvCon.ActiveFilter.Clear();

                    gvThanhVienHoi.OptionsBehavior.Editable = true;
                    gvThanhVienHoi.OptionsView.ShowAutoFilterRow = false;
                    gvThanhVienHoi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvThanhVienHoi.ActiveFilter.Clear();

                    _clearData();
                    _initData();
                    _setDefaultValue();
                    _statusAllControl(false);
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    gvHoiPhi.OptionsBehavior.Editable = true;
                    gvHoiPhi.OptionsView.ShowAutoFilterRow = false;
                    gvHoiPhi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;

                    gvCon.OptionsBehavior.Editable = true;
                    gvCon.OptionsView.ShowAutoFilterRow = false;
                    gvCon.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvCon.ActiveFilter.Clear();

                    gvThanhVienHoi.OptionsBehavior.Editable = true;
                    gvThanhVienHoi.OptionsView.ShowAutoFilterRow = false;
                    gvThanhVienHoi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
                    gvThanhVienHoi.ActiveFilter.Clear();

                    gvHoiPhi.ActiveFilter.Clear();
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
                    gvHoiPhi.OptionsBehavior.Editable = false;
                    gvHoiPhi.OptionsView.ShowAutoFilterRow = false;
                    gvHoiPhi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

                    gvCon.OptionsBehavior.Editable = false;
                    gvCon.OptionsView.ShowAutoFilterRow = false;
                    gvCon.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

                    gvThanhVienHoi.OptionsBehavior.Editable = false;
                    gvThanhVienHoi.OptionsView.ShowAutoFilterRow = false;
                    gvThanhVienHoi.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;

                    _loadData();
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    dxErrorProvider.ClearErrors();
                    _statusAllControl(true);
                    btnControl.btnAdd.Enabled = !_first_load_data;
                    btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled 
                        = btnControl.btnPrint.Enabled = btnControl.btnReport.Enabled = gvGrid.RowCount > 0;
                    base.permissionAccessButton(btnControl, (Int32)FunctionName.FUNC_LYLICH);
                }
            }
        }

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
                        
                        if (button != null)
                        {
                            button.Enabled = !readOnly;
                            continue;
                        }

                        LookUpEdit lue = items as LookUpEdit;
                        if(lue != null)
                        {
                            lue.Properties.TextEditStyle = TextEditStyles.Standard;
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
                }
            }

            seTuoi.ReadOnly = true;
            txtCMND.Enabled = false;
            //seTongThoiGianKT.ReadOnly = true;
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
                        CheckedListBoxControl checkList = items as CheckedListBoxControl;
                        CheckedComboBoxEdit checkCombo = items as CheckedComboBoxEdit;
                        if (checkList != null)
                        {
                            checkList.Ex_SetEditValueToString("");
                        }
                        else if (checkCombo != null) {
                            checkCombo.Ex_SetEditValueToString("");
                            checkCombo.RefreshEditValue();
                        }
                        else if (item != null)
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
            _setDefaultLookupedit(lueTrinhDoHocVan);
            _setDefaultLookupedit(lueTrinhDoChuyenMon);
            _setDefaultLookupedit(lueTrinhDoHocVan);
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
            string[] ignoreItem = new string[] { "pictureAvatar", "lueTonGiao", "txtCMND", "txtThuongTru_KhuVuc"
            , "lueTamTru_TP", "lueTamTru_Quan", "lueTamTru_Phuong", "txtTamTru_Duong", "txtTamTru_KhuVuc"
            , "txtEmail", "txtCoQuan", "txtDiaChiCoQuan"

            //Thể trạng hôn nhân
            , "txtNguyenNhanChiTiet", "txtTinhTrangSucKhoe"
            , "txtVoChong" , "seSoCon"
            //Dụng cụ hỗ trợ
            , "lueDungCuHoTro", "deDCHT_ThoiGianNhan_Ngay", "deDCHT_ThoiGianNhan_Thang", "deDCHT_ThoiGianNhan_Nam"
            ,"txtDCHT_ToChuc" , "txtDCHT_TinhTrang", "txtTCXHKhac"
            , "txtPhongTraoMongMuon", "txtPhongTraoTheThao", "txtNguyenVong"
            ,  "memoGhiChu" , "txtSongVoiNguoiKhac","txtHoTroCuaNguoiKhac"

            //Nhu cầu
            , "txtNC_DaoTaoNghe_ViecLam", "txtNC_NangCaoNhanThuc", "txtNC_NangCaoNangLuc", "txtNC_HoaNhapXH", "txtNC_ASXH", "txtNC_Khac"

            //Người giám hộ
            , "txtNGH_TEN", "txtNGH_DIACHI", "txtNGH_FACE", "txtNGH_SDT"
            };

            //LayoutControl[] layouts = new LayoutControl[] { layThongTinCaNhan,layViecLam, lay};    
            foreach (XtraTabPage tabPages in tabControlMain.TabPages)
            {
                Boolean is_error = false;
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
                        CheckEdit check = items as CheckEdit;
                        CheckedListBoxControl checkList = items as CheckedListBoxControl;
                        LookUpEdit lue = items as LookUpEdit;
                        if(checkList != null)
                        {
                            continue;
                        }

                        if(item != null)
                        {
                            item.Refresh();
                        }
                        //Nếu là checkbox thì không cần kiểm tra
                        if(check != null && check.Checked == false && !ignoreItem.Contains(check.Name))
                        {
                            //dxErrorProvider.SetError(check, "Vui lòng nhập thông tin");
                            //is_error = true;
                        }else if (item != null &&  item.EditValue == null && !ignoreItem.Contains(item.Name))
                        {
                            dxErrorProvider.SetError(item, "Vui lòng nhập thông tin");
                            is_error = true;
                        }
                        
                    }
                }
                if (is_error)
                {
                    tabControlMain.SelectedTabPage = tabPages;
                    break;
                }
            }

            if (dxErrorProvider.HasErrors)
            {
                clsMessage.MessageWarning("Vui lòng nhập đầy đủ thông tin.");
            }

            return !dxErrorProvider.HasErrors;
        }

        private void _bindingDataRow()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải hiển thị hội viên...", "Vui lòng đợi giây lát");
            _clearData();
            _initData();

            QL_HOIVIEN item = gvGrid.GetFocusedRow() as QL_HOIVIEN;
            if (item != null)
            {
                _hoiVien_cu = item;

                btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = true;
                _idRowSelected = item.HV_ID;

                //Thông tin cá nhân
                txtHo.Text = item.HV_HO;
                txtTen.Text = item.HV_TEN;

                context.QL_HOIVIEN_IMAGE.Load();
                var queryImage = (from p in context.QL_HOIVIEN_IMAGE where p.HV_ID == item.HV_ID select p).FirstOrDefault();
                if(queryImage != null)
                {
                    _hoiVienImage = queryImage;
                    pictureAvatar.Image = FunctionHelper.convertBinaryToImage(queryImage.IMG_HOIVIEN);
                }
                _hoiVien = item;

                lueGioiTinh.EditValue = item.HV_GIOI_TINH;
                lueDanToc.EditValue = item.HV_DAN_TOC;

                if (item.HV_NGAY_SINH.HasValue)
                {
                    deNgaySinh_Ngay.EditValue = item.HV_NGAY_SINH.Value.Day;
                    deNgaySinh_Thang.EditValue = item.HV_NGAY_SINH.Value.Month;
                    deNgaySinh_Nam.EditValue = item.HV_NGAY_SINH.Value.Year;
                }

                lueTonGiao.EditValue = item.HV_TON_GIAO;
                lueNgheNghiep.EditValue = item.HV_NGHE_NGHIEP;
                lueTrinhDoHocVan.EditValue = item.HV_TRINHDO_HOCVAN;
                lueTrinhDoChuyenMon.EditValue = item.HV_TRINHDO_CHUYENMON;
                lueNgoaiNgu.EditValue = item.HV_NGOAINGU;

                txtCMND.Text = item.HV_CMND;
                seKhuyetTat_Nam.EditValue = item.HV_KHUYETTAT_NAM;

                if (item.HV_VAOHOI_NGAY.HasValue)
                {
                    seVaoHoi_Ngay.EditValue = item.HV_VAOHOI_NGAY.Value.Day;
                    seVaoHoi_Thang.EditValue = item.HV_VAOHOI_NGAY.Value.Month;
                    seVaoHoi_Nam.EditValue = item.HV_VAOHOI_NGAY.Value.Year;
                }

                lueChucVuHoi.EditValue = item.HV_CHUCVU;
                lueDoiTuong.EditValue = item.HV_DOITUONG;

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
                txtCoQuan.Text = item.HV_COQUAN;
                txtDiaChiCoQuan.Text = item.HV_COQUAN_DIACHI;

                //Tab sức khỏe - hôn nhân
                checkTinhTrangKT.EditValue = item.HV_KT_TINHTRANG;
                checkTinhTrangKT.RefreshEditValue();
                txtTinhTrangKTChiTiet.Text = item.HV_KT_TINHTRANG_CHITIET;

                lueMucDoKT.EditValue = item.HV_KT_MUCDO;
                luePhuongTienDiLai.EditValue = item.HV_PHUONGTIEN_DILAI;
                txtTinhTrangSucKhoe.Text = item.HV_TINHTRANG_SUCKHOE;
                lueNguyenNhanKT.EditValue = item.HV_KT_NGUYENNHAN;

                txtNguyenNhanChiTiet.Text = item.HV_KT_NGUYENNHAN_CHITIET;
                lueTinhTrangHonNhan.EditValue = item.HV_TINHTRANG_HONNHAN;
                txtVoChong.Text = item.HV_VOCHONG;
                seSoCon.EditValue = item.HV_SOCON;
               

                txtPhongTraoTheThao.Text = item.HV_PHONGTRAO_THETHAO;
                txtPhongTraoMongMuon.Text = item.HV_PHONGTRAO_MONGMUON;
                txtNguyenVong.Text = item.HV_NGUYENVONG;

                //Tab chinh sách hỗ trợ
                lueDungCuHoTro.EditValue = item.HV_DUNGCU_HOTRO;

                if (item.HV_DCHT_THOIDIEM_NHAN.HasValue)
                {
                    deDCHT_ThoiGianNhan_Ngay.EditValue = item.HV_DCHT_THOIDIEM_NHAN.Value.Day;
                    deDCHT_ThoiGianNhan_Thang.EditValue = item.HV_DCHT_THOIDIEM_NHAN.Value.Month;
                    deDCHT_ThoiGianNhan_Nam.EditValue = item.HV_DCHT_THOIDIEM_NHAN.Value.Year;
                }
                txtDCHT_ToChuc.EditValue = item.HV_DCHT_TU_TOCHUC;
                txtDCHT_TinhTrang.EditValue = item.HV_DCHT_TINHTRANG;

                lueTCXH_HangThang.EditValue = item.HV_TCXH_HANGTHANG;
                seTienTCXHHangThang.EditValue = item.HV_TCXH_TIEN_HANGTHANG;
                txtTCXHKhac.EditValue = item.HV_TCXH_KHAC;
                chkNhanBHYTMienPhi.EditValue = item.HV_BHYT_MIENPHI;

                chkNhanGiayCNXacDinhMucDoKT.EditValue = item.HV_GIAY_CHUNGNHAN_KT;
                chkNhanQDCongNhanMucDoKT.EditValue = item.HV_QUYETDINH_CONGNHAN_KT;
                chkGiaDinhDienChinhSach.EditValue = item.HV_GIADINH_CHINHSACH;

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
                chkTreDiHoc.EditValue = item.HV_TRE_DIHOC;
                //chkListNhuCau.Ex_SetEditValueToString(item.HV_NHUCAU);
                //chkListThanhVienHoi.Ex_SetEditValueToString(item.HV_THANHVIEN_HOI);

                //Hôi phí
                context.QL_HOIVIEN_HOIPHI.Load();
                var queryHoiPhi = (from p in context.QL_HOIVIEN_HOIPHI where p.HV_ID == item.HV_ID select p).ToList();
                _listHoiPhi = new BindingList<QL_HOIVIEN_HOIPHI>(queryHoiPhi);
                gcHoiPhi.DataSource = _listHoiPhi;

                context.QL_HOIVIEN_CON.Load();
                var queryCon = (from p in context.QL_HOIVIEN_CON where p.HV_ID == item.HV_ID select p).ToList();
                _listCon = new BindingList<QL_HOIVIEN_CON>(queryCon);
                gcCon.DataSource = _listCon;

                context.QL_HOIVIEN_THANHVIENHOI.Load();
                var queryThanhVienHoi = (from p in context.QL_HOIVIEN_THANHVIENHOI where p.HV_ID == item.HV_ID select p).ToList();
                _listThanhVienHoi = new BindingList<QL_HOIVIEN_THANHVIENHOI>(queryThanhVienHoi);
                gcThanhVienHoi.DataSource = _listThanhVienHoi;

                memoGhiChu.EditValue = item.HV_GHICHU;

                //Người giám hộ
                txtNGH_TEN.EditValue = item.HV_NGH_TEN;
                txtNGH_DIACHI.EditValue = item.HV_NGH_DIACHI;
                txtNGH_SDT.EditValue = item.HV_NGH_SDT;
                txtNGH_FACE.EditValue = item.HV_NGH_FACE;

                //Nhu cầu
                txtNC_DaoTaoNghe_ViecLam.EditValue = item.HV_NC_DAOTAO_NGHE_VIEC_LAM;
                txtNC_NangCaoNhanThuc.EditValue = item.HV_NC_NANGCAO_NHANTHUC;
                txtNC_NangCaoNangLuc.EditValue = item.HV_NC_NANGCAO_NANGLUC;
                txtNC_ASXH.EditValue = item.HV_NC_ASXH;
                txtNC_HoaNhapXH.EditValue = item.HV_NC_HOANHAP_XH;
                txtNC_Khac.EditValue = item.HV_NC_KHAC;

            }

            _wait.Close();
        }

        

        private string _getFullAddress(LookUpEdit lueTp, LookUpEdit lueQuan, LookUpEdit luePhuong, TextEdit txtDuong, TextEdit txtKhuVuc) {
            string address = txtKhuVuc.Text;
            
            if(txtDuong.Text != "")
            {
                address = address != "" ? address + ", " : address;
                address += txtDuong.Text;
            }

            if (luePhuong.Text != "")
            {
                address = address != "" ? address + ", " : address;
                address += luePhuong.Text;
            }

            if (lueQuan.Text != "")
            {
                address = address != "" ? address + ", " : address;
                address += lueQuan.Text;
            }

            if (lueTp.Text != "")
            {
                address = address != "" ? address + ", " : address;
                address += lueTp.Text;
            }
            return address;
        }

        private void _setObjectEntities(ref QL_HOIVIEN item)
        {
            //Thông tin cá nhân
            item.HV_HO = txtHo.Text;
            item.HV_TEN = txtTen.Text;
            item.HV_HOTEN = item.HV_HO + " " + item.HV_TEN;

            if (pictureAvatar.Image != null)
            {
                if(_hoiVienImage == null)
                {
                    _hoiVienImage = new QL_HOIVIEN_IMAGE();
                }
                _hoiVienImage.IMG_HOIVIEN = FunctionHelper.convertImageToBinary(pictureAvatar.Image);
            }

            item.HV_GIOI_TINH = lueGioiTinh.EditValue + string.Empty;
            item.HV_DAN_TOC = lueDanToc.EditValue + string.Empty;
            if(deNgaySinh_Nam.EditValue != null)
            {
                item.HV_NGAY_SINH = new DateTime(deNgaySinh_Nam.Ex_EditValueToInt() ?? 1, deNgaySinh_Thang.Ex_EditValueToInt() ?? 1, deNgaySinh_Ngay.Ex_EditValueToInt() ?? 0);
            }
            item.HV_TUOI = seTuoi.Ex_EditValueToInt();
            item.HV_TON_GIAO = lueTonGiao.EditValue + string.Empty;
            item.HV_NGHE_NGHIEP = lueNgheNghiep.EditValue + string.Empty;
            item.HV_TRINHDO_HOCVAN = lueTrinhDoHocVan.EditValue + string.Empty;
            item.HV_TRINHDO_CHUYENMON = lueTrinhDoChuyenMon.EditValue + string.Empty;
            item.HV_NGOAINGU = lueNgoaiNgu.EditValue + string.Empty;

            item.HV_CMND = txtCMND.Text;
            if(_hoiVien != null)
            {
                item.HV_CMND_NGAY = _hoiVien.HV_CMND_NGAY;
                item.HV_CMND_NOICAP = _hoiVien.HV_CMND_NOICAP;
            }

            item.HV_KHUYETTAT_NAM = seKhuyetTat_Nam.Ex_EditValueToInt();
            if (seVaoHoi_Nam.EditValue != null && seVaoHoi_Nam.Ex_EditValueToInt() > 0)
            {
                item.HV_VAOHOI_NGAY = new DateTime(seVaoHoi_Nam.Ex_EditValueToInt() ?? 1900, seVaoHoi_Thang.Ex_EditValueToInt() ?? 1, seVaoHoi_Ngay.Ex_EditValueToInt() ?? 1);
            }
            else
            {
                item.HV_VAOHOI_NGAY = new Nullable<DateTime>();
            }

            item.HV_CHUCVU = lueChucVuHoi.EditValue + string.Empty;
            item.HV_DOITUONG = lueDoiTuong.EditValue + string.Empty;

            item.HV_THUONGTRU_TP = lueThuongTru_TP.EditValue + string.Empty;
            item.HV_THUONGTRU_QUAN = lueThuongTru_Quan.EditValue + string.Empty;
            item.HV_THUONGTRU_PHUONG = lueThuongTru_Phuong.EditValue + string.Empty;
            item.HV_THUONGTRU_KHUVUC = txtThuongTru_KhuVuc.Text;
            item.HV_THUONGTRU_DUONG = txtThuongTru_Duong.Text;
            item.HV_THUONGTRU_DIACHI = _getFullAddress(lueThuongTru_TP, lueThuongTru_Quan, lueThuongTru_Phuong, txtThuongTru_Duong, txtThuongTru_KhuVuc);

            item.HV_TAMTRU_TP = lueTamTru_TP.EditValue + string.Empty;
            item.HV_TAMTRU_QUAN = lueTamTru_Quan.EditValue + string.Empty;
            item.HV_TAMTRU_PHUONG = lueTamTru_Phuong.EditValue + string.Empty;
            item.HV_TAMTRU_KHUVUC = txtTamTru_KhuVuc.Text;
            item.HV_TAMTRU_DUONG = txtTamTru_Duong.Text;
            item.HV_TAMTRU_DIACHI = _getFullAddress(lueTamTru_TP, lueTamTru_Quan, lueTamTru_Phuong, txtTamTru_Duong, txtTamTru_KhuVuc);

            item.HV_DIENTHOAI = txtDienThoai.Text;
            item.HV_EMAIL = txtEmail.Text;
            item.HV_COQUAN = txtCoQuan.Text;
            item.HV_COQUAN_DIACHI = txtDiaChiCoQuan.Text;

            //Tab sức khỏe
            item.HV_KT_TINHTRANG = checkTinhTrangKT.EditValue + string.Empty ;
            item.HV_KT_TINHTRANG_CHITIET = txtTinhTrangKTChiTiet.Text;

            item.HV_KT_MUCDO = lueMucDoKT.EditValue + string.Empty;
            item.HV_PHUONGTIEN_DILAI = luePhuongTienDiLai.EditValue + string.Empty;
            item.HV_TINHTRANG_SUCKHOE = txtTinhTrangSucKhoe.Text;
            item.HV_KT_NGUYENNHAN = lueNguyenNhanKT.EditValue + string.Empty;
            item.HV_KT_NGUYENNHAN_CHITIET = txtNguyenNhanChiTiet.Text;

            item.HV_TINHTRANG_HONNHAN = lueTinhTrangHonNhan.EditValue + string.Empty;
            item.HV_VOCHONG = txtVoChong.Text;
            item.HV_SOCON = seSoCon.Ex_EditValueToInt();

            item.HV_PHONGTRAO_THETHAO = txtPhongTraoTheThao.Text;
            item.HV_PHONGTRAO_MONGMUON = txtPhongTraoMongMuon.Text;
            item.HV_NGUYENVONG = txtNguyenVong.Text;

            //Tab chinh sách hỗ trợ
            item.HV_DUNGCU_HOTRO = lueDungCuHoTro.EditValue + string.Empty;
            if (deDCHT_ThoiGianNhan_Nam.EditValue != null && deDCHT_ThoiGianNhan_Nam.Ex_EditValueToInt() > 0)
            {
                item.HV_DCHT_THOIDIEM_NHAN = new DateTime(deDCHT_ThoiGianNhan_Nam.Ex_EditValueToInt() ?? 1900, deDCHT_ThoiGianNhan_Thang.Ex_EditValueToInt() ?? 1, deDCHT_ThoiGianNhan_Ngay.Ex_EditValueToInt() ?? 1);
            }
            else
            {
                item.HV_DCHT_THOIDIEM_NHAN = new Nullable<DateTime>();
            }

            item.HV_DCHT_TU_TOCHUC = txtDCHT_ToChuc.EditValue + string.Empty;
            item.HV_DCHT_TINHTRANG = txtDCHT_TinhTrang.EditValue + string.Empty;

            item.HV_TCXH_HANGTHANG = lueTCXH_HangThang.Text;
            item.HV_TCXH_TIEN_HANGTHANG = seTienTCXHHangThang.Ex_EditValueToInt() ;
            item.HV_TCXH_KHAC = txtTCXHKhac.EditValue + string.Empty;
            item.HV_BHYT_MIENPHI = Convert.ToBoolean(chkNhanBHYTMienPhi.EditValue);

            item.HV_GIAY_CHUNGNHAN_KT = Convert.ToBoolean(chkNhanGiayCNXacDinhMucDoKT.EditValue);
            item.HV_QUYETDINH_CONGNHAN_KT = Convert.ToBoolean(chkNhanQDCongNhanMucDoKT.EditValue);
            item.HV_GIADINH_CHINHSACH = Convert.ToBoolean(chkGiaDinhDienChinhSach.EditValue);

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
            //item.HV_NHUCAU = chkListNhuCau.Ex_GetEditValueToString();
            //item.HV_THANHVIEN_HOI = chkListThanhVienHoi.Ex_GetEditValueToString();

            //Hội phí
            item.HV_GHICHU = memoGhiChu.Text;

            //Người giám hộ
            item.HV_NGH_TEN = txtNGH_TEN.EditValue + string.Empty;
            item.HV_NGH_SDT = txtNGH_SDT.EditValue + string.Empty;
            item.HV_NGH_DIACHI = txtNGH_DIACHI.EditValue + string.Empty;
            item.HV_NGH_FACE = txtNGH_FACE.EditValue + string.Empty;

            //Nhu cầu
            item.HV_NC_DAOTAO_NGHE_VIEC_LAM = txtNC_DaoTaoNghe_ViecLam.EditValue + string.Empty;
            item.HV_NC_NANGCAO_NHANTHUC = txtNC_NangCaoNhanThuc.EditValue + string.Empty;
            item.HV_NC_NANGCAO_NANGLUC = txtNC_NangCaoNangLuc.EditValue + string.Empty;
            item.HV_NC_ASXH = txtNC_ASXH.EditValue + string.Empty;
            item.HV_NC_HOANHAP_XH = txtNC_HoaNhapXH.EditValue + string.Empty;
            item.HV_NC_KHAC = txtNC_Khac.EditValue + string.Empty;

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

            _setFocusedRow(gvGrid, colHV_ID);
            _bindingDataRow();
        }

        private void _deleteRow()
        {
            QL_HOIVIEN item = gvGrid.GetFocusedRow() as QL_HOIVIEN;
            if(item != null)
            {
                if (clsMessage.MessageYesNo(string.Format("Bạn có chắc muốn xóa: {0}", item.HV_TEN)) == DialogResult.Yes)
                {
                    Int64 HV_ID = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colHV_ID));
                    var listHoiPhiDelete = (from p in context.QL_HOIVIEN_HOIPHI where p.HV_ID == HV_ID select p);
                    foreach (var item_delete in listHoiPhiDelete)
                    {
                        context.QL_HOIVIEN_HOIPHI.Remove(item_delete);
                    }

                    var listConDelete = (from p in context.QL_HOIVIEN_CON where p.HV_ID == HV_ID select p);
                    foreach (var item_delete in listConDelete)
                    {
                        context.QL_HOIVIEN_CON.Remove(item_delete);
                    }

                    var listImgDelete = (from p in context.QL_HOIVIEN_IMAGE where p.HV_ID == HV_ID select p);
                    foreach (var item_delete in listImgDelete)
                    {
                        context.QL_HOIVIEN_IMAGE.Remove(item_delete);
                    }

                    var listTVHDelete = (from p in context.QL_HOIVIEN_THANHVIENHOI where p.HV_ID == HV_ID select p);
                    foreach (var item_delete in listTVHDelete)
                    {
                        context.QL_HOIVIEN_THANHVIENHOI.Remove(item_delete);

                    }

                    QL_HOIVIEN entities = (from p in context.QL_HOIVIEN where p.HV_ID == HV_ID select p).FirstOrDefault();
                    context.QL_HOIVIEN.Remove(entities);
                    _writeLog(context, item, EnumFormStatus.DELETE);

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

            rpt.pLeftHeader.Value = clsParameter.pHospital;
            rpt.pParentLeftHeader.Value = clsParameter.pParentHospital;

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
            dt.Columns.Add("HV_CON1_TEN", typeof(String));
            dt.Columns.Add("HV_CON1_GIOITINH", typeof(String));
            dt.Columns.Add("HV_CON1_NGAYSINH", typeof(DateTime));
            dt.Columns.Add("HV_CON2_TEN", typeof(String));
            dt.Columns.Add("HV_CON2_GIOITINH", typeof(String));
            dt.Columns.Add("HV_CON2_NGAYSINH", typeof(DateTime));
            foreach (var item in hoivien)
            {
                var hoivien_con = item.QL_HOIVIEN_CON.ToList();
                int soCon = 1;
                foreach (var con in hoivien_con)
                {
                    if(soCon == 1)
                    {
                        dt.Rows[0]["HV_CON1_TEN"] = con.CON_TEN;
                        dt.Rows[0]["HV_CON1_GIOITINH"] = con.CON_GIOITINH;
                        dt.Rows[0]["HV_CON1_NGAYSINH"] = con.CON_NGAYSINH;
                    }else
                    {
                        dt.Rows[0]["HV_CON2_TEN"] = con.CON_TEN;
                        dt.Rows[0]["HV_CON2_GIOITINH"] = con.CON_GIOITINH;
                        dt.Rows[0]["HV_CON2_NGAYSINH"] = con.CON_NGAYSINH;
                        break;
                    }
                    soCon++;
                }
            }
            
            dt.TableName = "HOI_VIEN";
            frmPrint frm = new frmPrint(rpt);
            rpt.DataSource = dt;
            rpt.DataMember = "HOI_VIEN";
            frm.ShowDialog(); 
        }

        private void _initData()
        {
            _listHoiPhi = new BindingList<QL_HOIVIEN_HOIPHI>();
            _listCon = new BindingList<QL_HOIVIEN_CON>();
            _listThanhVienHoi = new BindingList<QL_HOIVIEN_THANHVIENHOI>();
            _hoiVien = new QL_HOIVIEN();
            _hoiVienImage = new QL_HOIVIEN_IMAGE();
            gcHoiPhi.DataSource = _listHoiPhi;
            gcCon.DataSource = _listCon;
            gcThanhVienHoi.DataSource = _listThanhVienHoi;
        }

        private void _updateHoiPhi(QL_HOIVIEN_KTEntities _context, QL_HOIVIEN item)
        {
            if (_listHoiPhi == null)
            {
                return;
            }

            foreach (var hp in _listHoiPhi)
            {
                if (hp.HV_ID == null) //add
                {
                    hp.QL_HOIVIEN = item;
                    _context.QL_HOIVIEN_HOIPHI.Add(hp);
                }
                else if (hp.HV_ID == clsParameter.statusDeleted) //delete
                {
                    var hp_delete = (from p in _context.QL_HOIVIEN_HOIPHI
                                    where p.HP_ID == hp.HP_ID
                                    select p).FirstOrDefault();
                    if (hp_delete != null)
                    {
                        _context.QL_HOIVIEN_HOIPHI.Remove(hp_delete);
                    }
                }
                else //modify
                {
                    var hp_modify = _context.QL_HOIVIEN_HOIPHI.Where(p => p.HP_ID == hp.HP_ID).FirstOrDefault();
                    if (hp_modify != null)
                    {
                        _context.Entry(hp_modify).CurrentValues.SetValues(hp);
                    }
                }
            }
        }

        private void _updateThanhVienHoi(QL_HOIVIEN_KTEntities _context, QL_HOIVIEN item)
        {
            if (_listThanhVienHoi == null)
            {
                return;
            }

            foreach (var child in _listThanhVienHoi)
            {
                if (child.HV_ID == null) //add
                {
                    child.QL_HOIVIEN = item;
                    _context.QL_HOIVIEN_THANHVIENHOI.Add(child);
                }
                else if (child.HV_ID == clsParameter.statusDeleted) //delete
                {
                    var item_delete = (from p in _context.QL_HOIVIEN_THANHVIENHOI
                                       where p.TV_ID == child.TV_ID
                                       select p).FirstOrDefault();
                    if (item_delete != null)
                    {
                        _context.QL_HOIVIEN_THANHVIENHOI.Remove(item_delete);
                    }
                }
                else //modify
                {
                    var item_modify = _context.QL_HOIVIEN_THANHVIENHOI.Where(p => p.TV_ID == child.TV_ID).FirstOrDefault();
                    if (item_modify != null)
                    {
                        _context.Entry(item_modify).CurrentValues.SetValues(child);
                    }
                }
            }
        }

        private void _updateCon(QL_HOIVIEN_KTEntities _context, QL_HOIVIEN item)
        {
            if (_listCon == null)
            {
                return;
            }

            foreach (var child in _listCon)
            {
                if (child.HV_ID == null) //add
                {
                    child.QL_HOIVIEN = item;
                    _context.QL_HOIVIEN_CON.Add(child);
                }
                else if (child.HV_ID == clsParameter.statusDeleted) //delete
                {
                    var item_delete = (from p in _context.QL_HOIVIEN_CON
                                     where p.CON_ID == child.CON_ID
                                     select p).FirstOrDefault();
                    if (item_delete != null)
                    {
                        _context.QL_HOIVIEN_CON.Remove(item_delete);
                    }
                }
                else //modify
                {
                    var item_modify = _context.QL_HOIVIEN_CON.Where(p => p.CON_ID == child.CON_ID).FirstOrDefault();
                    if (item_modify != null)
                    {
                        _context.Entry(item_modify).CurrentValues.SetValues(child);
                    }
                }
            }
        }

        private void _updateImage(QL_HOIVIEN_KTEntities _context, QL_HOIVIEN item)
        {
            if(_hoiVienImage == null)
            {
                return;
            }

            if (_hoiVienImage.HV_ID == null) //add
            {
                _hoiVienImage.QL_HOIVIEN = item;
                _context.QL_HOIVIEN_IMAGE.Add(_hoiVienImage);
            }
            else if (_hoiVienImage.HV_ID == clsParameter.statusDeleted) //delete
            {
                var item_delete = (from p in _context.QL_HOIVIEN_IMAGE
                                   where p.IMG_ID == _hoiVienImage.IMG_ID
                                   select p).FirstOrDefault();
                if (item_delete != null)
                {
                    _context.QL_HOIVIEN_IMAGE.Remove(item_delete);
                }
            }
            else //modify
            {
                var item_modify = _context.QL_HOIVIEN_IMAGE.Where(p => p.IMG_ID == _hoiVienImage.IMG_ID).FirstOrDefault();
                if (item_modify != null)
                {
                    _context.Entry(item_modify).CurrentValues.SetValues(_hoiVienImage);
                }
            }
        }

        private void _compareLog(ref QL_NHATKY nhatKy, QL_HOIVIEN item)
        {
            string title = "Họ và tên: ";
            string giatri_cu = title + _hoiVien_cu.HV_HO + " " + _hoiVien_cu.HV_TEN + Environment.NewLine;
            string giatri_moi = title + item.HV_HOTEN + Environment.NewLine;

            if (_hoiVien_cu.HV_GIOI_TINH != item.HV_GIOI_TINH)
            {
                title = "Giới tính: ";
                giatri_cu += title + _hoiVien_cu.HV_GIOI_TINH + Environment.NewLine;
                giatri_moi += title + item.HV_GIOI_TINH + Environment.NewLine;
            }

            if (_hoiVien_cu.HV_DAN_TOC != item.HV_DAN_TOC)
            {
                title = "Dân tộc: ";
                giatri_cu += title + _hoiVien_cu.HV_DAN_TOC + Environment.NewLine;
                giatri_moi += title + item.HV_DAN_TOC + Environment.NewLine;
            }

            if (_hoiVien_cu.HV_NGAY_SINH != item.HV_NGAY_SINH)
            {
                title = "Ngày sinh: ";
                giatri_cu += title + (_hoiVien_cu.HV_NGAY_SINH.HasValue ? _hoiVien_cu.HV_NGAY_SINH.Value.ToString("dd/MM/yyyy") : "") + Environment.NewLine;
                giatri_moi += title + (item.HV_NGAY_SINH.HasValue ? item.HV_NGAY_SINH.Value.ToString("dd/MM/yyyy") : "") + Environment.NewLine;
            }

            if (_hoiVien_cu.HV_TON_GIAO != item.HV_TON_GIAO)
            {
                title = "Tôn giáo: ";
                giatri_cu += title + _hoiVien_cu.HV_TON_GIAO + Environment.NewLine;
                giatri_moi += title + item.HV_TON_GIAO + Environment.NewLine;
            }

            if (_hoiVien_cu.HV_TRINHDO_HOCVAN != item.HV_TRINHDO_HOCVAN)
            {
                title = "Trình độ học vấn: ";
                giatri_cu += title + _hoiVien_cu.HV_TRINHDO_HOCVAN + Environment.NewLine;
                giatri_moi += title + item.HV_TRINHDO_HOCVAN + Environment.NewLine;
            }

            if (_hoiVien_cu.HV_TRINHDO_CHUYENMON != item.HV_TRINHDO_CHUYENMON)
            {
                title = "Trình độ C.môn: ";
                giatri_cu += title + _hoiVien_cu.HV_TRINHDO_CHUYENMON + Environment.NewLine;
                giatri_moi += title + item.HV_TRINHDO_CHUYENMON + Environment.NewLine;
            }

            if (_hoiVien_cu.HV_NGOAINGU != item.HV_NGOAINGU)
            {
                title = "Ngoại ngữ: ";
                giatri_cu += title + _hoiVien_cu.HV_NGOAINGU + Environment.NewLine;
                giatri_moi += title + item.HV_NGOAINGU + Environment.NewLine;
            }

            if (_hoiVien_cu.HV_NGHE_NGHIEP != item.HV_NGHE_NGHIEP)
            {
                title = "Nghề nghiệp: ";
                giatri_cu += title + _hoiVien_cu.HV_NGHE_NGHIEP + Environment.NewLine;
                giatri_moi += title + item.HV_NGHE_NGHIEP + Environment.NewLine;
            }

            if (_hoiVien_cu.HV_CMND != item.HV_CMND)
            {
                title = "CMND: ";
                giatri_cu += title + _hoiVien_cu.HV_CMND + Environment.NewLine;
                giatri_moi += title + item.HV_CMND + Environment.NewLine;
            }

            if (_hoiVien_cu.HV_CHUCVU != item.HV_CHUCVU)
            {
                title = "Chức vụ trong hội: ";
                giatri_cu += title + _hoiVien_cu.HV_CHUCVU + Environment.NewLine;
                giatri_moi += title + item.HV_CHUCVU + Environment.NewLine;
            }

            if (_hoiVien_cu.HV_KHUYETTAT_NAM != item.HV_KHUYETTAT_NAM)
            {
                title = "Khuyết tật năm: ";
                giatri_cu += title + _hoiVien_cu.HV_KHUYETTAT_NAM + Environment.NewLine;
                giatri_moi += title + item.HV_KHUYETTAT_NAM + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_VAOHOI_NGAY != item.HV_VAOHOI_NGAY)
            {
                title = "Ngày vào hội: ";
                giatri_cu += title + _hoiVien_cu.HV_VAOHOI_NGAY + Environment.NewLine;
                giatri_moi += title + item.HV_VAOHOI_NGAY + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_THUONGTRU_DIACHI != item.HV_THUONGTRU_DIACHI)
            {
                title = "Địa chỉ thường trú: ";
                giatri_cu += title + _hoiVien_cu.HV_THUONGTRU_DIACHI + Environment.NewLine;
                giatri_moi += title + item.HV_THUONGTRU_DIACHI + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_TAMTRU_DIACHI != item.HV_TAMTRU_DIACHI)
            {
                title = "Tạm trú địa chỉ: ";
                giatri_cu += title + _hoiVien_cu.HV_TAMTRU_DIACHI + Environment.NewLine;
                giatri_moi += title + item.HV_TAMTRU_DIACHI + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_DIENTHOAI != item.HV_DIENTHOAI)
            {
                title = "Điện thoại: ";
                giatri_cu += title + _hoiVien_cu.HV_DIENTHOAI + Environment.NewLine;
                giatri_moi += title + item.HV_DIENTHOAI + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_EMAIL != item.HV_EMAIL)
            {
                title = "Email/Facebook: ";
                giatri_cu += title + _hoiVien_cu.HV_EMAIL + Environment.NewLine;
                giatri_moi += title + item.HV_EMAIL + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_KT_TINHTRANG != item.HV_KT_TINHTRANG)
            {
                title = "Dạng tật: ";
                giatri_cu += title + _hoiVien_cu.HV_KT_TINHTRANG + Environment.NewLine;
                giatri_moi += title + item.HV_KT_TINHTRANG + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_KT_MUCDO != item.HV_KT_MUCDO)
            {
                title = "Khuyết tật mức độ: ";
                giatri_cu += title + _hoiVien_cu.HV_KT_MUCDO + Environment.NewLine;
                giatri_moi += title + item.HV_KT_MUCDO + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_KT_TINHTRANG_CHITIET != item.HV_KT_TINHTRANG_CHITIET)
            {
                title = "Ghi rõ tình trạng: ";
                giatri_cu += title + _hoiVien_cu.HV_KT_TINHTRANG_CHITIET + Environment.NewLine;
                giatri_moi += title + item.HV_KT_TINHTRANG_CHITIET + Environment.NewLine;
            }

            if (_hoiVien_cu.HV_PHUONGTIEN_DILAI != item.HV_PHUONGTIEN_DILAI)
            {
                title = "Phương tiện đi lại: ";
                giatri_cu += title + _hoiVien_cu.HV_PHUONGTIEN_DILAI + Environment.NewLine;
                giatri_moi += title + item.HV_PHUONGTIEN_DILAI + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_TINHTRANG_SUCKHOE != item.HV_TINHTRANG_SUCKHOE)
            {
                title = "Tình trạng sức khỏe: ";
                giatri_cu += title + _hoiVien_cu.HV_TINHTRANG_SUCKHOE + Environment.NewLine;
                giatri_moi += title + item.HV_TINHTRANG_SUCKHOE + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_KT_NGUYENNHAN != item.HV_KT_NGUYENNHAN)
            {
                title = "Khuyết tật do: ";
                giatri_cu += title + _hoiVien_cu.HV_KT_NGUYENNHAN + Environment.NewLine;
                giatri_moi += title + item.HV_KT_NGUYENNHAN + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_KT_NGUYENNHAN_CHITIET != item.HV_KT_NGUYENNHAN_CHITIET)
            {
                title = "Mô tả chi tiết do: ";
                giatri_cu += title + _hoiVien_cu.HV_KT_NGUYENNHAN_CHITIET + Environment.NewLine;
                giatri_moi += title + item.HV_KT_NGUYENNHAN_CHITIET + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_TINHTRANG_HONNHAN != item.HV_TINHTRANG_HONNHAN)
            {
                title = "Tình trạng hôn nhân: ";
                giatri_cu += title + _hoiVien_cu.HV_TINHTRANG_HONNHAN + Environment.NewLine;
                giatri_moi += title + item.HV_TINHTRANG_HONNHAN + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_VOCHONG != item.HV_VOCHONG)
            {
                title = "Tên vợ/chồng: ";
                giatri_cu += title + _hoiVien_cu.HV_VOCHONG + Environment.NewLine;
                giatri_moi += title + item.HV_VOCHONG + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_SOCON != item.HV_SOCON)
            {
                title = "Số con: ";
                giatri_cu += title + _hoiVien_cu.HV_SOCON + Environment.NewLine;
                giatri_moi += title + item.HV_SOCON + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_DUNGCU_HOTRO != item.HV_DUNGCU_HOTRO)
            {
                title = "Dụng cụ hỗ trợ: ";
                giatri_cu += title + _hoiVien_cu.HV_DUNGCU_HOTRO + Environment.NewLine;
                giatri_moi += title + item.HV_DUNGCU_HOTRO + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_DCHT_THOIDIEM_NHAN != item.HV_DCHT_THOIDIEM_NHAN)
            {
                title = "Dụng cụ hỗ trợ thời điểm nhận: ";
                giatri_cu += title + (_hoiVien_cu.HV_DCHT_THOIDIEM_NHAN.HasValue ? _hoiVien_cu.HV_DCHT_THOIDIEM_NHAN.Value.ToString("dd/MM/yyyy") : "") + Environment.NewLine;
                giatri_moi += title + (item.HV_DCHT_THOIDIEM_NHAN.HasValue ? item.HV_DCHT_THOIDIEM_NHAN.Value.ToString("dd/MM/yyyy") : "") + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_DCHT_TU_TOCHUC != item.HV_DCHT_TU_TOCHUC)
            {
                title = "Dụng cụ hỗ trợ từ tổ chức: ";
                giatri_cu += title + _hoiVien_cu.HV_DCHT_TU_TOCHUC + Environment.NewLine;
                giatri_moi += title + item.HV_DCHT_TU_TOCHUC + Environment.NewLine;
            }

            if (_hoiVien_cu.HV_DCHT_TINHTRANG != item.HV_DCHT_TINHTRANG)
            {
                title = "Dụng cụ hỗ trợ tình trạng hiện tại: ";
                giatri_cu += title + _hoiVien_cu.HV_DCHT_TINHTRANG + Environment.NewLine;
                giatri_moi += title + item.HV_DCHT_TINHTRANG + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_TCXH_HANGTHANG != item.HV_TCXH_HANGTHANG)
            {
                title = "Nhận TCXH: ";
                giatri_cu += title + _hoiVien_cu.HV_TCXH_HANGTHANG + Environment.NewLine;
                giatri_moi += title + item.HV_TCXH_HANGTHANG + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_TCXH_TIEN_HANGTHANG != item.HV_TCXH_TIEN_HANGTHANG)
            {
                title = "Số tiền TCXH: ";
                giatri_cu += title + _hoiVien_cu.HV_TCXH_TIEN_HANGTHANG + Environment.NewLine;
                giatri_moi += title + item.HV_TCXH_TIEN_HANGTHANG + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_TCXH_KHAC != item.HV_TCXH_KHAC)
            {
                title = "TCXH khác: ";
                giatri_cu += title + _hoiVien_cu.HV_TCXH_KHAC + Environment.NewLine;
                giatri_moi += title + item.HV_TCXH_KHAC + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_BHYT_MIENPHI != item.HV_BHYT_MIENPHI)
            {
                title = "Nhận BHYT miễn phí: ";
                giatri_cu += title + _hoiVien_cu.HV_BHYT_MIENPHI + Environment.NewLine;
                giatri_moi += title + item.HV_BHYT_MIENPHI + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_QUYETDINH_CONGNHAN_KT != item.HV_QUYETDINH_CONGNHAN_KT)
            {
                title = "Quyết định công nhận mức độ KT: ";
                giatri_cu += title + _hoiVien_cu.HV_QUYETDINH_CONGNHAN_KT + Environment.NewLine;
                giatri_moi += title + item.HV_QUYETDINH_CONGNHAN_KT + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_GIAY_CHUNGNHAN_KT != item.HV_GIAY_CHUNGNHAN_KT)
            {
                title = "Nhận giấy chứng nhận: ";
                giatri_cu += title + _hoiVien_cu.HV_GIAY_CHUNGNHAN_KT + Environment.NewLine;
                giatri_moi += title + item.HV_GIAY_CHUNGNHAN_KT + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_GIADINH_CHINHSACH != item.HV_GIADINH_CHINHSACH)
            {
                title = "Gia đình thuộc diện chính sách: ";
                giatri_cu += title + _hoiVien_cu.HV_GIADINH_CHINHSACH + Environment.NewLine;
                giatri_moi += title + item.HV_GIADINH_CHINHSACH + Environment.NewLine;
            }

            if (_hoiVien_cu.HV_NOI_SINH_SONG != item.HV_NOI_SINH_SONG)
            {
                title = "Nơi sinh sống: ";
                giatri_cu += title + _hoiVien_cu.HV_NOI_SINH_SONG + Environment.NewLine;
                giatri_moi += title + item.HV_NOI_SINH_SONG + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_DIEUKIEN_SONG_KHAC != item.HV_DIEUKIEN_SONG_KHAC)
            {
                title = "Điều kiện sống xung quanh: ";
                giatri_cu += title + _hoiVien_cu.HV_DIEUKIEN_SONG_KHAC + Environment.NewLine;
                giatri_moi += title + item.HV_DIEUKIEN_SONG_KHAC + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_NHA != item.HV_NHA)
            {
                title = "Nhà: ";
                giatri_cu += title + _hoiVien_cu.HV_NHA + Environment.NewLine;
                giatri_moi += title + item.HV_NHA + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_SONG_VOI != item.HV_SONG_VOI)
            {
                title = "NKT sống với: ";
                giatri_cu += title + _hoiVien_cu.HV_SONG_VOI + Environment.NewLine;
                giatri_moi += title + item.HV_SONG_VOI + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_SONG_VOI_CHITIET != item.HV_SONG_VOI_CHITIET)
            {
                title = "NKT sống với (ghi chú): ";
                giatri_cu += title + _hoiVien_cu.HV_SONG_VOI_CHITIET + Environment.NewLine;
                giatri_moi += title + item.HV_SONG_VOI_CHITIET + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_CHAMSOC_BANTHAN != item.HV_CHAMSOC_BANTHAN)
            {
                title = "Chăm sóc bản thân: ";
                giatri_cu += title + _hoiVien_cu.HV_CHAMSOC_BANTHAN + Environment.NewLine;
                giatri_moi += title + item.HV_CHAMSOC_BANTHAN + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_HOTRO_BOI_NGUOIKHAC != item.HV_HOTRO_BOI_NGUOIKHAC)
            {
                title = "Chăm sóc bản thân(Ghi chú): ";
                giatri_cu += title + _hoiVien_cu.HV_HOTRO_BOI_NGUOIKHAC + Environment.NewLine;
                giatri_moi += title + item.HV_HOTRO_BOI_NGUOIKHAC + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_VIECLAM != item.HV_VIECLAM)
            {
                title = "Công việc đang làm: ";
                giatri_cu += title + _hoiVien_cu.HV_VIECLAM + Environment.NewLine;
                giatri_moi += title + item.HV_VIECLAM + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_VIECLAM_THUNHAP != item.HV_VIECLAM_THUNHAP)
            {
                title = "Thu nhập từ việc làm: ";
                giatri_cu += title + _hoiVien_cu.HV_VIECLAM_THUNHAP + Environment.NewLine;
                giatri_moi += title + item.HV_VIECLAM_THUNHAP + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_PHONGTRAO_THETHAO != item.HV_PHONGTRAO_THETHAO)
            {
                title = "Thể thao: ";
                giatri_cu += title + _hoiVien_cu.HV_PHONGTRAO_THETHAO + Environment.NewLine;
                giatri_moi += title + item.HV_PHONGTRAO_THETHAO + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_PHONGTRAO_MONGMUON != item.HV_PHONGTRAO_MONGMUON)
            {
                title = "Phong trào thể thao: ";
                giatri_cu += title + _hoiVien_cu.HV_PHONGTRAO_MONGMUON + Environment.NewLine;
                giatri_moi += title + item.HV_PHONGTRAO_MONGMUON + Environment.NewLine;
            }
            if (_hoiVien_cu.HV_NGUYENVONG != item.HV_NGUYENVONG)
            {
                title = "Nguyện vọng: ";
                giatri_cu += title + _hoiVien_cu.HV_NGUYENVONG + Environment.NewLine;
                giatri_moi += title + item.HV_NGUYENVONG + Environment.NewLine;
            }
            nhatKy.NK_GIATRI_MOI = giatri_moi;
            nhatKy.NK_GIATRI_CU = giatri_cu;
            nhatKy.NK_THAOTAC = "Sửa";
        }

        private void _writeLog(QL_HOIVIEN_KTEntities _context, QL_HOIVIEN item, EnumFormStatus actionStatus)
        {
            QL_NHATKY nhatKy = new QL_NHATKY();
            switch (actionStatus)
            {
                case EnumFormStatus.ADD:
                    string giatri_moi = "Họ tên: " + item.HV_HOTEN + Environment.NewLine;
                    giatri_moi += "Địa chỉ thường trú: " + item.HV_THUONGTRU_DIACHI;
                    nhatKy.NK_GIATRI_MOI = giatri_moi;
                    nhatKy.NK_THAOTAC = "Thêm";
                    break;
                case EnumFormStatus.MODIFY:
                    _compareLog(ref nhatKy, item);
                    break;
                case EnumFormStatus.DELETE:
                    string giatri_cu = "Họ tên: " + item.HV_HO + " " + item.HV_TEN + Environment.NewLine;
                    giatri_cu += "Địa chỉ thường trú: " + item.HV_THUONGTRU_DIACHI;
                    nhatKy.NK_GIATRI_CU = giatri_cu;
                    nhatKy.NK_THAOTAC = "Xóa";
                    break;
                default:
                    break;
            }

            nhatKy.NK_BANG = "Hội viên";
            nhatKy.NK_NGAY = DateTime.Now;
            nhatKy.NK_USERNAME = clsParameter._username;
            _context.QL_NHATKY.Add(nhatKy);
        }

        protected override bool SaveData()
        {
            if (_validateControl())
            {
                WaitDialogForm _wait = new WaitDialogForm("Đang lưu dữ liệu ...", "Vui lòng đợi giây lát");
                using (var _context = new QL_HOIVIEN_KTEntities())
                {
                    if(txtCMND.Text != "")
                    {
                        var hoivien = _context.QL_HOIVIEN.Where(p => p.HV_CMND == txtCMND.Text && p.HV_ID != _idRowSelected).FirstOrDefault();
                        if (hoivien != null)
                        {
                            _wait.Close();
                            clsMessage.MessageExclamation("CMND đã bị trùng nhau. Vui lòng kiểm tra lại.");
                            return false;
                        }
                    }
                    
                    QL_HOIVIEN item = new QL_HOIVIEN();
                    switch (_formStatus)
                    {
                        case EnumFormStatus.ADD:

                            item = new QL_HOIVIEN();
                            _setObjectEntities(ref item);
                            _context.QL_HOIVIEN.Add(item);
                            _updateHoiPhi(_context, item);
                            _updateCon(_context, item);
                            _updateImage(_context, item);
                            _updateThanhVienHoi(_context, item);
                            _writeLog(_context, item, _formStatus);

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
                            _updateHoiPhi(_context, item);
                            _updateCon(_context, item);
                            _updateImage(_context, item);
                            _updateThanhVienHoi(_context, item);
                            _writeLog(_context, item, _formStatus);

                            break;
                        default:
                            break;
                    }
                    _context.SaveChanges();
                    _idRowSelected = item.HV_ID;

                   
                }
                FormStatus = EnumFormStatus.VIEW;
                _wait.Close();
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
            if (_first_load_data)
            {
                return;
            }

            FormStatus = EnumFormStatus.VIEW;
        }

        private void repLueGioiTinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                lue.EditValue = null;
            }
        }


        private void btnCMND_Click(object sender, EventArgs e)
        {
            frmLyLich_CMND frm = new frmLyLich_CMND(_hoiVien, _hoiVienImage);
            frm.ShowDialog();
            _hoiVien = frm.hoivien;
            _hoiVienImage = frm.hoivien_image;
            if (_hoiVien != null)
            {
                txtCMND.Text = _hoiVien.HV_CMND;
            }

        }

        #endregion

        #region gvGrid

        private void gvGrid_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            _idRowSelected = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colHV_ID));
            _bindingDataRow();
        }

        #endregion

        #region event Button

        
        private void deNgayKhuyetTat_EditValueChanged(object sender, EventArgs e)
        {
            DateEdit date = sender as DateEdit;
            DateTime? de = date.Ex_EditValueToDateTime();
            //seTongThoiGianKT.EditValue = de.HasValue ? DateTime.Now.Date.Year - de.Value.Year : new Nullable<Int64>();
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

        private void deNgayKhuyetTat_Nam_EditValueChanged(object sender, EventArgs e)
        {
            if (seKhuyetTat_Nam.EditValue != null)
            {
                int year = DateTime.Now.Date.Year - seKhuyetTat_Nam.Ex_EditValueToInt() ?? 0;
                year = year == 0 ? 1 : year;
                //seTongThoiGianKT.EditValue = year;
            }
        }

        private void deNgaySinh_Nam_EditValueChanged(object sender, EventArgs e)
        {
            if (deNgaySinh_Nam.EditValue != null)
            {
                int year = DateTime.Now.Date.Year - deNgaySinh_Nam.Ex_EditValueToInt() ?? 0;
                year = year == 0 ? 1 : year;
                seTuoi.EditValue = year;
            }
        }

        private void deNgayKhuyetTat_Nam_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if(e.Button.Kind == ButtonPredefines.Delete)
            {
                seKhuyetTat_Nam.EditValue = null;
            }
        }

        private void deNgaySinh_Nam_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                deNgaySinh_Nam.EditValue = null;
                deNgaySinh_Thang.EditValue = null;
                deNgaySinh_Ngay.EditValue = null;
            }
        }

        private void deDCHT_ThoiGianNhan_Nam_Properties_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Delete)
            {
                deDCHT_ThoiGianNhan_Nam.EditValue = null;
                deDCHT_ThoiGianNhan_Thang.EditValue = null;
                deDCHT_ThoiGianNhan_Ngay.EditValue = null;
            }
        }
        #endregion

        #region Gird Con

        private void gvCon_RowCountChanged(object sender, EventArgs e)
        {
            seSoCon.EditValue = gvCon.RowCount;
        }
        private void repCON_Button_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (clsMessage.MessageYesNo("Bạn có chắc muốn xóa?") == DialogResult.Yes)
            {
                var hv_id = gvCon.GetFocusedRowCellValue(colCON_HV_ID);
                if (hv_id == null) //row add
                {
                    gvCon.DeleteSelectedRows();
                }
                else //row old
                {
                    gvCon.SetFocusedRowCellValue(colCON_HV_ID, clsParameter.statusDeleted);
                }
            }
        }

        private void gvCon_ShowingEditor(object sender, CancelEventArgs e)
        {
            var hv_id = gvCon.GetFocusedRowCellValue(colCON_HV_ID);
            if (hv_id != null && Convert.ToInt64(hv_id) == clsParameter.statusDeleted)
            {
                e.Cancel = true;
            }
        }

        private void gvCon_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvCon_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (gvCon.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                return;
            }

            e.Valid = true;
            if ((gvCon.GetRowCellValue(e.RowHandle, colCON_TEN.FieldName) + string.Empty).Trim().Length == 0)
            {
                gvCon.SetColumnError(gvCon.Columns[colCON_TEN.FieldName], colCON_TEN.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }

            if ((gvCon.GetRowCellValue(e.RowHandle, colCON_GIOITINH.FieldName) + string.Empty).Trim().Length == 0)
            {
                gvCon.SetColumnError(gvCon.Columns[colCON_GIOITINH.FieldName], colCON_GIOITINH.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
        }

        private void gvCon_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            e.Valid = true;
            if (gvCon.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                return;
            }

            if (gvCon.FocusedRowHandle == GridControl.NewItemRowHandle
            && gvCon.GetRow(GridControl.NewItemRowHandle) == null)
            {
                return;
            }

            if (gvCon.FocusedColumn.FieldName == colCON_TEN.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colCON_TEN.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
            }
            if (gvCon.FocusedColumn.FieldName == colCON_GIOITINH.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colCON_GIOITINH.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
            }
        }


        #endregion

        #region Gird Hoi Phi

        
        private void repButtonDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if(clsMessage.MessageYesNo("Bạn có chắc muốn xóa?") == DialogResult.Yes)
            {
                var hv_id = gvHoiPhi.GetFocusedRowCellValue(colHP_HV_ID);
                if (hv_id == null) //row add
                {
                    gvHoiPhi.DeleteSelectedRows();
                }
                else //row old
                {
                    gvHoiPhi.SetFocusedRowCellValue(colHP_HV_ID, clsParameter.statusDeleted);
                }
            }
            
        }

        private void gvHoiPhi_ShowingEditor(object sender, CancelEventArgs e)
        {
            var hv_id = gvHoiPhi.GetFocusedRowCellValue(colHP_HV_ID);
            if(hv_id != null && Convert.ToInt64(hv_id) == clsParameter.statusDeleted)
            {
                e.Cancel = true;
            }
        }

        
        private void gvHoiPhi_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (gvHoiPhi.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                return;
            }

            e.Valid = true;
            if ((gvHoiPhi.GetRowCellValue(e.RowHandle, colHP_NGAY.FieldName) + string.Empty).Trim().Length == 0)
            {
                gvHoiPhi.SetColumnError(gvHoiPhi.Columns[colHP_NGAY.FieldName], colHP_NGAY.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }

            if ((gvHoiPhi.GetRowCellValue(e.RowHandle, colHP_PHI.FieldName) + string.Empty).Trim().Length == 0)
            {
                gvHoiPhi.SetColumnError(gvHoiPhi.Columns[colHP_PHI.FieldName], colHP_PHI.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
        }

        private void gvHoiPhi_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            e.Valid = true;
            if (gvHoiPhi.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                return;
            }

            if (gvHoiPhi.FocusedRowHandle == GridControl.NewItemRowHandle
            && gvHoiPhi.GetRow(GridControl.NewItemRowHandle) == null)
            {
                return;
            }

            if (gvHoiPhi.FocusedColumn.FieldName == colHP_NGAY.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colHP_NGAY.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
            }

            if (gvHoiPhi.FocusedColumn.FieldName == colHP_PHI.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colHP_PHI.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
            }
        }

       

        private void gvHoiPhi_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        #endregion

        #region Thanh vien hoi

        private void gvThanhVienHoi_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            e.Valid = true;
            if (gvThanhVienHoi.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                return;
            }

            if (gvThanhVienHoi.FocusedRowHandle == GridControl.NewItemRowHandle
            && gvThanhVienHoi.GetRow(GridControl.NewItemRowHandle) == null)
            {
                return;
            }

            if (gvThanhVienHoi.FocusedColumn.FieldName == colTV_TVH_TEN.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colTV_TVH_TEN.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
            }

            if (gvThanhVienHoi.FocusedColumn.FieldName == colTV_TVH_TEN.FieldName)
            {
                if (string.IsNullOrEmpty(e.Value.ToString().Trim()))
                {
                    e.ErrorText = colTV_TVH_TEN.Caption + " không được phép rỗng.";
                    e.Valid = false;
                }
            }
        }

        private void gvThanhVienHoi_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (gvThanhVienHoi.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                return;
            }

            e.Valid = true;
            if ((gvThanhVienHoi.GetRowCellValue(e.RowHandle, colTV_TVH_TEN.FieldName) + string.Empty).Trim().Length == 0)
            {
                gvThanhVienHoi.SetColumnError(gvThanhVienHoi.Columns[colTV_TVH_TEN.FieldName], colTV_TVH_TEN.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }

            if ((gvThanhVienHoi.GetRowCellValue(e.RowHandle, colTV_NGAY.FieldName) + string.Empty).Trim().Length == 0)
            {
                gvThanhVienHoi.SetColumnError(gvThanhVienHoi.Columns[colTV_NGAY.FieldName], colTV_NGAY.Caption + " không được phép rỗng.", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Default);
                e.Valid = false;
            }
        }

        private void repTV_ButtonDelete_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (clsMessage.MessageYesNo("Bạn có chắc muốn xóa?") == DialogResult.Yes)
            {
                var id = gvThanhVienHoi.GetFocusedRowCellValue(colTV_ID);
                if (id == null) //row add
                {
                    gvThanhVienHoi.DeleteSelectedRows();
                }
                else //row old
                {
                    gvThanhVienHoi.SetFocusedRowCellValue(colTV_HV_ID, clsParameter.statusDeleted);
                }
            }
            
        }

        private void gvThanhVienHoi_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }

        private void gvThanhVienHoi_ShowingEditor(object sender, CancelEventArgs e)
        {
            var id = gvThanhVienHoi.GetFocusedRowCellValue(colTV_ID);
            if (id != null && Convert.ToInt64(id) == clsParameter.statusDeleted)
            {
                e.Cancel = true;
            }
        }


        #endregion

        private void number_EditValueChanged(object sender, EventArgs e)
        {
            var item = sender as SpinEdit;
            if (item.EditValue != null && clsChangeType.change_int64(item.EditValue) <= 0)
            {
                item.EditValue = 0;
            }
        }
    }
}
