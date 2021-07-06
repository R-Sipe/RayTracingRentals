namespace RayTracingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UiMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RentalOrder", "CustomerId");
            DropColumn("dbo.RentalOrder", "ProductId");
            DropColumn("dbo.RentalStore", "RentalOrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RentalStore", "RentalOrderId", c => c.Int(nullable: false));
            AddColumn("dbo.RentalOrder", "ProductId", c => c.Int(nullable: false));
            AddColumn("dbo.RentalOrder", "CustomerId", c => c.Int(nullable: false));
        }
    }
}
