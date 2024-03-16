using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Models
{
    public partial class Customer
    {
      
        [Display(Name = "Mã Khách Hàng")]
        public int CustomerId { get; set; }
        [Display(Name = "Tên Khách Hàng")]
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ tên khách hàng")]
        public string? CustomerIdName { get; set; }
        [Display(Name = "Địa chỉ Khách Hàng")]
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ Địa chỉ khách hàng")]
        public string? Address { get; set; }
        [Display(Name = "Địa thoại Khách Hàng")]
        [Required(ErrorMessage = "Yêu cầu nhập đầy đủ Điện thoại khách hàng")]
        public string? PhoneNumber { get; set; }

    }
}
