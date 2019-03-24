using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DauThau.UserControlCategory;
using DauThau.Class;
using DauThau.Forms;
using System.Data.SqlClient;
using DevExpress.XtraTab;
using DauThau.Reports;
using DevExpress.XtraEditors;
using DauThau.UserControlCategoryMain;
using DevExpress.Utils;
using System.Linq;
using DevExpress.XtraBars.Ribbon;

namespace DauThau
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            
        }

        private void TabControlParent_CloseButtonClick(object sender, EventArgs e)
        {
            closeTabCurrent();
        }

        public void closeTabCurrent()
        {
            try
            {
                TabControlParent.TabPages.RemoveAt(TabControlParent.SelectedTabPageIndex);
            }
            catch (Exception)
            {

            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //clsConnection.OpenConn();
            this.ribbonStatusBar.ItemLinks.Add(clsParameter._barStaticLogin);
            barVersion.Caption = clsBuildClickOne.getVersion();
            String[] btnIngore = new String[] { "btnNapExcels" };
            foreach (var obj in ribbonMain.Items)
            {
                BarButtonItem items = obj as BarButtonItem;
                if (items == null || btnIngore.Contains(items.Name))
                {
                    continue;
                }
                items.ItemClick += new ItemClickEventHandler(this.event_ItemClick);
            }
        }

        private void event_ItemClick(object sender, ItemClickEventArgs e)
        {
            BarButtonItem item = e.Item as BarButtonItem;
            if(item != null)
            {
                ucBase uc = new ucBase();
                switch (item.Name)
                {
                    #region Danh mục
                    case "btnTinh":
                        uc = new ucDmTinh();
                        break;
                    case "btnHuyen":
                        uc = new ucDmHuyen();
                        break;
                    case "btnXa":
                        uc = new ucDmXa();
                        break;
                    case "btnTrinhDoHocVan":
                        uc = new ucDMTrinhDoHocVan();
                        break;
                    case "btnTrinhDoChuyenMon":
                        uc = new ucDMTrinhDoChuyenMon();
                        break;
                    case "btnNgheNghiep":
                        uc = new ucDMNgheNghiep();
                        break;
                        #endregion
                        
                    case "btnLyLich":
                        uc = new ucLyLich();
                        break;

                    #region Tập huấn

                    case "btnTapHuan":
                        uc = new ucHoatDongTapHuan((Int64)CategoryTapHuan.TH_TAPHUAN);
                        break;
                    case "btnGiaoDuc":
                        uc = new ucHoatDongTapHuan((Int64)CategoryTapHuan.TH_GIAODUC);
                        break;
                    case "btnHuongDanThucTap":
                        uc = new ucHoatDongTapHuan((Int64)CategoryTapHuan.HUONG_DAN_THUC_TAP);
                        break;
                    case "btnVanDongChinhSach":
                        uc = new ucHoatDongTapHuan((Int64)CategoryTapHuan.VAN_DONG_CHINH_SACH);
                        break;
                     case "btnTruyenThongPhapLy":
                        uc = new ucHoatDongTapHuan((Int64)CategoryTapHuan.TRUYEN_THONG_PHAP_LY);
                        break;

                    #endregion

                    #region Đại hội - hội nghị

                    case "btnDaiHoi":
                        uc = new ucHoatDongHoiThao((Int64)CategoryHoiThao.DAI_HOI);
                        break;
                    case "btnHoiNghi":
                        uc = new ucHoatDongHoiThao((Int64)CategoryHoiThao.HOI_NGHI);
                        break;
                    case "btnHoiThao":
                        uc = new ucHoatDongHoiThao((Int64)CategoryHoiThao.HOI_THAO);
                        break;
                    case "btnBuoiLe":
                        uc = new ucHoatDongHoiThao((Int64)CategoryHoiThao.BUOI_LE);
                        break;
                    case "btnCuocHop":
                        uc = new ucHoatDongHoiThao((Int64)CategoryHoiThao.CUOC_HOP);
                        break;
                    case "btnTruyenThongDaiChung":
                        uc = new ucHoatDongHoiThao((Int64)CategoryHoiThao.TRUYEN_THONG_DAI_CHUNG);
                        break;
                    case "btnToChucSuKien":
                        uc = new ucHoatDongHoiThao((Int64)CategoryHoiThao.TO_CHUC_SU_KIEN);
                        break;
                    case "btnToChucVanNghe":
                        uc = new ucHoatDongHoiThao((Int64)CategoryHoiThao.TO_CHUC_VAN_NGHE);
                        break;

                    #endregion

                    #region ASXH

                    case "btnGiaiPhauChinhHinh":
                        uc = new ucHoatDongASXH((Int64)CategoryASXH.GIAI_PHAU_CHINH_HINH);
                        break;

                    case "btnTangQua":
                        uc = new ucHoatDongASXH((Int64)CategoryASXH.TANG_QUA);
                        break;
                    case "btnTangDungCuTroGiup":
                        uc = new ucHoatDongASXH((Int64)CategoryASXH.TANG_DUNG_CU_TRO_GIUP);
                        break;
                    case "btnHocBong":
                        uc = new ucHoatDongASXH((Int64)CategoryASXH.HOC_BONG);
                        break;
                    case "btnBHYT":
                        uc = new ucHoatDongASXH((Int64)CategoryASXH.BHYT);
                        break;
                    case "btnHoTroHoiVienKK":
                        uc = new ucHoatDongASXH((Int64)CategoryASXH.HO_TRO_HOI_VIEN_KHO_KHAN);
                        break;
                    case "btnThamVieng":
                        uc = new ucHoatDongASXH((Int64)CategoryASXH.THAM_VIENG_HUU_SU);
                        break;
                    case "btnDamCuoi":
                        uc = new ucHoatDongASXH((Int64)CategoryASXH.DAM_CUOI);
                        break;
                    case "btnCatNha":
                        uc = new ucHoatDongASXH((Int64)CategoryASXH.CAT_NHA);
                        break;
                    case "btnSuaNha":
                        uc = new ucHoatDongASXH((Int64)CategoryASXH.SUA_NHA);
                        break;

                    #endregion

                    #region Hòa nhập xã hội
                    case "btnGiaoLuu":
                        uc = new ucHoatDongHNXH((Int64)CategoryHNXH.GIAO_LUU);
                        break;
                    case "btnLienHoan":
                        uc = new ucHoatDongHNXH((Int64)CategoryHNXH.LIEN_HOAN);
                        break;
                    case "btnDonKhach":
                        uc = new ucHoatDongHNXH((Int64)CategoryHNXH.DON_KHACH);
                        break;
                    case "btnThamQuanDuLich":
                        uc = new ucHoatDongHNXH((Int64)CategoryHNXH.THAM_QUAN_DU_LICH);
                        break;
                    case "btnVanNghe":
                        uc = new ucHoatDongHNXH((Int64)CategoryHNXH.VAN_NGHE);
                        break;
                    case "btnTheThao":
                        uc = new ucHoatDongHNXH((Int64)CategoryHNXH.THE_THAO);
                        break;

                    #endregion

                    #region Việc làm
                    case "btnDayNghe":
                        uc = new ucHoatDongDayNghe();
                        break;
                    case "btnGioiThieuViecLam":
                        uc = new ucHoatDongViecLam((Int64)CategoryViecLam.GIOI_THIEU_VIEC_LAM);
                        break;
                    case "btnGiaiQuyetViecLam":
                        uc = new ucHoatDongViecLam((Int64)CategoryViecLam.GIAI_QUYET_VIEC_LAM);
                        break;
                    case "btnVayVon":
                        uc = new ucHoatDongVayVon();
                        break;
                    #endregion

                    #region Báo cáo hội viên

                    case "btnBCLyLichTheoDieuKien":
                        uc = new ucBaoCaoHoiVienTheoDieuKien();
                        break;

                    case "btnTongSoNKTTheoPhuong":
                        uc = new ucBCHoiVienTongNKTTheoPhuong();
                        break;
                        
                    case "btnTongSoNKTTheoDangTat":
                        uc = new ucBCHoiVienTongNKTTheoDangTat();
                        break;
                        
                    case "btnTongSoNKTCoViecLam":
                        uc = new ucBCHoiVienTongNKTCoViecLam();
                        break;

                    case "btnTongSoNKTTheoHocVan":
                        uc = new ucBCHoiVienTongNKTTheoTrinhDoHocVan();
                        break;
                        
                    case "btnTongSoNamNu":
                        uc = new ucBCHoiVienTongNKTTheoNamNu();
                        break;
                        
                    case "btnSoTreKTTu0_8":
                        uc = new ucBCHoiVienTongNKTTheoTuoi(0,8);
                        break;
                        
                    case "btnSoTreKTTu6_18":
                        uc = new ucBCHoiVienTongNKTTheoTuoi(6, 18);
                        break;
                        
                    case "btnSoLuongNKTThamGiaHoatDong":
                        uc = new ucBCHoiVienTongNKTThamGiaHoatDong();
                        break;

                    case "btnSoLuongNKTNhanTCXH":
                        uc = new ucBCHoiVienTongNKTTCXH();
                        break;

                    case "btnPNKTCoGiaDinh":
                        uc = new ucBCHoiVienTongNKTPhuNuCoGiaDinh();
                        break;

                    #endregion

                    #region Báo cáo hoạt động

                    case "btnBCHoatDongNangCaoNhanThuc":
                        uc = new ucBCHoatDongNangCaoNhanThuc();
                        break;

                    #endregion
                    case "btnDonGiaNhapHoi":
                        rptBM_DonGiaNhapHoi rpt = new rptBM_DonGiaNhapHoi();
                        uc = new ucPrint(rpt);
                        break;
                     case "btnBMLyLich":
                        rptBM_LyLichHoiVien rpt2 = new rptBM_LyLichHoiVien();
                        uc = new ucPrint(rpt2);
                        break;

                     #region Báo cáo
                     case "btnBCLyLich":
                        uc = new ucBCLyLich();
                     break;
                    #endregion

                    default:
                        clsMessage.MessageWarning("Chức năng chưa được cấu hình");
                        return;
                }
                clsAddTab.AddTabControl(TabControlParent, uc, item.Name, item.Caption, this);

            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                frmConnectionDatabase _frmConnection = new frmConnectionDatabase();
                _frmConnection.ShowDialog();
            }
        }



        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnKichHoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmActive f = new frmActive();
            f.ShowDialog();
        }

        private void btnCreateKey_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmCreateKey f = new frmCreateKey();
            f.ShowDialog();
        }


        private void btnConfig_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucConfig(), "ucConfig", "Cấu hình hệ thống");
        }

        private void btnConfigSignature_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucConfigReportFooter(), "ucConfigReportFooter", "Cấu hình chữ ký báo cáo.");
        }


        private void btnNapExcels_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmExcelsManager frm = new frmExcelsManager();
            frm.ShowDialog();
        }

      

        private void btnHoatDongTimKiem_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucHoatDongTimKiem(), "ucHoatDongTimKiem", "Tìm kiếm Tập huấn - hội thảo - an sinh xã hội");
        }

        private void btnPhieuThu_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucPhieuThuChi(), "ucPhieuThuChi", "Phiếu thu");
        }

        private void btnPhieuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucPhieuThuChi(true), "ucPhieuThuChi_02", "Phiếu chi");
        }

        private void btnTimKiemPhieuThuChi_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucPhieuThuChiTimKiem(), "ucPhieuThuChiTimKiem", "Tìm kiếm phiếu thu chi");
        }

        private void btnXa_ItemClick(object sender, ItemClickEventArgs e)
        {
            //clsAddTab.AddTabControl(TabControlParent, new ucDmXa(), "ucDmXa", "Phường, xã");
        }

        private void btnBCHoatDong_ItemClick(object sender, ItemClickEventArgs e)
        {
            //clsAddTab.AddTabControl(TabControlParent, new ucBCHoatDong(), "ucBCHoatDong", "Báo cáo hoạt động");
        }

        private void btnCP_SoQuyTienMat_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucBCChiPhi_SoQuyTienMat(), "ucBCChiPhi_SoQuyTienMat", "Sổ quỷ tiền mặt");
        }
    }
}