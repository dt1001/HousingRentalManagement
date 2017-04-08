namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ticketId", c => c.Int());
            AddColumn("dbo.Tickets", "empId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "empId");
            DropColumn("dbo.Employees", "ticketId");
        }
    }
}
