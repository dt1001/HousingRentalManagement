namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "Assets_Id", "dbo.Assets");
            DropIndex("dbo.People", new[] { "Assets_Id" });
            DropColumn("dbo.People", "Assets_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Assets_Id", c => c.Int());
            CreateIndex("dbo.People", "Assets_Id");
            AddForeignKey("dbo.People", "Assets_Id", "dbo.Assets", "Id");
        }
    }
}
