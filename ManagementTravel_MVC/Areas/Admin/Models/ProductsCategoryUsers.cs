using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Group5_Management_Library.Models
{
    public class ProductsCategoryUsers
    {
        public ICollection<ProductCategory> ProductsCategory { get; set; }
        public IPagedList<Product> Products { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
