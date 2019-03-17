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
    public partial class ucBCHoiVienTongNKTTheoTrinhDoHocVan : ucBase
    {
        XtraReport rptGlobal = new XtraReport();
        public ucBCHoiVienTongNKTTheoTrinhDoHocVan()
        {
            InitializeComponent();
        }

        private void ucBCHoiVienTongNKTTheoTrinhDoHocVan_Load(object sender, EventArgs e)
        {
            registerButtonArray(btnControl);

            FuncCategory.loadCategoryByName(CategoryEntitiesTable.DM_TINH, lueThanhPho);
            LibraryDev.PermissionButton(btnControl, previewBar1);
            lueThanhPho.Properties.PopupFormMinSize = lueThanhPho.Size;
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
            context.QL_HOIVIEN.Load();
            string strPhuong = luePhuong.EditValue + string.Empty;
            string strQuan = lueQuan.EditValue + string.Empty;
            string strThanhPho = lueThanhPho.EditValue + string.Empty;
            var data = (from p in context.QL_HOIVIEN
                        where (strPhuong != "" ? p.HV_THUONGTRU_PHUONG == strPhuong : true)
                        && (strQuan != "" ? p.HV_THUONGTRU_QUAN == strQuan : true)
                        && (strThanhPho != "" ? p.HV_THUONGTRU_TP == strThanhPho : true)
                        select p).ToList();

            rptBCHoiVien_NKTTheoTrinhDoHocVan rpt = new rptBCHoiVien_NKTTheoTrinhDoHocVan();
            string tableName = "HOI_VIEN";
            DataTable dataPrint = FunctionHelper.ConvertToDataTable(data);
            dataPrint.TableName = tableName;

            rpt.pLeftHeader.Value = clsParameter.pHospital;
            rpt.pParentLeftHeader.Value = clsParameter.pParentHospital;
            rpt.pTitle.Value = lueQuan.Text;
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

        private void lueThanhPho_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMHuyen(lueQuan, lueThanhPho.EditValue + string.Empty);
        }

        private void lueQuan_EditValueChanged(object sender, EventArgs e)
        {
            FuncCategory.loadDMXa(luePhuong, lueQuan.EditValue + string.Empty);
            luePhuong.EditValue = null;
        }

        private void luePhuong_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)
            {
                luePhuong.EditValue = null;
            }
        }
    }
}
