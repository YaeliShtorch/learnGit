namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB6 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MaterialTypeOrders", name: "Order_Id", newName: "OrderId");
            RenameColumn(table: "dbo.MaterialTypeOrders", name: "VehicleType_Id", newName: "VehicleTypeId");
            RenameColumn(table: "dbo.MaterialTypeOrders", name: "StatusMaterial_Id", newName: "StatusMaterialId");
            RenameIndex(table: "dbo.MaterialTypeOrders", name: "IX_VehicleType_Id", newName: "IX_VehicleTypeId");
            RenameIndex(table: "dbo.MaterialTypeOrders", name: "IX_StatusMaterial_Id", newName: "IX_StatusMaterialId");
            RenameIndex(table: "dbo.MaterialTypeOrders", name: "IX_Order_Id", newName: "IX_OrderId");
            AddColumn("dbo.MaterialTypeOrders", "IsConcrete", c => c.Boolean(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "ConcreteTypeId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "ConcDescId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "DeepId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "ExposureId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "ExtensionId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "IsClay", c => c.Boolean(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "ClayTypeId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "IsPump", c => c.Boolean(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "Element", c => c.String());
            AddColumn("dbo.MaterialTypeOrders", "Amount", c => c.Int(nullable: false));
            CreateIndex("dbo.MaterialTypeOrders", "ConcreteTypeId");
            CreateIndex("dbo.MaterialTypeOrders", "ConcDescId");
            CreateIndex("dbo.MaterialTypeOrders", "DeepId");
            CreateIndex("dbo.MaterialTypeOrders", "ExposureId");
            CreateIndex("dbo.MaterialTypeOrders", "ExtensionId");
            CreateIndex("dbo.MaterialTypeOrders", "ClayTypeId");
            AddForeignKey("dbo.MaterialTypeOrders", "ClayTypeId", "dbo.ClayTypes", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "ConcDescId", "dbo.ConcDescs", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "ConcreteTypeId", "dbo.ConcreteTypes", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "DeepId", "dbo.Deeps", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "ExposureId", "dbo.Exposures", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "ExtensionId", "dbo.Extensions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterialTypeOrders", "ExtensionId", "dbo.Extensions");
            DropForeignKey("dbo.MaterialTypeOrders", "ExposureId", "dbo.Exposures");
            DropForeignKey("dbo.MaterialTypeOrders", "DeepId", "dbo.Deeps");
            DropForeignKey("dbo.MaterialTypeOrders", "ConcreteTypeId", "dbo.ConcreteTypes");
            DropForeignKey("dbo.MaterialTypeOrders", "ConcDescId", "dbo.ConcDescs");
            DropForeignKey("dbo.MaterialTypeOrders", "ClayTypeId", "dbo.ClayTypes");
            DropIndex("dbo.MaterialTypeOrders", new[] { "ClayTypeId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ExtensionId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ExposureId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "DeepId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ConcDescId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "ConcreteTypeId" });
            DropColumn("dbo.MaterialTypeOrders", "Amount");
            DropColumn("dbo.MaterialTypeOrders", "Element");
            DropColumn("dbo.MaterialTypeOrders", "IsPump");
            DropColumn("dbo.MaterialTypeOrders", "ClayTypeId");
            DropColumn("dbo.MaterialTypeOrders", "IsClay");
            DropColumn("dbo.MaterialTypeOrders", "ExtensionId");
            DropColumn("dbo.MaterialTypeOrders", "ExposureId");
            DropColumn("dbo.MaterialTypeOrders", "DeepId");
            DropColumn("dbo.MaterialTypeOrders", "ConcDescId");
            DropColumn("dbo.MaterialTypeOrders", "ConcreteTypeId");
            DropColumn("dbo.MaterialTypeOrders", "IsConcrete");
            RenameIndex(table: "dbo.MaterialTypeOrders", name: "IX_OrderId", newName: "IX_Order_Id");
            RenameIndex(table: "dbo.MaterialTypeOrders", name: "IX_StatusMaterialId", newName: "IX_StatusMaterial_Id");
            RenameIndex(table: "dbo.MaterialTypeOrders", name: "IX_VehicleTypeId", newName: "IX_VehicleType_Id");
            RenameColumn(table: "dbo.MaterialTypeOrders", name: "StatusMaterialId", newName: "StatusMaterial_Id");
            RenameColumn(table: "dbo.MaterialTypeOrders", name: "VehicleTypeId", newName: "VehicleType_Id");
            RenameColumn(table: "dbo.MaterialTypeOrders", name: "OrderId", newName: "Order_Id");
        }
    }
}
