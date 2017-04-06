using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalManagement.Models {
    public class OccupancyHistoryRecord {
        public int Id { get; set; }

        public int AssetId { get; set; }

        public int ClientId { get; set; }
    
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}