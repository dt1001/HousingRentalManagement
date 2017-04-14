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
        [Display(Name = "Ticket Id")]
        public int id { get; set; }
        [Display(Name = "Issue Date")]
        public DateTime issueDate { get; set; }
        [Display(Name = "Priority")]
        public int priority { get; set; }
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public virtual RentalUnit rentalUnit { get; set; }
        public virtual ICollection<Employee> employees {get;set;}
        public virtual ICollection<Contractor> contractors { get; set; }
        public Ticket()
        {
            this.employees = new List<Employee>();
            this.contractors = new List<Contractor>();
        }
    }
}