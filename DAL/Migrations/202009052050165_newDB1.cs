namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "MaterialTypeOrderId", "dbo.MaterialTypeOrders");
            DropForeignKey("dbo.MaterialTypeOrders", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.MaterialTypeOrders", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "MaterialTypeOrder_Id", "dbo.MaterialTypeOrders");
            DropIndex("dbo.MaterialTypeOrders", new[] { "OrderId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "MaterialTypeOrderId" });
            DropIndex("dbo.Orders", new[] { "MaterialTypeOrder_Id" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.OrderDetails", new[] { "ProviderId" });
            AddColumn("dbo.MaterialTypeOrders", "ConcreteTest", c => c.Boolean(nullable: false));
            DropColumn("dbo.MaterialTypeOrders", "OrderId");
            DropColumn("dbo.MaterialTypeOrders", "Order_Id");
            DropColumn("dbo.Orders", "MaterialTypeOrderId");
            DropColumn("dbo.Orders", "ConcreteTest");
            DropColumn("dbo.Orders", "MaterialTypeOrder_Id");
            DropColumn("dbo.OrderDetails", "OrderId");
            DropColumn("dbo.OrderDetails", "ProviderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderDetails", "ProviderId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "OrderId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "MaterialTypeOrder_Id", c => c.Int());
            AddColumn("dbo.Orders", "ConcreteTest", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "MaterialTypeOrderId", c => c.Int(nullable: false));
            AddColumn("dbo.MaterialTypeOrders", "Order_Id", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "OrderId", c => c.Int(nullable: false));
            DropColumn("dbo.MaterialTypeOrders", "ConcreteTest");
            CreateIndex("dbo.OrderDetails", "ProviderId");
            CreateIndex("dbo.OrderDetails", "OrderId");
            CreateIndex("dbo.Orders", "MaterialTypeOrder_Id");
            CreateIndex("dbo.Orders", "MaterialTypeOrderId");
            CreateIndex("dbo.MaterialTypeOrders", "Order_Id");
            CreateIndex("dbo.MaterialTypeOrders", "OrderId");
            AddForeignKey("dbo.Orders", "MaterialTypeOrder_Id", "dbo.MaterialTypeOrders", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "OrderId", "dbo.Orders", "Id");
            AddForeignKey("dbo.OrderDetails", "ProviderId", "dbo.Providers", "Id");
            AddForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.Orders", "MaterialTypeOrderId", "dbo.MaterialTypeOrders", "Id");
        }
    }
}
