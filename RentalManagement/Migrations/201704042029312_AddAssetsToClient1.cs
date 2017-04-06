namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssetsToClient1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "Assets_Id", c => c.Int());
            CreateIndex("dbo.People", "Assets_Id");
            CreateIndex("dbo.OccupancyHistoryRecords", "ClientId");
            CreateIndex("dbo.RentHistoryRecords", "ClientId");
            AddForeignKey("dbo.People", "Assets_Id", "dbo.Assets", "Id");
            AddForeignKey("dbo.OccupancyHistoryRecords", "ClientId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RentHistoryRecords", "ClientId", "dbo.People", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentHistoryRecords", "ClientId", "dbo.People");
            DropForeignKey("dbo.OccupancyHistoryRecords", "ClientId", "dbo.People");
            DropForeignKey("dbo.People", "Assets_Id", "dbo.Assets");
            DropIndex("dbo.RentHistoryRecords", new[] { "ClientId" });
            DropIndex("dbo.OccupancyHistoryRecords", new[] { "ClientId" });
            DropIndex("dbo.People", new[] { "Assets_Id" });
            DropColumn("dbo.People", "Assets_Id");
        }
    }
}
