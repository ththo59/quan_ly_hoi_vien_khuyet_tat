﻿using System;
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
    public partial class ucBCHoatDongASXH : ucBase
    {
        XtraReport rptGlobal = new XtraReport();
        public ucBCHoatDongASXH()
        {
            InitializeComponent();
        }

        private void ucBCHoatDongASXH_Load(object sender, EventArgs e)
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
            context.QL_HOATDONG_ASXH.Load();
            var listDMHoiThao = FuncCategory.loadDMASXH();

            var data = (from p in context.QL_HOATDONG_ASXH
                        where deTuNgay.DateTime.Date <= p.ASXH_THOIGIAN_BATDAU
                             && p.ASXH_THOIGIAN_BATDAU <= deDenNgay.DateTime.Date
                        select p).ToList();

            List<clsTongKetHoatDong> lists = new List<clsTongKetHoatDong>();
            foreach (QL_HOATDONG_ASXH row in data)
            {
                clsTongKetHoatDong item = new clsTongKetHoatDong();
                item.HD_ID = row.ASXH_ID;
                item.HD_TEN = row.ASXH_TEN;
                item.HD_THOIGIAN_BATDAU = row.ASXH_THOIGIAN_BATDAU;
                item.HD_THOIGIAN_KETTHUC = row.ASXH_THOIGIAN_KETTHUC;
                item.HD_THOIGIAN = FunctionHelper.formatFromDateToDate(row.ASXH_THOIGIAN_BATDAU, row.ASXH_THOIGIAN_KETTHUC);
                var dm = listDMHoiThao.Where(p => p.ID == row.ASXH_LOAI_ID).First();
                if(dm != null)
                {
                    item.HD_LOAI = dm.NAME;
                }
                item.HD_NOIDUNG = row.ASXH_NOIDUNG;
                lists.Add(item);
            }

            rptBCTongKetHoatDong_ASXH rpt = new rptBCTongKetHoatDong_ASXH();
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