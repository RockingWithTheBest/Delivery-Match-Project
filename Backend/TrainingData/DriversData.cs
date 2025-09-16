using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class DriversData : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasData
            (
                 new Driver
                 {
                     Id = 1,
                     Drivers_License = "DL123456789",
                     License_Expiry = new DateOnly(2025, 12, 31),
                     Is_Verified = true,
                     Is_Available = true,
                     Rating = "4.8",
                     Completion_Rate = "95%",
                     Total_Earnings = 1500.00m,
                     UserId = 7
                 },
                new Driver
                {
                    Id = 2,
                    Drivers_License = "DL987654321",
                    License_Expiry = new DateOnly(2025, 11, 15),
                    Is_Verified = true,
                    Is_Available = true,
                    Rating = "4.5",
                    Completion_Rate = "90%",
                    Total_Earnings = 1200.00m,
                    UserId = 8 
                },
                new Driver
                {
                    Id = 3,
                    Drivers_License = "DL456123789",
                    License_Expiry = new DateOnly(2026, 05, 01),
                    Is_Verified = true,
                    Is_Available = true,
                    Rating = "4.6",
                    Completion_Rate = "92%",
                    Total_Earnings = 1800.00m,
                    UserId = 9 
                },
                new Driver
                {
                    Id = 4,
                    Drivers_License = "DL321654987",
                    License_Expiry = new DateOnly(2025, 10, 30),
                    Is_Verified = true,
                    Is_Available = true,
                    Rating = "4.7",
                    Completion_Rate = "93%",
                    Total_Earnings = 1600.00m,
                    UserId = 10 
                },
                new Driver
                {
                    Id = 5,
                    Drivers_License = "DL159753468",
                    License_Expiry = new DateOnly(2026, 01, 14),
                    Is_Verified = true,
                    Is_Available = true,
                    Rating = "4.9",
                    Completion_Rate = "97%",
                    Total_Earnings = 2000.00m,
                    UserId = 11
                },
                new Driver
                {
                    Id = 6,
                    Drivers_License = "DL753159864",
                    License_Expiry = new DateOnly(2025, 08, 20),
                    Is_Verified = true,
                    Is_Available = true,
                    Rating = "4.4",
                    Completion_Rate = "89%",
                    Total_Earnings = 1400.00m,
                    UserId = 12 
                }
            );
        }
    }

    public class OrderPlacementData : IEntityTypeConfiguration<Order_Placement>
    {
        public void Configure(EntityTypeBuilder<Order_Placement> builder)
        {
            builder.HasData
            (
                // Orders for Driver 1
                new Order_Placement { Id = 25, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "456 Elm St", Pick_Up_Contact = "Alice", Delivery_Contact = "Bob", Weight = 5.5m, Volume = 2.0m, Description = "Electronics", Status = "Delivered", Price = 300.00m, Distance = "10 miles", Created_At = "2023-09-01", Scheduled_At = DateTime.Now.AddDays(1), Completed_On = DateTime.Now.AddDays(2), Driver_Id = 1 },
                new Order_Placement { Id = 26, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "789 Oak St", Pick_Up_Contact = "Alice", Delivery_Contact = "Tom", Weight = 3.0m, Volume = 1.5m, Description = "Computers", Status = "In Transit", Price = 500.00m, Distance = "15 miles", Created_At = "2023-09-02", Scheduled_At = DateTime.Now.AddDays(2), Completed_On = DateTime.Now.AddDays(3), Driver_Id = 1 },
                new Order_Placement { Id = 27, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "101 Pine St", Pick_Up_Contact = "Alice", Delivery_Contact = "Sarah", Weight = 2.5m, Volume = 1.0m, Description = "Accessories", Status = "Pending", Price = 150.00m, Distance = "8 miles", Created_At = "2023-09-03", Scheduled_At = DateTime.Now.AddDays(3), Completed_On = DateTime.Now.AddDays(4), Driver_Id = 1 },
                new Order_Placement { Id = 28, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "202 Maple St", Pick_Up_Contact = "Alice", Delivery_Contact = "Emma", Weight = 4.0m, Volume = 2.5m, Description = "Furniture", Status = "Cancelled", Price = 600.00m, Distance = "12 miles", Created_At = "2023-09-04", Scheduled_At = DateTime.Now.AddDays(4), Completed_On = DateTime.Now.AddDays(5), Driver_Id = 1 },
                new Order_Placement { Id = 29, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "303 Cedar St", Pick_Up_Contact = "Alice", Delivery_Contact = "Luke", Weight = 1.0m, Volume = 0.5m, Description = "Books", Status = "Delivered", Price = 50.00m, Distance = "3 miles", Created_At = "2023-09-05", Scheduled_At = DateTime.Now.AddDays(5), Completed_On = DateTime.Now.AddDays(6), Driver_Id = 1 },

                // Orders for Driver 2
                new Order_Placement { Id = 30, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "30 Center St", Pick_Up_Contact = "Bob", Delivery_Contact = "Alice", Weight = 6.0m, Volume = 3.0m, Description = "Fresh Produce", Status = "Delivered", Price = 200.00m, Distance = "5 miles", Created_At = "2023-09-01", Scheduled_At = DateTime.Now.AddDays(1), Completed_On = DateTime.Now.AddDays(2), Driver_Id = 2 },
                new Order_Placement { Id = 31, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "35 Park Ave", Pick_Up_Contact = "Bob", Delivery_Contact = "Sara", Weight = 8.0m, Volume = 4.0m, Description = "Dairy Products", Status = "In Transit", Price = 300.00m, Distance = "10 miles", Created_At = "2023-09-02", Scheduled_At = DateTime.Now.AddDays(2), Completed_On = DateTime.Now.AddDays(3), Driver_Id = 2 },
                new Order_Placement { Id = 32, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "40 Broadway", Pick_Up_Contact = "Bob", Delivery_Contact = "Daniel", Weight = 4.5m, Volume = 2.0m, Description = "Packaged Goods", Status = "Pending", Price = 250.00m, Distance = "7 miles", Created_At = "2023-09-03", Scheduled_At = DateTime.Now.AddDays(3), Completed_On = DateTime.Now.AddDays(4), Driver_Id = 2 },
                new Order_Placement { Id = 33, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "45 Fifth St", Pick_Up_Contact = "Bob", Delivery_Contact = "Emma", Weight = 5.0m, Volume = 2.5m, Description = "Beverages", Status = "Cancelled", Price = 400.00m, Distance = "15 miles", Created_At = "2023-09-04", Scheduled_At = DateTime.Now.AddDays(4), Completed_On = DateTime.Now.AddDays(5), Driver_Id = 2 },
                new Order_Placement { Id = 34, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "50 Main St", Pick_Up_Contact = "Bob", Delivery_Contact = "Chris", Weight = 3.0m, Volume = 1.5m, Description = "Snacks", Status = "Delivered", Price = 100.00m, Distance = "2 miles", Created_At = "2023-09-05", Scheduled_At = DateTime.Now.AddDays(5), Completed_On = DateTime.Now.AddDays(6), Driver_Id = 2 },

                // Orders for Driver 3
                new Order_Placement { Id = 35, Pick_Up_Address = "400 River Rd", Delivery_Up_Address = "450 Lake St", Pick_Up_Contact = "Charlie", Delivery_Contact = "Diana", Weight = 7.0m, Volume = 3.5m, Description = "Clothing", Status = "Delivered", Price = 350.00m, Distance = "12 miles", Created_At = "2023-09-06", Scheduled_At = DateTime.Now.AddDays(1), Completed_On = DateTime.Now.AddDays(2), Driver_Id = 3 },
                new Order_Placement { Id = 36, Pick_Up_Address = "400 River Rd", Delivery_Up_Address = "460 Ocean St", Pick_Up_Contact = "Charlie", Delivery_Contact = "Evan", Weight = 6.5m, Volume = 2.0m, Description = "Footwear", Status = "In Transit", Price = 200.00m, Distance = "14 miles", Created_At = "2023-09-07", Scheduled_At = DateTime.Now.AddDays(2), Completed_On = DateTime.Now.AddDays(3), Driver_Id = 3 },
                new Order_Placement { Id = 36, Pick_Up_Address = "400 River Rd", Delivery_Up_Address = "470 Sea St", Pick_Up_Contact = "Charlie", Delivery_Contact = "Fiona", Weight = 5.0m, Volume = 1.5m, Description = "Accessories", Status = "Pending", Price = 150.00m, Distance = "10 miles", Created_At = "2023-09-08", Scheduled_At = DateTime.Now.AddDays(3), Completed_On = DateTime.Now.AddDays(4), Driver_Id = 3 },
                new Order_Placement { Id = 37, Pick_Up_Address = "400 River Rd", Delivery_Up_Address = "480 Shore St", Pick_Up_Contact = "Charlie", Delivery_Contact = "Gina", Weight = 4.0m, Volume = 2.5m, Description = "Home Goods", Status = "Cancelled", Price = 300.00m, Distance = "8 miles", Created_At = "2023-09-09", Scheduled_At = DateTime.Now.AddDays(4), Completed_On = DateTime.Now.AddDays(5), Driver_Id = 3 },
                new Order_Placement { Id = 38, Pick_Up_Address = "400 River Rd", Delivery_Up_Address = "490 Hill St", Pick_Up_Contact = "Charlie", Delivery_Contact = "Hank", Weight = 3.5m, Volume = 1.0m, Description = "Stationery", Status = "Delivered", Price = 80.00m, Distance = "5 miles", Created_At = "2023-09-10", Scheduled_At = DateTime.Now.AddDays(5), Completed_On = DateTime.Now.AddDays(6), Driver_Id = 3 },

                // Orders for Driver 4
                new Order_Placement { Id = 39, Pick_Up_Address = "50 Green St", Delivery_Up_Address = "60 Blue St", Pick_Up_Contact = "Diana", Delivery_Contact = "Ethan", Weight = 2.5m, Volume = 1.2m, Description = "Gadgets", Status = "Delivered", Price = 120.00m, Distance = "3 miles", Created_At = "2023-09-11", Scheduled_At = DateTime.Now.AddDays(1), Completed_On = DateTime.Now.AddDays(2), Driver_Id = 4 },
                new Order_Placement { Id = 40, Pick_Up_Address = "50 Green St", Delivery_Up_Address = "70 Yellow St", Pick_Up_Contact = "Diana", Delivery_Contact = "Frank", Weight = 3.0m, Volume = 1.5m, Description = "Electronics", Status = "In Transit", Price = 250.00m, Distance = "4 miles", Created_At = "2023-09-12", Scheduled_At = DateTime.Now.AddDays(2), Completed_On = DateTime.Now.AddDays(3), Driver_Id = 4 },
                new Order_Placement { Id = 41, Pick_Up_Address = "50 Green St", Delivery_Up_Address = "80 Pink St", Pick_Up_Contact = "Diana", Delivery_Contact = "Grace", Weight = 5.0m, Volume = 2.0m, Description = "Home Appliances", Status = "Pending", Price = 400.00m, Distance = "6 miles", Created_At = "2023-09-13", Scheduled_At = DateTime.Now.AddDays(3), Completed_On = DateTime.Now.AddDays(4), Driver_Id = 4 },
                new Order_Placement { Id = 42, Pick_Up_Address = "50 Green St", Delivery_Up_Address = "90 Gray St", Pick_Up_Contact = "Diana", Delivery_Contact = "Henry", Weight = 1.5m, Volume = 0.5m, Description = "Books", Status = "Cancelled", Price = 50.00m, Distance = "2 miles", Created_At = "2023-09-14", Scheduled_At = DateTime.Now.AddDays(4), Completed_On = DateTime.Now.AddDays(5), Driver_Id = 4 },
                new Order_Placement { Id = 43, Pick_Up_Address = "50 Green St", Delivery_Up_Address = "100 Black St", Pick_Up_Contact = "Diana", Delivery_Contact = "Ivy", Weight = 4.0m, Volume = 3.0m, Description = "Clothing", Status = "Delivered", Price = 320.00m, Distance = "7 miles", Created_At = "2023-09-15", Scheduled_At = DateTime.Now.AddDays(5), Completed_On = DateTime.Now.AddDays(6), Driver_Id = 4 },

                // Orders for Driver 5
                new Order_Placement { Id = 44, Pick_Up_Address = "75 Red St", Delivery_Up_Address = "85 Orange St", Pick_Up_Contact = "Ethan", Delivery_Contact = "Jack", Weight = 6.0m, Volume = 3.0m, Description = "Furniture", Status = "Delivered", Price = 600.00m, Distance = "10 miles", Created_At = "2023-09-16", Scheduled_At = DateTime.Now.AddDays(1), Completed_On = DateTime.Now.AddDays(2), Driver_Id = 5 },
                new Order_Placement { Id = 45, Pick_Up_Address = "75 Red St", Delivery_Up_Address = "95 Violet St", Pick_Up_Contact = "Ethan", Delivery_Contact = "Liam", Weight = 2.5m, Volume = 1.0m, Description = "Kitchenware", Status = "In Transit", Price = 150.00m, Distance = "5 miles", Created_At = "2023-09-17", Scheduled_At = DateTime.Now.AddDays(2), Completed_On = DateTime.Now.AddDays(3), Driver_Id = 5 },
                new Order_Placement { Id = 46, Pick_Up_Address = "75 Red St", Delivery_Up_Address = "105 Indigo St", Pick_Up_Contact = "Ethan", Delivery_Contact = "Mia", Weight = 3.5m, Volume = 2.0m, Description = "Decor", Status = "Pending", Price = 250.00m, Distance = "6 miles", Created_At = "2023-09-18", Scheduled_At = DateTime.Now.AddDays(3), Completed_On = DateTime.Now.AddDays(4), Driver_Id = 5 },
                new Order_Placement { Id = 47, Pick_Up_Address = "75 Red St", Delivery_Up_Address = "115 Brown St", Pick_Up_Contact = "Ethan", Delivery_Contact = "Nora", Weight = 1.0m, Volume = 0.5m, Description = "Stationery", Status = "Cancelled", Price = 20.00m, Distance = "2 miles", Created_At = "2023-09-19", Scheduled_At = DateTime.Now.AddDays(4), Completed_On = DateTime.Now.AddDays(5), Driver_Id = 5 },
                new Order_Placement { Id = 48, Pick_Up_Address = "75 Red St", Delivery_Up_Address = "125 Gray St", Pick_Up_Contact = "Ethan", Delivery_Contact = "Olivia", Weight = 4.0m, Volume = 2.5m, Description = "Toys", Status = "Delivered", Price = 180.00m, Distance = "3 miles", Created_At = "2023-09-20", Scheduled_At = DateTime.Now.AddDays(5), Completed_On = DateTime.Now.AddDays(6), Driver_Id = 5 },

                // Orders for Driver 6
                new Order_Placement { Id = 49, Pick_Up_Address = "150 Black St", Delivery_Up_Address = "160 White St", Pick_Up_Contact = "Frank", Delivery_Contact = "Peter", Weight = 2.0m, Volume = 1.0m, Description = "Groceries", Status = "Delivered", Price = 100.00m, Distance = "4 miles", Created_At = "2023-09-21", Scheduled_At = DateTime.Now.AddDays(1), Completed_On = DateTime.Now.AddDays(2), Driver_Id = 6 },
                new Order_Placement { Id = 50, Pick_Up_Address = "150 Black St", Delivery_Up_Address = "170 Yellow St", Pick_Up_Contact = "Frank", Delivery_Contact = "Kyle", Weight = 3.0m, Volume = 1.5m, Description = "Clothes", Status = "In Transit", Price = 200.00m, Distance = "5 miles", Created_At = "2023-09-22", Scheduled_At = DateTime.Now.AddDays(2), Completed_On = DateTime.Now.AddDays(3), Driver_Id = 6 },
                new Order_Placement { Id = 51, Pick_Up_Address = "150 Black St", Delivery_Up_Address = "180 Green St", Pick_Up_Contact = "Frank", Delivery_Contact = "Laura", Weight = 4.0m, Volume = 2.0m, Description = "Electronics", Status = "Pending", Price = 300.00m, Distance = "7 miles", Created_At = "2023-09-23", Scheduled_At = DateTime.Now.AddDays(3), Completed_On = DateTime.Now.AddDays(4), Driver_Id = 6 },
                new Order_Placement { Id = 52, Pick_Up_Address = "150 Black St", Delivery_Up_Address = "190 Blue St", Pick_Up_Contact = "Frank", Delivery_Contact = "Nancy", Weight = 1.5m, Volume = 0.5m, Description = "Books", Status = "Cancelled", Price = 50.00m, Distance = "2 miles", Created_At = "2023-09-24", Scheduled_At = DateTime.Now.AddDays(4), Completed_On = DateTime.Now.AddDays(5), Driver_Id = 6 },
                new Order_Placement { Id = 53, Pick_Up_Address = "150 Black St", Delivery_Up_Address = "200 Red St", Pick_Up_Contact = "Frank", Delivery_Contact = "Olivia", Weight = 3.5m, Volume = 1.5m, Description = "Home Supplies", Status = "Delivered", Price = 150.00m, Distance = "3 miles", Created_At = "2023-09-25", Scheduled_At = DateTime.Now.AddDays(5), Completed_On = DateTime.Now.AddDays(6), Driver_Id = 6 }
            );
        }
    }
}
