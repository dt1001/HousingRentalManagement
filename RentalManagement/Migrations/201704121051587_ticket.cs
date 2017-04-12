namespace RentalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ticket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        AskingRent = c.String(),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FullAddresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.FullAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitNum = c.String(),
                        StreetAddress = c.String(),
                        Province = c.String(),
                        Country = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AssetId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        HomeAddress_Id = c.Int(),
                        WorkAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assets", t => t.AssetId, cascadeDelete: true)
                .ForeignKey("dbo.FullAddresses", t => t.HomeAddress_Id)
                .ForeignKey("dbo.FullAddresses", t => t.WorkAddress_Id)
                .Index(t => t.AssetId)
                .Index(t => t.HomeAddress_Id)
                .Index(t => t.WorkAddress_Id);
            
            CreateTable(
                "dbo.OccupancyHistoryRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.RentHistoryRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        NegotiatedOn = c.DateTime(nullable: false),
                        AskingRent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NegotiatedRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Contractor",
                c => new
                    {
                        contId = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 64),
                        companyName = c.String(maxLength: 64),
                        rate = c.Double(nullable: false),
                        profession = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.contId);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        issueDate = c.DateTime(nullable: false),
                        priority = c.Int(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        empId = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 64),
                        payRate = c.Double(nullable: false),
                        email = c.String(maxLength: 64),
                        phonenumber = c.String(maxLength: 64),
                    })
                .PrimaryKey(t => t.empId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
            
            CreateTable(
                "dbo.EmployeeTickets",
                c => new
                    {
                        Employee_empId = c.Int(nullable: false),
                        Ticket_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_empId, t.Ticket_id })
                .ForeignKey("dbo.Employee", t => t.Employee_empId, cascadeDelete: true)
                .ForeignKey("dbo.Ticket", t => t.Ticket_id, cascadeDelete: true)
                .Index(t => t.Employee_empId)
                .Index(t => t.Ticket_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.People", "WorkAddress_Id", "dbo.FullAddresses");
            DropForeignKey("dbo.People", "HomeAddress_Id", "dbo.FullAddresses");
            DropForeignKey("dbo.EmployeeTickets", "Ticket_id", "dbo.Ticket");
            DropForeignKey("dbo.EmployeeTickets", "Employee_empId", "dbo.Employee");
            DropForeignKey("dbo.TicketContractors", "Contractor_contId", "dbo.Contractor");
            DropForeignKey("dbo.TicketContractors", "Ticket_id", "dbo.Ticket");
            DropForeignKey("dbo.RentHistoryRecords", "ClientId", "dbo.People");
            DropForeignKey("dbo.OccupancyHistoryRecords", "ClientId", "dbo.People");
            DropForeignKey("dbo.People", "AssetId", "dbo.Assets");
            DropForeignKey("dbo.Assets", "Address_Id", "dbo.FullAddresses");
            DropIndex("dbo.EmployeeTickets", new[] { "Ticket_id" });
            DropIndex("dbo.EmployeeTickets", new[] { "Employee_empId" });
            DropIndex("dbo.TicketContractors", new[] { "Contractor_contId" });
            DropIndex("dbo.TicketContractors", new[] { "Ticket_id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RentHistoryRecords", new[] { "ClientId" });
            DropIndex("dbo.OccupancyHistoryRecords", new[] { "ClientId" });
            DropIndex("dbo.People", new[] { "WorkAddress_Id" });
            DropIndex("dbo.People", new[] { "HomeAddress_Id" });
            DropIndex("dbo.People", new[] { "AssetId" });
            DropIndex("dbo.Assets", new[] { "Address_Id" });
            DropTable("dbo.EmployeeTickets");
            DropTable("dbo.TicketContractors");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Employee");
            DropTable("dbo.Ticket");
            DropTable("dbo.Contractor");
            DropTable("dbo.RentHistoryRecords");
            DropTable("dbo.OccupancyHistoryRecords");
            DropTable("dbo.People");
            DropTable("dbo.FullAddresses");
            DropTable("dbo.Assets");
        }
    }
}
