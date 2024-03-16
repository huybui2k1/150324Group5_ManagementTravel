using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Group5_Management_Library.Models
{
    public partial class MyTravelDBContext : DbContext
    {
        public MyTravelDBContext() { }  
        public MyTravelDBContext(DbContextOptions<MyTravelDBContext> options) : base(options) { }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsCategory> NewsCategories { get; set; } 
        public virtual DbSet<Order> Orders { get; set; }  
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<ProductCategory> ProductCategorys { get; set; }
        public virtual DbSet<Review_Rating> Review_Ratings { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<User> Users { get; set; }
       public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HS7UVTQ ; Database= Travel_Admin1801;TrustServerCertificate=true;Trusted_Connection=SSPI;Encrypt=false;");
            }
        }
        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        { }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
