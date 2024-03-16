using Group5_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace ManagementTravel_MVC.Areas.Admin.Models
{
    public class NewsCategoryUsers
    {
        public ICollection<NewsCategory> NewsCategory { get; set; }
        public IPagedList<News> News { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
