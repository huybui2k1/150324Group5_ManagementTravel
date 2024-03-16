using Group5_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();
        public static ProductDAO Instance
        {
            //Singlestone pattern
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }



        public IEnumerable<Product> GetProductList(string sortBy)
        {
            ///ham sort by name 
            using var context = new MyTravelDBContext();
            List<Product> model = context.Products.ToList();
            try
            {
                switch (sortBy)
                { 
                    case "id":
                        model = model.OrderBy(o => o.Id).ToList();
                        break;
                    case "iddesc":
                        model = model.OrderByDescending(o => o.Id).ToList();
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

        public Product GetProductByID(int id)
        {
            Product kh = null;
            try
            {
                using var context = new MyTravelDBContext();
                kh = context.Products.SingleOrDefault(k => k.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return kh;
        }

        public IEnumerable<Product> GetProductBySearchName(string name, string CityName, string sortBy)
        {


            //ham sort by name  
            var context = new MyTravelDBContext();
            List<Product> model = context.Products.ToList();

            try
            {
                if (!String.IsNullOrEmpty(name))
                {
                    model = model.Where(x => x.City.ToLower().Contains(name)).ToList();
                }
                if (!String.IsNullOrEmpty(CityName))
                {
                    model = model.Where(x => x.Description.ToLower().Contains(CityName)).ToList();

                    switch (sortBy)
                    {
                     
                        case "id":
                            model = model.OrderBy(o => o.Id).ToList();
                            break;
                        case "iddesc":
                            model = model.OrderByDescending(o => o.Id).ToList();
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


        public void AddNew(Product kh)
        {

            try
            {
                Product _kh = GetProductByID(kh.Id);
                if (_kh == null)
                {
                    using var context = new MyTravelDBContext();
                    context.Products.Add(kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Product kh)
        {

            try
            {
                Product _kh = GetProductByID(kh.Id);
                if (_kh != null)
                {
                    using var context = new MyTravelDBContext();
                    context.Products.Update(kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product does not already exist.");
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
                Product _kh = GetProductByID(id);
                if (_kh != null)
                {
                    using var context = new MyTravelDBContext();
                    context.Products.Remove(_kh);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("This Product does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<Product> RemoveProductSelected(IEnumerable<int> DeleteList)
        {
            using var context = new MyTravelDBContext();
            var DeleteCatList = context.Products.Where(z => DeleteList.Contains(z.Id)).ToList();
            context.Products.RemoveRange(DeleteCatList);
            context.SaveChanges();
            return DeleteCatList;
        }
    }
}
