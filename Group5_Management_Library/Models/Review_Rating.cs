using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Models
{
    public partial class Review_Rating

    {
        public int Review_RatingId { get; set; }

        public int UserId { get; set; }

        public string Destination { get; set; }

        public int Rating { get; set; }
        public string Reviewtext { get; set; }

        
    }
}
