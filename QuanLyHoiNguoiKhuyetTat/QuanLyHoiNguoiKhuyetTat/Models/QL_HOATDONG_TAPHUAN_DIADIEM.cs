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
    
    public partial class QL_HOATDONG_TAPHUAN_DIADIEM
    {
        public long TH_DD_ID { get; set; }
        public Nullable<long> TH_ID { get; set; }
        public string TH_DD_TEN { get; set; }
        public string TH_DD_DIACHI { get; set; }
        public string TH_DD_MST { get; set; }
        public string TH_DD_SDT { get; set; }
        public string TH_DD_STK { get; set; }
        public string TH_DD_TEN_NGANHANG { get; set; }
        public string TH_DD_LINK_HOPDONG { get; set; }
    
        public virtual QL_HOATDONG_TAPHUAN QL_HOATDONG_TAPHUAN { get; set; }
    }
}
