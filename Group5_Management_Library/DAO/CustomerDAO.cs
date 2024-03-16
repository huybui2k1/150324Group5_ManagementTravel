using Group5_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance = null;
        private static readonly object instanceLock = new object();
        public static CustomerDAO Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }

       

        public IEnumerable<Customer> GetCustomerList(string sortBy)
        {
            ///ham sort by name 
            using var context = new MyTravelDBContext();
            List<Customer> model = context.Customers.ToList();
            try
            {
                switch (sortBy)
                {
                    case "name":
                        model = model.OrderBy(o => o.CustomerIdName).ToList();
                        break;
                    case "namedesc":
                        model = model.OrderByDescending(o => o.CustomerIdName).ToList();
                        break;
                    case "address":
                        model = model.OrderBy(o => o.Address).ToList();
                        break;
                    case "addressdesc":
                        model = model.OrderByDescending(o => o.Address).ToList();
                        break;
                    case "id":
                        model = model.OrderBy(o => o.CustomerId).ToList();
                        break;
                    case "iddesc":
                        model = model.OrderByDescending(o => o.CustomerId).ToList();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return model;
        }

        public Customer GetCustomerByID(int id)
        {
            Customer kh = null;
            try
            {
                using var context = new MyTravelDBContext();
                kh = context.Customers.SingleOrDefault(k => k.CustomerId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return kh;
        }

        public IEnumerable<Customer> GetCustomerBySearchName(string name, string CityName, string sortBy)
        {


            //ham sort by name  
            var context = new MyTravelDBContext();
            List<Customer> model = context.Customers.ToList();

            try
            {
                if (!String.IsNullOrEmpty(name))
                {
                    model = model.Where(x => x.CustomerIdName.ToLower().Contains(name)).ToList();
                }
                if (!String.IsNullOrEmpty(CityName))
                {
                    model = model.Where(x => x.Address.ToLower().Contains(CityName)).ToList();

                    switch (sortBy)
                    {
                        case "name":
                            model = model.OrderBy(o => o.CustomerIdName).ToList();
                            break;
                        case "namedesc":
                            model = model.OrderByDescending(o => o.CustomerIdName).ToList();
                            break;
                        case "address":
                            model = model.OrderBy(o => o.Address).ToList();
                            break;
                        case "addressdesc":
                            model = model.OrderByDescending(o => o.Address).ToList();
                            break;
                        case "id":
                            model = model.OrderBy(o => o.CustomerId).ToList();
                            break;
                        case "iddesc":
                            model = model.OrderByDescending(o => o.CustomerId).ToList();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return model;
        }


        public void AddNew(Customer kh)
        {

            try
            {
                Customer _kh = GetCustomerByID(kh.CustomerId);
                if (_kh == null)
                {
                    using var context = new MyTravelDBContext();
                    context.Customers.Add(kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Customer is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Customer kh)
        {

            try
            {
                Customer _kh = GetCustomerByID(kh.CustomerId);
                if (_kh != null)
                {
                    using var context = new MyTravelDBContext();
                    context.Customers.Update(kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Customer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(int id)
        {
            try
            {
                Customer _kh = GetCustomerByID(id);
                if (_kh != null)
                {
                    using var context = new MyTravelDBContext();
                    context.Customers.Remove(_kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Customer does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Customer> RemoveCustomerSelected(IEnumerable<int> DeleteList)
        {
            using var context = new MyTravelDBContext();
            var DeleteCatList = context.Customers.Where(z => DeleteList.Contains(z.CustomerId)).ToList();
            context.Customers.RemoveRange(DeleteCatList);
            context.SaveChanges();
            return DeleteCatList;
        }
    }
}
