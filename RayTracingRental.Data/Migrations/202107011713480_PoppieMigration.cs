namespace RayTracingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoppieMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "RentalOrderId", "dbo.RentalOrder");
            AddForeignKey("dbo.Product", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "RentalOrderId", "dbo.RentalOrder");
            AddForeignKey("dbo.Product", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId", cascadeDelete: true);
        }
    }
}
