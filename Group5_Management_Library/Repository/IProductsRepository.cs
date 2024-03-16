using Group5_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Repository
{
    public interface  IProductsRepository
    {
        IEnumerable<Product> GetProducts(string sortBy);
        IEnumerable<Product> GetProductByName(string name, string CityName, string sortBy);
        Product GetProductByID(int id);
        void InsertProduct(Product kh);
        void UpdateProduct(Product kh);
        void DeleteProduct(int id);
        IEnumerable<Product> DeleteSelectedProduct(IEnumerable<int> DeleteList);
    }
}
