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
                new Customer { Id = 1, Business_Name = "Tech Solutions", Business_Type = "IT Services", Tax_Identification = "TS123456A", Rating = "4.5", Total_Orders = 4, Total_Spent = 1500.00m, UserId = 1 },
                new Customer { Id = 2, Business_Name = "Green Grocers", Business_Type = "Retail", Tax_Identification = "GG987654B", Rating = "4.8", Total_Orders = 4, Total_Spent = 2200.00m, UserId = 2 },
                new Customer { Id = 3, Business_Name = "Fast Foodies", Business_Type = "Food & Beverage", Tax_Identification = "FF456789C", Rating = "4.3", Total_Orders = 4, Total_Spent = 800.00m, UserId = 3 },
                new Customer { Id = 4, Business_Name = "Book Haven", Business_Type = "Retail", Tax_Identification = "BH321654D", Rating = "4.7", Total_Orders = 4, Total_Spent = 1200.00m, UserId = 4 },
                new Customer { Id = 5, Business_Name = "Home Essentials", Business_Type = "Retail", Tax_Identification = "HE654123E", Rating = "4.6", Total_Orders = 4, Total_Spent = 1600.00m, UserId = 5 },
                new Customer { Id = 6, Business_Name = "Fitness Hub", Business_Type = "Health & Fitness", Tax_Identification = "FH159753F", Rating = "4.9", Total_Orders = 4, Total_Spent = 3000.00m, UserId = 6 }
            );          
        }
    }

   
}
