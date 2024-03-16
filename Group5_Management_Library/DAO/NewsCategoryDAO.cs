using Group5_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.DAO
{
    public class NewsCategoryDAO
    {
        private static NewsCategoryDAO instance;
        private static readonly object instanceLock = new object();
        public static NewsCategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NewsCategoryDAO();
                    }
                    return instance;
                }
            }
        }

        public List<NewsCategory> GetAll()
        {
            List<NewsCategory> newsCategory;
            try
            {
                using MyTravelDBContext stock = new MyTravelDBContext();
                newsCategory = stock.NewsCategories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newsCategory;
        }

        public NewsCategory GetById(int? id)
        {
            NewsCategory newsCategory;
            try
            {
                using MyTravelDBContext stock = new MyTravelDBContext();
                newsCategory = stock.NewsCategories.SingleOrDefault(r => r.NewsCategoryId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return newsCategory;
        }

        public void Insert(NewsCategory newsCategory)
        {
            try
            {
                using MyTravelDBContext stock = new MyTravelDBContext();
                stock.Add(newsCategory);
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(NewsCategory newsCategory)
        {
            try
            {
                using MyTravelDBContext stock = new MyTravelDBContext();
                stock.Entry<NewsCategory>(newsCategory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(NewsCategory newsCategory)
        {
            try
            {
                using MyTravelDBContext stock = new MyTravelDBContext();
                var rl = stock.NewsCategories.SingleOrDefault(c => c.NewsCategoryId == newsCategory.NewsCategoryId);
                stock.Remove(rl);
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
