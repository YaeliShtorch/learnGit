namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ShachlavDB>
    {
        private readonly bool _pendingMigrations;
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //לבדוק אם עובד בDB חדש
            // Check if there are migrations pending to run, this can happen if database doesn't exist or if there was any
            //  change in the schema

            //var migrator = new DbMigrator(this);
            //_pendingMigrations = migrator.GetPendingMigrations().Any();

            // If there are pending migrations run migrator.Update() to create/update the database then run the Seed() method to populate
            //  the data if necessary

            //if (_pendingMigrations)
            //{
            //    migrator.Update();
            //    Seed(new ShachlavDB());
            //}
        }
  
        protected override void Seed(ShachlavDB shachlav)
        {
           
            #region Material Status
            //for the first time only
            if (shachlav.StatusMaterial.Any()!=true) {
            var statusMaterialList = new List<StatusMaterial>()
            {
                new StatusMaterial(){Name="מחכה לאישור ספק"},
                new StatusMaterial(){Name="מחכה לאישור מנהל"},
                new StatusMaterial(){Name="מאושר"},
                new StatusMaterial(){Name="בוטל"}
            };
            statusMaterialList.ForEach(x => { shachlav.StatusMaterial.Add(x); });
            shachlav.SaveChanges();
            }
            #endregion

            #region Provider Status
            //for the first time only
            if (shachlav.StatusProvider.Any()!=true) { 
            var statusProviderList = new List<StatusProvider>()
            {
                new StatusProvider(){Name="מחכה לאישור"},
                new StatusProvider(){Name="מאושר עי ספק"},
                new StatusProvider(){Name="סורב"}
            };
            statusProviderList.ForEach(x => { shachlav.StatusProvider.Add(x); });
            shachlav.SaveChanges();
            }
            #endregion




        }



    }
}
