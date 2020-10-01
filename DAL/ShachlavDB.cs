using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;

namespace DAL
{
    public class ShachlavDB : DbContext
    {

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverWork> DriverWorks { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<MaterialProvider> MaterialProviders { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<MaterialTypeOrder> MaterialTypeOrders { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialCategory> MaterialCategorys { get; set; }
        public virtual DbSet<StatusMaterial> StatusMaterials { get; set; }
        public virtual DbSet<StatusProvider> StatusProviders { get; set; }

       public virtual DbSet<OrderViewDTO> OrderViewDto { get; set; }
        public virtual DbSet<MaterialTypeOrderView> MaterialForview { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            //making sure these tables wont be created in DB
            modelBuilder.Ignore<OrderViewDTO>();
            modelBuilder.Ignore<MaterialTypeOrderView>();



        }


        public ShachlavDB() : base(@"data source=(localdb)\mssqllocaldb;initial catalog=DAL.ShachlavDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShachlavDB, DAL.Migrations.Configuration>());
            Database.Initialize(force: false);



        }

    }
}
