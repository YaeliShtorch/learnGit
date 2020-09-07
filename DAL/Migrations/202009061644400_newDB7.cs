namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MaterialTypeOrders", "IsConcrete", c => c.Boolean());
            AlterColumn("dbo.MaterialTypeOrders", "IsClay", c => c.Boolean());
            AlterColumn("dbo.MaterialTypeOrders", "IsPump", c => c.Boolean());
            AlterColumn("dbo.MaterialTypeOrders", "Amount", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MaterialTypeOrders", "Amount", c => c.Int(nullable: false));
            AlterColumn("dbo.MaterialTypeOrders", "IsPump", c => c.Boolean(nullable: false));
            AlterColumn("dbo.MaterialTypeOrders", "IsClay", c => c.Boolean(nullable: false));
            AlterColumn("dbo.MaterialTypeOrders", "IsConcrete", c => c.Boolean(nullable: false));
        }
    }
}
