using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalManagement.Models;

namespace RentalManagement.ViewModel {
    public class AssetClientViewModel {
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        public FullAddress AssetAddress { get; set; }

        public FullAddress ClientHomeAddress { get; set; }

        public FullAddress ClientWorkAddress { get; set; }

        public string AssetType { get; set; }
    }
}