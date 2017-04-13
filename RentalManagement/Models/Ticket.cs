using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    [Table("Ticket")]
    public class Ticket
    {
        
        [Key]
        public int id { get; set; }
        public DateTime issueDate { get; set; }
        public int priority { get; set; }
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        //public virtual ICollection<RentalUnit>;
        public virtual ICollection<Employee> employees {get;set;}
        public virtual ICollection<Contractor> contractors { get; set; }
        public Ticket()
        {
            this.employees = new List<Employee>();
            this.contractors = new List<Contractor>();
        }
    }
}