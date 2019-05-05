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
    public partial class ucBCHoatDongHoaNhapXaHoi : ucBase
    {
        XtraReport rptGlobal = new XtraReport();
        public ucBCHoatDongHoaNhapXaHoi()
        {
            InitializeComponent();
        }

        private void ucBCHoatDongHoaNhapXaHoi_Load(object sender, EventArgs e)
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
            context.QL_HOATDONG_HNXH.Load();
            var listDMHoiThao = FuncCategory.loadDMHNXH();

            var data = (from p in context.QL_HOATDONG_HNXH
                        where deTuNgay.DateTime.Date <= p.HNXH_THOIGIAN_BATDAU
                             && p.HNXH_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                        select p).ToList();

            List<clsTongKetHoatDong> lists = new List<clsTongKetHoatDong>();
            foreach (QL_HOATDONG_HNXH row in data)
            {
                clsTongKetHoatDong item = new clsTongKetHoatDong();
                item.HD_ID = row.HNXH_ID;
                item.HD_TEN = row.HNXH_TEN;
                item.HD_THOIGIAN_BATDAU = row.HNXH_THOIGIAN_BATDAU;
                item.HD_THOIGIAN_KETTHUC = row.HNXH_THOIGIAN_KETTHUC;
                item.HD_DIADIEM = row.HNXH_DIADIEM;
                item.HD_SONGUOI_THAMGIA = row.HNXH_SOLUONG??0;
                item.HD_THOIGIAN = FunctionHelper.formatFromDateToDate(row.HNXH_THOIGIAN_BATDAU, row.HNXH_THOIGIAN_KETTHUC);
                var dm = listDMHoiThao.Where(p => p.ID == row.HNXH_LOAI_ID).First();
                if(dm != null)
                {
                    item.HD_LOAI_STT = dm.STT;
                    item.HD_LOAI = dm.NAME;
                }
                item.HD_NOIDUNG = row.HNXH_NOIDUNG;
                lists.Add(item);
            }

            rptBCTongKetHoatDong_HoaNhapXaHoi rpt = new rptBCTongKetHoatDong_HoaNhapXaHoi();
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
