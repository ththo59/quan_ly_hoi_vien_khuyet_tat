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
    
    public partial class DM_XA
    {
        public long XA_ID { get; set; }
        public string XA_TEN { get; set; }
        public Nullable<long> HUYEN_ID { get; set; }
        public string XA_DIENGIAI { get; set; }
        public Nullable<int> XA_STT { get; set; }
    
        public virtual DM_HUYEN DM_HUYEN { get; set; }
    }
}
