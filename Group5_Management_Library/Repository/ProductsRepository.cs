using Group5_Management_Library.DAO;
using Group5_Management_Library.Models;

namespace Group5_Management_Library.Repository
{
    public class ProductsRepository : IProductsRepository
    {

        public IEnumerable<Product> GetProducts(string sortBy) => ProductDAO.Instance.GetProductList(sortBy);
        public IEnumerable<Product> GetProductByName(string name, string CityName, string sortBy) => ProductDAO.Instance.GetProductBySearchName(name, CityName, sortBy);
        public Product GetProductByID(int id) => ProductDAO.Instance.GetProductByID(id);
        public void InsertProduct(Product kh) => ProductDAO.Instance.AddNew(kh);
        public void UpdateProduct(Product kh) => ProductDAO.Instance.Update(kh);
        public void DeleteProduct(int id) => ProductDAO.Instance.Remove(id);
        public IEnumerable<Product> DeleteSelectedProduct(IEnumerable<int> DeleteList) => ProductDAO.Instance.RemoveProductSelected(DeleteList);
    }
}