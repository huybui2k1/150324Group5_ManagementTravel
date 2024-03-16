using Group5_Management_Library.Models;
using X.PagedList;

namespace ManagementTravel_MVC.Areas.Admin.Models
{
    public class RoleUser
    {
        public ICollection<Role> Roles { get; set; }
        public IPagedList<User> Users { get; set; }
        public ICollection<UserDetail> UserDetails { get; set; }
    }
}
