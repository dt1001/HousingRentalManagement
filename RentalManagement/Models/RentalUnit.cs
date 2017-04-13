using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    [Table("RentalUnit")]
    public class RentalUnit
    {
        [Key]
        [Display(Name = "Unit Id")]
        public int unitId { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        [Display(Name = "Rooms")]
        public int rooms { get; set; }
        [Display(Name = "Size(sqre ft.)")]
        public double size { get; set; }
        [Display(Name = "Vacancies")]
        public int vacancies { get; set; }
        public ICollection<Ticket> tickets { get; set; }
        public RentalUnit()
        {
            tickets = new List<Ticket>();
        }
    }
}