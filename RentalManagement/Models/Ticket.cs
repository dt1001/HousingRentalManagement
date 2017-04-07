using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class Ticket
    {
        public int id { get; set; }
        public string description { get; set; }
        public DateTime issueDate { get; set; }
        public int priority { get; set; }
    }
    public class TicketDBContext : DbContext
    {
        public DbSet<Contractor> Contractors { get; set; }

        public System.Data.Entity.DbSet<RentalManagement.Models.Ticket> Tickets { get; set; }
    }
}