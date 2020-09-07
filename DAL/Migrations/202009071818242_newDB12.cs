namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Materials", "Name");
        }
    }
}
