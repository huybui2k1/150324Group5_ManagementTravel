using Group5_Management_Library.DAO;
using Group5_Management_Library.Models;

namespace Group5_Management_Library.Repository
{
    public class CustomersRepository : ICustomersRepository
    {

        public IEnumerable<Customer> GetCustomers(string sortBy) => CustomerDAO.Instance.GetCustomerList(sortBy);
        public IEnumerable<Customer> GetCustomerByName(string name, string CityName, string sortBy) => CustomerDAO.Instance.GetCustomerBySearchName(name, CityName, sortBy);
        public Customer GetCustomerByID(int id) => CustomerDAO.Instance.GetCustomerByID(id);
        public void InsertCustomer(Customer kh) => CustomerDAO.Instance.AddNew(kh);
        public void UpdateCustomer(Customer kh) => CustomerDAO.Instance.Update(kh);
        public void DeleteCustomer(int id) => CustomerDAO.Instance.Remove(id);
        public IEnumerable<Customer> DeleteSelectedCustomer(IEnumerable<int> DeleteList) => CustomerDAO.Instance.RemoveCustomerSelected(DeleteList);
    }
}