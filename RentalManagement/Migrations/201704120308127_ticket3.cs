namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ticket3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employee", "ticketId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employee", "ticketId", c => c.Int());
        }
    }
}
