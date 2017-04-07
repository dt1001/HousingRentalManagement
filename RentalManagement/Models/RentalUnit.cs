using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class RentalUnit
    {
        public int id { get; set; }
        public int rooms { get; set; }
        public double size { get; set; }
        public string address { get; set; }
        public int vacancies{ get; set; }
    }
    public class RentalUnitDBContext : DbContext
    {
        public DbSet<RentalUnit> RentalUnits { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<House> Houses { get; set; }
    }
}