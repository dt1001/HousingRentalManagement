namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateContext : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Assets", "isOccupied");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Assets", "isOccupied", c => c.Boolean(nullable: false));
        }
    }
}
