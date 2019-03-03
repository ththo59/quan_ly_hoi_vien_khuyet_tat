using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DauThau.Class
{
    public class clsHoatDongTapHuan
    {
        public string TH_TEN { get; set; }
        public string TH_THOIGIAN { get; set; }
        public string TH_DIADIEM { get; set; }
        public string TH_DONVI_THUCHIEN { get; set; }
        public string TH_NOIDUNG { get; set; }
        public int? TH_SOLUONG { get; set; }
        public int TH_TONGTIEN { get; set; }
    }

    public class clsHoatDongHoiThao
    {
        public string HT_TEN { get; set; }
        public string HT_THOIGIAN { get; set; }
        public string HT_DIADIEM { get; set; }
        public string HT_DONVI_THUCHIEN { get; set; }
        public string HT_NOIDUNG { get; set; }
        public int? HT_SOLUONG { get; set; }
    }

    public class clsHoatDongASXH
    {
        public string ASXH_TEN { get; set; }
        public string ASXH_THOIGIAN { get; set; }
        public string ASXH_DIADIEM { get; set; }
        public string ASXH_DONVI_THUCHIEN { get; set; }
        public string ASXH_NOIDUNG { get; set; }
        public int? ASXH_SOLUONG { get; set; }
        public int? ASXH_TONGSO_TIEN { get; set; }
        public string ASXH_DOITUONG { get; set; }
    }

    public class clsHoatDongHNXH
    {
        public string HNXH_TEN { get; set; }
        public string HNXH_THOIGIAN { get; set; }
        public string HNXH_DIADIEM { get; set; }
        public string HNXH_DONVI_THUCHIEN { get; set; }
        public string HNXH_NOIDUNG { get; set; }
        public int? HNXH_SOLUONG { get; set; }
        public int? HNXH_TONGSO_TIEN { get; set; }
    }
}
