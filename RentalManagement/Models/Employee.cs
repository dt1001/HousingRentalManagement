using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public double payRate { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
    }
    public class EmployeeDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}