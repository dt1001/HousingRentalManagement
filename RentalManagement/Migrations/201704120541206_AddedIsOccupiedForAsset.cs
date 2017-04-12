namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsOccupiedForAsset : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assets", "isOccupied", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assets", "isOccupied");
        }
    }
}
