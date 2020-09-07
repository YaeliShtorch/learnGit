namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterialTypeOrders", "VehicleTypeId", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "StatusMaterialId", c => c.Int());
            CreateIndex("dbo.MaterialTypeOrders", "VehicleTypeId");
            CreateIndex("dbo.MaterialTypeOrders", "StatusMaterialId");
            AddForeignKey("dbo.MaterialTypeOrders", "VehicleTypeId", "dbo.VehicleTypes", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "StatusMaterialId", "dbo.StatusMaterials", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterialTypeOrders", "StatusMaterialId", "dbo.StatusMaterials");
            DropForeignKey("dbo.MaterialTypeOrders", "VehicleTypeId", "dbo.VehicleTypes");
            DropIndex("dbo.MaterialTypeOrders", new[] { "StatusMaterialId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "VehicleTypeId" });
            DropColumn("dbo.MaterialTypeOrders", "StatusMaterialId");
            DropColumn("dbo.MaterialTypeOrders", "VehicleTypeId");
        }
    }
}
