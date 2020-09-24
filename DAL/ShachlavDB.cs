using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ShachlavDB : DbContext
    {

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverWork> DriverWork { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<MaterialProvider> MaterialProviders { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<MaterialTypeOrder> MaterialTypeOrder { get; set; }
        public virtual DbSet<Material> Material { get; set; }
        public virtual DbSet<MaterialCategory> MaterialCategory { get; set; }
        public virtual DbSet<StatusMaterial> StatusMaterial { get; set; }
        public virtual DbSet<StatusProvider> StatusProvider { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));


        }


        public ShachlavDB() : base(@"data source=(localdb)\mssqllocaldb;initial catalog=DAL.ShachlavDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShachlavDB, DAL.Migrations.Configuration>());
            Database.Initialize(force: false);



        }

    }
}
