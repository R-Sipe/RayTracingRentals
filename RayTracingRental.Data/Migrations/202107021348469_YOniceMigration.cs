namespace RayTracingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YOniceMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder");
            AddForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder");
            AddForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId");
        }
    }
}
