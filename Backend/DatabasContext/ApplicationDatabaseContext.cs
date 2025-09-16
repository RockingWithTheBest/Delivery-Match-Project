using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.DatabasContext
{
    public class ApplicationDatabaseContext:DbContext
    {
        public ApplicationDatabaseContext(DbContextOptions<ApplicationDatabaseContext> options) : base(options) { }
        public DbSet<Address>Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Earnings> Earnings { get; set; }
        public DbSet<Notification> Notifications { get; set; }  
        public DbSet<Order_Items> Order_Items { get; set; }
        public DbSet<Order_Tracking>Order_Trackings { get; set; }
        public DbSet<Order_Placement> Order_Placement { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Models.Route> Routes { get; set; }
        public DbSet<User>Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        //public override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>()
        //}
    }
}
