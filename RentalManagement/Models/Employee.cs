using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class Employee
    {
        public int empId { get; set; }
        [StringLength(64)]
        public string name { get; set; }
        public double payRate { get; set; }
        [StringLength(64)]
        public string email { get; set; }
        [StringLength(64)]
        public string phonenumber { get; set; }
        public Nullable<int>ticketId { get; set; }
        public virtual ICollection<Ticket> tickets { get; set; }
    }
}