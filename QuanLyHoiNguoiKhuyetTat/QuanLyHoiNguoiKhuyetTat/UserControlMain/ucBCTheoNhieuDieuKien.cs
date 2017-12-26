using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using DauThau.Reports;
using DauThau.Class;
using System.Data.SqlClient;
using DevExpress.Utils;
using CuscLibrary.Offices;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucBCTheoNhieuDieuKien : DevExpress.XtraEditors.XtraUserControl
    {
        public ucBCTheoNhieuDieuKien()
        {
            InitializeComponent();
        }

        private void gvBand_RowCountChanged(object sender, EventArgs e)
        {
            btnControl.btnExcel.Enabled = gvBand.RowCount > 0;
        }

        private void ucBCTheoNhieuDieuKien_Load(object sender, EventArgs e)
        {
            //lueCongTy.Properties.DataSource = FunctionHelper.LoadDM("select * from DM_CONGTY where DOT_MA='" + clsParameter._dotMaDauThau + "'");
            //lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();

            //FormHelper.LookUpEdit_Init(lueCongTy);
            //FormHelper.LookUpEdit_Init(lueGoiThau);

            //btnControl.btnExcel.Enabled = false;
            //List<object> _list = new List<object>();
            //object item1 = new
            //{
            //    Id = "Có",
            //    Ten = "Có"
            //};
            //_list.Add(item1);
            //object item2 = new
            //{
            //    Id = "Không",
            //    Ten = "Không"
            //};
            //_list.Add(item2);

            //lueICH.Properties.DataSource = _list;
        }

        void ClearEditValue(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            LookUpEdit lue = sender as LookUpEdit;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
                lue.EditValue = null;
        }

        private void lueCongTy_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ClearEditValue(sender,e);
        }

        private void lueICH_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ClearEditValue(sender, e);
        }

        private void btnControl_btnEventExcel_Click(object sender, EventArgs e)
        {
            ExportExcel("BÁO CÁO THEO NHIỀU ĐIỀU KIỆN", string.Empty, gvBand, string.Empty);
        }

       

        void ExportExcel(String Title, string RangeTime, BandedGridView table, string formatNumber)
        {
            DevExpress.Utils.WaitDialogForm waitDialogForm = new DevExpress.Utils.WaitDialogForm("Đang xuất excel ...", "Vui lòng chờ giây lát !");
            try
            {
                ExcelManager excelManager = new ExcelManager(true);

                // Print band header
                BandedGridView view = table;
                view.ExpandAllGroups();
                object[] data = new object[view.VisibleColumns.Count];
                excelManager.BandedGridHeader2Excel(view, false, 8, 1, "headerRangeName");
                excelManager.SetTitleRows();
                excelManager.SelectRange()
                           .SetFontFamily("Times New Roman");

                waitDialogForm.SetCaption(String.Format("{0} - {1}%", "Đang xuất excel ...", 50));

                excelManager.GridData2Excel(table, 9, 1, false, false, "", false, false);

                excelManager.SelectRange(excelManager.WorkingRange.Row + excelManager.WorkingRange.Rows.Count, excelManager.WorkingRange.Column,
                    excelManager.WorkingRange.Row + excelManager.WorkingRange.Rows.Count, excelManager.WorkingRange.Column + excelManager.WorkingRange.Columns.Count - 1);


                // Save working range
                excelManager.MoveRange(2, 0);
                //int maxCol = 12;
                //int xtraCol = 2;

                int sr = excelManager.WorkingRange.Row + 1;
                int sc = excelManager.WorkingRange.Column;
                int er = excelManager.WorkingRange.Row + 1;
                int ec = excelManager.WorkingRange.Column + excelManager.WorkingRange.Columns.Count - 1;

                //excelManager.SelectRange(8, 1, 8, maxCol).SetRowHeight("", 45);

                ////Dòng Title
                excelManager
                    .SelectRange(1, 1, 1, 4)
                    .Merge()
                    .SetFontStyle(true, false, false)
                    .SetFontSize(12)
                    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                    .SetRangeValue(clsParameter.pParentHospital);

                excelManager
                    .SelectRange(2, 1, 2, 4)
                    .Merge()
                    .SetFontStyle(false, false, false)
                    .SetFontSize(12)
                    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                    .SetRangeValue(clsParameter.pHospital);

                excelManager
                     .SelectRange(1, 11, 1, ec)
                     .Merge()
                     .SetFontStyle(true, false, false)
                     .SetFontSize(12)
                     .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                     .SetRangeValue("CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM");
                excelManager
                     .SelectRange(2, 11, 2, ec)
                     .Merge()
                     .SetFontStyle(true, false, false)
                     .SetFontSize(12)
                     .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                     .SetRangeValue("Độc lập - Tự do - Hạnh phúc");

                excelManager
                    .SelectRange(5, 1, 5, ec)
                    .Merge()
                    .SetFontStyle(true, false, false)
                    .SetFontSize(16)
                    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                    .SetRangeValue(Title);

                //excelManager
                //    .SelectRange(6, 1, 6, ec)
                //    .Merge()
                //    .SetFontStyle(true, false, false)
                //    .SetFontSize(14)
                //    .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                //    .SetRangeValue("Gói thầu: " + lueGoiThau.Text);

                if (RangeTime != string.Empty)
                    excelManager
                        .SelectRange(9, 1, 9, ec)
                        .Merge()
                        .SetFontStyle(true, false, false)
                        .SetFontSize(12)
                        .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter)
                        .SetRangeValue(RangeTime);

                excelManager.SelectRange(10, 2, er, ec).AutoFitColumn();
                excelManager.SelectRange(10, 2, er, ec).SetNumberFormat("#,#0");
                excelManager
                .SelectRange(er - 2, ec - 3, er - 2, ec - 3)
                .Merge()
                .SetFontStyle(false, false, false)
                .SetFontSize(12)
                .SetHorizontalAlignment(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft)
                .SetRangeValue(string.Format("Ngày {0} tháng {1} năm {2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));



            }
            catch (Exception)
            {
                XtraMessageBox.Show("Lỗi trong quá trình xuất Excel.\nVui lòng kiểm tra lại biểu mẫu hoặc tài liệu đang mở.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Marshal.ReleaseComObject(excelSheet);
                //Marshal.ReleaseComObject(excelBook);
                //Marshal.ReleaseComObject(books);
                //Marshal.ReleaseComObject(excel);

                waitDialogForm.Close();
            }
        }
    }
}
