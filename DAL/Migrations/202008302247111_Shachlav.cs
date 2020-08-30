namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shachlav : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Providers", "Comments", c => c.String());
            AddColumn("dbo.Providers", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Providers", "IsActive");
            DropColumn("dbo.Providers", "Comments");
            DropColumn("dbo.Customers", "IsActive");
        }
    }
}
