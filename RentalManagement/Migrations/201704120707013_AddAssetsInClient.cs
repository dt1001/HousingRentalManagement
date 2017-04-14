namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssetsInClient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Assets_Id", c => c.Int());
            CreateIndex("dbo.People", "Assets_Id");
            AddForeignKey("dbo.People", "Assets_Id", "dbo.Assets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "Assets_Id", "dbo.Assets");
            DropIndex("dbo.People", new[] { "Assets_Id" });
            DropColumn("dbo.People", "Assets_Id");
        }
    }
}
