using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;

namespace Project_Travel.Areas.Client.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext() { 
        
        }   
        public StoreContext(DbContextOptions options) : base (options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
       
        /* public DbSet<Basket> Baskets { get; set; }*/
        /* public DbSet<Order> Orders { get; set; }*/
        //public DbSet<User> Users { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        //public DbSet<TripDetails> TripDetails { get; set; }

        //public DbSet<Booking> Bookings { get; set; }
        //public DbSet<Staff> Staff { get; set; }
        //public DbSet<TransactionLog> TransactionLogs { get; set; }

        //public DbSet<PaymentMethod> PaymentMethods { get; set; }
        //public DbSet<Login> Logins { get; set; }
        //public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DataTravel_1501"));
        }


    }


}

