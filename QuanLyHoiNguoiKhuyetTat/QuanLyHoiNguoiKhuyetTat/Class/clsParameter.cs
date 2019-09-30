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

        //Dùng để đánh dấu 1 dòng dữ liệu đang ở trạng thái deleted.
        public static Int64 statusDeleted = -1;

        public static string pParentHospital = "SỞ LĐTB&XH TP CẦN THƠ";
        public static string pHospital = "HỘI NGƯỜI KHUYẾT TẬT TP CẤN THƠ";
        public static string pStoreDanhGiaHoSoDuThau = "sp_DanhGiaHoSoDuThau_BV121";

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

        //Hội viên
        public static String HV_DOITUONG_TEKT = "TEKT";

        //Hoạt động
        public static Int64 LOAI_HOATDONG_DAYNGHE_ID = 1;
        public static string LOAI_HOATDONG_DAYNGHE_TEN = "Dạy nghề";

        public static Int64 LOAI_HOATDONG_VIECLAM_ID = 2;
        public static string LOAI_HOATDONG_VIECLAM_TEN = "Việc làm";

        public static Int64 LOAI_HOATDONG_VAYVON_ID = 3;
        public static string LOAI_HOATDONG_VAYVON_TEN = "Vay vốn";

        public static Int64 LOAI_HOATDONG_HOICHO_TRIENLAM_ID = 4;
        public static string LOAI_HOATDONG_HOICHO_TRIENLAM_TEN = "Hội chợ triễn lãm";

        public static Int64 LOAI_HOATDONG_HOITHAO_ID = 5;
        public static string LOAI_HOATDONG_HOITHAO_TEN = "Hội thảo";

        public static Int64 LOAI_HOATDONG_TAPHUAN_ID = 6;
        public static string LOAI_HOATDONG_TAPHUAN_TEN = "Tập huấn";

        public static Int64 LOAI_HOATDONG_ASXH_ID = 7;
        public static string LOAI_HOATDONG_ASXH_TEN = "An sinh xã hội";

        public static Int64 LOAI_HOATDONG_HNXH_ID = 8;
        public static string LOAI_HOATDONG_HNXH_TEN = "Hòa nhập xã hội";

        public static Int64 LOAI_HOATDONG_KHAC_ID = 9;
        public static string LOAI_HOATDONG_KHAC_TEN = "Hoạt động khác";

    }
}
