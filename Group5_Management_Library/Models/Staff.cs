using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Models
{
    public class Staff

    {
        public int StaffId { get; set; }

        [Display(Name = "Tên đăng nhập")]
        public string? StaffName { get; set; }
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public DateTime NgaySinh { get; set; }

        public virtual ICollection<News> News { get; set; } = new List<News>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public virtual Role Role { get; set; }

        public virtual UserDetail UserDetail { get; set; }

    
}
}
