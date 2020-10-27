namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ShachlavDB>
    {
        private readonly bool pendingMigrations;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //לבדוק אם עובד בDB חדש
            // Check if there are migrations pending to run, this can happen if database doesn't exist or if there was any
            //  change in the schema

            //var migrator = new DbMigrator(this);
            //pendingMigrations = migrator.GetPendingMigrations().Any();

            // If there are pending migrations run migrator.Update() to create/update the database then run the Seed() method to populate
            //  the data if necessary

            //if (pendingMigrations == true)
            //{
            //    migrator.Update();
            //    Seed(new ShachlavDB());
            //}

        }

        protected override void Seed(ShachlavDB shachlav)
        {
            //for debugging
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}
            #region Material Status
            //for the first time only
            if (shachlav.StatusMaterials.Any() != true)
            {
                var statusMaterialList = new List<StatusMaterial>()
            {
                new StatusMaterial(){Name="מחכה לאישור ספק"},
                new StatusMaterial(){Name="מחכה לאישור מנהל"},
                new StatusMaterial(){Name="מאושר"},
                new StatusMaterial(){Name="בוטל"}
            };
                statusMaterialList.ForEach(x => { shachlav.StatusMaterials.Add(x); });
                shachlav.SaveChanges();
            }
            #endregion

            #region Provider Status
            //for the first time only
            if (shachlav.StatusProviders.Any() != true)
            {
                var statusProviderList = new List<StatusProvider>()
            {
                new StatusProvider(){Name="מחכה לאישור"},
                new StatusProvider(){Name="מאושר עי ספק"},
                new StatusProvider(){Name="סורב"}
            };
                statusProviderList.ForEach(x => { shachlav.StatusProviders.Add(x); });
                shachlav.SaveChanges();
            }
            #endregion

            #region MaterialCategory

            if (shachlav.MaterialCategorys.Any() != true)
            {
                var Categories= new List<MaterialCategory>()
            {
                new MaterialCategory(){Name="משאבה"},
                new MaterialCategory(){Name="בטון הרחבה"},
                new MaterialCategory(){Name="בטון חשיפה"},
                new MaterialCategory(){Name="בטון שקיעה"},
                new MaterialCategory(){Name="בטון תוספת"},
                new MaterialCategory(){Name="טיט"}
            };
                Categories.ForEach(x => { shachlav.MaterialCategorys.Add(x); });
                shachlav.SaveChanges();
            }

            #endregion

            #region orderView

            int isExist =-1;
            // check- var ExistVW4 = context.Database.SqlQuery<int>(@"SELECT CASE WHEN NOT exists  (SELECT * FROM sys.views WHERE name ='Report1-4') THEN 0 ELSE 1 END "); if (ExistVW4.First() == 0)
           //isExist = shachlav.Database.ExecuteSqlCommand("IF object_id('dbo.OrderDTO') is not null PRINT '1' ELSE PRINT '0'");
            //to check why not working
            //var  isExist = shachlav.Database.SqlQuery<int>("select count(*)from INFORMATION_SCHEMA.VIEWS where table_name = 'dbo.OrderDTO'");
            if (isExist==0)
            {
                shachlav.Database.ExecuteSqlCommand("CREATE VIEW dbo.OrderDTO AS SELECT o.Id, c.FirstName + '' + c.LastName as CustomerName, o.SiteAdress, o.OrderDate, o.OrderDueDate, o.StartTime, o.EndTime," +
                    " o.IsApproved, o.IsDone, o.ManagerComment, o.Comment, o.ConcreteTest FROM dbo.Orders o INNER JOIN dbo.Customers c ON o.CustomerId = c.Id");

            }

            //isExist = shachlav.Database.SqlQuery<int>("select count(*)from INFORMATION_SCHEMA.VIEWS where table_name = 'dbo.MaterialDTO'");
            //isExist = shachlav.Database.ExecuteSqlCommand("IF object_id('dbo.MaterialDTO') is not null PRINT '1' ELSE PRINT '0'");
            if (isExist==0)
            {
                shachlav.Database.ExecuteSqlCommand("CREATE VIEW dbo.MaterialDTO AS SELECT mt.Id, o.Id AS OrderId, mt.Element, mt.Amount, sm.Name as StatusMaterial," +
                    " m.Name as MaterialName, mt.ManagerComment, mt.PipeLength FROM dbo.Orders o INNER JOIN dbo.MaterialTypeOrders mt ON mt.OrderId = o.Id INNER JOIN dbo.StatusMaterials AS sm ON sm.Id = mt.StatusMaterialId INNER JOIN dbo.Materials AS m ON m.Id = mt.MaterialId");

            }
            #endregion

        }



    }
}
