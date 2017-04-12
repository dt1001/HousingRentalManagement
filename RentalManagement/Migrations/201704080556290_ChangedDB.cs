namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "AssetId", "dbo.Assets");
            DropIndex("dbo.People", new[] { "AssetId" });
            DropColumn("dbo.People", "AssetId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "AssetId", c => c.Int());
            CreateIndex("dbo.People", "AssetId");
            AddForeignKey("dbo.People", "AssetId", "dbo.Assets", "Id", cascadeDelete: true);
        }
    }
}
