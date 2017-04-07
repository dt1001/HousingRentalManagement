using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class Contract
    {
        public ICollection<Ticket> tickets { get; set; }
        public ICollection<Contractor> contractors { get; set; }
        public DateTime issueDate { get; set; }
    }
    public class ContractDBContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
    }
}