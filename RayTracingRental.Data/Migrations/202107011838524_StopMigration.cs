namespace RayTracingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StopMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder");
            DropForeignKey("dbo.RentalOrder", "RentalStoreId", "dbo.RentalStore");
            DropIndex("dbo.Customer", new[] { "RentalOrderId" });
            DropIndex("dbo.Product", new[] { "RentalOrderId" });
            DropIndex("dbo.RentalOrder", new[] { "RentalStoreId" });
            DropColumn("dbo.RentalStore", "RentalOrderId");
            RenameColumn(table: "dbo.RentalStore", name: "RentalStoreId", newName: "RentalOrderId");
            AlterColumn("dbo.Customer", "RentalOrderId", c => c.Int());
            AlterColumn("dbo.Product", "RentalOrderId", c => c.Int());
            AlterColumn("dbo.RentalOrder", "RentalStoreId", c => c.Int());
            AlterColumn("dbo.RentalStore", "RentalOrderId", c => c.Int());
            AlterColumn("dbo.RentalStore", "RentalOrderId", c => c.Int());
            CreateIndex("dbo.Customer", "RentalOrderId");
            CreateIndex("dbo.Product", "RentalOrderId");
            CreateIndex("dbo.RentalStore", "RentalOrderId");
            AddForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId");
            AddForeignKey("dbo.RentalStore", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentalStore", "RentalOrderId", "dbo.RentalOrder");
            DropForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder");
            DropIndex("dbo.RentalStore", new[] { "RentalOrderId" });
            DropIndex("dbo.Product", new[] { "RentalOrderId" });
            DropIndex("dbo.Customer", new[] { "RentalOrderId" });
            AlterColumn("dbo.RentalStore", "RentalOrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.RentalStore", "RentalOrderId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.RentalOrder", "RentalStoreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Product", "RentalOrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.Customer", "RentalOrderId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.RentalStore", name: "RentalOrderId", newName: "RentalStoreId");
            AddColumn("dbo.RentalStore", "RentalOrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.RentalOrder", "RentalStoreId");
            CreateIndex("dbo.Product", "RentalOrderId");
            CreateIndex("dbo.Customer", "RentalOrderId");
            AddForeignKey("dbo.RentalOrder", "RentalStoreId", "dbo.RentalStore", "RentalStoreId", cascadeDelete: true);
            AddForeignKey("dbo.Customer", "RentalOrderId", "dbo.RentalOrder", "RentalOrderId", cascadeDelete: true);
        }
    }
}
