using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class OrderPlacmentData : IEntityTypeConfiguration<OrderPlacement>
    {
        public void Configure(EntityTypeBuilder<OrderPlacement> builder)
        {
            builder.HasData
            (
                // Orders for Customer 1
                new OrderPlacement { Id = 1, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "456 Elm St", Pick_Up_Contact = "John Doe", Delivery_Contact = "Jane Smith", Weight = 5.5m, Volume = 2.0m, Description = "Electronics", Status = "Delivered", Price = 300.00m, Distance = "10 miles", Created_At = "2023-09-01", Scheduled_At = new DateTime(2023, 9, 2), Completed_On = new DateTime(2023, 9, 3), CustomerId = 1 },
                new OrderPlacement { Id = 2, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "789 Oak St", Pick_Up_Contact = "John Doe", Delivery_Contact = "Alice Brown", Weight = 3.0m, Volume = 1.5m, Description = "Computers", Status = "In Transit", Price = 500.00m, Distance = "15 miles", Created_At = "2023-09-02", Scheduled_At = new DateTime(2023, 9, 4), Completed_On = new DateTime(2023, 9, 5), CustomerId = 1 },
                new OrderPlacement { Id = 3, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "101 Pine St", Pick_Up_Contact = "John Doe", Delivery_Contact = "Bob White", Weight = 2.5m, Volume = 1.0m, Description = "Accessories", Status = "Pending", Price = 150.00m, Distance = "8 miles", Created_At = "2023-09-03", Scheduled_At = new DateTime(2023, 9, 6), Completed_On = new DateTime(2023, 9, 7), CustomerId = 1 },
                new OrderPlacement { Id = 4, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "202 Maple St", Pick_Up_Contact = "John Doe", Delivery_Contact = "Lucy Green", Weight = 4.0m, Volume = 2.5m, Description = "Furniture", Status = "Cancelled", Price = 600.00m, Distance = "12 miles", Created_At = "2023-09-04", Scheduled_At = new DateTime(2023, 9, 7), Completed_On = new DateTime(2023, 9, 8), CustomerId = 1 },

                // Orders for Customer 2
                new OrderPlacement { Id = 5, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "30 Center St", Pick_Up_Contact = "Alice Green", Delivery_Contact = "Tom Brown", Weight = 6.0m, Volume = 3.0m, Description = "Fresh Produce", Status = "Delivered", Price = 200.00m, Distance = "5 miles", Created_At = "2023-09-01", Scheduled_At = new DateTime(2023, 9, 2), Completed_On = new DateTime(2023, 9, 3), CustomerId = 2 },
                new OrderPlacement { Id = 6, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "35 Park Ave", Pick_Up_Contact = "Alice Green", Delivery_Contact = "Sarah White", Weight = 8.0m, Volume = 4.0m, Description = "Dairy Products", Status = "In Transit", Price = 300.00m, Distance = "10 miles", Created_At = "2023-09-02", Scheduled_At = new DateTime(2023, 9, 4), Completed_On = new DateTime(2023, 9, 5), CustomerId = 2 },
                new OrderPlacement { Id = 7, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "40 Broadway", Pick_Up_Contact = "Alice Green", Delivery_Contact = "Daniel Black", Weight = 4.5m, Volume = 2.0m, Description = "Packaged Goods", Status = "Pending", Price = 250.00m, Distance = "7 miles", Created_At = "2023-09-03", Scheduled_At = new DateTime(2023, 9, 6), Completed_On = new DateTime(2023, 9, 7), CustomerId = 2 },
                new OrderPlacement { Id = 8, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "45 Fifth St", Pick_Up_Contact = "Alice Green", Delivery_Contact = "Emma Red", Weight = 5.0m, Volume = 2.5m, Description = "Beverages", Status = "Cancelled", Price = 400.00m, Distance = "15 miles", Created_At = "2023-09-04", Scheduled_At = new DateTime(2023, 9, 7), Completed_On = new DateTime(2023, 9, 8), CustomerId = 2 },

                // Orders for Customer 3
                new OrderPlacement { Id = 9, Pick_Up_Address = "45 Fast Food Rd", Delivery_Up_Address = "50 Snack Ave", Pick_Up_Contact = "Alice Johnson", Delivery_Contact = "Jim Doe", Weight = 2.0m, Volume = 1.0m, Description = "Fast Food Order", Status = "Delivered", Price = 50.00m, Distance = "3 miles", Created_At = "2023-09-01", Scheduled_At = new DateTime(2023, 9, 2), Completed_On = new DateTime(2023, 9, 3), CustomerId = 3 },
                new OrderPlacement { Id = 10, Pick_Up_Address = "45 Fast Food Rd", Delivery_Up_Address = "55 Snack Ave", Pick_Up_Contact = "Alice Johnson", Delivery_Contact = "Kate Brown", Weight = 1.5m, Volume = 0.5m, Description = "Burger Order", Status = "In Transit", Price = 30.00m, Distance = "2 miles", Created_At = "2023-09-02", Scheduled_At = new DateTime(2023, 9, 4), Completed_On = new DateTime(2023, 9, 5), CustomerId = 3 },
                new OrderPlacement { Id = 11, Pick_Up_Address = "45 Fast Food Rd", Delivery_Up_Address = "60 Snack Ave", Pick_Up_Contact = "Alice Johnson", Delivery_Contact = "Ben White", Weight = 2.5m, Volume = 1.0m, Description = "Pizza Order", Status = "Pending", Price = 40.00m, Distance = "1.5 miles", Created_At = "2023-09-03", Scheduled_At = new DateTime(2023, 9, 6), Completed_On = new DateTime(2023, 9, 7), CustomerId = 3 },
                new OrderPlacement { Id = 12, Pick_Up_Address = "45 Fast Food Rd", Delivery_Up_Address = "65 Snack Ave", Pick_Up_Contact = "Alice Johnson", Delivery_Contact = "Beth Green", Weight = 3.0m, Volume = 1.5m, Description = "Dessert Order", Status = "Cancelled", Price = 20.00m, Distance = "2 miles", Created_At = "2023-09-04", Scheduled_At = new DateTime(2023, 9, 7), Completed_On = new DateTime(2023, 9, 8), CustomerId = 3 },

                // Orders for Customer 4
                new OrderPlacement { Id = 13, Pick_Up_Address = "100 Book St", Delivery_Up_Address = "110 Library Lane", Pick_Up_Contact = "John Smith", Delivery_Contact = "Alice Johnson", Weight = 1.0m, Volume = 0.5m, Description = "Books", Status = "Delivered", Price = 25.00m, Distance = "1 mile", Created_At = "2023-09-01", Scheduled_At = new DateTime(2023, 9, 2), Completed_On = new DateTime(2023, 9, 3), CustomerId = 4 },
                new OrderPlacement { Id = 14, Pick_Up_Address = "100 Book St", Delivery_Up_Address = "120 Library Lane", Pick_Up_Contact = "John Smith", Delivery_Contact = "Bob White", Weight = 1.5m, Volume = 0.75m, Description = "Textbooks", Status = "In Transit", Price = 45.00m, Distance = "2 miles", Created_At = "2023-09-02", Scheduled_At = new DateTime(2023, 9, 4), Completed_On = new DateTime(2023, 9, 5), CustomerId = 4 },
                new OrderPlacement { Id = 15, Pick_Up_Address = "100 Book St", Delivery_Up_Address = "130 Library Lane", Pick_Up_Contact = "John Smith", Delivery_Contact = "Charlie Black", Weight = 2.0m, Volume = 1.0m, Description = "Novels", Status = "Pending", Price = 50.00m, Distance = "3 miles", Created_At = "2023-09-03", Scheduled_At = new DateTime(2023, 9, 6), Completed_On = new DateTime(2023, 9, 7), CustomerId = 4 },
                new OrderPlacement { Id = 16, Pick_Up_Address = "100 Book St", Delivery_Up_Address = "140 Library Lane", Pick_Up_Contact = "John Smith", Delivery_Contact = "David Green", Weight = 2.5m, Volume = 1.25m, Description = "Magazines", Status = "Cancelled", Price = 30.00m, Distance = "4 miles", Created_At = "2023-09-04", Scheduled_At = new DateTime(2023, 9, 7), Completed_On = new DateTime(2023, 9, 8), CustomerId = 4 },

                // Orders for Customer 5
                new OrderPlacement { Id = 17, Pick_Up_Address = "150 Home St", Delivery_Up_Address = "160 Home Lane", Pick_Up_Contact = "Emily White", Delivery_Contact = "James Black", Weight = 3.5m, Volume = 2.0m, Description = "Home Goods", Status = "Delivered", Price = 200.00m, Distance = "5 miles", Created_At = "2023-09-01", Scheduled_At = new DateTime(2023, 9, 2), Completed_On = new DateTime(2023, 9, 3), CustomerId = 5 },
                new OrderPlacement { Id = 18, Pick_Up_Address = "150 Home St", Delivery_Up_Address = "170 Home Lane", Pick_Up_Contact = "Emily White", Delivery_Contact = "Sarah Green", Weight = 4.0m, Volume = 2.5m, Description = "Furniture", Status = "In Transit", Price = 800.00m, Distance = "10 miles", Created_At = "2023-09-02", Scheduled_At = new DateTime(2023, 9, 4), Completed_On = new DateTime(2023, 9, 5), CustomerId = 5 },
                new OrderPlacement { Id = 19, Pick_Up_Address = "150 Home St", Delivery_Up_Address = "180 Home Lane", Pick_Up_Contact = "Emily White", Delivery_Contact = "Paul Red", Weight = 2.0m, Volume = 1.0m, Description = "Kitchenware", Status = "Pending", Price = 150.00m, Distance = "3 miles", Created_At = "2023-09-03", Scheduled_At = new DateTime(2023, 9, 6), Completed_On = new DateTime(2023, 9, 7), CustomerId = 5 },
                new OrderPlacement { Id = 20, Pick_Up_Address = "150 Home St", Delivery_Up_Address = "190 Home Lane", Pick_Up_Contact = "Emily White", Delivery_Contact = "Jessica Blue", Weight = 1.5m, Volume = 0.5m, Description = "Decorations", Status = "Cancelled", Price = 100.00m, Distance = "2 miles", Created_At = "2023-09-04", Scheduled_At = new DateTime(2023, 9, 7), Completed_On = new DateTime(2023, 9, 8), CustomerId = 5 },

                // Orders for Customer 6
                new OrderPlacement { Id = 21, Pick_Up_Address = "200 Fitness St", Delivery_Up_Address = "210 Gym Lane", Pick_Up_Contact = "Mike Brown", Delivery_Contact = "Anna Green", Weight = 5.0m, Volume = 3.0m, Description = "Gym Equipment", Status = "Delivered", Price = 500.00m, Distance = "6 miles", Created_At = "2023-09-01", Scheduled_At = new DateTime(2023, 9, 2), Completed_On = new DateTime(2023, 9, 3), CustomerId = 6 },
                new OrderPlacement { Id = 22, Pick_Up_Address = "200 Fitness St", Delivery_Up_Address = "220 Gym Lane", Pick_Up_Contact = "Mike Brown", Delivery_Contact = "Laura Black", Weight = 2.5m, Volume = 1.5m, Description = "Fitness Apparel", Status = "In Transit", Price = 150.00m, Distance = "3 miles", Created_At = "2023-09-02", Scheduled_At = new DateTime(2023, 9, 4), Completed_On = new DateTime(2023, 9, 5), CustomerId = 6 },
                new OrderPlacement { Id = 23, Pick_Up_Address = "200 Fitness St", Delivery_Up_Address = "230 Gym Lane", Pick_Up_Contact = "Mike Brown", Delivery_Contact = "Cathy White", Weight = 3.0m, Volume = 2.0m, Description = "Health Supplements", Status = "Pending", Price = 300.00m, Distance = "5 miles", Created_At = "2023-09-03", Scheduled_At = new DateTime(2023, 9, 6), Completed_On = new DateTime(2023, 9, 7), CustomerId = 6 },
                new OrderPlacement { Id = 24, Pick_Up_Address = "200 Fitness St", Delivery_Up_Address = "240 Gym Lane", Pick_Up_Contact = "Mike Brown", Delivery_Contact = "Sarah Blue", Weight = 4.0m, Volume = 2.5m, Description = "Yoga Mats", Status = "Cancelled", Price = 100.00m, Distance = "4 miles", Created_At = "2023-09-04", Scheduled_At = new DateTime(2023, 9, 7), Completed_On = new DateTime(2023, 9, 8), CustomerId = 6 },
          

                   // Orders for Driver 1
                   new OrderPlacement { Id = 25, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "456 Elm St", Pick_Up_Contact = "Alice", Delivery_Contact = "Bob", Weight = 5.5m, Volume = 2.0m, Description = "Electronics", Status = "Delivered", Price = 300.00m, Distance = "10 miles", Created_At = "2023-09-01", Scheduled_At = new DateTime(2023, 9, 2), Completed_On = new DateTime(2023, 9, 3), DriverId = 1 },
                   new OrderPlacement { Id = 26, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "789 Oak St", Pick_Up_Contact = "Alice", Delivery_Contact = "Tom", Weight = 3.0m, Volume = 1.5m, Description = "Computers", Status = "In Transit", Price = 500.00m, Distance = "15 miles", Created_At = "2023-09-02", Scheduled_At = new DateTime(2023, 9, 4), Completed_On = new DateTime(2023, 9, 5), DriverId = 1 },
                   new OrderPlacement { Id = 27, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "101 Pine St", Pick_Up_Contact = "Alice", Delivery_Contact = "Sarah", Weight = 2.5m, Volume = 1.0m, Description = "Accessories", Status = "Pending", Price = 150.00m, Distance = "8 miles", Created_At = "2023-09-03", Scheduled_At = new DateTime(2023, 9, 6), Completed_On = new DateTime(2023, 9, 7), DriverId = 1 },
                   new OrderPlacement { Id = 28, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "202 Maple St", Pick_Up_Contact = "Alice", Delivery_Contact = "Emma", Weight = 4.0m, Volume = 2.5m, Description = "Furniture", Status = "Cancelled", Price = 600.00m, Distance = "12 miles", Created_At = "2023-09-04", Scheduled_At = new DateTime(2023, 9, 7), Completed_On = new DateTime(2023, 9, 8), DriverId = 1 },
                   new OrderPlacement { Id = 29, Pick_Up_Address = "123 Main St", Delivery_Up_Address = "303 Cedar St", Pick_Up_Contact = "Alice", Delivery_Contact = "Luke", Weight = 1.0m, Volume = 0.5m, Description = "Books", Status = "Delivered", Price = 50.00m, Distance = "3 miles", Created_At = "2023-09-05", Scheduled_At = new DateTime(2023, 9, 8), Completed_On = new DateTime(2023, 9, 9), DriverId = 1 },

                   // Orders for Driver 2
                   new OrderPlacement { Id = 30, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "30 Center St", Pick_Up_Contact = "Bob", Delivery_Contact = "Alice", Weight = 6.0m, Volume = 3.0m, Description = "Fresh Produce", Status = "Delivered", Price = 200.00m, Distance = "5 miles", Created_At = "2023-09-01", Scheduled_At = new DateTime(2023, 9, 2), Completed_On = new DateTime(2023, 9, 3), DriverId = 2 },
                   new OrderPlacement { Id = 31, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "35 Park Ave", Pick_Up_Contact = "Bob", Delivery_Contact = "Sara", Weight = 8.0m, Volume = 4.0m, Description = "Dairy Products", Status = "In Transit", Price = 300.00m, Distance = "10 miles", Created_At = "2023-09-02", Scheduled_At = new DateTime(2023, 9, 4), Completed_On = new DateTime(2023, 9, 5), DriverId = 2 },
                   new OrderPlacement { Id = 32, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "40 Broadway", Pick_Up_Contact = "Bob", Delivery_Contact = "Daniel", Weight = 4.5m, Volume = 2.0m, Description = "Packaged Goods", Status = "Pending", Price = 250.00m, Distance = "7 miles", Created_At = "2023-09-03", Scheduled_At = new DateTime(2023, 9, 5), Completed_On = new DateTime(2023, 9, 6), DriverId = 2 },
                   new OrderPlacement { Id = 33, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "45 Fifth St", Pick_Up_Contact = "Bob", Delivery_Contact = "Emma", Weight = 5.0m, Volume = 2.5m, Description = "Beverages", Status = "Cancelled", Price = 400.00m, Distance = "15 miles", Created_At = "2023-09-04", Scheduled_At = new DateTime(2023, 9, 6), Completed_On = new DateTime(2023, 9, 7), DriverId = 2 },
                   new OrderPlacement { Id = 34, Pick_Up_Address = "25 Market St", Delivery_Up_Address = "50 Main St", Pick_Up_Contact = "Bob", Delivery_Contact = "Chris", Weight = 3.0m, Volume = 1.5m, Description = "Snacks", Status = "Delivered", Price = 100.00m, Distance = "2 miles", Created_At = "2023-09-05", Scheduled_At = new DateTime(2023, 9, 7), Completed_On = new DateTime(2023, 9, 8), DriverId = 2 },

                   // Orders for Driver 3
                   new OrderPlacement { Id = 35, Pick_Up_Address = "400 River Rd", Delivery_Up_Address = "450 Lake St", Pick_Up_Contact = "Charlie", Delivery_Contact = "Diana", Weight = 7.0m, Volume = 3.5m, Description = "Clothing", Status = "Delivered", Price = 350.00m, Distance = "12 miles", Created_At = "2023-09-06", Scheduled_At = new DateTime(2023, 9, 7), Completed_On = new DateTime(2023, 9, 8), DriverId = 3 },
                   new OrderPlacement { Id = 36, Pick_Up_Address = "400 River Rd", Delivery_Up_Address = "460 Ocean St", Pick_Up_Contact = "Charlie", Delivery_Contact = "Evan", Weight = 6.5m, Volume = 2.0m, Description = "Footwear", Status = "In Transit", Price = 200.00m, Distance = "14 miles", Created_At = "2023-09-07", Scheduled_At = new DateTime(2023, 9, 8), Completed_On = new DateTime(2023, 9, 9), DriverId = 3 },
                   new OrderPlacement { Id = 37, Pick_Up_Address = "400 River Rd", Delivery_Up_Address = "470 Sea St", Pick_Up_Contact = "Charlie", Delivery_Contact = "Fiona", Weight = 5.0m, Volume = 1.5m, Description = "Accessories", Status = "Pending", Price = 150.00m, Distance = "10 miles", Created_At = "2023-09-08", Scheduled_At = new DateTime(2023, 9, 9), Completed_On = new DateTime(2023, 9, 10), DriverId = 3 },
                   new OrderPlacement { Id = 38, Pick_Up_Address = "400 River Rd", Delivery_Up_Address = "480 Shore St", Pick_Up_Contact = "Charlie", Delivery_Contact = "Gina", Weight = 4.0m, Volume = 2.5m, Description = "Home Goods", Status = "Cancelled", Price = 300.00m, Distance = "8 miles", Created_At = "2023-09-09", Scheduled_At = new DateTime(2023, 9, 10), Completed_On = new DateTime(2023, 9, 11), DriverId = 3 },
                   new OrderPlacement { Id = 39, Pick_Up_Address = "400 River Rd", Delivery_Up_Address = "490 Hill St", Pick_Up_Contact = "Charlie", Delivery_Contact = "Hank", Weight = 3.5m, Volume = 1.0m, Description = "Stationery", Status = "Delivered", Price = 80.00m, Distance = "5 miles", Created_At = "2023-09-10", Scheduled_At = new DateTime(2023, 9, 11), Completed_On = new DateTime(2023, 9, 12), DriverId = 3 },

                   // Orders for Driver 4
                   new OrderPlacement { Id = 40, Pick_Up_Address = "50 Green St", Delivery_Up_Address = "60 Blue St", Pick_Up_Contact = "Diana", Delivery_Contact = "Ethan", Weight = 2.5m, Volume = 1.2m, Description = "Gadgets", Status = "Delivered", Price = 120.00m, Distance = "3 miles", Created_At = "2023-09-11", Scheduled_At = new DateTime(2023, 9, 12), Completed_On = new DateTime(2023, 9, 13), DriverId = 4 },
                   new OrderPlacement { Id = 41, Pick_Up_Address = "50 Green St", Delivery_Up_Address = "70 Yellow St", Pick_Up_Contact = "Diana", Delivery_Contact = "Frank", Weight = 3.0m, Volume = 1.5m, Description = "Electronics", Status = "In Transit", Price = 250.00m, Distance = "4 miles", Created_At = "2023-09-12", Scheduled_At = new DateTime(2023, 9, 13), Completed_On = new DateTime(2023, 9, 14), DriverId = 4 },
                   new OrderPlacement { Id = 42, Pick_Up_Address = "50 Green St", Delivery_Up_Address = "80 Pink St", Pick_Up_Contact = "Diana", Delivery_Contact = "Grace", Weight = 5.0m, Volume = 2.0m, Description = "Home Appliances", Status = "Pending", Price = 400.00m, Distance = "6 miles", Created_At = "2023-09-13", Scheduled_At = new DateTime(2023, 9, 14), Completed_On = new DateTime(2023, 9, 15), DriverId = 4 },
                   new OrderPlacement { Id = 43, Pick_Up_Address = "50 Green St", Delivery_Up_Address = "90 Gray St", Pick_Up_Contact = "Diana", Delivery_Contact = "Henry", Weight = 1.5m, Volume = 0.5m, Description = "Books", Status = "Cancelled", Price = 50.00m, Distance = "2 miles", Created_At = "2023-09-14", Scheduled_At = new DateTime(2023, 9, 15), Completed_On = new DateTime(2023, 9, 16), DriverId = 4 },
                   new OrderPlacement { Id = 44, Pick_Up_Address = "50 Green St", Delivery_Up_Address = "100 Black St", Pick_Up_Contact = "Diana", Delivery_Contact = "Ivy", Weight = 4.0m, Volume = 3.0m, Description = "Clothing", Status = "Delivered", Price = 320.00m, Distance = "7 miles", Created_At = "2023-09-15", Scheduled_At = new DateTime(2023, 9, 16), Completed_On = new DateTime(2023, 9, 17), DriverId = 4 },

                   // Orders for Driver 5
                   new OrderPlacement { Id = 45, Pick_Up_Address = "75 Red St", Delivery_Up_Address = "85 Orange St", Pick_Up_Contact = "Ethan", Delivery_Contact = "Jack", Weight = 6.0m, Volume = 3.0m, Description = "Furniture", Status = "Delivered", Price = 600.00m, Distance = "10 miles", Created_At = "2023-09-16", Scheduled_At = new DateTime(2023, 9, 17), Completed_On = new DateTime(2023, 9, 18), DriverId = 5 },
                   new OrderPlacement { Id = 46, Pick_Up_Address = "75 Red St", Delivery_Up_Address = "95 Violet St", Pick_Up_Contact = "Ethan", Delivery_Contact = "Liam", Weight = 2.5m, Volume = 1.0m, Description = "Kitchenware", Status = "In Transit", Price = 150.00m, Distance = "5 miles", Created_At = "2023-09-17", Scheduled_At = new DateTime(2023, 9, 18), Completed_On = new DateTime(2023, 9, 19), DriverId = 5 },
                   new OrderPlacement
                   {
                       Id = 47,
                       Pick_Up_Address = "75 Red St",
                       Delivery_Up_Address = "105 Indigo St",
                       Pick_Up_Contact = "Ethan",
                       Delivery_Contact = "Mia",
                       Weight = 3.5m,
                       Volume = 2.0m,
                       Description = "Decor",
                       Status = "Pending",
                       Price = 300.00m,
                       Distance = "6 miles",
                       Created_At = "2023-09-18",
                       Scheduled_At = new DateTime(2023, 9, 19),
                       Completed_On = new DateTime(2023, 9, 20),
                       DriverId = 5
                   },
                   new OrderPlacement
                   {
                       Id = 48,
                       Pick_Up_Address = "75 Red St",
                       Delivery_Up_Address = "115 Brown St",
                       Pick_Up_Contact = "Ethan",
                       Delivery_Contact = "Nora",
                       Weight = 1.0m,
                       Volume = 2.0m,
                       Description = "Toy",
                       Status = "Pending",
                       Price = 300.00m,
                       Distance = "6 miles",
                       Created_At = "2023-09-18",
                       Scheduled_At = new DateTime(2023, 9, 19),
                       Completed_On = new DateTime(2023, 9, 20),
                       DriverId = 5
                   },
                   // Orders for Driver 5
                   new OrderPlacement
                   {
                       Id = 49,
                       Pick_Up_Address = "75 Red St",
                       Delivery_Up_Address = "125 Gray St",
                       Pick_Up_Contact = "Ethan",
                       Delivery_Contact = "Olivia",
                       Weight = 4.0m,
                       Volume = 2.5m,
                       Description = "Toys",
                       Status = "Delivered",
                       Price = 180.00m,
                       Distance = "3 miles",
                       Created_At = "2023-09-20",
                       Scheduled_At = new DateTime(2023, 09, 25),
                       Completed_On = new DateTime(2023, 09, 26),
                       DriverId = 5
                   },

                   // Orders for Driver 6
                   new OrderPlacement
                   {
                       Id = 50,
                       Pick_Up_Address = "150 Black St",
                       Delivery_Up_Address = "160 White St",
                       Pick_Up_Contact = "Frank",
                       Delivery_Contact = "Peter",
                       Weight = 2.0m,
                       Volume = 1.0m,
                       Description = "Groceries",
                       Status = "Delivered",
                       Price = 100.00m,
                       Distance = "4 miles",
                       Created_At = "2023-09-21",
                       Scheduled_At = new DateTime(2023, 09, 22),
                       Completed_On = new DateTime(2023, 09, 23),
                       DriverId = 6
                   },
                   new OrderPlacement
                   {
                       Id = 51,
                       Pick_Up_Address = "150 Black St",
                       Delivery_Up_Address = "170 Yellow St",
                       Pick_Up_Contact = "Frank",
                       Delivery_Contact = "Kyle",
                       Weight = 3.0m,
                       Volume = 1.5m,
                       Description = "Clothes",
                       Status = "In Transit",
                       Price = 200.00m,
                       Distance = "5 miles",
                       Created_At = "2023-09-22",
                       Scheduled_At = new DateTime(2023, 09, 24),
                       Completed_On = new DateTime(2023, 09, 25),
                       DriverId = 6
                   },
                   new OrderPlacement
                   {
                       Id = 52,
                       Pick_Up_Address = "150 Black St",
                       Delivery_Up_Address = "180 Green St",
                       Pick_Up_Contact = "Frank",
                       Delivery_Contact = "Laura",
                       Weight = 4.0m,
                       Volume = 2.0m,
                       Description = "Electronics",
                       Status = "Pending",
                       Price = 300.00m,
                       Distance = "7 miles",
                       Created_At = "2023-09-23",
                       Scheduled_At = new DateTime(2023, 09, 26),
                       Completed_On = new DateTime(2023, 09, 27),
                       DriverId = 6
                   },
                   new OrderPlacement
                   {
                       Id = 53,
                       Pick_Up_Address = "150 Black St",
                       Delivery_Up_Address = "190 Blue St",
                       Pick_Up_Contact = "Frank",
                       Delivery_Contact = "Nancy",
                       Weight = 1.5m,
                       Volume = 0.5m,
                       Description = "Books",
                       Status = "Cancelled",
                       Price = 50.00m,
                       Distance = "2 miles",
                       Created_At = "2023-09-24",
                       Scheduled_At = new DateTime(2023, 09, 28),
                       Completed_On = new DateTime(2023, 09, 29),
                       DriverId = 6
                   }
               );
        }
    }
}
