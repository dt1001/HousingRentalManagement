namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewmodel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "contractorId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "contractorId");
        }
    }
}
