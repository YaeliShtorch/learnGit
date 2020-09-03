namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClayTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaterialTypeOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        IsConcrete = c.Boolean(nullable: false),
                        ConcreteTypeId = c.Int(nullable: false),
                        ConcDescId = c.Int(nullable: false),
                        DeepId = c.Int(nullable: false),
                        ExposureId = c.Int(nullable: false),
                        ExtensionId = c.Int(nullable: false),
                        IsClay = c.Boolean(nullable: false),
                        ClayTypeId = c.Int(nullable: false),
                        IsPump = c.Boolean(nullable: false),
                        VehicleTypeId = c.Int(nullable: false),
                        Element = c.String(nullable: false),
                        Amount = c.Int(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClayTypes", t => t.ClayTypeId)
                .ForeignKey("dbo.ConcDescs", t => t.ConcDescId)
                .ForeignKey("dbo.ConcreteTypes", t => t.ConcreteTypeId)
                .ForeignKey("dbo.Deeps", t => t.DeepId)
                .ForeignKey("dbo.Exposures", t => t.ExposureId)
                .ForeignKey("dbo.Extensions", t => t.ExtensionId)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId)
                .Index(t => t.ConcreteTypeId)
                .Index(t => t.ConcDescId)
                .Index(t => t.DeepId)
                .Index(t => t.ExposureId)
                .Index(t => t.ExtensionId)
                .Index(t => t.ClayTypeId)
                .Index(t => t.VehicleTypeId)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "dbo.ConcDescs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConcreteTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deeps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exposures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Extensions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                        MaterialTypeOrderId = c.Int(nullable: false),
                        ConcreteTest = c.Boolean(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        ManagerComment = c.String(),
                        Comment = c.String(),
                        MaterialTypeOrder_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.MaterialTypeOrders", t => t.MaterialTypeOrderId)
                .ForeignKey("dbo.MaterialTypeOrders", t => t.MaterialTypeOrder_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.MaterialTypeOrderId)
                .Index(t => t.MaterialTypeOrder_Id);
            
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
                        VehicleTypeId = c.Int(),
                        MixerNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId)
                .Index(t => t.DriverId)
                .Index(t => t.VehicleTypeId);
            
            CreateTable(
                "dbo.VehicleTypes",
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
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
                .Index(t => t.OrderId)
                .Index(t => t.ProviderId);
            
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
            DropForeignKey("dbo.Orders", "MaterialTypeOrder_Id", "dbo.MaterialTypeOrders");
            DropForeignKey("dbo.MaterialTypeOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.MaterialTypeOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "MaterialTypeOrderId", "dbo.MaterialTypeOrders");
            DropForeignKey("dbo.DriverWorks", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.MaterialTypeOrders", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.DriverWorks", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.DriverWorks", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.MaterialTypeOrders", "ExtensionId", "dbo.Extensions");
            DropForeignKey("dbo.MaterialTypeOrders", "ExposureId", "dbo.Exposures");
            DropForeignKey("dbo.MaterialTypeOrders", "DeepId", "dbo.Deeps");
            DropForeignKey("dbo.MaterialTypeOrders", "ConcreteTypeId", "dbo.ConcreteTypes");
            DropForeignKey("dbo.MaterialTypeOrders", "ConcDescId", "dbo.ConcDescs");
            DropForeignKey("dbo.MaterialTypeOrders", "ClayTypeId", "dbo.ClayTypes");
            DropIndex("dbo.OrderDetails", new[] { "ProviderId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeId" });
            DropIndex("dbo.Vehicles", new[] { "DriverId" });
            DropIndex("dbo.DriverWorks", new[] { "VehicleId" });
            DropIndex("dbo.DriverWorks", new[] { "OrderId" });
            DropIndex("dbo.DriverWorks", new[] { "DriverId" });
            DropIndex("dbo.Orders", new[] { "MaterialTypeOrder_Id" });
            DropIndex("dbo.Orders", new[] { "MaterialTypeOrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "Order_Id" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "VehicleTypeId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ClayTypeId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ExtensionId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ExposureId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "DeepId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ConcDescId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ConcreteTypeId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "OrderId" });
            DropTable("dbo.Managers");
            DropTable("dbo.Providers");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Drivers");
            DropTable("dbo.DriverWorks");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.Extensions");
            DropTable("dbo.Exposures");
            DropTable("dbo.Deeps");
            DropTable("dbo.ConcreteTypes");
            DropTable("dbo.ConcDescs");
            DropTable("dbo.MaterialTypeOrders");
            DropTable("dbo.ClayTypes");
        }
    }
}
