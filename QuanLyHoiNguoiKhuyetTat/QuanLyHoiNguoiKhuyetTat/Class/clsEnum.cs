using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace DauThau.Class
{
    enum LoaiGoiThau
    {
        THUOC = 0,
        VTYT = 1,
        TATCA = 2
    }
    
    enum CategoryTapHuanChiTietLoai
    {
        NGUOI_THUC_HIEN = 1,
        TAP_HUAN_VIEN_CHINH,
        TAP_HUAN_VIEN_PHU,
        PHIEN_DICH_VIEN,
        DOITUONG_KHONG_KHUYETTAT
    }

    enum CategoryHoatDong
    {
        DAYNGHE = 1,
        VIECLAM,
        VAYVON,
        HOICHO_TRIENLAM,
        HOITHAO,
        TAPHUAN,
        ASXH,
        HNXH,
        KHAC
    }

    enum CategoryEntitiesTable
    {
        DM_GIOITINH = 0,
        DM_NGHE_NGHIEP,
        DM_TINH,
        DM_HUYEN,
        DM_XA,
        DM_TRINH_DO_HOC_VAN,
        DM_TRINH_DO_CHUYEN_MON,
        DM_TONGIAO,
        DM_DANTOC,
        DM_CHUCVU_HOI,
        DM_DOITUONG,
        DM_DOITUONG2, //Bao gồm : Người không khuyết tât, người khuyết tật

        DM_KHUYETTAT_MUCDO,
        DM_KHUYETTAT_NGUYENNHAN,
        DM_KHUYETTAT_TINHTRANG,
        DM_PHUONGTIEN_DILAI,
        DM_TINHTRANG_HONNHAN,

        DM_DUNGCU_HOTRO,
        DM_NOI_SINH_SONG,
        DM_NOI_O_NHA,
        DM_NOI_O_SONG_VOI,
        DM_CHAMSOC_BANTHAN,

        DM_NHUCAU,
        DM_THANHVIEN_HOI,
        DM_NGOAINGU,
        DM_NHA_TAI_TRO,
        DM_NHA_TAI_TRO_LOAI,
        DM_DONVI_PHUTRACH,
        DM_LOAI_HOATDONG,
        DM_TCXH_HANG_THANG
    }

    enum FunctionName
    {
        FUNC_LYLICH = 1,
        FUNC_VIECLAM,
        FUNC_NANGCAO_NHANTHUC,
        FUNC_NANGCAO_NANGLUC,
        FUNC_ANSINH_XAHOI,
        FUNC_HOANHAP_XAHOI,
        FUNC_HOATDONG_KHAC,
        FUNC_BC_KHAC
    }

    enum CategoryTapHuan
    {
        TH_TAPHUAN = 1,
        TH_GIAODUC,
        HUONG_DAN_THUC_TAP,
        VAN_DONG_CHINH_SACH,
        TRUYEN_THONG_PHAP_LY,
        HOI_NGHI,
        HOI_THAO
    }

    enum CategoryDoiTuong
    {
        DT_NGUOI_KHONG_KHUYET_TAT = 1,
        DT_NGUOI_KHUYET_TAT
    }

    enum CategoryHoiThao
    {
        DAI_HOI = 1,
        HOI_NGHI, //không dùng
        HOI_THAO, //không dùng
        BUOI_LE,
        CUOC_HOP,
        TRUYEN_THONG_DAI_CHUNG,
        TO_CHUC_SU_KIEN,
        TO_CHUC_VAN_NGHE,
        TO_CHUC_THE_THAO
    }

    enum CategoryASXH
    {
        GIAI_PHAU_CHINH_HINH = 1,
        TANG_QUA,
        TANG_DUNG_CU_TRO_GIUP,
        HOC_BONG,
        BHYT,
        HO_TRO_HOI_VIEN_KHO_KHAN,
        THAM_VIENG_HUU_SU,
        DAM_CUOI,
        CAT_NHA,
        SUA_NHA
    }

    enum CategoryHNXH
    {
        GIAO_LUU = 1,
        LIEN_HOAN,
        DON_KHACH,
        THAM_QUAN_DU_LICH,
        VAN_NGHE,
        THE_THAO,
        LAO_DONG_CONG_ICH
    }

    enum CategoryViecLam
    {
        GIOI_THIEU_VIEC_LAM = 1,
        GIAI_QUYET_VIEC_LAM
    }

    /// <summary>
    /// Liệt kê các mẫu báo cáo có trong hệ thống
    /// Sử dụng:
    /// 1. Nhận biết biểu mẫu để hiển thị phần header.
    /// </summary>
    public enum LoaiBaoCao
    {
        [Description("(01)Chi tiết hồ sơ dự thầu")]
        BM01 = 1,

        [Description("(02)Sản phẩm tham gia xét thầu")]
        BM02,

        [Description("(03)Sản phẩm giá chào thầu nhỏ nhất")]
        BM03,

        [Description("(04)Tổng hợp sản phẩm dự thầu")]
        BM04,

        [Description("(05)Sản phẩm đạt điểm kỹ thuật")]
        BM05,

        [Description("(06)Đề nghị trúng thầu theo từng SP của 1 công ty")]
        BM06,

        [Description("(07)Đề nghị trúng thầu theo gói thầu")]
        BM07,

        [Description("(08)Đề nghị trúng thầu theo gói thầu - giá kê khai")]
        BM08,

        [Description("(09)Đề nghị trúng thầu theo gói thầu - không giá kế hoạch")]
        BM09,

        [Description("(10)Danh sách công ty trúng thầu")]
        BM10,

        [Description("(11)Danh sách sản phẩm trúng thầu")]
        BM11,

        [Description("(12)Danh sách sản phẩm loại pháp lý")]
        BM12,

        [Description("(13)Danh sách sản phẩm vượt giá kế hoạch")]
        BM13,

        [Description("(14)Sản phẩm vượt giá kế hoạch (giá trị vượt)")]
        BM14,

        [Description("(15)Danh sách Công ty không trúng thầu")]
        BM15,

        [Description("(16)Danh sách sản phẩm loại pháp lý (mẫu 01)")]
        BM16,

        [Description("(17)Danh sách sản phẩm loại pháp lý (mẫu 02)")]
        BM17,

        [Description("(18)Sản phẩm không tham gia xét thầu")]
        BM18,

        [Description("(19)Danh mục mặt hàng không trúng thầu - theo gói thầu")]
        BM19,

        [Description("(20)Danh sách Công ty mua - nộp hồ sơ")]
        BM20,

        [Description("(21)Danh sách Công ty không nộp dữ liệu")]
        BM21,

        [Description("(22)Biên bản pháp lý")]
        BM22,

        [Description("(23)Sản phẩm của nhà thầu")]
        BM23,

        [Description("(24)Sản phẩm chỉ có một công ty đấu thầu")]
        BM24,

        [Description("(25)Sản phẩm được xét giá đánh giá")]
        BM25,

        [Description("(28)Tổng hợp sản phẩm chênh lệch giá dự thầu giữa các nhóm")]
        BM28,

        [Description("(29)Thống kê kết quả công ty tham dự")]
        BM29,

        [Description("Điểm kỹ thuật theo gói thầu")]
        BM27,
    }

    /// <summary>
    /// Danh sách loại cấu hình
    /// Phân biệt các danh sách cấu hình
    /// </summary>
    enum loaiCauHinh
    {
        [Description("System")]
        Type_System = 5,
        [Description("Report")]
        Type_Report = 8,
    }

    public static class CustomizeEnum{

        public static string GetDescriptionExtension(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        /// <summary>
        /// value : phẩn tử của enum (Type_System, BM01, ...)
        /// value.GetType() : kiểu của enum tương ứng (loaiCauHinh, LoaiBaoCao, ...)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int GetValueExtension(this Enum value)
        {
            Array values = Enum.GetValues(value.GetType());
            foreach (var val in values)
            {
                if (val.ToString() == value.ToString())
                {
                    return (int)Enum.Parse(value.GetType(), val.ToString());
                }
            }
            throw new ArgumentException("Không xác định giá trị của enum.");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetNameExtension(this Enum value)
        {
            return value.ToString();
        }

        public static IEnumerable<T> EnumToList<T>()
        {
            Type enumType = typeof(T);

            // Can't use generic type constraints on value types,
            // so have to do check like this
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = Enum.GetValues(enumType);
            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }
    }

}
