namespace RayTracingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YoWaddup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder");
            DropForeignKey("dbo.Product", "RentalOrderId", "dbo.RentalOrder");
            DropIndex("dbo.Customer", new[] { "RentalOrderId" });
            DropIndex("dbo.Product", new[] { "RentalOrderId" });
            AlterColumn("dbo.Customer", "RentalOrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "RentalOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customer", "RentalOrderId");
            CreateIndex("dbo.Product", "RentalOrderId");
            AddForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId", cascadeDelete: true);
            AddForeignKey("dbo.Product", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "RentalOrderId", "dbo.RentalOrder");
            DropForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder");
            DropIndex("dbo.Product", new[] { "RentalOrderId" });
            DropIndex("dbo.Customer", new[] { "RentalOrderId" });
            AlterColumn("dbo.Product", "RentalOrderId", c => c.Int());
            AlterColumn("dbo.Customer", "RentalOrderId", c => c.Int());
            CreateIndex("dbo.Product", "RentalOrderId");
            CreateIndex("dbo.Customer", "RentalOrderId");
            AddForeignKey("dbo.Product", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId");
            AddForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId");
        }
    }
}
