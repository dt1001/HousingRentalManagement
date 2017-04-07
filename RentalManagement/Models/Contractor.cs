using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class Contractor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string companyName { get; set; }
        public double rate { get; set; }
        public string profession { get; set; }
    }
    public class ContractorDBContext : DbContext
    {
        public DbSet<Contractor> Contractors { get; set; }
    }
}