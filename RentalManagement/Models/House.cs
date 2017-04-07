using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RentalManagement.Models
{
    public class House : RentalUnit
    {
        int unitId { get; set; }
        int floors { get; set; }
        string type { get; set; }
    }
}