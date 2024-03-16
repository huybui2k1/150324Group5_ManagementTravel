using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Models
{
    public partial class Booking
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public DateTime Departure { get; set; }
        public string Flightdetails { get; set; }
        public string Accommodationdetails { get; set; }
        public string TotalCost { get; set; }
        public bool Bookingstatus { get; set; }

    }
}
