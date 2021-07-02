namespace RayTracingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HelpMeMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "RentalOrderId", "dbo.RentalOrder");
            AlterColumn("dbo.RentalOrder", "Clerk", c => c.String());
            AddForeignKey("dbo.Product", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "RentalOrderId", "dbo.RentalOrder");
            AlterColumn("dbo.RentalOrder", "Clerk", c => c.String(nullable: false));
            AddForeignKey("dbo.Product", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId");
        }
    }
}
