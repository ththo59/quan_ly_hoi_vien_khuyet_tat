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
    
    public partial class QL_HOATDONG_VAYVON_CHITIET
    {
        public long VV_CT_ID { get; set; }
        public Nullable<long> VV_ID { get; set; }
        public Nullable<long> HV_ID { get; set; }
        public Nullable<int> SOTIEN { get; set; }
    
        public virtual QL_HOATDONG_VAYVON QL_HOATDONG_VAYVON { get; set; }
        public virtual QL_HOIVIEN QL_HOIVIEN { get; set; }
    }
}