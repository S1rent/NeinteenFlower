﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NeinteenFlower_FrontEnd.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NeinteenFlowerDBEntities : DbContext
    {
        public NeinteenFlowerDBEntities()
            : base("name=NeinteenFlowerDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<MsEmployee> MsEmployees { get; set; }
        public virtual DbSet<MsFlower> MsFlowers { get; set; }
        public virtual DbSet<MsFlowerType> MsFlowerTypes { get; set; }
        public virtual DbSet<MsMember> MsMembers { get; set; }
        public virtual DbSet<TrDetail> TrDetails { get; set; }
        public virtual DbSet<TrHeader> TrHeaders { get; set; }
    }
}
