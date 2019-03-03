using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace DauThau.Reports
{
    public partial class rptBCHoatDongHoiThao : DevExpress.XtraReports.UI.XtraReport
    {
        private TopMarginBand topMarginBand1;
        private DetailBand detailBand1;
        private TopMarginBand topMarginBand2;
        private DetailBand detailBand2;
        private BottomMarginBand bottomMarginBand2;
        private BottomMarginBand bottomMarginBand1;

        public rptBCHoatDongHoiThao()
        {
            InitializeComponent();
        }
    }
}
