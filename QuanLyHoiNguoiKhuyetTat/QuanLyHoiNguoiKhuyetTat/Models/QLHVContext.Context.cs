﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QL_HOIVIEN_KTEntities : DbContext
    {
        public QL_HOIVIEN_KTEntities()
            : base("name=QL_HOIVIEN_KTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DM_HUYEN> DM_HUYEN { get; set; }
        public virtual DbSet<DM_NGHE_NGHIEP> DM_NGHE_NGHIEP { get; set; }
        public virtual DbSet<DM_TINH> DM_TINH { get; set; }
        public virtual DbSet<DM_TRINH_DO_CHUYEN_MON> DM_TRINH_DO_CHUYEN_MON { get; set; }
        public virtual DbSet<DM_TRINH_DO_HOC_VAN> DM_TRINH_DO_HOC_VAN { get; set; }
        public virtual DbSet<DM_XA> DM_XA { get; set; }
    }
}
