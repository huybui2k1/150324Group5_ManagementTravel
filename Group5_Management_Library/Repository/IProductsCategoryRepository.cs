using Group5_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Repository
{
    public interface IProductsCategoryRepository
    {
        IEnumerable<ProductCategory> GetAll();
        void Insert(ProductCategory productCategory);
        void Update(ProductCategory productCategory);
        ProductCategory GetById(int id);
        void Delete(ProductCategory productCategory);
    }
}
