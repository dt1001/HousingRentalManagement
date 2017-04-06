using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentalManagement.Models {
    public class Asset {
        public int Id { get; set; }

        [Display(Name = "Asset Name")]
        public string Name { get; set; }

        [Display(Name = "Asset Type")]
        public string Type { get; set; }

        public FullAddress Address { get; set; }

        [Display(Name = "Asking Rent")]
        public string AskingRent { get; set; }

        public ICollection<OccupancyHistoryRecord> OccupancyRecords;

        public ICollection<RentHistoryRecord> RentRecords;

    }
}