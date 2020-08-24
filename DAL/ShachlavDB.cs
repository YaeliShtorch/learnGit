using System;
 using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class ShachlavDB:DbContext
    {

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }
        public virtual DbSet<DriverWork> DriverWork { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Material> Material { get; set; }

        public virtual DbSet<MaterialTypeOrder> MaterialTypeOrder { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }
        public virtual DbSet<PumpType> PumpType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public ShachlavDB():base(@"data source=(localdb)\mssqllocaldb;initial catalog=DAL.ShachlavDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShachlavDB, DAL.Migrations.Configuration>());
        }

    }
}
