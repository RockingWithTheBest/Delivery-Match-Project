using Backend.Models;
using Backend.TrainingData;
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
        public DbSet<Order_Items> OrderItems { get; set; }
        public DbSet<Order_Tracking>OrderTrackings { get; set; }
        public DbSet<Order_Placement> OrderPlacements { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Models.Route> Routes { get; set; }
        public DbSet<User>Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order_Placement>()
                .Property(p => p.CustomerId)
                .IsRequired(false);
            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .HasMaxLength(20);
            modelBuilder.ApplyConfiguration(new AddressData());
            modelBuilder.ApplyConfiguration(new CustomerData());
            modelBuilder.ApplyConfiguration(new DocumentData());
            modelBuilder.ApplyConfiguration(new DriversData());
            modelBuilder.ApplyConfiguration(new EarningsData());
            //modelBuilder.ApplyConfiguration(new NotificationData());
            modelBuilder.ApplyConfiguration(new OrderItemsData());
            modelBuilder.ApplyConfiguration(new OrderTrackingData());
            modelBuilder.ApplyConfiguration(new OrderPlacmentData());
            modelBuilder.ApplyConfiguration(new PaymentData());
            modelBuilder.ApplyConfiguration(new TrainingData.RouteData());
            modelBuilder.ApplyConfiguration(new UserData());
            modelBuilder.ApplyConfiguration(new VehicleData());
        }
    }
}
