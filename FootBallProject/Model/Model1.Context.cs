﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootBallProject.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class officialleagueEntities1 : DbContext
    {
        public officialleagueEntities1()
            : base("name=officialleagueEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CAUTHU> CAUTHUs { get; set; }
        public virtual DbSet<DIADIEM> DIADIEMs { get; set; }
        public virtual DbSet<DIEM> DIEMs { get; set; }
        public virtual DbSet<DOIBONG> DOIBONGs { get; set; }
        public virtual DbSet<DOIHINHCHINH> DOIHINHCHINHs { get; set; }
        public virtual DbSet<FOOTBALLMATCH> FOOTBALLMATCHes { get; set; }
        public virtual DbSet<HUANLUYENVIEN> HUANLUYENVIENs { get; set; }
        public virtual DbSet<ITEM> ITEMs { get; set; }
        public virtual DbSet<ITEMTYPE> ITEMTYPEs { get; set; }
        public virtual DbSet<LEAGUE> LEAGUEs { get; set; }
        public virtual DbSet<OTP> OTPs { get; set; }
        public virtual DbSet<QUOCTICH> QUOCTICHes { get; set; }
        public virtual DbSet<ROUND> ROUNDs { get; set; }
        public virtual DbSet<TAPLUYEN> TAPLUYENs { get; set; }
        public virtual DbSet<TEAMOFLEAGUE> TEAMOFLEAGUEs { get; set; }
        public virtual DbSet<THONGTINGIAIDAU> THONGTINGIAIDAUs { get; set; }
        public virtual DbSet<THONGTINTRANDAU> THONGTINTRANDAUs { get; set; }
        public virtual DbSet<USERROLE> USERROLEs { get; set; }
        public virtual DbSet<USER> USERS { get; set; }
    }
}
