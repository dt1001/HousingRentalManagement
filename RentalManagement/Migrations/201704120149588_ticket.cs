namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ticket : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Contractor", "Ticket_id");
            RenameTable(name: "dbo.TicketEmployees", newName: "EmployeeTickets");
            DropForeignKey("dbo.Contractor", "Ticket_id", "dbo.Ticket");
            DropIndex("dbo.Contractor", new[] { "Ticket_id" });
            DropPrimaryKey("dbo.EmployeeTickets");
            
            CreateTable(
                "dbo.TicketContractors",
                c => new
                    {
                        Ticket_id = c.Int(nullable: false),
                        Contractor_contId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ticket_id, t.Contractor_contId })
                .ForeignKey("dbo.Ticket", t => t.Ticket_id, cascadeDelete: true)
                .ForeignKey("dbo.Contractor", t => t.Contractor_contId, cascadeDelete: true)
                .Index(t => t.Ticket_id)
                .Index(t => t.Contractor_contId);
            
            AddPrimaryKey("dbo.EmployeeTickets", new[] { "Employee_empId", "Ticket_id" });
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contractor", "Ticket_id", c => c.Int());
            DropForeignKey("dbo.TicketContractors", "Contractor_contId", "dbo.Contractor");
            DropForeignKey("dbo.TicketContractors", "Ticket_id", "dbo.Ticket");
            DropIndex("dbo.TicketContractors", new[] { "Contractor_contId" });
            DropIndex("dbo.TicketContractors", new[] { "Ticket_id" });
            DropPrimaryKey("dbo.EmployeeTickets");
            DropTable("dbo.TicketContractors");
            AddPrimaryKey("dbo.EmployeeTickets", new[] { "Ticket_id", "Employee_empId" });
            CreateIndex("dbo.Contractor", "Ticket_id");
            AddForeignKey("dbo.Contractor", "Ticket_id", "dbo.Ticket", "id");
            RenameTable(name: "dbo.EmployeeTickets", newName: "TicketEmployees");
        }
    }
}
