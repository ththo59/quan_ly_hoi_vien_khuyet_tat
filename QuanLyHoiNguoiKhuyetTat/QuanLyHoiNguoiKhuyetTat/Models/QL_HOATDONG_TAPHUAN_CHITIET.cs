//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DauThau.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class QL_HOATDONG_TAPHUAN_CHITIET
    {
        public long TH_CT_ID { get; set; }
        public Nullable<long> TH_ID { get; set; }
        public Nullable<int> TH_CT_LOAI { get; set; }
        public Nullable<long> TH_CT_DOITUONG { get; set; }
        public string TH_CT_DANGTAT { get; set; }
        public string TH_CT_HO { get; set; }
        public string TH_CT_TEN { get; set; }
        public string TH_CT_GIOITINH { get; set; }
        public string TH_CT_CHUCVU { get; set; }
        public string TH_CT_EMAIL { get; set; }
        public string TH_CT_FACEBOOK { get; set; }
        public string TH_CT_CMND_SO { get; set; }
        public Nullable<System.DateTime> TH_CT_CMND_NGAYCAP { get; set; }
        public string TH_CT_CMND_NOICAP { get; set; }
        public string TH_CT_DIACHI { get; set; }
        public string TH_CT_DONVI_TEN { get; set; }
        public string TH_CT_DONVI_DIACHI { get; set; }
        public string TH_CT_DONVI_SDT { get; set; }
        public string TH_CT_SDT { get; set; }
        public string TH_CT_MASOTHUE { get; set; }
        public string TH_CT_TK_SO { get; set; }
        public string TH_CT_TK_NGANHANG { get; set; }
        public string TH_CT_TK_DIACHI { get; set; }
        public string TH_CT_LINK_TOR { get; set; }
        public string TH_CT_LINK_CV { get; set; }
        public string TH_CT_LINK_HOPDONG { get; set; }
        public string TH_CT_LINK_BANCAMKET { get; set; }
        public Nullable<int> TH_CT_CHIPHI_1 { get; set; }
        public Nullable<int> TH_CT_CHIPHI_2 { get; set; }
        public Nullable<int> TH_CT_CHIPHI_3 { get; set; }
        public Nullable<int> TH_CT_CHIPHI_4 { get; set; }
    
        public virtual QL_HOATDONG_TAPHUAN QL_HOATDONG_TAPHUAN { get; set; }
    }
}
