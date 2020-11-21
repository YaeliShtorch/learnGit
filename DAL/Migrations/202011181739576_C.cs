namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class C : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Materials", "PipeLength");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Materials", "PipeLength", c => c.Int());
        }
    }
}
