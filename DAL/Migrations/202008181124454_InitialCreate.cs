namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityNumber = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        CompanyName = c.String(),
                        BusinessCode = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        CellNumber = c.String(nullable: false),
                        Address = c.String(),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Element = c.String(nullable: false),
                        SiteAdress = c.String(nullable: false),
                        ConcreteCheck = c.Boolean(nullable: false),
                        PumpNeeded = c.Boolean(nullable: false),
                        PumpType = c.String(),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        IsIssue = c.Boolean(nullable: false),
                        Status = c.Boolean(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
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
                        Date = c.DateTime(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.DriverId)
                .Index(t => t.OrderId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityNumber = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        CellNumber = c.String(nullable: false),
                        Address = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        EntryToWorkDate = c.DateTime(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        PipesLengh = c.Int(nullable: false),
                        LicenseNumber = c.String(nullable: false),
                        DriverId = c.Int(nullable: false),
                        MixerNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.MaterialTypeOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.MaterialId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProviderId = c.Int(nullable: false),
                        MaterialId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Providers", t => t.ProviderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProviderId)
                .Index(t => t.MaterialId);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentityNumber = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        CellNumber = c.String(),
                        Address = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterialTypeOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.MaterialTypeOrders", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.OrderDetails", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.DriverWorks", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.DriverWorks", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "Id", "dbo.Drivers");
            DropForeignKey("dbo.DriverWorks", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderDetails", new[] { "MaterialId" });
            DropIndex("dbo.OrderDetails", new[] { "ProviderId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "MaterialId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "OrderId" });
            DropIndex("dbo.Vehicles", new[] { "Id" });
            DropIndex("dbo.DriverWorks", new[] { "VehicleId" });
            DropIndex("dbo.DriverWorks", new[] { "OrderId" });
            DropIndex("dbo.DriverWorks", new[] { "DriverId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.Managers");
            DropTable("dbo.Providers");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Materials");
            DropTable("dbo.MaterialTypeOrders");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Drivers");
            DropTable("dbo.DriverWorks");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
