using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentalManagement.Models {
    public class FullAddress {

        public int Id { get; set; }

        [Display(Name = "Suite")]
        public string UnitNum { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
    }
}