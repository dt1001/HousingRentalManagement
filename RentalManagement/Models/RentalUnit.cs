using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class RentalUnit
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Rooms")]
        public int rooms { get; set; }
        [Display(Name = "Vacancies")]
        public int vacancies { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "Size")]
        public double size { get; set; }
    }
}