using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class Contractor
    {
        public int contId { get; set; }
        [StringLength(64)]
        public string name { get; set; }
        [StringLength(64)]
        public string companyName { get; set; }
        public double rate { get; set; }
        [StringLength(64)]
        public string profession { get; set; }
    }
}