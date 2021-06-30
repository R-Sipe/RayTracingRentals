namespace RayTracingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PogMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentalStore",
                c => new
                    {
                        RentalStoreId = c.Int(nullable: false, identity: true),
                        StoreName = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        RentalOrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RentalStoreId);
            
            AddColumn("dbo.RentalOrder", "RentalStoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.RentalOrder", "RentalStoreId");
            AddForeignKey("dbo.RentalOrder", "RentalStoreId", "dbo.RentalStore", "RentalStoreId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentalOrder", "RentalStoreId", "dbo.RentalStore");
            DropIndex("dbo.RentalOrder", new[] { "RentalStoreId" });
            DropColumn("dbo.RentalOrder", "RentalStoreId");
            DropTable("dbo.RentalStore");
        }
    }
}
