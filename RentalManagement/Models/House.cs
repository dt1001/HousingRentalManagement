using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class House:RentalUnit
    {
        [Display(Name = "Floors")]
        public int floors { get; set; }
        [Display(Name = "Type")]
        public string type { get; set; }
    }
}