namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Check : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "MaterialId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "MaterialId");
            AddForeignKey("dbo.Vehicles", "MaterialId", "dbo.Materials", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "MaterialId", "dbo.Materials");
            DropIndex("dbo.Vehicles", new[] { "MaterialId" });
            DropColumn("dbo.Vehicles", "MaterialId");
        }
    }
}
