using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class Assignment
    {
        ICollection<Ticket> tickets { get; set; }
        ICollection<Employee> employees { get; set; }
        DateTime dateIssued { get; set; }
    }
    public class AssignmentDBContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
    }
}