namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _202009021351377_newDB : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeId" });
            AlterColumn("dbo.Vehicles", "VehicleTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "VehicleTypeId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vehicles", new[] { "VehicleTypeId" });
            AlterColumn("dbo.Vehicles", "VehicleTypeId", c => c.Int());
            CreateIndex("dbo.Vehicles", "VehicleTypeId");
        }
    }
}
