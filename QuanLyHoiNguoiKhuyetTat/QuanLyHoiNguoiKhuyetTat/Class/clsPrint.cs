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

    public class clsHoatDongDayNghe
    {
        public string DN_NGHE { get; set; }
        public string DN_THOIGIAN { get; set; }
        public string DN_DIADIEM { get; set; }
        public string DN_DONVI_THUCHIEN { get; set; }
        public string DN_NU_TONGSO { get; set; }
        public int? DN_TONGTIEN { get; set; }
        public string DN_NOIDUNG { get; set; }
        public string DN_DOITUONG_THAMGIA { get; set; }
    }

    public class clsHoatDongViecLam
    {
        public string VL_TEN { get; set; }
        public string VL_THOIGIAN { get; set; }
        public string VL_DIADIEM { get; set; }
        public string VL_DONVI_GIOITHIEU { get; set; }
        public string VL_NU_TONGSO{ get; set; }
        public int? VL_THUNHAP_THANG { get; set; }
        public string VL_DOITUONG { get; set; }
        public string VL_NOIDUNG { get; set; }
    }

    public class clsHoatDongVayVon
    {
        public string VV_TEN { get; set; }
        public string VV_THOIGIAN { get; set; }
        public string VV_DIADIEM { get; set; }
        public string VV_NGUON_VAY { get; set; }
        public string VV_NU_TONGSO { get; set; }
        public int? VV_TIEN_VAY { get; set; }
        public string VV_DOITUONG { get; set; }
        public string VV_NOIDUNG { get; set; }
    }

    public class clsTongKetHoatDong
    {
        public Int64 HD_ID { get; set; }
        public string HD_TEN { get; set; }
        public string HD_THOIGIAN { get; set; }
        public DateTime? HD_THOIGIAN_BATDAU { get; set; }
        public DateTime? HD_THOIGIAN_KETTHUC { get; set; }
        public string HD_GHICHU { get; set; }
        public string HD_LOAI { get; set; }
        public string HD_NOIDUNG { get; set; }
    }
}
