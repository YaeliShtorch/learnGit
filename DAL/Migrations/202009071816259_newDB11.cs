namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaterialTypeOrders", "ClayTypeId", "dbo.ClayTypes");
            DropForeignKey("dbo.MaterialTypeOrders", "ConcDescId", "dbo.ConcDescs");
            DropForeignKey("dbo.MaterialTypeOrders", "ConcreteTypeId", "dbo.ConcreteTypes");
            DropForeignKey("dbo.MaterialTypeOrders", "DeepId", "dbo.Deeps");
            DropForeignKey("dbo.MaterialTypeOrders", "ExposureId", "dbo.Exposures");
            DropForeignKey("dbo.MaterialTypeOrders", "ExtensionId", "dbo.Extensions");
            DropForeignKey("dbo.MaterialTypeOrders", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.VehicleTypes");
            DropIndex("dbo.MaterialTypeOrders", new[] { "ConcreteTypeId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ConcDescId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "DeepId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ExposureId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ExtensionId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ClayTypeId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "VehicleTypeId" });
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeId" });
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialCategoryId = c.Int(nullable: false),
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
            
            AddColumn("dbo.MaterialTypeOrders", "MaterialId", c => c.Int());
            CreateIndex("dbo.MaterialTypeOrders", "MaterialId");
            AddForeignKey("dbo.MaterialTypeOrders", "MaterialId", "dbo.Materials", "Id");
            DropColumn("dbo.MaterialTypeOrders", "IsConcrete");
            DropColumn("dbo.MaterialTypeOrders", "ConcreteTypeId");
            DropColumn("dbo.MaterialTypeOrders", "ConcDescId");
            DropColumn("dbo.MaterialTypeOrders", "DeepId");
            DropColumn("dbo.MaterialTypeOrders", "ExposureId");
            DropColumn("dbo.MaterialTypeOrders", "ExtensionId");
            DropColumn("dbo.MaterialTypeOrders", "IsClay");
            DropColumn("dbo.MaterialTypeOrders", "ClayTypeId");
            DropColumn("dbo.MaterialTypeOrders", "IsPump");
            DropColumn("dbo.MaterialTypeOrders", "VehicleTypeId");
            DropColumn("dbo.Vehicles", "VehicleTypeId");
            DropTable("dbo.ClayTypes");
            DropTable("dbo.ConcDescs");
            DropTable("dbo.ConcreteTypes");
            DropTable("dbo.Deeps");
            DropTable("dbo.Exposures");
            DropTable("dbo.Extensions");
            DropTable("dbo.VehicleTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VehicleTypes",
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
                "dbo.Exposures",
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
                "dbo.ConcreteTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConcDescs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClayTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Vehicles", "VehicleTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "VehicleTypeId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "IsPump", c => c.Boolean());
            AddColumn("dbo.MaterialTypeOrders", "ClayTypeId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "IsClay", c => c.Boolean());
            AddColumn("dbo.MaterialTypeOrders", "ExtensionId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "ExposureId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "DeepId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "ConcDescId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "ConcreteTypeId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "IsConcrete", c => c.Boolean());
            DropForeignKey("dbo.MaterialTypeOrders", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Materials", "MaterialCategoryId", "dbo.MaterialCategories");
            DropIndex("dbo.Materials", new[] { "MaterialCategoryId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "MaterialId" });
            DropColumn("dbo.MaterialTypeOrders", "MaterialId");
            DropTable("dbo.MaterialCategories");
            DropTable("dbo.Materials");
            CreateIndex("dbo.Vehicles", "VehicleTypeId");
            CreateIndex("dbo.MaterialTypeOrders", "VehicleTypeId");
            CreateIndex("dbo.MaterialTypeOrders", "ClayTypeId");
            CreateIndex("dbo.MaterialTypeOrders", "ExtensionId");
            CreateIndex("dbo.MaterialTypeOrders", "ExposureId");
            CreateIndex("dbo.MaterialTypeOrders", "DeepId");
            CreateIndex("dbo.MaterialTypeOrders", "ConcDescId");
            CreateIndex("dbo.MaterialTypeOrders", "ConcreteTypeId");
            AddForeignKey("dbo.Vehicles", "VehicleTypeId", "dbo.VehicleTypes", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "VehicleTypeId", "dbo.VehicleTypes", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "ExtensionId", "dbo.Extensions", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "ExposureId", "dbo.Exposures", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "DeepId", "dbo.Deeps", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "ConcreteTypeId", "dbo.ConcreteTypes", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "ConcDescId", "dbo.ConcDescs", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "ClayTypeId", "dbo.ClayTypes", "Id");
        }
    }
}
