using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentalManagement.Models {
    public class Person {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Home Address")]
        public FullAddress HomeAddress { get; set; }

        [Display(Name = "Work Address")]
        public FullAddress WorkAddress { get; set; }
    }
}