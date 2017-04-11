namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tickets1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ticket", "description", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ticket", "description", c => c.String(maxLength: 64));
        }
    }
}
