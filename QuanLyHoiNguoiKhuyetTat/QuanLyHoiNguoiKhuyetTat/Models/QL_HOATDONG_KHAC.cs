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
    
    public partial class QL_HOATDONG_KHAC
    {
        public long KHAC_ID { get; set; }
        public string KHAC_TEN_HOATDONG { get; set; }
        public string KHAC_TEN { get; set; }
        public Nullable<System.DateTime> KHAC_THOIGIAN_BATDAU { get; set; }
        public Nullable<System.DateTime> KHAC_THOIGIAN_KETTHUC { get; set; }
        public Nullable<int> KHAC_TONGSO_NGAY { get; set; }
        public string KHAC_DIADIEM { get; set; }
        public Nullable<int> KHAC_SOLUONG { get; set; }
        public Nullable<int> KHAC_TONGSO_TIEN { get; set; }
        public string KHAC_DOITUONG { get; set; }
        public string KHAC_DONVI_THUCHIEN { get; set; }
        public string KHAC_NOIDUNG { get; set; }
    }
}
