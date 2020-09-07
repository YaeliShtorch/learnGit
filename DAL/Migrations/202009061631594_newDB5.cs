namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaterialTypeOrders", "ClayTypeId", "dbo.ClayTypes");
            DropForeignKey("dbo.MaterialTypeOrders", "ConcDescId", "dbo.ConcDescs");
            DropForeignKey("dbo.MaterialTypeOrders", "ConcreteTypeId", "dbo.ConcreteTypes");
            DropForeignKey("dbo.MaterialTypeOrders", "DeepId", "dbo.Deeps");
            DropForeignKey("dbo.MaterialTypeOrders", "ExposureId", "dbo.Exposures");
            DropForeignKey("dbo.MaterialTypeOrders", "ExtensionId", "dbo.Extensions");
            DropIndex("dbo.MaterialTypeOrders", new[] { "OrderId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ConcreteTypeId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ConcDescId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "DeepId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ExposureId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ExtensionId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ClayTypeId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "VehicleTypeId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "StatusMaterialId" });
            RenameColumn(table: "dbo.MaterialTypeOrders", name: "VehicleTypeId", newName: "VehicleType_Id");
            RenameColumn(table: "dbo.MaterialTypeOrders", name: "StatusMaterialId", newName: "StatusMaterial_Id");
            RenameColumn(table: "dbo.MaterialTypeOrders", name: "OrderId", newName: "Order_Id");
            AlterColumn("dbo.MaterialTypeOrders", "Order_Id", c => c.Int());
            AlterColumn("dbo.MaterialTypeOrders", "VehicleType_Id", c => c.Int());
            AlterColumn("dbo.MaterialTypeOrders", "StatusMaterial_Id", c => c.Int());
            CreateIndex("dbo.MaterialTypeOrders", "VehicleType_Id");
            CreateIndex("dbo.MaterialTypeOrders", "Order_Id");
            CreateIndex("dbo.MaterialTypeOrders", "StatusMaterial_Id");
            DropColumn("dbo.MaterialTypeOrders", "IsConcrete");
            DropColumn("dbo.MaterialTypeOrders", "ConcreteTypeId");
            DropColumn("dbo.MaterialTypeOrders", "ConcDescId");
            DropColumn("dbo.MaterialTypeOrders", "DeepId");
            DropColumn("dbo.MaterialTypeOrders", "ExposureId");
            DropColumn("dbo.MaterialTypeOrders", "ExtensionId");
            DropColumn("dbo.MaterialTypeOrders", "IsClay");
            DropColumn("dbo.MaterialTypeOrders", "ClayTypeId");
            DropColumn("dbo.MaterialTypeOrders", "IsPump");
            DropColumn("dbo.MaterialTypeOrders", "Element");
            DropColumn("dbo.MaterialTypeOrders", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaterialTypeOrders", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "Element", c => c.String(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "IsPump", c => c.Boolean(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "ClayTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "IsClay", c => c.Boolean(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "ExtensionId", c => c.Int(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "ExposureId", c => c.Int(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "DeepId", c => c.Int(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "ConcDescId", c => c.Int(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "ConcreteTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "IsConcrete", c => c.Boolean(nullable: false));
            DropIndex("dbo.MaterialTypeOrders", new[] { "StatusMaterial_Id" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "Order_Id" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "VehicleType_Id" });
            AlterColumn("dbo.MaterialTypeOrders", "StatusMaterial_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.MaterialTypeOrders", "VehicleType_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.MaterialTypeOrders", "Order_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.MaterialTypeOrders", name: "Order_Id", newName: "OrderId");
            RenameColumn(table: "dbo.MaterialTypeOrders", name: "StatusMaterial_Id", newName: "StatusMaterialId");
            RenameColumn(table: "dbo.MaterialTypeOrders", name: "VehicleType_Id", newName: "VehicleTypeId");
            CreateIndex("dbo.MaterialTypeOrders", "StatusMaterialId");
            CreateIndex("dbo.MaterialTypeOrders", "VehicleTypeId");
            CreateIndex("dbo.MaterialTypeOrders", "ClayTypeId");
            CreateIndex("dbo.MaterialTypeOrders", "ExtensionId");
            CreateIndex("dbo.MaterialTypeOrders", "ExposureId");
            CreateIndex("dbo.MaterialTypeOrders", "DeepId");
            CreateIndex("dbo.MaterialTypeOrders", "ConcDescId");
            CreateIndex("dbo.MaterialTypeOrders", "ConcreteTypeId");
            CreateIndex("dbo.MaterialTypeOrders", "OrderId");
            AddForeignKey("dbo.MaterialTypeOrders", "ExtensionId", "dbo.Extensions", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "ExposureId", "dbo.Exposures", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "DeepId", "dbo.Deeps", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "ConcreteTypeId", "dbo.ConcreteTypes", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "ConcDescId", "dbo.ConcDescs", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "ClayTypeId", "dbo.ClayTypes", "Id");
        }
    }
}
