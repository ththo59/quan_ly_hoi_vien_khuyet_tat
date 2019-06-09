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
using DauThau.UserControlCategoryMain;
using DauThau.Reports;
using DevExpress.XtraReports.UI;
using DauThau.UserControlMain;
using DauThau.Forms;
using System.Threading.Tasks;
using System.Threading;
using DevExpress.XtraTab;

namespace DauThau.UserControlCategory
{
    public partial class ucHoatDongTapHuan2 : ucBase
    {
        private Int64 _id_loai;
        public ucHoatDongTapHuan2(Int64 id_loai)
        {
            InitializeComponent();
            _id_loai = id_loai;
        }

        public BindingList<QL_HOATDONG_TAPHUAN_CHITIET> listTapHuanVienChinh = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
        public BindingList<QL_HOATDONG_TAPHUAN_CHITIET> listTapHuanVienPhu = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
        public BindingList<QL_HOATDONG_TAPHUAN_CHITIET> listNguoiThucHien = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
        public BindingList<QL_HOATDONG_TAPHUAN_CHITIET> listPhienDichVien = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
        public BindingList<QL_HOATDONG_TAPHUAN_CHITIET> listDoiTuongKhongKhuyetTat = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
        public QL_HOATDONG_TAPHUAN_DIADIEM tapHuanDiaDiem = new QL_HOATDONG_TAPHUAN_DIADIEM();
        

        //Lưu ý: khi mở lần đầu tiên idRowSeleted = 0 và lấy dữ liệu dòng đầu tiên (nếu có)
        const Int64 constIdDeleted = -1;
        private Boolean _first_load_data = true;

        private void ucHoatDongHoiThaoTapHuan_Load(object sender, EventArgs e)
        {
            registerButtonArray(btnControl);

            deSearchTuNgay.Ex_FormatCustomDateEdit();
            deSearchDenNgay.Ex_FormatCustomDateEdit();
            deTuNgay.Ex_FormatCustomDateEdit();
            deDenNgay.Ex_FormatCustomDateEdit();

            seTienDiLai.Ex_FormatCustomSpinEdit();
            seTienAnTrua.Ex_FormatCustomSpinEdit();
            seTienAnNhe.Ex_FormatCustomSpinEdit();
            seTongSoNguoiThamDu.Ex_FormatCustomSpinEdit();
            seSoLuongNam.Ex_FormatCustomSpinEdit();
            seSoLuongNu.Ex_FormatCustomSpinEdit();

            seTongTienDuyet.Ex_FormatCustomSpinEdit();
            seTongTienThucHien.Ex_FormatCustomSpinEdit();
            seTongTienTrongBanKeHoach.Ex_FormatCustomSpinEdit();

            var current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var nextMonth = current.AddMonths(1);
            deSearchTuNgay.DateTime = current;
            deSearchDenNgay.DateTime = nextMonth.AddDays(-1);

            _loadBeginData();
        }

        #region Variable

        #endregion

        #region Function

        private void _loadBeginData()
        {
            _enableButtonArray();
            //show data after 1 second
            Task.Factory.StartNew(() => Thread.Sleep(clsParameter.secondWait))
            .ContinueWith((t) =>
            {
                _initDisplay();
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

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

            lueLaHoatDong.Properties.DataSource = FuncCategory.loadHoatDong();
            _loadNhaTaiTro();

            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_DONVI_PHUTRACH, lueDonViPhuTrach);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TINH, lueTinh);
            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_LOAI_HOATDONG, lueLoaiHoatDong);

            _wait.Close();
        }

        private void _loadNhaTaiTro()
        {
            string value = checkNhaTaiTro.EditValue + string.Empty;
            checkNhaTaiTro.Ex_SetDataSource(CategoryEntitiesTable.DM_NHA_TAI_TRO.Ex_ToString());
            checkNhaTaiTro.EditValue = value;
            checkNhaTaiTro.RefreshEditValue();
        }

        private void _initDisplay()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang khởi tạo ...", "Vui lòng đợi giây lát");

            _changeLayout((CategoryTapHuan)_id_loai);

            lueLoaiTapHuan.Properties.DataSource = FuncCategory.loadDMTapHuan();
            lueLoaiTapHuan.EditValue = _id_loai;

            _loadCategory();

            _first_load_data = false;
            FormStatus = EnumFormStatus.VIEW;

            _wait.Close();
        } 

        private void _changeLayout(CategoryTapHuan enumLoai)
        {
            switch (enumLoai)
            {
                case CategoryTapHuan.TH_TAPHUAN:
                    //layThongTinGV.Visibility = layGiangVienThuLao.Visibility
                    //    = layThongTinGV_empty.Visibility = layNguoiHoTro_empty.Visibility
                    //    = layNguoiHoTro.Visibility = layHoTroThuLao.Visibility = LayoutVisibility.Always;
                    grpSearchTitle.Text = "Danh sách hoạt động tập huấn";
                    break;
                case CategoryTapHuan.TH_GIAODUC:
                    grpSearchTitle.Text = "Danh sách hoạt động giáo dục";
                    //layThongTinGV.Visibility = layThongTinGV_empty.Visibility = LayoutVisibility.Always;
                    break;
                case CategoryTapHuan.HUONG_DAN_THUC_TAP:
                    grpSearchTitle.Text = "Danh sách hoạt động hướng dẫn thực tập";
                    break;
                case CategoryTapHuan.VAN_DONG_CHINH_SACH:
                    //laySoNguoiThamGia.Visibility = laySoTienTrenNguoi.Visibility = layTongTien.Visibility = LayoutVisibility.Never;
                    //layNguoiHoTro.Visibility = LayoutVisibility.Always;
                    //layNguoiHoTro.Text = "Người thực hiện";
                    //layDiaDiem.Text = "Nơi nhận";
                    grpSearchTitle.Text = "Danh sách hoạt động vận động chính sách";
                    break;
                case CategoryTapHuan.TRUYEN_THONG_PHAP_LY:
                    //layDonViThucHien.Visibility = LayoutVisibility.Always;
                    grpSearchTitle.Text = "Danh sách hoạt động truyền thông pháp lý";
                    break;
                default:
                    break;
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
            foreach (var items in layoutEdit2.Controls)
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
            foreach (var items in layoutEdit3.Controls)
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

            foreach (var items in layoutEdit4.Controls)
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

            deSearchTuNgay.ReadOnly = deSearchDenNgay.ReadOnly = !readOnly;
            btnSearch.Enabled = readOnly;
            gcGrid.Enabled = readOnly;
            seTongSoNgay.ReadOnly = true;
            //txtDoiTuong.ReadOnly = true;
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
            foreach (var items in layoutEdit2.Controls)
            {
                BaseEdit item = items as BaseEdit;
                if (item != null)
                {
                    item.EditValue = null;
                }
            }
            foreach (var items in layoutEdit3.Controls)
            {
                BaseEdit item = items as BaseEdit;
                if (item != null)
                {
                    item.EditValue = null;
                }
            }
            foreach (var items in layoutEdit4.Controls)
            {
                BaseEdit item = items as BaseEdit;
                if (item != null)
                {
                    item.EditValue = null;
                }
            }
        }

        private void _setFocusedRow()
        {
            for (int i = 0; i < gvGrid.RowCount; i++)
            {
                Int64 id = Convert.ToInt64(gvGrid.GetRowCellValue(i, colTH_ID));
                if (id == _idRowSelected)
                {
                    gvGrid.FocusedRowHandle = i;
                    break;
                }
            }
        }

        private void _loadData()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            context = new QL_HOIVIEN_KTEntities();
            context.QL_HOATDONG_TAPHUAN.Load();
            var data = (from p in context.QL_HOATDONG_TAPHUAN
                        where deSearchTuNgay.DateTime.Date <= p.TH_THOIGIAN_BATDAU
                             && p.TH_THOIGIAN_BATDAU <= deSearchDenNgay.DateTime.Date
                             && p.TH_LOAI_ID == _id_loai
                        select p).ToList();
            gcGrid.DataSource = data;

            _setFocusedRow();
            _bindingData();

            _wait.Close();
        }

        private string _getMemoText(BindingList<QL_HOATDONG_TAPHUAN_CHITIET> data)
        {
            StringBuilder title = new StringBuilder();
            foreach (var item in data.Where(p=>p.TH_ID != constIdDeleted))
            {
                if (item.TH_CT_DIACHI != "")
                {
                    title.AppendFormat("{0}({1}); ", item.TH_CT_HO + " " + item.TH_CT_TEN, item.TH_CT_DIACHI);
                }else if(item.TH_CT_DONVI_TEN != "")
                {
                    title.AppendFormat("{0}({1}); ", item.TH_CT_HO + " " + item.TH_CT_TEN, item.TH_CT_DONVI_TEN);
                }
                else
                {
                    title.AppendFormat("{0}; ", item.TH_CT_HO + " " + item.TH_CT_TEN);
                }
                
            }
            return title.ToString();
        }

        private void _setMemoText(QL_HOATDONG_TAPHUAN item, CategoryTapHuanChiTietLoai enumLoai)
        {
            var query = context.QL_HOATDONG_TAPHUAN_CHITIET
                    .Where(p => p.TH_CT_LOAI == (int)enumLoai && p.TH_ID == item.TH_ID).ToList();

            switch (enumLoai)
            {
                case CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN:
                    listNguoiThucHien = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>(query);
                    memoNguoiThucHien.Text = _getMemoText(listNguoiThucHien);
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH:
                    listTapHuanVienChinh = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>(query);
                    memoTHVChinh.Text = _getMemoText(listTapHuanVienChinh);
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU:
                    listTapHuanVienPhu = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>(query);
                    memoTHVPhu.Text = _getMemoText(listTapHuanVienPhu);
                    break;
                case CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN:
                    listPhienDichVien = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>(query);
                    memoPhienDichVien.Text = _getMemoText(listPhienDichVien);
                    break;
                case CategoryTapHuanChiTietLoai.DOITUONG_KHONG_KHUYETTAT:
                    listDoiTuongKhongKhuyetTat = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>(query);
                    memoDoiTuongKhongKT.Text = _getMemoText(listDoiTuongKhongKhuyetTat);
                    break;
                default:
                    break;
            }
        }

        private void _bindingData()
        {
            _clearData();
            QL_HOATDONG_TAPHUAN item = gvGrid.GetFocusedRow() as QL_HOATDONG_TAPHUAN;
            if (item != null)
            {
                //Thông tin chung
                deTuNgay.EditValue = item.TH_THOIGIAN_BATDAU;
                deDenNgay.EditValue = item.TH_THOIGIAN_KETTHUC;
                seTongSoNgay.EditValue = item.TH_TONGSO_NGAY;
                txtTenChuongTrinh.EditValue = item.TH_TEN;
                lueLaHoatDong.EditValue = item.TH_LA_HOATDONG;

                checkNhaTaiTro.EditValue = (item.NTT_TEN);
                checkNhaTaiTro.RefreshEditValue();

                lueDonViPhuTrach.EditValue = item.TH_DONVI_PHUTRACH;
                lueTinh.EditValue = item.TH_TINH_THUCHIEN;
                txtHoatDongMa.EditValue = item.TH_HOATDONG_MA;
                lueLoaiHoatDong.EditValue = item.TH_HOATDONG_LOAI;

                _setMemoText(item, CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN);
                _setMemoText(item, CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH);
                _setMemoText(item, CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU);
                _setMemoText(item, CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN);
                _setMemoText(item, CategoryTapHuanChiTietLoai.DOITUONG_KHONG_KHUYETTAT);

               
                //Tập huấn viên
                txtLinkTHVHopDong.EditValue = item.TH_LINK_THV_HOPDONG;
                txtLinkTHVBanCamKet.EditValue = item.TH_LINK_THV_BANCAMKET;
                txtLinkTaiLieu.EditValue = item.TH_LINK_TAILIEU;
                txtLinkBaoCaoSauTapHuan.EditValue = item.TH_LINK_BAOCAO_SAU_TAPHUAN;
                

                memoDoiTuong.EditValue = item.TH_DOITUONG_HV_TEN;
                memoDoiTuongId.EditValue = item.TH_DOITUONG_HV_ID;

                txtLinkTDVScan.EditValue = item.TH_DOITUONG_LINK_SCAN;
                seTongSoNguoiThamDu.EditValue = item.TH_DOITUONG_TONGSO;
                seSoLuongNam.EditValue = item.TH_DOITUONG_SL_NAM;
                seSoLuongNu.EditValue = item.TH_DOITUONG_SL_NU;
                seTienDiLai.EditValue = item.TH_TIEN_DILAI;
                seTienAnTrua.EditValue = item.TH_TIEN_ANTRUA;
                seTienAnNhe.EditValue = item.TH_TIEN_ANNHE;

                seKTKhac.EditValue = item.TH_KT_SL_KHAC;
                seKTNgheNoi.EditValue = item.TH_KT_SL_NGHENOI;
                seKTNhin.EditValue = item.TH_KT_SL_NHIN;
                seKTTamThanThanKinh.EditValue = item.TH_KT_SL_THANKINH_TAMTHAN;
                seKTTriTue.EditValue = item.TH_KT_SL_TRITUE;
                seKTVanDong.EditValue = item.TH_KT_SL_VANDONG;

                var query = item.QL_HOATDONG_TAPHUAN_DIADIEM.FirstOrDefault();
                tapHuanDiaDiem = query;
                if (query != null)
                {
                    memoDiaDiemToChuc.Text = query.TH_DD_TEN;
                }
                txtLinkDiaDiem_HopDong.EditValue = item.TH_DIADIEM_LINK_HOPDONG;
                txtLinkDiaDiem_BBThanhLy.EditValue = item.TH_DIADIEM_LINK_BB_THANHLY;

                //Tài chính
                seTongTienDuyet.EditValue = item.TH_TONGTIEN_DUYET;
                seTongTienThucHien.EditValue = item.TH_TONGTIEN_THUCHIEN;
                seTongTienTrongBanKeHoach.EditValue = item.TH_TONGTIEN_BAN_KEHOACH;
                txtLinkDuyetChi.EditValue = item.TH_LINK_DUYETCHI;
                txtLinkKeHoachHoatDong.EditValue = item.TH_LINK_KEHOACH_HOATDONG;
                txtLinkChungTu.EditValue = item.TH_LINK_CHUNGTU;

                //Công văn
                txtCongVan_So.EditValue = item.TH_CONGVAN_SO;
                txtCongVan_DonViGoi.EditValue = item.TH_CONGVAN_DONVI_GUI;
                txtCongVan_GuiDonVi.EditValue = item.TH_CONGVAN_GUI_DONVI;
                txtLinkCongVan.EditValue = item.TH_CONGVAN_LINK;

            }
        }

        private void _setObjectEntities(ref QL_HOATDONG_TAPHUAN item)
        {
            item.TH_LOAI_ID = _id_loai;
            item.TH_THOIGIAN_BATDAU = deTuNgay.Ex_EditValueToDateTime();
            item.TH_THOIGIAN_KETTHUC = deDenNgay.Ex_EditValueToDateTime();
            item.TH_TONGSO_NGAY = seTongSoNgay.Ex_EditValueToInt();

            //Thông tin
            item.TH_TEN = txtTenChuongTrinh.Text ;
            item.TH_LA_HOATDONG = lueLaHoatDong.Text;
            item.NTT_TEN = checkNhaTaiTro.EditValue + string.Empty;
            item.TH_DONVI_PHUTRACH = lueDonViPhuTrach.Text;
            item.TH_TINH_THUCHIEN = lueTinh.Text;
            item.TH_HOATDONG_MA = txtHoatDongMa.Text;
            item.TH_HOATDONG_LOAI = lueLoaiHoatDong.Text;
            item.TH_LINK_THV_HOPDONG = txtLinkTHVHopDong.Text;
            item.TH_LINK_THV_BANCAMKET = txtLinkTHVBanCamKet.Text;
            item.TH_LINK_TAILIEU = txtLinkTaiLieu.Text;
            item.TH_LINK_BAOCAO_SAU_TAPHUAN = txtLinkBaoCaoSauTapHuan.Text;

            item.TH_DOITUONG_HV_ID = memoDoiTuongId.Text;
            item.TH_DOITUONG_HV_TEN = memoDoiTuong.Text;
            item.TH_DOITUONG_LINK_SCAN = txtLinkTDVScan.Text;

            item.TH_DOITUONG_TONGSO = seTongSoNguoiThamDu.Ex_EditValueToInt();
            item.TH_DOITUONG_SL_NAM = seSoLuongNam.Ex_EditValueToInt();
            item.TH_DOITUONG_SL_NU = seSoLuongNu.Ex_EditValueToInt();
            item.TH_TIEN_DILAI = seTienDiLai.Ex_EditValueToInt();
            item.TH_TIEN_ANTRUA = seTienAnTrua.Ex_EditValueToInt();
            item.TH_TIEN_ANNHE = seTienAnNhe.Ex_EditValueToInt();

            item.TH_KT_SL_VANDONG = seKTVanDong.Ex_EditValueToInt();
            item.TH_KT_SL_TRITUE = seKTTriTue.Ex_EditValueToInt();
            item.TH_KT_SL_NHIN = seKTNhin.Ex_EditValueToInt();
            item.TH_KT_SL_NGHENOI = seKTNgheNoi.Ex_EditValueToInt();
            item.TH_KT_SL_THANKINH_TAMTHAN = seKTTamThanThanKinh.Ex_EditValueToInt();
            item.TH_KT_SL_KHAC = seKTKhac.Ex_EditValueToInt();

            item.TH_DIADIEM_LINK_HOPDONG = txtLinkDiaDiem_HopDong.Text;
            item.TH_DIADIEM_LINK_BB_THANHLY = txtLinkDiaDiem_BBThanhLy.Text;

            //Tài chính
            item.TH_TONGTIEN_DUYET = seTongTienDuyet.Ex_EditValueToInt();
            item.TH_TONGTIEN_THUCHIEN = seTongTienThucHien.Ex_EditValueToInt();
            item.TH_TONGTIEN_BAN_KEHOACH = seTongTienTrongBanKeHoach.Ex_EditValueToInt();
            item.TH_LINK_DUYETCHI = txtLinkDuyetChi.Text;
            item.TH_LINK_KEHOACH_HOATDONG = txtLinkKeHoachHoatDong.Text;
            item.TH_LINK_CHUNGTU = txtLinkChungTu.Text;

            item.TH_CONGVAN_SO = txtCongVan_So.Text;
            item.TH_CONGVAN_DONVI_GUI = txtCongVan_DonViGoi.Text;
            item.TH_CONGVAN_GUI_DONVI = txtCongVan_GuiDonVi.Text;
            item.TH_CONGVAN_LINK = txtLinkCongVan.Text;
        }

        private Boolean _validateControl()
        {
            dxErrorProvider.ClearErrors();

            if (txtTenChuongTrinh.Text.Trim() == string.Empty)
            {
                dxErrorProvider.SetError(txtTenChuongTrinh, "Vui lòng nhập họ tên");
            }

            if (clsChangeType.change_int(seTongSoNgay.EditValue)  <= 0)
            {
                dxErrorProvider.SetError(deDenNgay, "Từ ngày và đến ngày không phù hợp");
            }

            if (dxErrorProvider.HasErrors)
            {
                clsMessage.MessageWarning("Vui lòng nhập đầy đủ thông tin.");
            }

            return !dxErrorProvider.HasErrors;
        }

        private void _initMemoData()
        {
            listNguoiThucHien = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
            listTapHuanVienChinh = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
            listTapHuanVienPhu = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
            listPhienDichVien = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
            tapHuanDiaDiem = new QL_HOATDONG_TAPHUAN_DIADIEM();
        }

        private void _updateMemoData(QL_HOIVIEN_KTEntities _context, QL_HOATDONG_TAPHUAN item, CategoryTapHuanChiTietLoai enumLoai)
        {
            BindingList<QL_HOATDONG_TAPHUAN_CHITIET> list_chitiet = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>() ;
            switch (enumLoai)
            {
                case CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN:
                    list_chitiet = listNguoiThucHien;
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH:
                    list_chitiet = listTapHuanVienChinh;
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU:
                    list_chitiet = listTapHuanVienPhu;
                    break;
                case CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN:
                    list_chitiet = listPhienDichVien;
                    break;
                case CategoryTapHuanChiTietLoai.DOITUONG_KHONG_KHUYETTAT:
                    list_chitiet = listDoiTuongKhongKhuyetTat;
                    break;
                default:
                    break;
            }

            QL_HOATDONG_TAPHUAN_CHITIET item_chitiet;
            foreach (var person in list_chitiet)
            {
                if (person.TH_ID == null) //add
                {
                    person.QL_HOATDONG_TAPHUAN = item;
                    _context.QL_HOATDONG_TAPHUAN_CHITIET.Add(person);
                }
                else if (person.TH_ID == constIdDeleted) //delete
                {
                    item_chitiet = (from p in _context.QL_HOATDONG_TAPHUAN_CHITIET
                                    where p.TH_CT_ID == person.TH_CT_ID
                                    select p).FirstOrDefault();
                    if (item_chitiet != null)
                    {
                        _context.QL_HOATDONG_TAPHUAN_CHITIET.Remove(item_chitiet);
                    }
                }
                else //modify
                {
                    var chitiet = _context.QL_HOATDONG_TAPHUAN_CHITIET.Where(p => p.TH_CT_ID == person.TH_CT_ID).FirstOrDefault();
                    if (chitiet != null)
                    {
                        _context.Entry(chitiet).CurrentValues.SetValues(person);
                    }
                }
            }
        }

        private void _insertMemoData(QL_HOIVIEN_KTEntities _context, QL_HOATDONG_TAPHUAN item, CategoryTapHuanChiTietLoai enumLoai)
        {
            BindingList<QL_HOATDONG_TAPHUAN_CHITIET> list_chitiet = new BindingList<QL_HOATDONG_TAPHUAN_CHITIET>();
            switch (enumLoai)
            {
                case CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN:
                    list_chitiet = listNguoiThucHien;
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH:
                    list_chitiet = listTapHuanVienChinh;
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU:
                    list_chitiet = listTapHuanVienPhu;
                    break;
                case CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN:
                    list_chitiet = listPhienDichVien;
                    break;
                case CategoryTapHuanChiTietLoai.DOITUONG_KHONG_KHUYETTAT:
                    list_chitiet = listDoiTuongKhongKhuyetTat;
                    break;
                default:
                    break;
            }

            foreach (var row in list_chitiet)
            {
                row.QL_HOATDONG_TAPHUAN = item;
                _context.QL_HOATDONG_TAPHUAN_CHITIET.Add(row);
            }
            _context.QL_HOATDONG_TAPHUAN.Add(item);
        }

        private void _updateDiaDiemToChucData(QL_HOIVIEN_KTEntities _context, QL_HOATDONG_TAPHUAN item)
        {
            if(tapHuanDiaDiem == null)
            {
                return;
            }
            
            if (tapHuanDiaDiem.TH_ID == null) //add
            {
                tapHuanDiaDiem.QL_HOATDONG_TAPHUAN = item;
                _context.QL_HOATDONG_TAPHUAN_DIADIEM.Add(tapHuanDiaDiem);
            }
            else if (tapHuanDiaDiem.TH_ID == constIdDeleted) //delete
            {
                var item_chitiet = (from p in _context.QL_HOATDONG_TAPHUAN_DIADIEM
                                where p.TH_DD_ID == tapHuanDiaDiem.TH_DD_ID
                                select p).FirstOrDefault();
                if (item_chitiet != null)
                {
                    _context.QL_HOATDONG_TAPHUAN_DIADIEM.Remove(item_chitiet);
                }
            }
            else //modify
            {
                var chitiet = _context.QL_HOATDONG_TAPHUAN_DIADIEM.Where(p => p.TH_DD_ID== tapHuanDiaDiem.TH_DD_ID).FirstOrDefault();
                if (chitiet != null)
                {
                    _context.Entry(chitiet).CurrentValues.SetValues(tapHuanDiaDiem);
                }
            }
        }

        protected override bool SaveData()
        {
            try
            {
                if (_validateControl())
                {
                    using (var _context = new QL_HOIVIEN_KTEntities())
                    {
                        QL_HOATDONG_TAPHUAN item;
                        switch (_formStatus)
                        {
                            case EnumFormStatus.ADD:

                                item = new QL_HOATDONG_TAPHUAN();
                                _setObjectEntities(ref item);

                                _updateMemoData(_context, item, CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN);
                                _updateMemoData(_context, item, CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH);
                                _updateMemoData(_context, item, CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU);
                                _updateMemoData(_context, item, CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN);
                                _updateMemoData(_context, item, CategoryTapHuanChiTietLoai.DOITUONG_KHONG_KHUYETTAT);

                                _updateDiaDiemToChucData(_context, item);

                                _context.QL_HOATDONG_TAPHUAN.Add(item);

                                _context.SaveChanges();
                                _idRowSelected = item.TH_ID;
                                break;

                            case EnumFormStatus.MODIFY:
                                Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colTH_ID));
                                item = (from p in _context.QL_HOATDONG_TAPHUAN where p.TH_ID == id select p).FirstOrDefault<QL_HOATDONG_TAPHUAN>();
                                if (item != null)
                                {
                                    _setObjectEntities(ref item);
                                }
                                var entity = _context.QL_HOATDONG_TAPHUAN.Find(id);
                                if (entity != null)
                                {
                                    _context.Entry(entity).CurrentValues.SetValues(item);
                                }

                                _updateMemoData(_context, item, CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN);
                                _updateMemoData(_context, item, CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH);
                                _updateMemoData(_context, item, CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU);
                                _updateMemoData(_context, item, CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN);
                                _updateMemoData(_context, item, CategoryTapHuanChiTietLoai.DOITUONG_KHONG_KHUYETTAT);

                                _updateDiaDiemToChucData(_context, item);

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
            catch (Exception ex)
            {
                clsMessage.MessageExclamation("Có lỗi phát sinh. Chi tiết:" + ex.Message);
                return false;
            }
            
        }

        private void _deleteRow()
        {
            QL_HOATDONG_TAPHUAN item = gvGrid.GetFocusedRow() as QL_HOATDONG_TAPHUAN;
            if (item != null)
            {
                if (clsMessage.MessageYesNo(string.Format("Bạn có chắc muốn xóa: {0}", item.TH_TEN)) == DialogResult.Yes)
                {
                    Int64 id = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colTH_ID));
                    var listChiTiet = (from p in context.QL_HOATDONG_TAPHUAN_CHITIET where p.TH_ID == id select p);
                    foreach (var item_delete in listChiTiet)
                    {
                        context.QL_HOATDONG_TAPHUAN_CHITIET.Remove(item_delete);
                    }

                    var listDiaDiem = (from p in context.QL_HOATDONG_TAPHUAN_DIADIEM where p.TH_ID == id select p);
                    foreach (var item_delete in listDiaDiem)
                    {
                        context.QL_HOATDONG_TAPHUAN_DIADIEM.Remove(item_delete);
                    }
                    QL_HOATDONG_TAPHUAN entities = (from p in context.QL_HOATDONG_TAPHUAN where p.TH_ID == id select p).FirstOrDefault();
                    context.QL_HOATDONG_TAPHUAN.Remove(entities);
                    
                    context.SaveChanges();
                    FormStatus = EnumFormStatus.VIEW;
                }

            }

        }

        private void _print()
        {
            rptBCHoatDongTapHuan rpt = new rptBCHoatDongTapHuan();
            CategoryTapHuan enumLoai = (CategoryTapHuan)_id_loai;
            //switch (enumLoai)
            //{
            //    case CategoryTapHuan.TH_TAPHUAN:
                    var data = (from p in context.QL_HOATDONG_TAPHUAN
                                where deSearchTuNgay.DateTime.Date <= p.TH_THOIGIAN_BATDAU
                                     && p.TH_THOIGIAN_BATDAU <= deSearchDenNgay.DateTime.Date
                                     && p.TH_LOAI_ID == _id_loai
                                select p).ToList();
                    List<clsHoatDongTapHuan> listTapHuan = new List<clsHoatDongTapHuan>();
                    foreach (QL_HOATDONG_TAPHUAN row in data)
                    {
                        clsHoatDongTapHuan item = new clsHoatDongTapHuan();
                        item.TH_TEN = row.TH_TEN;
                        item.TH_THOIGIAN = FunctionHelper.formatFromDateToDate(row.TH_THOIGIAN_BATDAU, row.TH_THOIGIAN_KETTHUC);
                        //item.TH_DIADIEM = row.TH_DIADIEM;
                        //item.TH_DONVI_THUCHIEN = row.TH_DONVI_THUCHIEN;
                        //item.TH_SOLUONG = row.TH_SOLUONG;
                        //item.TH_TONGTIEN = row.TH_TONGTIEN??0;
                        item.TH_NOIDUNG = row.TH_NOIDUNG;
                        listTapHuan.Add(item);
                    }
                    DataTable dataTapHuan = FunctionHelper.ConvertToDataTable(listTapHuan);
                    dataTapHuan.TableName = "HoatDongTapHuan";

                    rpt.pLeftHeader.Value = clsParameter.pHospital;
                    rpt.pParentLeftHeader.Value = clsParameter.pParentHospital;
                    rpt.pTitle.Value = lueLoaiTapHuan.Text.ToUpper();
                    rpt.pTuNgayDenNgay.Value = FunctionHelper.formatFromDateToDate(deSearchTuNgay.DateTime, deSearchDenNgay.DateTime);
                    //rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM10);
                    //rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM10);

                    rpt.DataSource = dataTapHuan;
                    rpt.DataMember = "HoatDongTapHuan";
            //        break;
            //    default:
            //        break;
            //}

            frmPrint f = new frmPrint(rpt);
            f.ShowDialog();
        }

        private void _memoButtonClick(CategoryTapHuanChiTietLoai enumLoai)
        {
            frmTapHuanChiTiet frm = new frmTapHuanChiTiet((int)enumLoai);

            QL_HOATDONG_TAPHUAN item = new QL_HOATDONG_TAPHUAN();
            _setObjectEntities(ref item);
            frm.tapHuanData = item;
            frm.tapHuan_DiaDiemData = tapHuanDiaDiem;
            frm.tapHuanNguoiKhongKT = listDoiTuongKhongKhuyetTat;

            switch (enumLoai)
            {
                case CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN:
                    frm.Text = "Người thực hiện";
                    frm.data = listNguoiThucHien;
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH:
                    frm.Text = "Tập huấn viên chính";
                    frm.data = listTapHuanVienChinh;
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU:
                    frm.Text = "Tập huấn viên phụ";
                    frm.data = listTapHuanVienPhu;
                    break;
                case CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN:
                    frm.Text = "Phiên dịch viên";
                    frm.data = listPhienDichVien;
                    break;
                case CategoryTapHuanChiTietLoai.DOITUONG_KHONG_KHUYETTAT:
                    frm.Text = "Đối tượng không khuyết tật";
                    frm.data = listDoiTuongKhongKhuyetTat;
                    break;
                default:
                    break;
            }

            frm.ShowDialog();

            switch (enumLoai)
            {
                case CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN:
                    listNguoiThucHien = frm.data;
                    memoNguoiThucHien.Text = _getMemoText(listNguoiThucHien);
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH:
                    listTapHuanVienChinh = frm.data;
                    memoTHVChinh.Text = _getMemoText(listTapHuanVienChinh);
                    break;
                case CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU:
                    listTapHuanVienPhu = frm.data;
                    memoTHVPhu.Text = _getMemoText(listTapHuanVienPhu);
                    break;
                case CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN:
                    listPhienDichVien = frm.data;
                    memoPhienDichVien.Text = _getMemoText(listPhienDichVien);
                    break;
                case CategoryTapHuanChiTietLoai.DOITUONG_KHONG_KHUYETTAT:
                    listDoiTuongKhongKhuyetTat = frm.data;
                    memoDoiTuongKhongKT.Text = _getMemoText(listDoiTuongKhongKhuyetTat);
                    _updateStatusDoiTuong();
                    break;
                default:
                    break;
            }

        }

        private void _updateStatusDoiTuong()
        {
            string[] idStringList = memoDoiTuongId.Text.Split(new[] { "; " }, StringSplitOptions.None);
            List<Int64> idList = new List<long>();
            foreach (var id in idStringList)
            {
                idList.Add(Convert.ToInt64(id));
            }

            var hoivienList = context.QL_HOIVIEN.Where(p => idList.Contains(p.HV_ID)).OrderBy(p => p.HV_TEN).ToList();
            int count_hoiVien = hoivienList != null ? hoivienList.Count : 0;

            int count_Nam = 0;
            int count_Nu = 0;

            int count_KT_VanDong = 0;
            int count_KT_Nhin = 0;
            int count_KT_NgheNoi = 0;
            int count_KT_TriTue = 0;
            int count_KT_TamThan_ThanKinh = 0;
            int count_KT_Khac = 0;

            foreach (var item in hoivienList)
            {
                count_Nam += item.HV_GIOI_TINH == "Nam" ? 1 : 0;
                count_Nu += item.HV_GIOI_TINH == "Nữ" ? 1 : 0;

                count_KT_VanDong += item.HV_KT_TINHTRANG.Contains("Khuyết tật vận động") ? 1 : 0;
                count_KT_Nhin += item.HV_KT_TINHTRANG.Contains("Khuyết tật nhìn") ? 1 : 0;
                count_KT_NgheNoi += item.HV_KT_TINHTRANG.Contains("Khuyết tật nghe, nói") ? 1 : 0;
                count_KT_TriTue += item.HV_KT_TINHTRANG.Contains("Khuyết tật trí tuệ") ? 1 : 0;
                count_KT_TamThan_ThanKinh += item.HV_KT_TINHTRANG.Contains("Khuyết tật thần kinh, tâm thần") ? 1 : 0;
                count_KT_Khac += item.HV_KT_TINHTRANG.Contains("Khuyết tật khác") ? 1 : 0;

            }

            //Người không khuyết tật
            int count_NguoiKhongKT = listDoiTuongKhongKhuyetTat.Count;
            foreach (var item in listDoiTuongKhongKhuyetTat)
            {
                count_Nam += item.TH_CT_GIOITINH == "Nam" ? 1 : 0;
                count_Nu += item.TH_CT_GIOITINH == "Nữ" ? 1 : 0;
            }

            seTongSoNguoiThamDu.EditValue = count_hoiVien + count_NguoiKhongKT;
            seSoLuongNam.EditValue = count_Nam;
            seSoLuongNu.EditValue = count_Nu;

            seKTVanDong.EditValue = count_KT_VanDong;
            seKTNhin.EditValue = count_KT_Nhin;
            seKTNgheNoi.EditValue = count_KT_NgheNoi;
            seKTTriTue.EditValue = count_KT_TriTue;
            seKTTamThanThanKinh.EditValue = count_KT_TamThan_ThanKinh;
            seKTKhac.EditValue = count_KT_Khac;

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
                    _clearData();
                    _initMemoData();
                    deTuNgay.Focus();
                    _statusAllControl(false);
                }
                else if (_formStatus == EnumFormStatus.MODIFY)
                {
                    deTuNgay.Focus();
                    _statusAllControl(false);
                }
                else if (_formStatus == EnumFormStatus.DELETE)
                {
                    _deleteRow();
                }
                else if (_formStatus == EnumFormStatus.PRINT)
                {
                    _print();
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

                    _enableButtonArray();

                    base.permissionAccessButton(btnControl, (Int32)FunctionName.FUNC_NANGCAO_NANGLUC);
                }
            }
        }

        private void _enableButtonArray()
        {
            btnControl.btnAdd.Enabled = !_first_load_data;
            btnControl.btnModify.Enabled = btnControl.btnDelete.Enabled = btnControl.btnPrint.Enabled = gvGrid.RowCount > 0;
        }
        private void _calTongSoNgay()
        {
            if (deTuNgay.EditValue != null && deDenNgay.EditValue != null)
            {
                TimeSpan diff = deDenNgay.DateTime - deTuNgay.DateTime;
                seTongSoNgay.EditValue = diff.Days + 1;
            }
        }

        #endregion

        #region Event Grid

        private void gvGrid_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            _idRowSelected = Convert.ToInt64(gvGrid.GetFocusedRowCellValue(colTH_ID));
            _bindingData();
        }

        #endregion

        #region Event button

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _loadData();
            FormStatus = EnumFormStatus.VIEW;
        }

        private void deTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            _calTongSoNgay();
        }

        private void deDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            _calTongSoNgay();
        }

        private void btnSelectHoiVien_Click(object sender, EventArgs e)
        {
            frmSelectHoiVien frm = new frmSelectHoiVien();
            frm.selectNameList = memoDoiTuong.Text;
            frm.selectIdList = memoDoiTuongId.Text;
            frm.ShowDialog();

            memoDoiTuong.Text = frm.selectNameList;
            memoDoiTuongId.Text = frm.selectIdList;
            _updateStatusDoiTuong();
        }

        private void btnDonViTaiTro_Click(object sender, EventArgs e)
        {
            frmNhaTaiTro frm = new frmNhaTaiTro();
            frm.ShowDialog();
            _loadNhaTaiTro();
        }

        private void btnTapHuanVienChinh_Click(object sender, EventArgs e)
        {
            _memoButtonClick(CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_CHINH);
        }

        private void btnNguoiThucHien_Click(object sender, EventArgs e)
        {
            _memoButtonClick(CategoryTapHuanChiTietLoai.NGUOI_THUC_HIEN);

        }

        private void btnDoiTuongKhongKT_Click(object sender, EventArgs e)
        {
            _memoButtonClick(CategoryTapHuanChiTietLoai.DOITUONG_KHONG_KHUYETTAT);
        }

        private void btnPhienDichVien_Click(object sender, EventArgs e)
        {
            _memoButtonClick(CategoryTapHuanChiTietLoai.PHIEN_DICH_VIEN);
        }

        private void btnTapHuanVienPhu_Click(object sender, EventArgs e)
        {
            _memoButtonClick(CategoryTapHuanChiTietLoai.TAP_HUAN_VIEN_PHU);
        }

        private void btnLinkTHVHopDong_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkTHVHopDong.Text);
        }

        private void btnLinkTHVBanCamKet_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkTHVBanCamKet.Text);
        }

        private void btnLinkTaiLieu_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkTaiLieu.Text);
        }

        private void btnLinkBaoCaoSauTapHuan_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkBaoCaoSauTapHuan.Text);
        }

        private void btnDiaDiemToChuc_Click(object sender, EventArgs e)
        {
            frmTapHuanDiaDiem frm = new frmTapHuanDiaDiem();
            frm.data = tapHuanDiaDiem;
            frm.id_parent = _idRowSelected;

            frm.ShowDialog();
            tapHuanDiaDiem = frm.data;
            memoDiaDiemToChuc.Text = (tapHuanDiaDiem != null && tapHuanDiaDiem.TH_ID != constIdDeleted) ? tapHuanDiaDiem.TH_DD_TEN : "";
        }


        private void btnLinkTDVScan_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkTDVScan.Text);
        }

        private void btnLinkHDThanhLy_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkDiaDiem_HopDong.Text);
        }

        private void btnLinkDuyetChi_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkDuyetChi.Text);
        }

        private void btnLinkKeHoachHoatDong_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkKeHoachHoatDong.Text);
        }

        private void btnLinkChungTu_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkChungTu.Text);
        }

        private void btnLinkCongVan_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkCongVan.Text);
        }

        #endregion

        private void btnLinkDiaDiem_BBThanhLy_Click(object sender, EventArgs e)
        {
            FunctionHelper.openLink(txtLinkDiaDiem_BBThanhLy.Text);
        }

        #region Print

        private void btnPrintDiaDiem_HopDong_Click(object sender, EventArgs e)
        {
            if(tapHuanDiaDiem == null)
            {
                clsMessage.MessageExclamation("Thông tin địa điểm chưa được cập nhật. Vui lòng kiểm tra lại.");
                return;
            }
            var dataPrint = new Dictionary<string, string>()
            {
                {"TH_DD_NGUOI_DAIDIEN", tapHuanDiaDiem.TH_DD_NGUOI_DAIDIEN},
                {"TH_DD_CHUCVU", tapHuanDiaDiem.TH_DD_CHUCVU},
                {"TH_DD_DIACHI", tapHuanDiaDiem.TH_DD_DIACHI},
                {"TH_DD_SDT", tapHuanDiaDiem.TH_DD_SDT},
                {"TH_DD_MST", tapHuanDiaDiem.TH_DD_MST},
                {"TH_DD_TK_SO", tapHuanDiaDiem.TH_DD_TK_SO },
                {"TH_DD_TK_TEN", tapHuanDiaDiem.TH_DD_TK_TEN}
            };
            ExportHelper.exportWord(dataPrint, "DiaDiemToChuc_HopDong.doc");
        }

        private void btnPrintDiaDiem_ThanhLy_Click(object sender, EventArgs e)
        {
            if (tapHuanDiaDiem == null)
            {
                clsMessage.MessageExclamation("Thông tin địa điểm chưa được cập nhật. Vui lòng kiểm tra lại.");
                return;
            }
            var dataPrint = new Dictionary<string, string>()
            {
                {"TH_DD_NGUOI_DAIDIEN", tapHuanDiaDiem.TH_DD_NGUOI_DAIDIEN},
                {"TH_DD_CHUCVU", tapHuanDiaDiem.TH_DD_CHUCVU},
                {"TH_DD_DIACHI", tapHuanDiaDiem.TH_DD_DIACHI},
                {"TH_DD_SDT", tapHuanDiaDiem.TH_DD_SDT},
                {"TH_DD_MST", tapHuanDiaDiem.TH_DD_MST},
                {"TH_DD_TK_SO", tapHuanDiaDiem.TH_DD_TK_SO },
                {"TH_DD_TK_TEN", tapHuanDiaDiem.TH_DD_TK_TEN}
            };
            ExportHelper.exportWord(dataPrint, "DiaDiemToChuc_ThanhLy.doc");
        }

        private void btnExportTDVExcel_Click(object sender, EventArgs e)
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang xuất excel...", "Xin vui lòng chờ giây lát");
            try
            {

                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbooks books = excel.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook excelBook = null;
                Microsoft.Office.Interop.Excel.Worksheet excelSheet = null;

                excel.DisplayAlerts = false;
                excel.StandardFont = "Times New Roman";
                excel.StandardFontSize = 12;
                excelBook = books.Add(Application.StartupPath + "\\Template\\TapHuan_DanhSachTDV.xlt");
                //excel.Visible = true;

                int rowStart = 10;
                int row = rowStart;

                int stt = 1;

                int colSTT = 1;
                int colHoten = 2;
                int colDiaChi = 3;

                //int _rowMergeStart = 0;
                //Decimal _tongTien = 0;
                excel.ActiveWindow.Caption = "DanhSachThamDuVien";
                excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets[1];
               
                //data
                string[] idStringList = memoDoiTuongId.Text.Split(new[] { "; " }, StringSplitOptions.None);
                List<Int64> idList = new List<long>();
                foreach (var id in idStringList)
                {
                    idList.Add(Convert.ToInt64(id));
                }

                var hoivienList = context.QL_HOIVIEN.Where(p => idList.Contains(p.HV_ID)).OrderBy(p=>p.HV_TEN).ToList();
                foreach (var item in hoivienList)
                {
                    object cell = excelSheet.Cells[row, colSTT];
                    excelSheet.get_Range(cell, cell).Value = stt;

                    cell = excelSheet.Cells[row, colHoten];
                    excelSheet.get_Range(cell, cell).Value = item.HV_HO + " " + item.HV_TEN ;

                    cell = excelSheet.Cells[row, colDiaChi];
                    excelSheet.get_Range(cell, cell).Value = item.HV_THUONGTRU_DIACHI;

                    cell = excelSheet.Cells[row + 1, colSTT];
                    Microsoft.Office.Interop.Excel.Range decoy = excelSheet.get_Range(cell, cell);
                    decoy.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                    row++;
                    stt++;
                }

                foreach (var item in listDoiTuongKhongKhuyetTat.OrderBy(p=>p.TH_CT_TEN))
                {
                    object cell = excelSheet.Cells[row, colSTT];
                    excelSheet.get_Range(cell, cell).Value = stt;

                    cell = excelSheet.Cells[row, colHoten];
                    excelSheet.get_Range(cell, cell).Value = item.TH_CT_HO + " " + item.TH_CT_TEN;

                    cell = excelSheet.Cells[row, colDiaChi];
                    excelSheet.get_Range(cell, cell).Value = item.TH_CT_DIACHI;

                    cell = excelSheet.Cells[row + 1, colSTT];
                    Microsoft.Office.Interop.Excel.Range decoy = excelSheet.get_Range(cell, cell);
                    decoy.EntireRow.Insert(Microsoft.Office.Interop.Excel.XlInsertShiftDirection.xlShiftDown);
                    row++;
                    stt++;
                }

                //excel.get_Range((object)excel.Cells[rowStart, colHoten], (object)excel.Cells[row, colDiaChi]).WrapText = true;
                excel.get_Range((object)excel.Cells[rowStart, colHoten], (object)excel.Cells[row, colDiaChi]).EntireColumn.AutoFit();
                //string SoYTe = _cLoader.GetStringConfig("parentcompany.name");
                //string BenhVien = _cLoader.GetStringConfig("company.name");
                //excel.Cells[1, 1] = SoYTe.ToUpper();
                //excel.Cells[2, 1] = BenhVien.ToUpper();

                //excel.Cells[5, 1] = String.Format("Từ ngày {0:dd/MM/yyy HH:ss:mm} đến ngày {1:dd/MM/yyy HH:ss:mm}", deTuNgay.DateTime, deDenNgay.DateTime);
                //excel.Cells[6, 1] = Convert.ToInt32(rdHinhThucDT.EditValue) == 1 ? "HÌNH THỨC ĐIỀU TRỊ NỘI TRÚ" : "HÌNH THỨC ĐIỀU TRỊ NGOẠI TRÚ";
                //foreach (var bn in _presenter._listBenhNhan)
                //{
                //    _wait.Caption = string.Format("Đang xuất bệnh nhân {0}/{1}", _stt, _presenter._listBenhNhan.Count());
                //    excel.Cells[_row, 1] = _stt++;
                //    excel.Cells[_row, 2] = "'" + bn.DOTKHAM_SOKHAMBENH;
                //    excel.Cells[_row, 3] = bn.BN_HOTEN;
                //    excel.Cells[_row, 4] = bn.VAOKHOA_KHOA;
                //    //In dòng sản phẩm
                //    _row++;
                //    _rowMergeStart = _row;
                //    //Hiển thị tiêu đề
                //    excel.Cells[_row, 5] = "Tên thuốc nồng độ hàm lượng";
                //    excel.Cells[_row, 6] = "Số lượng";
                //    excel.Cells[_row, 7] = "Đơn vị tính";
                //    excel.Cells[_row, 8] = "Đơn giá";
                //    excel.Cells[_row, 9] = "Thành tiền";

                //    excel.get_Range((object)excel.Cells[_row, 5], (object)excel.Cells[_row, 9]).Font.Bold = true;
                //    //excel.get_Range((object)excel.Cells[_row, 5], (object)excel.Cells[_row, 9]).VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                //    foreach (var item in _presenter._listData.Where(k => k.DOTKHAM_ID == bn.DOTKHAM_ID))
                //    {
                //        _row++;
                //        excel.Cells[_row, 5] = item.SANPHAM_TEN;
                //        excel.Cells[_row, 6] = item.SANPHAM_SOLUONG;
                //        excel.Cells[_row, 7] = item.SANPHAM_DVT;
                //        excel.Cells[_row, 8] = item.SANPHAM_DONGIA;
                //        excel.Cells[_row, 9] = item.SANPHAM_THANHTIEN;
                //        _tongTien += item.SANPHAM_THANHTIEN;
                //    }

                //    excel.get_Range((object)excel.Cells[_rowMergeStart, 1], (object)excel.Cells[_row, 4]).Merge();
                //    _row++;
                //}

                //excel.get_Range((object)excel.Cells[9, 1], (object)excel.Cells[_row, 4]).Borders.Value = 1;
                //excel.get_Range((object)excel.Cells[10, 5], (object)excel.Cells[_row, 9]).Borders.Value = 1;
                //excel.get_Range((object)excel.Cells[9, 2], (object)excel.Cells[_row, 9]).EntireColumn.AutoFit();
                ////Dòng tổng
                //excel.get_Range((object)excel.Cells[_row, 1], (object)excel.Cells[_row, 4]).Merge();

                //excel.Cells[_row, 1] = "Tổng cộng:";
                //excel.Cells[_row, 9] = string.Format("=SUM(I9:I{0})", _row - 1);

                //excel.Cells[_row + 1, 1] = "THÀNH TIỀN BẲNG CHỮ: " + Math.Round(_tongTien, 0).ChangeNum2VNStr(",");
                //excel.get_Range((object)excel.Cells[_row + 1, 1], (object)excel.Cells[_row + 1, 1]).Font.Bold = true;

                //_row = _row + 2;
                //excel.Cells[_row, 5] = string.Format("Ngày {0} tháng {1} năm {2}", _dateServer.Day, _dateServer.Month, _dateServer.Year);
                //excel.get_Range((object)excel.Cells[_row, 5], (object)excel.Cells[_row, 8]).Merge();

                //excel.Cells[_row + 1, 5] = "Lập bảng";
                //excel.get_Range((object)excel.Cells[_row + 1, 5], (object)excel.Cells[_row + 1, 8]).Merge();

                //excel.get_Range((object)excel.Cells[_row, 5], (object)excel.Cells[_row + 1, 9]).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                _wait.Close();
                excel.Visible = true;
            }
            catch (Exception)
            {
                _wait.Close();
                
            }
        }

        #endregion
    }
}
