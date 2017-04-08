namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contractors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 64),
                        companyName = c.String(maxLength: 64),
                        rate = c.Double(nullable: false),
                        profession = c.String(maxLength: 64),
                        Ticket_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tickets", t => t.Ticket_id)
                .Index(t => t.Ticket_id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 64),
                        payRate = c.Double(nullable: false),
                        email = c.String(maxLength: 64),
                        phonenumber = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 64),
                        issueDate = c.DateTime(nullable: false),
                        priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.TicketEmployees",
                c => new
                    {
                        Ticket_id = c.Int(nullable: false),
                        Employee_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ticket_id, t.Employee_id })
                .ForeignKey("dbo.Tickets", t => t.Ticket_id, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_id, cascadeDelete: true)
                .Index(t => t.Ticket_id)
                .Index(t => t.Employee_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketEmployees", "Employee_id", "dbo.Employees");
            DropForeignKey("dbo.TicketEmployees", "Ticket_id", "dbo.Tickets");
            DropForeignKey("dbo.Contractors", "Ticket_id", "dbo.Tickets");
            DropIndex("dbo.TicketEmployees", new[] { "Employee_id" });
            DropIndex("dbo.TicketEmployees", new[] { "Ticket_id" });
            DropIndex("dbo.Contractors", new[] { "Ticket_id" });
            DropTable("dbo.TicketEmployees");
            DropTable("dbo.Tickets");
            DropTable("dbo.Employees");
            DropTable("dbo.Contractors");
        }
    }
}
