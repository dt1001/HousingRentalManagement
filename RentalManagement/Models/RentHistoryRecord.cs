using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalManagement.Models {
    public class RentHistoryRecord {
        public int Id { get; set; }

        public int AssetId { get; set; }

        public int ClientId { get; set; }

        public DateTime? NegotiatedOn { get; set; }

        public Decimal AskingRent { get; set; }

        public Decimal NegotiatedRate { get; set; }
    }
}