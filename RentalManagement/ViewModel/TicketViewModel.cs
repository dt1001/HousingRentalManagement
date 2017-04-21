using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentalManagement.Models;

namespace RentalManagement.ViewModel
{
    public class TicketViewModel
    {
        public Ticket ticket { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public Employee employee { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public Contractor contractor { get; set; }

        public Asset Asset { get; set; }

        public ICollection<Contractor> Contractors { get; set; }

        public ICollection<TicketWrapper> TicketData { get; set; }

        public ICollection<Asset> Assets { get; set; }
    }
}