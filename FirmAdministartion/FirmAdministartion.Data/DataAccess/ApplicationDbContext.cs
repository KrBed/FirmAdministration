using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FirmAdministartion.Data.Identity;
using FirmAdministration.Entities.DomainModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FirmAdministartion.Data.DataAccess
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Inventory> Inventories { get; set; }
        public IDbSet<History> Histories { get; set; }
        public IDbSet<InventoryType> InventoryTypes { get; set; }
        public IDbSet<InventoryHistory> InventoryHistories { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<InventoryHistory>()
                .HasRequired(i=>i.Inventory)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}