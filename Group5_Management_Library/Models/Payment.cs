using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentName { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }

    }
}
