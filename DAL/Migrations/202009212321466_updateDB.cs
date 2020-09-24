namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "PipeLength", c => c.Int());
            AddColumn("dbo.MaterialTypeOrders", "ManagerComment", c => c.String());
            AddColumn("dbo.MaterialProviders", "ProviderComment", c => c.String());
            DropColumn("dbo.MaterialProviders", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaterialProviders", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.MaterialProviders", "ProviderComment");
            DropColumn("dbo.MaterialTypeOrders", "ManagerComment");
            DropColumn("dbo.Materials", "PipeLength");
        }
    }
}
