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
using DauThau.Forms;
using CuscLibrary.Offices;
using DevExpress.XtraEditors.Controls;

namespace DauThau.UserControlCategoryMain
{
    public partial class ucSanPhamTheoCty : DevExpress.XtraEditors.XtraUserControl
    {
        public ucSanPhamTheoCty()
        {
            InitializeComponent();
        }

        #region Variable

        private EnumFormStatus _formStatus = EnumFormStatus.VIEW;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        #endregion

        void CommandData()
        {
            //gv._SetDefaultColorRowStyle();
            //UPDATE
            string str_update = "update DAU_THAU set SP_GHICHU=@SP_GHICHU, SP_DIEM_BTC=@SP_DIEM_BTC where DAUTHAU_ID=@DAUTHAU_ID ";
            da.UpdateCommand = new SqlCommand(str_update, clsConnection._conn);
            da.UpdateCommand.Parameters.Add("@SP_GHICHU", SqlDbType.NVarChar, 50, "SP_GHICHU");
            da.UpdateCommand.Parameters.Add("@SP_DIEM_BTC", SqlDbType.Int, 5, "SP_DIEM_BTC");
            da.UpdateCommand.Parameters.Add("@DAUTHAU_ID", SqlDbType.BigInt, 10, "DAUTHAU_ID");
      
        }

        Boolean _loadFirst = false;
        private void ucSanPhamTheoCty_Load(object sender, EventArgs e)
        {
            LibraryDev.PermissionButton(btnControl, null);
            _loadFirst = true;
            lueCongTy.Properties.DataSource =FunctionHelper.LoadDM("select * from DM_CONGTY where DOT_MA='"+clsParameter._dotMaDauThau+"'");
            try
            {
                lueCongTy.ItemIndex = 0;
            }
            catch
            {
            }
            //lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThau();
            //lueCongTy.ItemIndex = lueGoiThau.ItemIndex = 0;
            CommandData();
            this.FormStatus = EnumFormStatus.VIEW;
            FunctionHelper.PermissionLockButton(btnControl);

            FormHelper.LookUpEdit_Init(lueCongTy);
            FormHelper.LookUpEdit_Init(lueGoiThau);
        }

        #region Print

        void Print6()
        {
            dsSanPhamTheoCty1.cty.Clear();
            SqlDataAdapter d = new SqlDataAdapter("select * from DM_CONGTY where CTY_MA='" + lueCongTy.EditValue + "'", clsConnection._conn);
            d.Fill(dsSanPhamTheoCty1.cty);

            rptDsSanPhamTheoCty6 rpt = new rptDsSanPhamTheoCty6();
            rpt.pGoiThau.Value = lueGoiThau.Text;
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;
            rpt.pThuKy.Value = clsParameter.pThuKy;
            rpt.pUyVien.Value = clsParameter.pUyVien;
            rpt.pToTruong.Value = clsParameter.pToTruongToXetThau;
            rpt.pNgayMoThau.Value = clsParameter.pNgayMoThau;

            //rpt.p1.Value = dtCol.Rows[0]["VIET_TAT"].ToString();
            //rpt.p2.Value = dtCol.Rows[1]["VIET_TAT"].ToString();
            //rpt.p3.Value = dtCol.Rows[2]["VIET_TAT"].ToString();
            //rpt.p4.Value = dtCol.Rows[3]["VIET_TAT"].ToString();
            //rpt.p5.Value = dtCol.Rows[4]["VIET_TAT"].ToString();
            //rpt.p6.Value = dtCol.Rows[5]["VIET_TAT"].ToString();

            rpt.p1.Value = "1";
            rpt.p2.Value = "2";
            rpt.p3.Value = "3";
            rpt.p4.Value = "4";
            rpt.p5.Value = "5";
            rpt.p6.Value = "6";

            rpt.dc1.Value = dtCol.Rows[0]["DIEM_CHUAN"] + string.Empty;
            rpt.dc2.Value = dtCol.Rows[1]["DIEM_CHUAN"] + string.Empty;
            rpt.dc3.Value = dtCol.Rows[2]["DIEM_CHUAN"] + string.Empty;
            rpt.dc4.Value = dtCol.Rows[3]["DIEM_CHUAN"] + string.Empty;
            rpt.dc5.Value = dtCol.Rows[4]["DIEM_CHUAN"] + string.Empty;
            rpt.dc6.Value = dtCol.Rows[5]["DIEM_CHUAN"] + string.Empty;

            //rpt.dc1.Value = "(1)";
            //rpt.dc2.Value = "(2)";
            //rpt.dc3.Value = "(3)";
            //rpt.dc4.Value = "(4)";
            //rpt.dc5.Value = "(5)";
            //rpt.dc6.Value = "(6)";

            rpt.d1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[0]["VIET_TAT"].ToString())});

            rpt.d2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[1]["VIET_TAT"].ToString())});

            rpt.d3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[2]["VIET_TAT"].ToString())});

            rpt.d4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[3]["VIET_TAT"].ToString())});

            rpt.d5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[4]["VIET_TAT"].ToString())});

            rpt.d6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[5]["VIET_TAT"].ToString())});

            rpt.DataSource = dsSanPhamTheoCty1;
            rpt.DataMember = "DsSanPhamTheoCty";
            rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM27);
            rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM27);
            frmPrint f = new frmPrint(rpt);
            f.ShowDialog();
        }

        void Print3()
        {
            dsSanPhamTheoCty1.cty.Clear();
            SqlDataAdapter d = new SqlDataAdapter("select * from DM_CONGTY where CTY_MA='" + lueCongTy.EditValue + "'", clsConnection._conn);
            d.Fill(dsSanPhamTheoCty1.cty);

            rptDsSanPhamTheoCty3 rpt = new rptDsSanPhamTheoCty3();
            rpt.pGoiThau.Value = lueGoiThau.Text;
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;

            rpt.p1.Value = dtCol.Rows[0]["VIET_TAT"].ToString();
            rpt.p2.Value = dtCol.Rows[1]["VIET_TAT"].ToString();
            rpt.p3.Value = dtCol.Rows[2]["VIET_TAT"].ToString();


            rpt.dc1.Value = dtCol.Rows[0]["DIEM_CHUAN"] + string.Empty;
            rpt.dc2.Value = dtCol.Rows[1]["DIEM_CHUAN"] + string.Empty;
            rpt.dc3.Value = dtCol.Rows[2]["DIEM_CHUAN"] + string.Empty;


            rpt.d1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[0]["VIET_TAT"].ToString())});

            rpt.d2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[1]["VIET_TAT"].ToString())});

            rpt.d3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[2]["VIET_TAT"].ToString())});



            rpt.DataSource = dsSanPhamTheoCty1;
            rpt.DataMember = "DsSanPhamTheoCty";
            frmPrint f = new frmPrint(rpt);
            f.ShowDialog();
        }

        void Print4()
        {
            dsSanPhamTheoCty1.cty.Clear();
            SqlDataAdapter d = new SqlDataAdapter("select * from DM_CONGTY where CTY_MA='" + lueCongTy.EditValue + "'", clsConnection._conn);
            d.Fill(dsSanPhamTheoCty1.cty);

            rptDsSanPhamTheoCty4 rpt = new rptDsSanPhamTheoCty4();
            rpt.pGoiThau.Value = lueGoiThau.Text;
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;

            rpt.p1.Value = dtCol.Rows[0]["VIET_TAT"].ToString();
            rpt.p2.Value = dtCol.Rows[1]["VIET_TAT"].ToString();
            rpt.p3.Value = dtCol.Rows[2]["VIET_TAT"].ToString();
            rpt.p4.Value = dtCol.Rows[3]["VIET_TAT"].ToString();
            

            rpt.dc1.Value = dtCol.Rows[0]["DIEM_CHUAN"] + string.Empty;
            rpt.dc2.Value = dtCol.Rows[1]["DIEM_CHUAN"] + string.Empty;
            rpt.dc3.Value = dtCol.Rows[2]["DIEM_CHUAN"] + string.Empty;
            rpt.dc4.Value = dtCol.Rows[3]["DIEM_CHUAN"] + string.Empty;
            

            rpt.d1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[0]["VIET_TAT"].ToString())});

            rpt.d2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[1]["VIET_TAT"].ToString())});

            rpt.d3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[2]["VIET_TAT"].ToString())});

            rpt.d4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[3]["VIET_TAT"].ToString())});

            

            rpt.DataSource = dsSanPhamTheoCty1;
            rpt.DataMember = "DsSanPhamTheoCty";
            frmPrint f = new frmPrint(rpt);
            f.ShowDialog();
        }

        void Print5()
        {
            dsSanPhamTheoCty1.cty.Clear();
            SqlDataAdapter d = new SqlDataAdapter("select * from DM_CONGTY where CTY_MA='" + lueCongTy.EditValue + "'", clsConnection._conn);
            d.Fill(dsSanPhamTheoCty1.cty);

            rptDsSanPhamTheoCty5 rpt = new rptDsSanPhamTheoCty5();
            rpt.pGoiThau.Value = lueGoiThau.Text;
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;

            rpt.p1.Value = dtCol.Rows[0]["VIET_TAT"].ToString();
            rpt.p2.Value = dtCol.Rows[1]["VIET_TAT"].ToString();
            rpt.p3.Value = dtCol.Rows[2]["VIET_TAT"].ToString();
            rpt.p4.Value = dtCol.Rows[3]["VIET_TAT"].ToString();
            rpt.p5.Value = dtCol.Rows[4]["VIET_TAT"].ToString();
            

            rpt.dc1.Value = dtCol.Rows[0]["DIEM_CHUAN"] + string.Empty;
            rpt.dc2.Value = dtCol.Rows[1]["DIEM_CHUAN"] + string.Empty;
            rpt.dc3.Value = dtCol.Rows[2]["DIEM_CHUAN"] + string.Empty;
            rpt.dc4.Value = dtCol.Rows[3]["DIEM_CHUAN"] + string.Empty;
            rpt.dc5.Value = dtCol.Rows[4]["DIEM_CHUAN"] + string.Empty;
            

            rpt.d1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[0]["VIET_TAT"].ToString())});

            rpt.d2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[1]["VIET_TAT"].ToString())});

            rpt.d3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[2]["VIET_TAT"].ToString())});

            rpt.d4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[3]["VIET_TAT"].ToString())});

            rpt.d5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[4]["VIET_TAT"].ToString())});

           

            rpt.DataSource = dsSanPhamTheoCty1;
            rpt.DataMember = "DsSanPhamTheoCty";
            frmPrint f = new frmPrint(rpt);
            f.ShowDialog();
        }

        void Print7()
        {
            dsSanPhamTheoCty1.cty.Clear();
            SqlDataAdapter d = new SqlDataAdapter("select * from DM_CONGTY where CTY_MA='" + lueCongTy.EditValue + "'", clsConnection._conn);
            d.Fill(dsSanPhamTheoCty1.cty);

            rptDsSanPhamTheoCty7 rpt = new rptDsSanPhamTheoCty7();
            rpt.pGoiThau.Value = lueGoiThau.Text;
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;

            rpt.p1.Value = dtCol.Rows[0]["VIET_TAT"].ToString();
            rpt.p2.Value = dtCol.Rows[1]["VIET_TAT"].ToString();
            rpt.p3.Value = dtCol.Rows[2]["VIET_TAT"].ToString();
            rpt.p4.Value = dtCol.Rows[3]["VIET_TAT"].ToString();
            rpt.p5.Value = dtCol.Rows[4]["VIET_TAT"].ToString();
            rpt.p6.Value = dtCol.Rows[5]["VIET_TAT"].ToString();
            rpt.p7.Value = dtCol.Rows[6]["VIET_TAT"].ToString();

            rpt.dc1.Value = dtCol.Rows[0]["DIEM_CHUAN"] + string.Empty;
            rpt.dc2.Value = dtCol.Rows[1]["DIEM_CHUAN"] + string.Empty;
            rpt.dc3.Value = dtCol.Rows[2]["DIEM_CHUAN"] + string.Empty;
            rpt.dc4.Value = dtCol.Rows[3]["DIEM_CHUAN"] + string.Empty;
            rpt.dc5.Value = dtCol.Rows[4]["DIEM_CHUAN"] + string.Empty;
            rpt.dc6.Value = dtCol.Rows[5]["DIEM_CHUAN"] + string.Empty;
            rpt.dc7.Value = dtCol.Rows[6]["DIEM_CHUAN"] + string.Empty;

            rpt.d1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[0]["VIET_TAT"].ToString())});

            rpt.d2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[1]["VIET_TAT"].ToString())});

            rpt.d3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[2]["VIET_TAT"].ToString())});

            rpt.d4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[3]["VIET_TAT"].ToString())});

            rpt.d5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[4]["VIET_TAT"].ToString())});

            rpt.d6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[5]["VIET_TAT"].ToString())});

            rpt.d7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[6]["VIET_TAT"].ToString())});

            rpt.DataSource = dsSanPhamTheoCty1;
            rpt.DataMember = "DsSanPhamTheoCty";
            frmPrint f = new frmPrint(rpt);
            f.ShowDialog();
        }

        void Print13()
        {
            dsSanPhamTheoCty1.cty.Clear();
            SqlDataAdapter d = new SqlDataAdapter("select * from DM_CONGTY where CTY_MA='" + lueCongTy.EditValue + "'", clsConnection._conn);
            d.Fill(dsSanPhamTheoCty1.cty);

            rptDsSanPhamTheoCty13 rpt = new rptDsSanPhamTheoCty13();
            rpt.pGoiThau.Value = lueGoiThau.Text;
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;

            rpt.p1.Value = dtCol.Rows[0]["VIET_TAT"].ToString();
            rpt.p2.Value = dtCol.Rows[1]["VIET_TAT"].ToString();
            rpt.p3.Value = dtCol.Rows[2]["VIET_TAT"].ToString();
            rpt.p4.Value = dtCol.Rows[3]["VIET_TAT"].ToString();
            rpt.p5.Value = dtCol.Rows[4]["VIET_TAT"].ToString();
            rpt.p6.Value = dtCol.Rows[5]["VIET_TAT"].ToString();
            rpt.p7.Value = dtCol.Rows[6]["VIET_TAT"].ToString();
            rpt.p8.Value = dtCol.Rows[7]["VIET_TAT"].ToString();
            rpt.p9.Value = dtCol.Rows[8]["VIET_TAT"].ToString();
            rpt.p10.Value = dtCol.Rows[9]["VIET_TAT"].ToString();
            rpt.p11.Value = dtCol.Rows[10]["VIET_TAT"].ToString();
            rpt.p12.Value = dtCol.Rows[11]["VIET_TAT"].ToString();
            rpt.p13.Value = dtCol.Rows[12]["VIET_TAT"].ToString();

            rpt.dc1.Value = dtCol.Rows[0]["DIEM_CHUAN"] + string.Empty;
            rpt.dc2.Value = dtCol.Rows[1]["DIEM_CHUAN"] + string.Empty;
            rpt.dc3.Value = dtCol.Rows[2]["DIEM_CHUAN"] + string.Empty;
            rpt.dc4.Value = dtCol.Rows[3]["DIEM_CHUAN"] + string.Empty;
            rpt.dc5.Value = dtCol.Rows[4]["DIEM_CHUAN"] + string.Empty;
            rpt.dc6.Value = dtCol.Rows[5]["DIEM_CHUAN"] + string.Empty;
            rpt.dc7.Value = dtCol.Rows[6]["DIEM_CHUAN"] + string.Empty;
            rpt.dc8.Value = dtCol.Rows[7]["DIEM_CHUAN"] + string.Empty;
            rpt.dc9.Value = dtCol.Rows[8]["DIEM_CHUAN"] + string.Empty;
            rpt.dc10.Value = dtCol.Rows[9]["DIEM_CHUAN"] + string.Empty;
            rpt.dc11.Value = dtCol.Rows[10]["DIEM_CHUAN"] + string.Empty;
            rpt.dc12.Value = dtCol.Rows[11]["DIEM_CHUAN"] + string.Empty;
            rpt.dc13.Value = dtCol.Rows[12]["DIEM_CHUAN"] + string.Empty;

            rpt.d1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[0]["VIET_TAT"].ToString())});

            rpt.d2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[1]["VIET_TAT"].ToString())});

            rpt.d3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[2]["VIET_TAT"].ToString())});

            rpt.d4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[3]["VIET_TAT"].ToString())});

            rpt.d5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[4]["VIET_TAT"].ToString())});

            rpt.d6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[5]["VIET_TAT"].ToString())});

            rpt.d7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[6]["VIET_TAT"].ToString())});
            
            rpt.d8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[7]["VIET_TAT"].ToString())});
            
            rpt.d9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[8]["VIET_TAT"].ToString())});
            
            rpt.d10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[9]["VIET_TAT"].ToString())});
            
            rpt.d11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[10]["VIET_TAT"].ToString())});
            
            rpt.d12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[11]["VIET_TAT"].ToString())});

            rpt.d13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[12]["VIET_TAT"].ToString())});


            rpt.DataSource = dsSanPhamTheoCty1;
            rpt.DataMember = "DsSanPhamTheoCty";
            frmPrint f = new frmPrint(rpt);
            f.ShowDialog();
        }

        void Print15()
        {
            dsSanPhamTheoCty1.cty.Clear();
            SqlDataAdapter d = new SqlDataAdapter("select * from DM_CONGTY where CTY_MA='" + lueCongTy.EditValue + "'", clsConnection._conn);
            d.Fill(dsSanPhamTheoCty1.cty);

            rptDsSanPhamTheoCty15 rpt = new rptDsSanPhamTheoCty15();
            rpt.pGoiThau.Value = lueGoiThau.Text;
            rpt.pHospital.Value = clsParameter.pHospital;
            rpt.pParentHospital.Value = clsParameter.pParentHospital;

            //rpt.p1.Value = dtCol.Rows[0]["VIET_TAT"].ToString();
            //rpt.p2.Value = dtCol.Rows[1]["VIET_TAT"].ToString();
            //rpt.p3.Value = dtCol.Rows[2]["VIET_TAT"].ToString();
            //rpt.p4.Value = dtCol.Rows[3]["VIET_TAT"].ToString();
            //rpt.p5.Value = dtCol.Rows[4]["VIET_TAT"].ToString();
            //rpt.p6.Value = dtCol.Rows[5]["VIET_TAT"].ToString();
            //rpt.p7.Value = dtCol.Rows[6]["VIET_TAT"].ToString();
            //rpt.p8.Value = dtCol.Rows[7]["VIET_TAT"].ToString();
            //rpt.p9.Value = dtCol.Rows[8]["VIET_TAT"].ToString();
            //rpt.p10.Value = dtCol.Rows[9]["VIET_TAT"].ToString();
            //rpt.p11.Value = dtCol.Rows[10]["VIET_TAT"].ToString();
            //rpt.p12.Value = dtCol.Rows[11]["VIET_TAT"].ToString();
            //rpt.p13.Value = dtCol.Rows[12]["VIET_TAT"].ToString();
            //rpt.p14.Value = dtCol.Rows[13]["VIET_TAT"].ToString();
            //rpt.p15.Value = dtCol.Rows[14]["VIET_TAT"].ToString();

            rpt.p1.Value = "1";
            rpt.p2.Value = "2";
            rpt.p3.Value = "3";
            rpt.p4.Value = "4";
            rpt.p5.Value = "5";
            rpt.p6.Value = "6";
            rpt.p7.Value = "7";
            rpt.p8.Value = "8";
            rpt.p9.Value = "9";
            rpt.p10.Value = "10";
            rpt.p11.Value = "11";
            rpt.p12.Value = "12";
            rpt.p13.Value = "13";
            rpt.p14.Value = "14";
            rpt.p15.Value = "15";

            rpt.dc1.Value = dtCol.Rows[0]["DIEM_CHUAN"] + string.Empty;
            rpt.dc2.Value = dtCol.Rows[1]["DIEM_CHUAN"] + string.Empty;
            rpt.dc3.Value = dtCol.Rows[2]["DIEM_CHUAN"] + string.Empty;
            rpt.dc4.Value = dtCol.Rows[3]["DIEM_CHUAN"] + string.Empty;
            rpt.dc5.Value = dtCol.Rows[4]["DIEM_CHUAN"] + string.Empty;
            rpt.dc6.Value = dtCol.Rows[5]["DIEM_CHUAN"] + string.Empty;
            rpt.dc7.Value = dtCol.Rows[6]["DIEM_CHUAN"] + string.Empty;
            rpt.dc8.Value = dtCol.Rows[7]["DIEM_CHUAN"] + string.Empty;
            rpt.dc9.Value = dtCol.Rows[8]["DIEM_CHUAN"] + string.Empty;
            rpt.dc10.Value = dtCol.Rows[9]["DIEM_CHUAN"] + string.Empty;
            rpt.dc11.Value = dtCol.Rows[10]["DIEM_CHUAN"] + string.Empty;
            rpt.dc12.Value = dtCol.Rows[11]["DIEM_CHUAN"] + string.Empty;
            rpt.dc13.Value = dtCol.Rows[12]["DIEM_CHUAN"] + string.Empty;
            rpt.dc14.Value = dtCol.Rows[13]["DIEM_CHUAN"] + string.Empty;
            rpt.dc15.Value = dtCol.Rows[14]["DIEM_CHUAN"] + string.Empty;

            //rpt.dc1.Value = "(1)";
            //rpt.dc2.Value = "(2)";
            //rpt.dc3.Value = "(3)";
            //rpt.dc4.Value = "(4)";
            //rpt.dc5.Value = "(5)";
            //rpt.dc6.Value = "(6)";
            //rpt.dc7.Value = "(7)";
            //rpt.dc8.Value = "(8)";
            //rpt.dc9.Value = "(9)";
            //rpt.dc10.Value = "(10)";
            //rpt.dc11.Value = "(11)";
            //rpt.dc12.Value = "(12)";
            //rpt.dc13.Value = "(13)";
            //rpt.dc14.Value = "(14)";
            //rpt.dc15.Value = "(15)";

            rpt.d1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[0]["VIET_TAT"].ToString())});

            rpt.d2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[1]["VIET_TAT"].ToString())});

            rpt.d3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[2]["VIET_TAT"].ToString())});

            rpt.d4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[3]["VIET_TAT"].ToString())});

            rpt.d5.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[4]["VIET_TAT"].ToString())});

            rpt.d6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[5]["VIET_TAT"].ToString())});

            rpt.d7.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[6]["VIET_TAT"].ToString())});

            rpt.d8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[7]["VIET_TAT"].ToString())});

            rpt.d9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[8]["VIET_TAT"].ToString())});

            rpt.d10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[9]["VIET_TAT"].ToString())});

            rpt.d11.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[10]["VIET_TAT"].ToString())});

            rpt.d12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[11]["VIET_TAT"].ToString())});

            rpt.d13.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[12]["VIET_TAT"].ToString())});

            rpt.d14.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[13]["VIET_TAT"].ToString())});

            rpt.d15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DsSanPhamTheoCty." + dtCol.Rows[14]["VIET_TAT"].ToString())});

            rpt.DataSource = dsSanPhamTheoCty1;
            rpt.DataMember = "DsSanPhamTheoCty";
            rpt.pThuKy.Value = clsParameter.pThuKy;
            rpt.pUyVien.Value = clsParameter.pUyVien;
            rpt.pToTruong.Value = clsParameter.pToTruongToXetThau;
            rpt.pNgayMo.Value = clsParameter.pNgayMoThau;
            rpt.pTitleFooter.Value = ReportHelper.getTitleFooter(LoaiBaoCao.BM27);
            rpt.pValueFooter.Value = ReportHelper.getValueFooter(LoaiBaoCao.BM27);
            frmPrint f = new frmPrint(rpt);
            f.ShowDialog();
        }

        #endregion

        private void btnControl_btnEventPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtCol.Rows.Count == 3)
                    Print3();
                else if (dtCol.Rows.Count == 4)
                    Print4();
                else if (dtCol.Rows.Count == 5)
                    Print5();
                else if (dtCol.Rows.Count == 6)
                    Print6();
                else if (dtCol.Rows.Count == 7)
                    Print7();
                else if (dtCol.Rows.Count == 13)
                    Print13();
                else if (dtCol.Rows.Count == 15)
                    Print15();
            }
            catch (Exception)
            {
                clsMessage.MessageExclamation("Vui lòng cấu hình biểu mẫu.");
            }
            
        }

        DataTable dtCol =new DataTable();

        void CreateColumn()
        {
            dsSanPhamTheoCty1 = new DataSets.dsSanPhamTheoCty();
            //dsSanPhamTheoCty1.DsSanPhamTheoCty.Clear();
            ////Clear all column exits
            //for (int i = 0; i < dtCol.Rows.Count; i++)
            //{
            //    dsSanPhamTheoCty1.DsSanPhamTheoCty.Columns.Remove(dtCol.Rows[i][0].ToString());
            //}

            dtCol = new DataTable();
            string str = "SELECT DISTINCT VIET_TAT ,SORT_NHOM, DIEM_CHUAN FROM dbo.DM_GOITHAU_KYTHUAT a "
                        + " LEFT JOIN dbo.DM_NHOM_KYTHUAT b ON a.NHOM_KYTHUAT_ID = b.NHOM_KYTHUAT_ID "
                        + " LEFT JOIN dbo.DM_NHOM_KYTHUAT_DIEMCHUAN c ON a.GOITHAU_ID = c.GOITHAU_ID AND a.NHOM_KYTHUAT_ID = c.NHOM_KYTHUAT_ID"
                        + " WHERE a.GOITHAU_ID ="+ clsChangeType.change_int64(lueGoiThau.EditValue) +" ORDER BY a.SORT_NHOM";
            
            dtCol = FunctionHelper.LoadDM(str);
            int k = bandYCKT.Columns.Count;
            
            //Xóa các cột động trong band
            for (int i = 0; i < k; i++)
            {
                bandYCKT.Columns.Remove(bandYCKT.Columns[0]);
            }

            //Thêm mới.
            for (int i = 0; i < dtCol.Rows.Count; i++)
            {
                //Add Band
                BandedGridColumn col = new BandedGridColumn();
                col.Caption = string.Format("({0})", i+1);//dtCol.Rows[i][0] + string.Empty;
                col.Name = dtCol.Rows[i][0] + string.Empty;
                col.FieldName = dtCol.Rows[i][0] + string.Empty;
                col.OptionsColumn.AllowEdit = false;
                col.Visible = true;
                gvGrid.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { col });
                this.bandYCKT.Columns.Add(col);

                //Add Column Dataset
                dsSanPhamTheoCty1.DsSanPhamTheoCty.Columns.Add(dtCol.Rows[i][0].ToString(), typeof(String));
            }
            bandYCKT.Width = 45 * bandYCKT.Columns.Count;
        }

        void GetData()
        {
            string str = "SELECT ROW_NUMBER() OVER(ORDER BY dt.SP_MA) AS TT,dt.SP_MA,DAUTHAU_ID, sp.SP_TEN,sp.SP_QUICACH_YEUCAU, sp.SP_TENBIETDUOC "
                         + " ,dt.SP_TEN_THUONGMAI, dt.DONG_GOI SP_QUICACH_DONGGOI, TONG_DIEM_KT, ISNULL(GIA_SUADOI,GIA_CHAOTHAU) GIA_CHAOTHAU "
                         + " , SP_DIEM_BTC, dt.SP_GHICHU, dvt.TEN TENDONVITINH, sp.SP_HAMLUONG, sp.SP_DANGDUNG, nsx.TEN TENNUOCSX "
                         + " FROM DAU_THAU dt "
                         + " JOIN DM_SANPHAM sp ON dt.SP_MA = sp.SP_MA "
                         + " LEFT JOIN DM_DVT dvt ON dvt.DVT_ID = sp.DVT_ID "
                         + " LEFT JOIN DM_NUOCSX nsx ON nsx.NUOCSX_ID = sp.SP_NUOCSX_ID " //ON nsx.NUOCSX_ID = dt.NUOCSX_ID
                         + " WHERE CTY_MA = '"+ (lueCongTy.EditValue + string.Empty) +"' AND GOITHAU_ID =" + clsChangeType.change_int64(lueGoiThau.EditValue);
            
            if (chkDiemKT_Dat.Checked)
            {
                DataTable dt = FunctionHelper.LoadDM("select * from DM_GOITHAU where GOITHAU_ID = " + clsChangeType.change_int64(lueGoiThau.EditValue));
                if (dt.Rows.Count > 0)
                {
                    str += " AND isnull(dt.LOAI_PL, 0) = 0 AND ISNULL(dt.SP_DIEM_BTC,dt.TONG_DIEM_KT) >=" + dt.Rows[0]["DIEMKT"];
                }
            }

            SqlDataAdapter d = new SqlDataAdapter(str, clsConnection._conn);
            d.Fill(dsSanPhamTheoCty1.DsSanPhamTheoCty);
        }

        void BindingData()
        {
            string str = "SELECT a.DAUTHAU_ID, a.SP_MA, VIET_TAT, a.DIEM FROM dbo.DAUTHAU_CT a "
                            + " join DAU_THAU dt on a.DAUTHAU_ID = dt.DAUTHAU_ID "
                            + " JOIN dbo.DM_NHOM_KYTHUAT_CT b ON a.NHOM_KYTHUAT_CT_ID = b.NHOM_KYTHUAT_CT_ID "
                            + " JOIN dbo.DM_GOITHAU_KYTHUAT c ON b.NHOM_KYTHUAT_CT_ID = c.NHOM_KYTHUAT_CT_ID AND a.GOITHAU_ID = c.GOITHAU_ID "
                            + " JOIN dbo.DM_NHOM_KYTHUAT d ON d.NHOM_KYTHUAT_ID = c.NHOM_KYTHUAT_ID "
                            + " WHERE a.CTY_MA = '" + (lueCongTy.EditValue + string.Empty) + "' AND a.GOITHAU_ID =" + clsChangeType.change_int64(lueGoiThau.EditValue);
            
            if (chkDiemKT_Dat.Checked)
            {
                DataTable dt = FunctionHelper.LoadDM("select * from DM_GOITHAU where GOITHAU_ID = " + clsChangeType.change_int64(lueGoiThau.EditValue));
                if (dt.Rows.Count > 0)
                {
                    str += " AND isnull(dt.LOAI_PL, 0) = 0 AND ISNULL(dt.SP_DIEM_BTC,dt.TONG_DIEM_KT) >=" + dt.Rows[0]["DIEMKT"];
                }              
            }

            str += " ORDER BY a.SP_MA,c.SORT_NHOM";

            SqlDataAdapter d = new SqlDataAdapter(str, clsConnection._conn);
            DataTable t = new DataTable();
            d.Fill(t);

            for (int i = 0; i < dsSanPhamTheoCty1.DsSanPhamTheoCty.Rows.Count; i++)
            {
                int TongDiemKT = 0;
                DataRow[] r = t.Select(string.Format("SP_MA='{0}' and DAUTHAU_ID ={1}", dsSanPhamTheoCty1.DsSanPhamTheoCty.Rows[i]["SP_MA"].ToString(),dsSanPhamTheoCty1.DsSanPhamTheoCty.Rows[i]["DAUTHAU_ID"].ToString()));
                foreach (DataRow item in r)
                {
                    dsSanPhamTheoCty1.DsSanPhamTheoCty.Rows[i][item["VIET_TAT"].ToString()] = item["DIEM"].ToString();
                    TongDiemKT = TongDiemKT + clsChangeType.change_int(item["DIEM"]); 
                }

                //Cập nhật tổng điểm
                dsSanPhamTheoCty1.DsSanPhamTheoCty.Rows[i]["TONG_DIEM_KT"] = TongDiemKT;
                
                //Nếu Có điểm của BTC thì in điểm BTC ngược lại lấy tổng điểm.
                dsSanPhamTheoCty1.DsSanPhamTheoCty.Rows[i]["SP_TONGDIEM_PRINT"] = clsChangeType.change_int(dsSanPhamTheoCty1.DsSanPhamTheoCty.Rows[i]["SP_DIEM_BTC"]) > 0 ? dsSanPhamTheoCty1.DsSanPhamTheoCty.Rows[i]["SP_DIEM_BTC"] : dsSanPhamTheoCty1.DsSanPhamTheoCty.Rows[i]["TONG_DIEM_KT"];
            }
        }
        
        void Save()
        {
            try
            {
                clsParameter._isLoadHoSoDauThau = true;
                da.Update(dsSanPhamTheoCty1.DsSanPhamTheoCty);
            }
            catch
            {
                XtraMessageBox.Show("Dữ liệu đã được sử dụng bạn không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public EnumFormStatus FormStatus
        {
            get { return _formStatus; }
            set
            {
                _formStatus = value;
                if (_formStatus == EnumFormStatus.MODIFY)
                {
                    colSP_GHICHU.OptionsColumn.AllowEdit = true;
                    colSP_DIEM_BTC.OptionsColumn.AllowEdit = true;
                }

                else
                {
                    colSP_GHICHU.OptionsColumn.AllowEdit = false;
                    colSP_DIEM_BTC.OptionsColumn.AllowEdit = false;
                    this.btnControl.Status = ControlsLib.ButtonsArray.StateEnum.View;
                    btnControl.btnPrint.Enabled= btnControl.btnModify.Enabled = gvGrid.RowCount > 0;
                }
            }
        }

        void SelectData()
        {
            CreateColumn();
            GetData();
            BindingData();
            gcGrid.DataSource = dsSanPhamTheoCty1.DsSanPhamTheoCty;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if ((lueCongTy.EditValue == null || lueGoiThau.EditValue == null) && !_loadFirst)
            {
                clsMessage.MessageWarning("Vui lòng chọn Công ty và gói thầu.");
                return;
            }
            _loadFirst = false;
            SelectData();
        }

        private void btnControl_btnEventModify_Click(object sender, EventArgs e)
        {
            FormStatus = EnumFormStatus.MODIFY;
        }

        private void btnControl_btnEventSave_Click(object sender, EventArgs e)
        {
            Save();
            SelectData();
            this.FormStatus = EnumFormStatus.VIEW;
        }

        private void btnControl_btnEventCancel_Click(object sender, EventArgs e)
        {
            SelectData();
            this.FormStatus = EnumFormStatus.VIEW;
        }

        private void gv_RowCountChanged(object sender, EventArgs e)
        {
            btnControl.btnModify.Enabled = btnControl.btnPrint.Enabled = gvGrid.RowCount > 0;
        }

        private void lueCongTy_EditValueChanged(object sender, EventArgs e)
        {
            lueGoiThau.Properties.DataSource = FunctionHelper.LoadGoiThauTheoCongTy(lueCongTy.EditValue +string.Empty);
            try
            {
                lueGoiThau.ItemIndex = 0;
            }
            catch 
            {
            }
            btnXem.PerformClick();
        }

        private void lueGoiThau_EditValueChanged(object sender, EventArgs e)
        {
            btnXem.PerformClick();
        }

        private void repUpdateDiemKT_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            
        }

        private void btnControl_btnEventExcel_Click(object sender, EventArgs e)
        {

        }

        private void chkDiemKT_Dat_CheckedChanged(object sender, EventArgs e)
        {
            btnXem.PerformClick();
        }

        
    }
}
