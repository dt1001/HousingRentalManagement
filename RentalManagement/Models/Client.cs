﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentalManagement.Models {
    public class Client : Person {
        public ICollection<OccupancyHistoryRecord> OccupancyRecords { get; set; }

        public ICollection<RentHistoryRecord> RentRecords { get; set; }
    }
}