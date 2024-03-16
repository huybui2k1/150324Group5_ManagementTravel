using Group5_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.Repository
{
    public interface  ICustomersRepository
    {
        IEnumerable<Customer> GetCustomers(string sortBy);
        IEnumerable<Customer> GetCustomerByName(string name, string CityName, string sortBy);
        Customer GetCustomerByID(int id);
        void InsertCustomer(Customer kh);
        void UpdateCustomer(Customer kh);
        void DeleteCustomer(int id);
        IEnumerable<Customer> DeleteSelectedCustomer(IEnumerable<int> DeleteList);
    }
}
