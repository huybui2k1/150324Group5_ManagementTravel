using ManagementTravel_API.BusinessObjects.Domain;
using Microsoft.EntityFrameworkCore;

namespace ManagementTravel_API.BusinessObjects
{
    public class ManagementTravelDBContext : DbContext
    {
        public ManagementTravelDBContext() { }
        public ManagementTravelDBContext(DbContextOptions<ManagementTravelDBContext> options)
     : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("Management_Travel"));

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
       
        protected override void OnModelCreating(ModelBuilder optionsBuilder)
        { }
       
        }
}
