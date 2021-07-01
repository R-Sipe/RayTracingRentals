namespace RayTracingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IeMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RentalOrder", "Clerk", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RentalOrder", "Clerk", c => c.String());
        }
    }
}
