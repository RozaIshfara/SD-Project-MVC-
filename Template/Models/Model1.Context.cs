//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Template.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class frrEntities : DbContext
    {
        public frrEntities()
            : base("name=frrEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblCategory> tblCategory { get; set; }
        public virtual DbSet<tblContact> tblContact { get; set; }
        public virtual DbSet<tblInvoice> tblInvoice { get; set; }
        public virtual DbSet<tblOrder> tblOrder { get; set; }
        public virtual DbSet<tblProduct> tblProduct { get; set; }
        public virtual DbSet<tblUser> tblUser { get; set; }
    }
}
