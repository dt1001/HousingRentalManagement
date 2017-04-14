using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class Apartment:RentalUnit
    {
        public int unitNumber { get; set; }
        public int floorNumber { get; set; }
    }
}