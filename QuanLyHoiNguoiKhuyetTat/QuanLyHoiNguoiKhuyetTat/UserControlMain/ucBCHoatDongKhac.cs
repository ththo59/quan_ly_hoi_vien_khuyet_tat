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
    public partial class ucBCHoatDongKhac : ucBase
    {
        XtraReport rptGlobal = new XtraReport();
        public ucBCHoatDongKhac()
        {
            InitializeComponent();
        }

        private void ucBCHoatDongKhac_Load(object sender, EventArgs e)
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
            context.QL_HOATDONG_KHAC.Load();

            var data = (from p in context.QL_HOATDONG_KHAC
                        where deTuNgay.DateTime.Date <= p.KHAC_THOIGIAN_BATDAU
                             && p.KHAC_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                        select p).ToList();

            List<clsTongKetHoatDong> lists = new List<clsTongKetHoatDong>();
            foreach (QL_HOATDONG_KHAC row in data)
            {
                clsTongKetHoatDong item = new clsTongKetHoatDong();
                item.HD_ID = row.KHAC_ID;
                item.HD_TEN = row.KHAC_TEN;
                item.HD_THOIGIAN_BATDAU = row.KHAC_THOIGIAN_BATDAU;
                item.HD_THOIGIAN_KETTHUC = row.KHAC_THOIGIAN_KETTHUC;
                item.HD_THOIGIAN = FunctionHelper.formatFromDateToDate(row.KHAC_THOIGIAN_BATDAU, row.KHAC_THOIGIAN_KETTHUC);
                item.HD_LOAI = row.KHAC_TEN_HOATDONG;
                item.HD_NOIDUNG = row.KHAC_NOIDUNG;
                lists.Add(item);
            }

            rptBCTongKetHoatDong_Khac rpt = new rptBCTongKetHoatDong_Khac();
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
