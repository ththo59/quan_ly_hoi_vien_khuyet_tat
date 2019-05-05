using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System.Diagnostics;
using DauThau.Class;
using DauThau.Reports;
using DevExpress.Utils;
using DauThau.Models;
using System.Linq;
using System.Data.Entity;

namespace DauThau.UserControlCategory
{
    public partial class ucBCHoatDongViecLam : ucBase
    {
        XtraReport rptGlobal = new XtraReport();
        public ucBCHoatDongViecLam()
        {
            InitializeComponent();
        }

        private void ucBCHoatDongViecLam_Load(object sender, EventArgs e)
        {
            registerButtonArray(btnControl);
            LibraryDev.PermissionButton(btnControl, previewBar1);

            deTuNgay.Ex_FormatCustomDateEdit();
            deDenNgay.Ex_FormatCustomDateEdit();

            var current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var nextMonth = current.AddMonths(1);
            deTuNgay.DateTime = current;
            deDenNgay.DateTime = nextMonth.AddDays(-1);

            _loadData();
        }

        #region Function

        private void _print()
        {
            try
            {
                rptGlobal.Print();
            }
            catch (Exception)
            {

            }
        }

        private void _loadData()
        {
            WaitDialogForm _wait = new WaitDialogForm("Đang tải dữ liệu ...", "Vui lòng đợi giây lát");
            context = new QL_HOIVIEN_KTEntities();
            context.QL_HOATDONG_DAYNGHE.Load();
            //Dạy nghề
            var data = (from p in context.QL_HOATDONG_DAYNGHE
                        where deTuNgay.DateTime.Date <= p.DN_THOIGIAN_BATDAU
                             && p.DN_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                        select p).ToList();

            List<clsTongKetHoatDong> lists = new List<clsTongKetHoatDong>();
            foreach (QL_HOATDONG_DAYNGHE row in data)
            {
                clsTongKetHoatDong item = new clsTongKetHoatDong();
                item.HD_ID = row.DN_ID;
                item.HD_TEN = row.DN_NGHE;
                item.HD_THOIGIAN_BATDAU = row.DN_THOIGIAN_BATDAU;
                item.HD_THOIGIAN_KETTHUC = row.DN_THOIGIAN_KETTHUC;
                item.HD_DIADIEM = row.DN_DIADIEM;
                item.HD_SONGUOI_THAMGIA = row.DN_SOLUONG_NU??0;
                item.HD_SONGUOI_NU_TONGSO = string.Format("{0}/{1}", row.DN_SOLUONG_NU, row.DN_SOLUONG);
                item.HD_THOIGIAN = FunctionHelper.formatFromDateToDate(row.DN_THOIGIAN_BATDAU, row.DN_THOIGIAN_KETTHUC);
                item.HD_LOAI_STT = 1;
                item.HD_LOAI = "Việc làm";
                item.HD_NOIDUNG = row.DN_NOIDUNG;
                lists.Add(item);
            }

            //Giai quyet viẹc lam
            context.QL_HOATDONG_VIECLAM.Load();
            var listDMViecLam = FuncCategory.loadDMViecLam();
            var dataViecLam = (from p in context.QL_HOATDONG_VIECLAM
                    where deTuNgay.DateTime.Date <= p.VL_THOIGIAN_BATDAU
                             && p.VL_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                        select p).ToList();

            foreach (QL_HOATDONG_VIECLAM row in dataViecLam)
            {
                clsTongKetHoatDong item = new clsTongKetHoatDong();
                item.HD_ID = row.VL_ID;
                item.HD_TEN = row.VL_TEN;
                item.HD_THOIGIAN_BATDAU = row.VL_THOIGIAN_BATDAU;
                item.HD_THOIGIAN_KETTHUC = row.VL_THOIGIAN_KETTHUC;
                item.HD_DIADIEM = row.VL_DIADIEM;
                item.HD_SONGUOI_THAMGIA = row.VL_SOLUONG_NU ?? 0;
                item.HD_SONGUOI_NU_TONGSO = string.Format("{0}/{1}", row.VL_SOLUONG_NU, row.VL_SOLUONG);
                item.HD_THOIGIAN = FunctionHelper.formatFromDateToDate(row.VL_THOIGIAN_BATDAU, row.VL_THOIGIAN_KETTHUC);
                var dm = listDMViecLam.Where(p => p.ID == row.VL_LOAI_ID).FirstOrDefault();
                if (dm != null)
                {
                    item.HD_LOAI_STT = 2;
                    item.HD_LOAI = dm.NAME;
                }
                item.HD_NOIDUNG = row.VL_NOIDUNG;
                lists.Add(item);
            }

            //vay vốn
            context.QL_HOATDONG_VIECLAM.Load();
            var dataVayVon = (from p in context.QL_HOATDONG_VAYVON
                               where deTuNgay.DateTime.Date <= p.VV_THOIGIAN_BATDAU
                                        && p.VV_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                               select p).ToList();

            foreach (QL_HOATDONG_VAYVON row in dataVayVon)
            {
                clsTongKetHoatDong item = new clsTongKetHoatDong();
                item.HD_ID = row.VV_ID;
                item.HD_TEN = row.VV_TEN;
                item.HD_THOIGIAN_BATDAU = row.VV_THOIGIAN_BATDAU;
                item.HD_THOIGIAN_KETTHUC = row.VV_THOIGIAN_KETTHUC;
                item.HD_DIADIEM = row.VV_DIADIEM;
                item.HD_SONGUOI_THAMGIA = row.VV_SOLUONG_NU ?? 0;
                item.HD_SONGUOI_NU_TONGSO = string.Format("{0}/{1}", row.VV_SOLUONG_NU, row.VV_SOLUONG);
                item.HD_THOIGIAN = FunctionHelper.formatFromDateToDate(row.VV_THOIGIAN_BATDAU, row.VV_THOIGIAN_KETTHUC);
                item.HD_LOAI_STT = 3;
                item.HD_LOAI = "Vay vốn nhỏ tự mưu sinh";
                item.HD_NOIDUNG = row.VV_NOIDUNG;
                lists.Add(item);
            }

            //hội trợ triễn lãm
            context.QL_HOATDONG_HOICHO_TRIENLAM.Load();
            var dataHoiCho = (from p in context.QL_HOATDONG_HOICHO_TRIENLAM
                              where deTuNgay.DateTime.Date <= p.HC_THOIGIAN_BATDAU
                                       && p.HC_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                              select p).ToList();

            foreach (QL_HOATDONG_HOICHO_TRIENLAM row in dataHoiCho)
            {
                clsTongKetHoatDong item = new clsTongKetHoatDong();
                item.HD_ID = row.HC_ID;
                item.HD_TEN = row.HC_TEN;
                item.HD_THOIGIAN_BATDAU = row.HC_THOIGIAN_BATDAU;
                item.HD_THOIGIAN_KETTHUC = row.HC_THOIGIAN_KETTHUC;
                item.HD_DIADIEM = row.HC_DIADIEM;
                item.HD_SONGUOI_THAMGIA = row.HC_SOLUONG_NU ?? 0;
                item.HD_SONGUOI_NU_TONGSO = string.Format("{0}/{1}", row.HC_SOLUONG_NU, row.HC_SOLUONG);
                item.HD_THOIGIAN = FunctionHelper.formatFromDateToDate(row.HC_THOIGIAN_BATDAU, row.HC_THOIGIAN_KETTHUC);
                item.HD_LOAI_STT = 4;
                item.HD_LOAI = "Hội chợ triễn lãm, thi tay nghề";
                item.HD_NOIDUNG = row.HC_NOIDUNG;
                lists.Add(item);
            }

            rptBCTongKetHoatDong_ViecLam rpt = new rptBCTongKetHoatDong_ViecLam();
            string tableName = "TongKetHoatDong";
            DataTable dataPrint = FunctionHelper.ConvertToDataTable(lists);
            dataPrint.TableName = tableName;

            rpt.pLeftHeader.Value = clsParameter.pHospital;
            rpt.pParentLeftHeader.Value = clsParameter.pParentHospital;
            rpt.pTuNgayDenNgay.Value = FunctionHelper.formatFromDateToDate(deTuNgay.DateTime, deDenNgay.DateTime);
            //rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM10);
            //rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM10);

            rpt.DataSource = dataPrint;
            rpt.DataMember = tableName;
            printControl.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument(true);

            rptGlobal = rpt;
            _wait.Close();
        }

        #endregion

        protected override EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.PRINT)
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
                else if (_formStatus == EnumFormStatus.REPORT)
                {
                    _loadData();
                }
                else
                {

                }
            }
        }

        private void StartProcess(string path)
        {
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = path;
                proc.Start();
                proc.WaitForInputIdle();
            }
            catch (Exception)
            {
                // SimpleMessage.ShowSimpleMessage(ex, "In danh sách dự trù");
            }
        }

    }
}
