namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNullableDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OccupancyHistoryRecords", "StartDate", c => c.DateTime());
            AlterColumn("dbo.OccupancyHistoryRecords", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OccupancyHistoryRecords", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.OccupancyHistoryRecords", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
