using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class CustomerData : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData
            (
                // Sample Customers
                new Customer { Id = 1, BusinessName = "Tech Solutions", BusinessType = "IT Services", TaxIdentification = "TS123456A", Rating = "4.5", TotalOrders = 4, TotalSpent = 1500.00m, UserId = 1 },
                new Customer { Id = 2, BusinessName = "Green Grocers", BusinessType = "Retail", TaxIdentification = "GG987654B", Rating = "4.8", TotalOrders = 4, TotalSpent = 2200.00m, UserId = 2 },
                new Customer { Id = 3, BusinessName = "Fast Foodies", BusinessType = "Food & Beverage", TaxIdentification = "FF456789C", Rating = "4.3", TotalOrders = 4, TotalSpent = 800.00m, UserId = 3 },
                new Customer { Id = 4, BusinessName = "Book Haven", BusinessType = "Retail", TaxIdentification = "BH321654D", Rating = "4.7", TotalOrders = 4, TotalSpent = 1200.00m, UserId = 4 },
                new Customer { Id = 5, BusinessName = "Home Essentials", BusinessType = "Retail", TaxIdentification = "HE654123E", Rating = "4.6", TotalOrders = 4, TotalSpent = 1600.00m, UserId = 5 },
                new Customer { Id = 6, BusinessName = "Fitness Hub", BusinessType = "Health & Fitness", TaxIdentification = "FH159753F", Rating = "4.9", TotalOrders = 4, TotalSpent = 3000.00m, UserId = 6 }
            );          
        }
    }

   
}
