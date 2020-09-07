namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaterialTypeOrders", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.MaterialTypeOrders", "StatusMaterialId", "dbo.StatusMaterials");
            DropIndex("dbo.MaterialTypeOrders", new[] { "VehicleTypeId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "StatusMaterialId" });
            DropColumn("dbo.MaterialTypeOrders", "VehicleTypeId");
            DropColumn("dbo.MaterialTypeOrders", "StatusMaterialId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaterialTypeOrders", "StatusMaterialId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "VehicleTypeId", c => c.Int());
            CreateIndex("dbo.MaterialTypeOrders", "StatusMaterialId");
            CreateIndex("dbo.MaterialTypeOrders", "VehicleTypeId");
            AddForeignKey("dbo.MaterialTypeOrders", "StatusMaterialId", "dbo.StatusMaterials", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "VehicleTypeId", "dbo.VehicleTypes", "Id");
        }
    }
}
