﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Inventory_Manager
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PublicEntities1 : DbContext
    {
        public PublicEntities1()
            : base("name=PublicEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Product> Product { get; set; }
    }
}
