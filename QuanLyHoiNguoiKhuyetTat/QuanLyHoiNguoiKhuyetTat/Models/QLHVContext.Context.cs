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
        public virtual DbSet<DM_CHUCVU_HOI> DM_CHUCVU_HOI { get; set; }
        public virtual DbSet<DM_DANTOC> DM_DANTOC { get; set; }
        public virtual DbSet<DM_TONGIAO> DM_TONGIAO { get; set; }
        public virtual DbSet<DM_KHUYETTAT_MUCDO> DM_KHUYETTAT_MUCDO { get; set; }
        public virtual DbSet<DM_KHUYETTAT_NGUYENNHAN> DM_KHUYETTAT_NGUYENNHAN { get; set; }
        public virtual DbSet<DM_KHUYETTAT_TINHTRANG> DM_KHUYETTAT_TINHTRANG { get; set; }
        public virtual DbSet<DM_PHUONGTIEN_DILAI> DM_PHUONGTIEN_DILAI { get; set; }
        public virtual DbSet<DM_TINHTRANG_HONNHAN> DM_TINHTRANG_HONNHAN { get; set; }
        public virtual DbSet<DM_XA> DM_XA { get; set; }
        public virtual DbSet<DM_NOI_O_NHA> DM_NOI_O_NHA { get; set; }
        public virtual DbSet<DM_CHAMSOC_BANTHAN> DM_CHAMSOC_BANTHAN { get; set; }
        public virtual DbSet<DM_NOI_O_SONG_VOI> DM_NOI_O_SONG_VOI { get; set; }
        public virtual DbSet<DM_NHUCAU> DM_NHUCAU { get; set; }
        public virtual DbSet<DM_THANHVIEN_HOI> DM_THANHVIEN_HOI { get; set; }
        public virtual DbSet<DM_DUNGCU_HOTRO> DM_DUNGCU_HOTRO { get; set; }
        public virtual DbSet<DM_NOI_SINH_SONG> DM_NOI_SINH_SONG { get; set; }
        public virtual DbSet<DM_NGOAINGU> DM_NGOAINGU { get; set; }
        public virtual DbSet<QL_HOIVIEN> QL_HOIVIEN { get; set; }
        public virtual DbSet<QL_HOATDONG_ASXH> QL_HOATDONG_ASXH { get; set; }
        public virtual DbSet<QL_HOATDONG_DAYNGHE> QL_HOATDONG_DAYNGHE { get; set; }
        public virtual DbSet<QL_HOATDONG_HNXH> QL_HOATDONG_HNXH { get; set; }
        public virtual DbSet<QL_HOATDONG_HOITHAO> QL_HOATDONG_HOITHAO { get; set; }
        public virtual DbSet<QL_HOATDONG_KHAC> QL_HOATDONG_KHAC { get; set; }
        public virtual DbSet<QL_HOATDONG_TAPHUAN> QL_HOATDONG_TAPHUAN { get; set; }
        public virtual DbSet<QL_HOATDONG_VAYVON> QL_HOATDONG_VAYVON { get; set; }
        public virtual DbSet<QL_HOATDONG_VIECLAM> QL_HOATDONG_VIECLAM { get; set; }
        public virtual DbSet<QL_USERS> QL_USERS { get; set; }
        public virtual DbSet<QL_USERS_PERMISSION> QL_USERS_PERMISSION { get; set; }
        public virtual DbSet<QL_HOATDONG_HOICHO_TRIENLAM> QL_HOATDONG_HOICHO_TRIENLAM { get; set; }
        public virtual DbSet<DM_NHA_TAI_TRO> DM_NHA_TAI_TRO { get; set; }
        public virtual DbSet<DM_NHA_TAI_TRO_CHITIET> DM_NHA_TAI_TRO_CHITIET { get; set; }
        public virtual DbSet<DM_NHA_TAI_TRO_LOAI> DM_NHA_TAI_TRO_LOAI { get; set; }
    }
}
