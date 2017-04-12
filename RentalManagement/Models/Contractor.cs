using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    [Table("Contractor")]
    public class Contractor
    {
        [Key]
        public int contId { get; set; }
        [StringLength(64)]
        public string name { get; set; }
        [StringLength(64)]
        public string companyName { get; set; }
        public double rate { get; set; }
        [StringLength(64)]
        public string profession { get; set; }
        public virtual ICollection<Ticket> tickets { get; set; }
        public Contractor()
        {
            this.tickets = new List<Ticket>();
        }
    }
}