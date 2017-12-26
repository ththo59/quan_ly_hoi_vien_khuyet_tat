using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DauThau.Class;
using DevExpress.Utils;
using DauThau.Reports;
using System.Linq;
using System.Collections;
using DevExpress.XtraReports.UI;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucTrungThauCongTy : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTrungThauCongTy()
        {
            InitializeComponent();
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

        rptDsCongTyTrungThau rpt;
        public class clsCongTy
        {
            public string CTY_TEN { get; set; }
            public string DIACHI { get; set; }
            public string DIENTHOAI { get; set; }
            public string FAX { get; set; }
            public int COUNT_SP { get; set; }
            public Int64 THANHTIEN {get; set;}
        }
        private void ucTrungThauCongTy_Load(object sender, EventArgs e)
        {
            LibraryDev.PermissionButton(btnControl, previewBar1);

            DataSet ds = new DataSet();
            ds = FunctionHelper.HoSoDauThau(0);
            WaitDialogForm _wait  = new WaitDialogForm("Đang hiển thị dữ liệu ...", "Vui lòng đợi giây lát");
            //DataView dv = ds.Tables[0].DefaultView;
            //dv.RowFilter = "TT=True";

            //DataTable dataCongTyTT = dv.ToTable(true, new string[] { "CTY_TEN", "DIACHI", "DIENTHOAI", "FAX" });
            //dataCongTyTT.TableName = "ChiTietHoSo";

            List<clsCongTy> query = (from p in ds.Tables[0].AsEnumerable()
                                     where p.Field<Boolean>("TT") == true
                                     group p by new { CTY_TEN = p["CTY_TEN"], DIACHI = p["DIACHI"], DIENTHOAI = p["DIENTHOAI"], FAX = p["FAX"] } into grp
                                     select new clsCongTy
                                     {
                                         CTY_TEN = grp.Key.CTY_TEN + string.Empty,
                                         DIACHI = grp.Key.DIACHI + string.Empty,
                                         DIENTHOAI = grp.Key.DIENTHOAI + string.Empty,
                                         FAX = grp.Key.FAX + string.Empty,
                                         COUNT_SP = grp.Count(k => k.Field<Int64>("DAUTHAU_ID") > 0),
                                         THANHTIEN = grp.Sum(k => k.Field<Int64>("THANHTIEN"))
                                     }).ToList();

            DataTable dataCongTyTT = ConvertToDataTable(query);
            dataCongTyTT.TableName = "ChiTietHoSo";

            rpt = new rptDsCongTyTrungThau();
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;
            rpt.pNgayMoThau.Value = clsParameter.pNgayMoThau;

            rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM10);
            rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM10);

            rpt.DataSource = dataCongTyTT;
            rpt.DataMember = "ChiTietHoSo";
            printControl1.PrintingSystem = rpt.PrintingSystem;
            rpt.CreateDocument(true);
            btnControl.btnPrint.Enabled = ds.Tables[0].Rows.Count > 0;
            _wait.Close();
        }
        private void btnControl_btnEventPrint_Click(object sender, EventArgs e)
        {
            try
            {
                using (ReportPrintTool printTool = new ReportPrintTool(rpt))
                {
                    printTool.Print();
                    //or printTool.PrintDialog();
                }
            }
            catch (Exception)
            {

            }
        }

        
    }
}
