using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class Apartment : RentalUnit
    {
        int unitId { get; set; }
        int number { get; set; }
        int floor { get; set; }
    }
}