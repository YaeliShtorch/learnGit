namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class check2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.MaterialTypeOrders", new[] { "OrderId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "StatusMaterialId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "MaterialId" });
            AlterColumn("dbo.MaterialTypeOrders", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.MaterialTypeOrders", "Amount", c => c.Int(nullable: false));
            AlterColumn("dbo.MaterialTypeOrders", "StatusMaterialId", c => c.Int(nullable: false));
            AlterColumn("dbo.MaterialTypeOrders", "MaterialId", c => c.Int(nullable: false));
            CreateIndex("dbo.MaterialTypeOrders", "OrderId");
            CreateIndex("dbo.MaterialTypeOrders", "StatusMaterialId");
            CreateIndex("dbo.MaterialTypeOrders", "MaterialId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MaterialTypeOrders", new[] { "MaterialId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "StatusMaterialId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "OrderId" });
            AlterColumn("dbo.MaterialTypeOrders", "MaterialId", c => c.Int());
            AlterColumn("dbo.MaterialTypeOrders", "StatusMaterialId", c => c.Int());
            AlterColumn("dbo.MaterialTypeOrders", "Amount", c => c.Int());
            AlterColumn("dbo.MaterialTypeOrders", "OrderId", c => c.Int());
            CreateIndex("dbo.MaterialTypeOrders", "MaterialId");
            CreateIndex("dbo.MaterialTypeOrders", "StatusMaterialId");
            CreateIndex("dbo.MaterialTypeOrders", "OrderId");
        }
    }
}
