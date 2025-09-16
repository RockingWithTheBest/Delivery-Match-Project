using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class CustomerData : IEntityTypeConfiguration<CustomerData>
    {
        public void Configure(EntityTypeBuilder<CustomerData> builder)
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

    public class OrderPlacmentData : IEntityTypeConfiguration<Order_Placement>
    {
        public void Configure(EntityTypeBuilder<Order_Placement> builder)
        {
            builder.HasData
          (
              // Orders for Customer 1
              new Order_Placement { Id = 1, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "456 Elm St", Pick_Up_Contact = "John Doe", Delivery_Contact = "Jane Smith", Weight = 5.5m, Volume = 2.0m, Description = "Electronics", Status = "Delivered", Price = 300.00m, Distance = "10 miles", Created_At = "2023-09-01", Scheduled_At = DateTime.Now.AddDays(1), Completed_On = DateTime.Now.AddDays(2), Customer_Id = 1 },
              new Order_Placement { Id = 2, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "789 Oak St", Pick_Up_Contact = "John Doe", Delivery_Contact = "Alice Brown", Weight = 3.0m, Volume = 1.5m, Description = "Computers", Status = "In Transit", Price = 500.00m, Distance = "15 miles", Created_At = "2023-09-02", Scheduled_At = DateTime.Now.AddDays(2), Completed_On = DateTime.Now.AddDays(3), Customer_Id = 1 },
              new Order_Placement { Id = 3, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "101 Pine St", Pick_Up_Contact = "John Doe", Delivery_Contact = "Bob White", Weight = 2.5m, Volume = 1.0m, Description = "Accessories", Status = "Pending", Price = 150.00m, Distance = "8 miles", Created_At = "2023-09-03", Scheduled_At = DateTime.Now.AddDays(3), Completed_On = DateTime.Now.AddDays(4), Customer_Id = 1 },
              new Order_Placement { Id = 4, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "202 Maple St", Pick_Up_Contact = "John Doe", Delivery_Contact = "Lucy Green", Weight = 4.0m, Volume = 2.5m, Description = "Furniture", Status = "Cancelled", Price = 600.00m, Distance = "12 miles", Created_At = "2023-09-04", Scheduled_At = DateTime.Now.AddDays(4), Completed_On = DateTime.Now.AddDays(5), Customer_Id = 1 },

              // Orders for Customer 2
              new Order_Placement { Id = 5, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "30 Center St", Pick_Up_Contact = "Alice Green", Delivery_Contact = "Tom Brown", Weight = 6.0m, Volume = 3.0m, Description = "Fresh Produce", Status = "Delivered", Price = 200.00m, Distance = "5 miles", Created_At = "2023-09-01", Scheduled_At = DateTime.Now.AddDays(1), Completed_On = DateTime.Now.AddDays(2), Customer_Id = 2 },
              new Order_Placement { Id = 6, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "35 Park Ave", Pick_Up_Contact = "Alice Green", Delivery_Contact = "Sarah White", Weight = 8.0m, Volume = 4.0m, Description = "Dairy Products", Status = "In Transit", Price = 300.00m, Distance = "10 miles", Created_At = "2023-09-02", Scheduled_At = DateTime.Now.AddDays(2), Completed_On = DateTime.Now.AddDays(3), Customer_Id = 2 },
              new Order_Placement { Id = 7, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "40 Broadway", Pick_Up_Contact = "Alice Green", Delivery_Contact = "Daniel Black", Weight = 4.5m, Volume = 2.0m, Description = "Packaged Goods", Status = "Pending", Price = 250.00m, Distance = "7 miles", Created_At = "2023-09-03", Scheduled_At = DateTime.Now.AddDays(3), Completed_On = DateTime.Now.AddDays(4), Customer_Id = 2 },
              new Order_Placement { Id = 8, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "45 Fifth St", Pick_Up_Contact = "Alice Green", Delivery_Contact = "Emma Red", Weight = 5.0m, Volume = 2.5m, Description = "Beverages", Status = "Cancelled", Price = 400.00m, Distance = "15 miles", Created_At = "2023-09-04", Scheduled_At = DateTime.Now.AddDays(4), Completed_On = DateTime.Now.AddDays(5), Customer_Id = 2 },

              // Orders for Customer 3
              new Order_Placement { Id = 9, Pick_Up_Address = "45 Fast Food Rd", Delivery_Up_Address = "50 Snack Ave", Pick_Up_Contact = "Alice Johnson", Delivery_Contact = "Jim Doe", Weight = 2.0m, Volume = 1.0m, Description = "Fast Food Order", Status = "Delivered", Price = 50.00m, Distance = "3 miles", Created_At = "2023-09-01", Scheduled_At = DateTime.Now.AddDays(1), Completed_On = DateTime.Now.AddDays(2), Customer_Id = 3 },
              new Order_Placement { Id = 10, Pick_Up_Address = "45 Fast Food Rd", Delivery_Up_Address = "55 Snack Ave", Pick_Up_Contact = "Alice Johnson", Delivery_Contact = "Kate Brown", Weight = 1.5m, Volume = 0.5m, Description = "Burger Order", Status = "In Transit", Price = 30.00m, Distance = "2 miles", Created_At = "2023-09-02", Scheduled_At = DateTime.Now.AddDays(2), Completed_On = DateTime.Now.AddDays(3), Customer_Id = 3 },
              new Order_Placement { Id = 11, Pick_Up_Address = "45 Fast Food Rd", Delivery_Up_Address = "60 Snack Ave", Pick_Up_Contact = "Alice Johnson", Delivery_Contact = "Ben White", Weight = 2.5m, Volume = 1.0m, Description = "Pizza Order", Status = "Pending", Price = 40.00m, Distance = "1.5 miles", Created_At = "2023-09-03", Scheduled_At = DateTime.Now.AddDays(3), Completed_On = DateTime.Now.AddDays(4), Customer_Id = 3 },
              new Order_Placement { Id = 12, Pick_Up_Address = "45 Fast Food Rd", Delivery_Up_Address = "65 Snack Ave", Pick_Up_Contact = "Alice Johnson", Delivery_Contact = "Beth Green", Weight = 3.0m, Volume = 1.5m, Description = "Dessert Order", Status = "Cancelled", Price = 20.00m, Distance = "2 miles", Created_At = "2023-09-04", Scheduled_At = DateTime.Now.AddDays(4), Completed_On = DateTime.Now.AddDays(5), Customer_Id = 3 },

              // Orders for Customer 4
              new Order_Placement { Id = 13, Pick_Up_Address = "100 Book St", Delivery_Up_Address = "110 Library Lane", Pick_Up_Contact = "John Smith", Delivery_Contact = "Alice Johnson", Weight = 1.0m, Volume = 0.5m, Description = "Books", Status = "Delivered", Price = 25.00m, Distance = "1 mile", Created_At = "2023-09-01", Scheduled_At = DateTime.Now.AddDays(1), Completed_On = DateTime.Now.AddDays(2), Customer_Id = 4 },
              new Order_Placement { Id = 14, Pick_Up_Address = "100 Book St", Delivery_Up_Address = "120 Library Lane", Pick_Up_Contact = "John Smith", Delivery_Contact = "Bob White", Weight = 1.5m, Volume = 0.75m, Description = "Textbooks", Status = "In Transit", Price = 45.00m, Distance = "2 miles", Created_At = "2023-09-02", Scheduled_At = DateTime.Now.AddDays(2), Completed_On = DateTime.Now.AddDays(3), Customer_Id = 4 },
              new Order_Placement { Id = 15, Pick_Up_Address = "100 Book St", Delivery_Up_Address = "130 Library Lane", Pick_Up_Contact = "John Smith", Delivery_Contact = "Charlie Black", Weight = 2.0m, Volume = 1.0m, Description = "Novels", Status = "Pending", Price = 50.00m, Distance = "3 miles", Created_At = "2023-09-03", Scheduled_At = DateTime.Now.AddDays(3), Completed_On = DateTime.Now.AddDays(4), Customer_Id = 4 },
              new Order_Placement { Id = 16, Pick_Up_Address = "100 Book St", Delivery_Up_Address = "140 Library Lane", Pick_Up_Contact = "John Smith", Delivery_Contact = "David Green", Weight = 2.5m, Volume = 1.25m, Description = "Magazines", Status = "Cancelled", Price = 30.00m, Distance = "4 miles", Created_At = "2023-09-04", Scheduled_At = DateTime.Now.AddDays(4), Completed_On = DateTime.Now.AddDays(5), Customer_Id = 4 },

              // Orders for Customer 5
              new Order_Placement { Id = 17, Pick_Up_Address = "150 Home St", Delivery_Up_Address = "160 Home Lane", Pick_Up_Contact = "Emily White", Delivery_Contact = "James Black", Weight = 3.5m, Volume = 2.0m, Description = "Home Goods", Status = "Delivered", Price = 200.00m, Distance = "5 miles", Created_At = "2023-09-01", Scheduled_At = DateTime.Now.AddDays(1), Completed_On = DateTime.Now.AddDays(2), Customer_Id = 5 },
              new Order_Placement { Id = 18, Pick_Up_Address = "150 Home St", Delivery_Up_Address = "170 Home Lane", Pick_Up_Contact = "Emily White", Delivery_Contact = "Sarah Green", Weight = 4.0m, Volume = 2.5m, Description = "Furniture", Status = "In Transit", Price = 800.00m, Distance = "10 miles", Created_At = "2023-09-02", Scheduled_At = DateTime.Now.AddDays(2), Completed_On = DateTime.Now.AddDays(3), Customer_Id = 5 },
              new Order_Placement { Id = 19, Pick_Up_Address = "150 Home St", Delivery_Up_Address = "180 Home Lane", Pick_Up_Contact = "Emily White", Delivery_Contact = "Paul Red", Weight = 2.0m, Volume = 1.0m, Description = "Kitchenware", Status = "Pending", Price = 150.00m, Distance = "3 miles", Created_At = "2023-09-03", Scheduled_At = DateTime.Now.AddDays(3), Completed_On = DateTime.Now.AddDays(4), Customer_Id = 5 },
              new Order_Placement { Id = 20, Pick_Up_Address = "150 Home St", Delivery_Up_Address = "190 Home Lane", Pick_Up_Contact = "Emily White", Delivery_Contact = "Jessica Blue", Weight = 1.5m, Volume = 0.5m, Description = "Decorations", Status = "Cancelled", Price = 100.00m, Distance = "2 miles", Created_At = "2023-09-04", Scheduled_At = DateTime.Now.AddDays(4), Completed_On = DateTime.Now.AddDays(5), Customer_Id = 5 },

              // Orders for Customer 6
              new Order_Placement { Id = 21, Pick_Up_Address = "200 Fitness St", Delivery_Up_Address = "210 Gym Lane", Pick_Up_Contact = "Mike Brown", Delivery_Contact = "Anna Green", Weight = 5.0m, Volume = 3.0m, Description = "Gym Equipment", Status = "Delivered", Price = 500.00m, Distance = "6 miles", Created_At = "2023-09-01", Scheduled_At = DateTime.Now.AddDays(1), Completed_On = DateTime.Now.AddDays(2), Customer_Id = 6 },
              new Order_Placement { Id = 22, Pick_Up_Address = "200 Fitness St", Delivery_Up_Address = "220 Gym Lane", Pick_Up_Contact = "Mike Brown", Delivery_Contact = "Laura Black", Weight = 2.5m, Volume = 1.5m, Description = "Fitness Apparel", Status = "In Transit", Price = 150.00m, Distance = "3 miles", Created_At = "2023-09-02", Scheduled_At = DateTime.Now.AddDays(2), Completed_On = DateTime.Now.AddDays(3), Customer_Id = 6 },
              new Order_Placement { Id = 23, Pick_Up_Address = "200 Fitness St", Delivery_Up_Address = "230 Gym Lane", Pick_Up_Contact = "Mike Brown", Delivery_Contact = "Cathy White", Weight = 3.0m, Volume = 2.0m, Description = "Health Supplements", Status = "Pending", Price = 300.00m, Distance = "5 miles", Created_At = "2023-09-03", Scheduled_At = DateTime.Now.AddDays(3), Completed_On = DateTime.Now.AddDays(4), Customer_Id = 6 },
              new Order_Placement { Id = 24, Pick_Up_Address = "200 Fitness St", Delivery_Up_Address = "240 Gym Lane", Pick_Up_Contact = "Mike Brown", Delivery_Contact = "Sarah Blue", Weight = 4.0m, Volume = 2.5m, Description = "Yoga Mats", Status = "Cancelled", Price = 100.00m, Distance = "4 miles", Created_At = "2023-09-04", Scheduled_At = DateTime.Now.AddDays(4), Completed_On = DateTime.Now.AddDays(5), Customer_Id = 6 }
          );
        }
    }
}
