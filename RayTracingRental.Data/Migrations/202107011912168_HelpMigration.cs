namespace RayTracingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HelpMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder");
            DropIndex("dbo.Customer", new[] { "RentalOrderId" });
            AlterColumn("dbo.Customer", "RentalOrderId", c => c.Int());
            CreateIndex("dbo.Customer", "RentalOrderId");
            AddForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder");
            DropIndex("dbo.Customer", new[] { "RentalOrderId" });
            AlterColumn("dbo.Customer", "RentalOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customer", "RentalOrderId");
            AddForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId", cascadeDelete: true);
        }
    }
}
