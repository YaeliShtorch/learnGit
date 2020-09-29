namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class status : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityNumber = c.String(nullable: false, maxLength: 9),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        BusinessCode = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        CellNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        SiteAdress = c.String(nullable: false),
                        OrderDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        OrderDueDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        IsApproved = c.Boolean(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        ManagerComment = c.String(),
                        Comment = c.String(),
                        ConcreteTest = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.DriverWorks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DriverId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        VehicleId = c.Int(nullable: false),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.DriverId)
                .Index(t => t.OrderId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityNumber = c.String(nullable: false, maxLength: 9),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        CellNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EntryToWorkDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        PipeLength = c.Int(nullable: false),
                        LicenseNumber = c.String(nullable: false),
                        DriverId = c.Int(nullable: false),
                        MixerNumber = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .ForeignKey("dbo.Materials", t => t.MaterialId)
                .Index(t => t.DriverId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MaterialCategoryId = c.Int(nullable: false),
                        PipeLength = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialCategories", t => t.MaterialCategoryId)
                .Index(t => t.MaterialCategoryId);
            
            CreateTable(
                "dbo.MaterialCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaterialTypeOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Element = c.String(),
                        Amount = c.Int(nullable: false),
                        StatusMaterialId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        ManagerComment = c.String(),
                        PipeLength = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.StatusMaterials", t => t.StatusMaterialId)
                .Index(t => t.OrderId)
                .Index(t => t.StatusMaterialId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.MaterialProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialTypeOrderId = c.Int(nullable: false),
                        ProviderId = c.Int(nullable: false),
                        StatusProviderId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        ManagerApproval = c.Boolean(nullable: false),
                        ProviderComment = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialTypeOrders", t => t.MaterialTypeOrderId)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
                .ForeignKey("dbo.StatusProviders", t => t.StatusProviderId)
                .Index(t => t.MaterialTypeOrderId)
                .Index(t => t.ProviderId)
                .Index(t => t.StatusProviderId);
            
            CreateTable(
                "dbo.Providers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        CompanyCode = c.String(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        CellNumber = c.String(nullable: false),
                        Email = c.String(),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityNumber = c.String(nullable: false, maxLength: 9),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        CellNumber = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterialTypeOrders", "StatusMaterialId", "dbo.StatusMaterials");
            DropForeignKey("dbo.MaterialTypeOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.MaterialProviders", "StatusProviderId", "dbo.StatusProviders");
            DropForeignKey("dbo.MaterialProviders", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.MaterialProviders", "MaterialTypeOrderId", "dbo.MaterialTypeOrders");
            DropForeignKey("dbo.MaterialTypeOrders", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.DriverWorks", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Vehicles", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Materials", "MaterialCategoryId", "dbo.MaterialCategories");
            DropForeignKey("dbo.DriverWorks", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.DriverWorks", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.MaterialProviders", new[] { "StatusProviderId" });
            DropIndex("dbo.MaterialProviders", new[] { "ProviderId" });
            DropIndex("dbo.MaterialProviders", new[] { "MaterialTypeOrderId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "MaterialId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "StatusMaterialId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "OrderId" });
            DropIndex("dbo.Materials", new[] { "MaterialCategoryId" });
            DropIndex("dbo.Vehicles", new[] { "MaterialId" });
            DropIndex("dbo.Vehicles", new[] { "DriverId" });
            DropIndex("dbo.DriverWorks", new[] { "VehicleId" });
            DropIndex("dbo.DriverWorks", new[] { "OrderId" });
            DropIndex("dbo.DriverWorks", new[] { "DriverId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.Managers");
            DropTable("dbo.StatusMaterials");
            DropTable("dbo.StatusProviders");
            DropTable("dbo.Providers");
            DropTable("dbo.MaterialProviders");
            DropTable("dbo.MaterialTypeOrders");
            DropTable("dbo.MaterialCategories");
            DropTable("dbo.Materials");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Drivers");
            DropTable("dbo.DriverWorks");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
