using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalManagement.Models;

namespace RentalManagement.ViewModel {
    public class ClientViewModel {
       public Client Client { get; set; }
       public IEnumerable<Asset> Assets { get; set; }
    }
}