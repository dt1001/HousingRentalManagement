using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class Apartment:RentalUnit
    {
        [Display(Name = "Unit Number")]
        public int unitNumber { get; set; }
        [Display(Name = "Floor Number")]
        public int floor { get; set; }
    }
}