//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ItPartnerPractice.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ItPartner10Entities : DbContext
    {
        public ItPartner10Entities()
            : base("name=ItPartner10Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<ServicesInOrders> ServicesInOrders { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
