using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraTab;
using System.Data;

namespace DauThau.Class
{
    class clsParameter
    {
        public static Int32 secondWait = 2 * 1000;

        //Dùng để phân cách dữ liệu checklistbox
        public static char separatorChar = ';';

        public static Int64 _goiThauID = 0;
        public static Int64 statusDeleted = -1;
#if (ReleaseKonTum)
        public static string pHospital = "BỆNH VIỆN ĐA KHOA TỈNH";
        public static string pParentHospital = "SỞ Y TẾ TỈNH KON TUM";
        public static string pStoreDanhGiaHoSoDuThau = "sp_DanhGiaHoSoDuThau";
#else
        public static string pParentHospital = "SỞ LĐTB&XH TP CẦN THƠ";
        public static string pHospital = "HỘI NGƯỜI KHUYẾT TẬT TP CẤN THƠ";
        public static string pStoreDanhGiaHoSoDuThau = "sp_DanhGiaHoSoDuThau_BV121";
#endif

        public static string pFormatNumber = "###,##0.####";
        public static string pNgayMoThau = "Cần Thơ, ngày 11 tháng 06 năm 2013";
        public static string pQuyetDinh = "(QĐ số 1034/QĐ-BTL ngày 12/08/2013)";

        public static string pToTruongToXetThau = string.Empty;
        public static string pToPhoToXetThau = string.Empty;
        public static string pThuKy = string.Empty;
        public static string pGiamDoc = string.Empty;
        public static string pUyVien = string.Empty;

        /// <summary>
        /// Trạng thái kiểm tra có cần tải lại dữ liệu đấu thầu.
        /// True : tải lại dữ liệu đấu thầu.
        /// </summary>
        public static Boolean _isLoadHoSoDauThau = true;
        public static DataSet _dataHoSoDauThau = new DataSet();
        public static Boolean _isfirstLoadHoSoDauThau = true;
        /// <summary>
        /// Đợt đấu thầu
        /// </summary>
        public static String _dotMaDauThau = string.Empty;
        
        /// <summary>
        /// Dữ liệu có khóa hay không
        /// </summary>
        public static Boolean _dotKhoaDuLieu = false;
        
        /// <summary>
        /// 
        /// </summary>
        public static DateTime _dotNgayMoThau;

        public static String _maCongTy = string.Empty;
        public static XtraTabControl TabControlParent = new XtraTabControl();
        public static String _username = "admin" + string.Empty;
        public static bool _isAdmin = false;
        public static Int64 _userId;

        /// <summary>
        /// Control hiển thị trạng thái đang chọn đợt đấu thầu.
        /// </summary>
        public static DevExpress.XtraBars.BarStaticItem _barStaticLogin =new DevExpress.XtraBars.BarStaticItem();
    }
}
