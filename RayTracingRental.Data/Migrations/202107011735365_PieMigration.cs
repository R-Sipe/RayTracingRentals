namespace RayTracingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PieMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Product", new[] { "RentalOrderId" });
            AlterColumn("dbo.Product", "RentalOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "RentalOrderId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", new[] { "RentalOrderId" });
            AlterColumn("dbo.Product", "RentalOrderId", c => c.Int());
            CreateIndex("dbo.Product", "RentalOrderId");
        }
    }
}
