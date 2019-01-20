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
                        clsMessage.MessageWarning("Vui lòng cấu hình link...");
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
            clsAddTab.AddTabControl(TabControlParent, new ucDmXa(), "ucDmXa", "Phường, xã");
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

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}