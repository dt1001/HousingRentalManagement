namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssetId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Assets_Id", "dbo.Assets");
            RenameColumn(table: "dbo.People", name: "Assets_Id", newName: "AssetId");
            RenameIndex(table: "dbo.People", name: "IX_Assets_Id", newName: "IX_AssetId");
            AddForeignKey("dbo.People", "AssetId", "dbo.Assets", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "AssetId", "dbo.Assets");
            RenameIndex(table: "dbo.People", name: "IX_AssetId", newName: "IX_Assets_Id");
            RenameColumn(table: "dbo.People", name: "AssetId", newName: "Assets_Id");
            AddForeignKey("dbo.People", "Assets_Id", "dbo.Assets", "Id");
        }
    }
}
