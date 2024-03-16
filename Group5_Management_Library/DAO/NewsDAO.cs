using Group5_Management_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group5_Management_Library.DAO
{
    public class NewsDAO
    {
       /* private static NewsDAO instance;
        private static readonly object instanceLock = new object();
        public static NewsDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new NewsDAO();
                    }
                    return instance;
                }
            }
        }
        public List<News> GetAll()
        {
            List<News> news;
            try
            {
                using MyTravelDBContext stock = new MyTravelDBContext();
                news = stock.News.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return news;
        }


        public IEnumerable<News> GetNewsByKeyword(string keyword, string sortBy, int? categoryId)
        {
            List<News> news = new List<News>();
            try
            {
                MyTravelDBContext stock = new MyTravelDBContext();
                IQueryable<News> newsQuery = stock.News;
                if (!String.IsNullOrEmpty(keyword))
                {
                    newsQuery = newsQuery.Where(u => u.Title != null && u.Title.ToLower().Contains(keyword)); // Remove ToList() here
                }

                switch (sortBy)
                {
                    case "title":
                        newsQuery = (Microsoft.EntityFrameworkCore.DbSet<News>)newsQuery.OrderBy(o => o.Title);
                        break;
                    case "titledesc":
                        newsQuery = (Microsoft.EntityFrameworkCore.DbSet<News>)newsQuery.OrderByDescending(o => o.Title);
                        break;
                    default:
                        break;
                }
                if (categoryId != null)
                {
                    news = newsQuery.Where(u => u.CategoryId == categoryId).ToList();
                }
                else
                {
                    news = newsQuery.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return news;
        }

        public News GetById(int? id)
        {
            News news;
            try
            {
                using MyTravelDBContext stock = new MyTravelDBContext();
                news = stock.News.SingleOrDefault(r => r.NewsId == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return news;
        }


        public void Insert(News news)
        {
            using MyTravelDBContext stock = new MyTravelDBContext();
            using (var transaction = stock.Database.BeginTransaction())
            {
                try
                {

                    stock.Add(news);
                    stock.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        public void Update(News news)
        {
            using MyTravelDBContext stock = new MyTravelDBContext();
            using (var transaction = stock.Database.BeginTransaction())
            {
                try
                {
                    stock.Entry<News>(news).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    stock.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

       *//* public IEnumerable<NewsCategory> GetAllNewsCategory()
        {
            using MyTravelDBContext stock = new MyTravelDBContext();
            return stock.NewsCategories.ToList();
        }*//*

        public void Delete(News news)
        {
            try
            {
                using MyTravelDBContext stock = new MyTravelDBContext();
                var us = stock.News.SingleOrDefault(c => c.NewsId == news.UserId);
                stock.Remove(us);
                stock.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ChangeStatus(int id)
        {
            using MyTravelDBContext stock = new MyTravelDBContext();
            var news = stock.News.Find(id);
            news.Status = !news.Status;
            stock.SaveChanges();
            return (bool)news.Status;
        }*/
    }
}
