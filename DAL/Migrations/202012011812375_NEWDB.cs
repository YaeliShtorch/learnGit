namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NEWDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "registeredDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Customers", "Token", c => c.String());
            AddColumn("dbo.Drivers", "Token", c => c.String());
            AddColumn("dbo.MaterialProviders", "datePApproved", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.MaterialProviders", "datePSend", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Providers", "Token", c => c.String());
            AddColumn("dbo.Managers", "Token", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Managers", "Token");
            DropColumn("dbo.Providers", "Token");
            DropColumn("dbo.MaterialProviders", "datePSend");
            DropColumn("dbo.MaterialProviders", "datePApproved");
            DropColumn("dbo.Drivers", "Token");
            DropColumn("dbo.Customers", "Token");
            DropColumn("dbo.Customers", "registeredDate");
        }
    }
}
