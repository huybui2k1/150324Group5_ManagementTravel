using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Models
{
    public partial class UserDetail
    {
        public int UserDetailId { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
        //public virtual User User { get; set; }

    }
}
