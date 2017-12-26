﻿using System;
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

         private void btnLyLich_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucLyLich(), "ucLyLich", "Cập nhật lý lịch hội viên", this);
        }

        private void btnNapExcels_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmExcelsManager frm = new frmExcelsManager();
            frm.ShowDialog();
        }

        private void btnHoatDongHoiThaoASXH_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucHoatDongHoiThaoTapHuan(), "ucHoatDongHoiThaoTapHuan", "Tập huấn - hội thảo - an sinh xã hội", this);
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

        private void btnTinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucDmTinh(), "ucDmTinh", "Thành phố, tỉnh");
        }

        private void btnHuyen_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucDmHuyen(), "ucDmHuyen", "Quận, huyện");
        }

        private void btnXa_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucDmXa(), "ucDmXa", "Phường, xã");
        }

        private void btnBCLyLich_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucBCLyLich(), "ucBCLyLich", "In lý lịch hội viên");
        }

        private void btnBCLyLichTheoDieuKien_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucBCTheoNhieuDieuKien(), "ucBCTheoNhieuDieuKien", "Báo cáo Lý lịch hội viên theo điều kiện");
        }

        private void btnBCHoatDong_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucBCHoatDong(), "ucBCHoatDong", "Báo cáo hoạt động");
        }

        private void btnCP_SoQuyTienMat_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucBCChiPhi_SoQuyTienMat(), "ucBCChiPhi_SoQuyTienMat", "Sổ quỷ tiền mặt");
        }

        private void btnBMLyLich_ItemClick(object sender, ItemClickEventArgs e)
        {
            rptBM_LyLichHoiVien rpt = new rptBM_LyLichHoiVien();
            clsAddTab.AddTabControl(TabControlParent, new ucPrint(rpt), "ucBM_LyLich", "Biểu mẫu lý lịch");
        }

        private void btnDonGiaNhapHoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            rptBM_DonGiaNhapHoi rpt = new rptBM_DonGiaNhapHoi();
            clsAddTab.AddTabControl(TabControlParent, new ucPrint(rpt), "ucBM_DonGiaNhapHoi", "Đơn xin gia nhập hội");
        }

        private void btnTrinhDoHocVan_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucDMTrinhDoHocVan(), "ucDMTrinhDoHocVan", "Trình độ học vấn");
        }

        private void btnTrinhDoChuyenMon_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucDMTrinhDoChuyenMon(), "ucDMTrinhDoChuyenMon", "Trình độ chuyên môn");
        }

        private void btnNgheNghiep_ItemClick(object sender, ItemClickEventArgs e)
        {
            clsAddTab.AddTabControl(TabControlParent, new ucDMNgheNghiep(), "ucDMNgheNghiep", "Nghề nghiệp");
        }
    }
}