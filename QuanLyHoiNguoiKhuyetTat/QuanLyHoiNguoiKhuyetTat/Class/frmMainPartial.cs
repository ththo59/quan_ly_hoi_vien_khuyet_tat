using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DauThau
{
    public partial class frmMain
    {
        public class clsTongHopSPDuThau
        {
            public string CTY_TEN { get; set; }
            public string DIACHI { get; set; }
            public string DIENTHOAI { get; set; }
            public string FAX { get; set; }
            public Int32 COUNT_SP { get; set; }
            public Int32 TRUNGTHAU { get; set; }
            public Int32 KHONG_TRUNGTHAU { get; set; }
        }

        /// <summary>
        /// Công ty mua nộp hồ sơ
        /// </summary>
        public class clsCongTyMuaNopHoSo{
            public string GOITHAU_TEN { get; set; }
            public string CTY_TEN { get; set; }
            public Int32 COUNT_SP { get; set; }
            public string MUA { get; set; }
            public string NOP { get; set; }
            public Int32 COUNT_KYTHUAT_DAT { get; set; }
            public Int32 COUNT_KYTHUAT_KHONGDAT { get; set; }

        }

        /// <summary>
        /// Thống kê kết quả các công ty tham dự
        /// </summary>
        public class clsThongKeKetQuaThamDu
        {
            public string CTY_MA { get; set; }
            public string CTY_TEN { get; set; }
            public string GOITHAU_TEN { get; set; }
            public Int32 SOLUONG_THAMDU { get; set; }
            public Int32 SOLUONG_TRUNGTHAU { get; set; }
            public Int64 THANHTIEN_THEO_GIA_CTY { get; set; }
            public Decimal THANHTIEN_THEO_GIAKH { get; set; }
            public Decimal TIETKIEM { get; set; }
        }
    }
}
