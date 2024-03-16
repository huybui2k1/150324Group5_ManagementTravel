using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Models
{
    public partial class Order
    {
        [Display(Name = "Mã đặt hàng")]
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public DateTime DateBuy { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

       // public virtual User User { get; set; }
    }
}
