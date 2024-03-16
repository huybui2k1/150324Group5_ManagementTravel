using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Models
{
    public partial class News
    {
        public int NewsId { get; set; }

        public int CategoryId { get; set; }

        [DisplayName("Tiêu đề")]
        public string Title { get; set; }
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        public string SubjectContent { get; set; }

        [DisplayName("Ngày đăng")]
        public DateTime DateUpdate { get; set; }

        [DisplayName("Trạng thái")]
        public bool? Status { get; set; }

        [DisplayName("Ảnh đại diện")]
        public string Avatar { get; set; }

        public int UserId { get; set; }

        public virtual NewsCategory Category { get; set; }

        public virtual User User { get; set; }
    }
}