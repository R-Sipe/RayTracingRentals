namespace RayTracingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RentalOrder", "Clerk", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RentalOrder", "Clerk");
        }
    }
}
