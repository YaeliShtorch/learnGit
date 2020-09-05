namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB2 : DbMigration
    {
        public override void Up()
        {
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
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaterialTypeOrders", t => t.MaterialTypeOrderId)
                .ForeignKey("dbo.Providers", t => t.ProviderId)
                .ForeignKey("dbo.StatusProviders", t => t.StatusProviderId)
                .Index(t => t.MaterialTypeOrderId)
                .Index(t => t.ProviderId)
                .Index(t => t.StatusProviderId);
            
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
            
            AddColumn("dbo.MaterialTypeOrders", "StatusMaterialId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "MaterialTypeOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.MaterialTypeOrders", "StatusMaterialId");
            CreateIndex("dbo.Orders", "MaterialTypeOrderId");
            AddForeignKey("dbo.Orders", "MaterialTypeOrderId", "dbo.MaterialTypeOrders", "Id");
            AddForeignKey("dbo.MaterialTypeOrders", "StatusMaterialId", "dbo.StatusMaterials", "Id");
            DropTable("dbo.OrderDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.MaterialTypeOrders", "StatusMaterialId", "dbo.StatusMaterials");
            DropForeignKey("dbo.Orders", "MaterialTypeOrderId", "dbo.MaterialTypeOrders");
            DropForeignKey("dbo.MaterialProviders", "StatusProviderId", "dbo.StatusProviders");
            DropForeignKey("dbo.MaterialProviders", "ProviderId", "dbo.Providers");
            DropForeignKey("dbo.MaterialProviders", "MaterialTypeOrderId", "dbo.MaterialTypeOrders");
            DropIndex("dbo.Orders", new[] { "MaterialTypeOrderId" });
            DropIndex("dbo.MaterialProviders", new[] { "StatusProviderId" });
            DropIndex("dbo.MaterialProviders", new[] { "ProviderId" });
            DropIndex("dbo.MaterialProviders", new[] { "MaterialTypeOrderId" });
            DropIndex("dbo.MaterialTypeOrders", new[] { "StatusMaterialId" });
            DropColumn("dbo.Orders", "MaterialTypeOrderId");
            DropColumn("dbo.MaterialTypeOrders", "StatusMaterialId");
            DropTable("dbo.StatusMaterials");
            DropTable("dbo.StatusProviders");
            DropTable("dbo.MaterialProviders");
        }
    }
}
