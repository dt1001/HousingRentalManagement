namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tickets : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Contractors", newName: "Contractor");
            RenameTable(name: "dbo.Employees", newName: "Employee");
            RenameTable(name: "dbo.Tickets", newName: "Ticket");
            DropForeignKey("dbo.TicketEmployees", "Employee_id", "dbo.Employees");
            DropPrimaryKey("dbo.Contractor");
            DropPrimaryKey("dbo.Employee");
            DropColumn("dbo.Contractor", "id");
            DropColumn("dbo.Employee", "id");
            DropColumn("dbo.Ticket", "empId");
            DropColumn("dbo.Ticket", "contractorId");
            RenameColumn(table: "dbo.TicketEmployees", name: "Employee_id", newName: "Employee_empId");
            RenameIndex(table: "dbo.TicketEmployees", name: "IX_Employee_id", newName: "IX_Employee_empId");
            AddColumn("dbo.Contractor", "contId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Employee", "empId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Contractor", "contId");
            AddPrimaryKey("dbo.Employee", "empId");
            AddForeignKey("dbo.TicketEmployees", "Employee_empId", "dbo.Employee", "empId", cascadeDelete: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketEmployees", "Employee_empId", "dbo.Employee");
            DropPrimaryKey("dbo.Employee");
            DropPrimaryKey("dbo.Contractor");
            DropColumn("dbo.Employee", "empId");
            DropColumn("dbo.Contractor", "contId");
            AddColumn("dbo.Ticket", "contractorId", c => c.Int());
            AddColumn("dbo.Ticket", "empId", c => c.Int());
            AddColumn("dbo.Employee", "id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Contractor", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employee", "id");
            AddPrimaryKey("dbo.Contractor", "id");
            RenameIndex(table: "dbo.TicketEmployees", name: "IX_Employee_empId", newName: "IX_Employee_id");
            RenameColumn(table: "dbo.TicketEmployees", name: "Employee_empId", newName: "Employee_id");
            AddForeignKey("dbo.TicketEmployees", "Employee_id", "dbo.Employees", "id", cascadeDelete: true);
            RenameTable(name: "dbo.Ticket", newName: "Tickets");
            RenameTable(name: "dbo.Employee", newName: "Employees");
            RenameTable(name: "dbo.Contractor", newName: "Contractors");
        }
    }
}
