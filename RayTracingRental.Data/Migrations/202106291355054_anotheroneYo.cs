namespace RayTracingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotheroneYo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentalOrder",
                c => new
                    {
                        RentalOrderId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Created = c.DateTimeOffset(nullable: false, precision: 7),
                        Returned = c.DateTimeOffset(precision: 7),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RentalOrderId);
            
            AddColumn("dbo.Customer", "RentalOrder_RentalOrderId", c => c.Int());
            AddColumn("dbo.Product", "RentalOrder_RentalOrderId", c => c.Int());
            CreateIndex("dbo.Customer", "RentalOrder_RentalOrderId");
            CreateIndex("dbo.Product", "RentalOrder_RentalOrderId");
            AddForeignKey("dbo.Customer", "RentalOrder_RentalOrderId", "dbo.RentalOrder", "RentalOrderId");
            AddForeignKey("dbo.Product", "RentalOrder_RentalOrderId", "dbo.RentalOrder", "RentalOrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "RentalOrder_RentalOrderId", "dbo.RentalOrder");
            DropForeignKey("dbo.Customer", "RentalOrder_RentalOrderId", "dbo.RentalOrder");
            DropIndex("dbo.Product", new[] { "RentalOrder_RentalOrderId" });
            DropIndex("dbo.Customer", new[] { "RentalOrder_RentalOrderId" });
            DropColumn("dbo.Product", "RentalOrder_RentalOrderId");
            DropColumn("dbo.Customer", "RentalOrder_RentalOrderId");
            DropTable("dbo.RentalOrder");
        }
    }
}
