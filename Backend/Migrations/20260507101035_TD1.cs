using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class TD1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "OrderPlacements",
                columns: new[] { "Id", "CompletedOn", "CreatedAt", "CustomerId", "DeliveryContact", "DeliveryUpAddress", "Description", "Distance", "DriverId", "PickUpAddress", "PickUpContact", "Price", "ScheduledAt", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Jane Smith", "Palace Square, 2, St. Petersburg, Russia, 191186", "Electronics", 0m, null, "Red Square, 1, Moscow, Russia, 101000", "John Doe", 300.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 2, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Alice Brown", "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "Computers", 0m, null, "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "John Doe", 500.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 3, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bob White", "Kuibysheva Street, 1, Samara, Russia, 443000", "Accessories", 0m, null, "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "John Doe", 150.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 4, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lucy Green", "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Furniture", 0m, null, "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "John Doe", 600.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 5, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Tom Brown", "Red Square, 1, Moscow, Russia, 101000", "Fresh Produce", 0m, null, "Palace Square, 2, St. Petersburg, Russia, 191186", "Alice Green", 200.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 6, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Sarah White", "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Dairy Products", 0m, null, "Kuibysheva Street, 1, Samara, Russia, 443000", "Alice Green", 300.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 7, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Daniel Black", "Red Square, 1, Moscow, Russia, 101000", "Packaged Goods", 0m, null, "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Alice Green", 250.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 8, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Emma Red", "Palace Square, 2, St. Petersburg, Russia, 191186", "Beverages", 0m, null, "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "Alice Green", 400.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 9, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Jim Doe", "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "Fast Food Order", 0m, null, "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Alice Johnson", 50.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 10, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Kate Brown", "Kuibysheva Street, 1, Samara, Russia, 443000", "Burger Order", 0m, null, "Palace Square, 2, St. Petersburg, Russia, 191186", "Alice Johnson", 30.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 11, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Ben White", "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Pizza Order", 0m, null, "Red Square, 1, Moscow, Russia, 101000", "Alice Johnson", 40.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 12, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Beth Green", "Red Square, 1, Moscow, Russia, 101000", "Dessert Order", 0m, null, "Kuibysheva Street, 1, Samara, Russia, 443000", "Alice Johnson", 20.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 13, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Alice Johnson", "Kuibysheva Street, 1, Samara, Russia, 443000", "Books", 0m, null, "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "John Smith", 25.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 14, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Bob White", "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Textbooks", 0m, null, "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "John Smith", 45.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 15, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Charlie Black", "Palace Square, 2, St. Petersburg, Russia, 191186", "Novels", 0m, null, "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "John Smith", 50.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 16, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "David Green", "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "Magazines", 0m, null, "Red Square, 1, Moscow, Russia, 101000", "John Smith", 30.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 17, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "James Black", "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Home Goods", 0m, null, "Palace Square, 2, St. Petersburg, Russia, 191186", "Emily White", 200.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 18, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Sarah Green", "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Furniture", 0m, null, "Kuibysheva Street, 1, Samara, Russia, 443000", "Emily White", 800.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 19, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Paul Red", "Palace Square, 2, St. Petersburg, Russia, 191186", "Kitchenware", 0m, null, "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Emily White", 150.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 20, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Jessica Blue", "Red Square, 1, Moscow, Russia, 101000", "Decorations", 0m, null, "Lenina Street, 1, Ufa, Republic of Bashkortostan, Russia, 450000", "Emily White", 100.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" },
                    { 21, new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Anna Green", "Kuibysheva Street, 1, Samara, Russia, 443000", "Gym Equipment", 0m, null, "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000t", "Mike Brown", 500.00m, new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Delivered" },
                    { 22, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Laura Black", "Red Square, 1, Moscow, Russia, 101000", "Fitness Apparel", 0m, null, "Palace Square, 2, St. Petersburg, Russia, 191186", "Mike Brown", 150.00m, new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "In Transit" },
                    { 23, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Cathy White", "Minin and Pozharsky Square, 1, Nizhny Novgorod, Russia, 603000", "Health Supplements", 0m, null, "Red Square, 1, Moscow, Russia, 101000", "Mike Brown", 300.00m, new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 24, new DateTime(2023, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Sarah Blue", "Bauman Street, 1, Kazan, Republic of Tatarstan, Russia, 420111", "Yoga Mats", 0m, null, "Kuibysheva Street, 1, Samara, Russia, 443000", "Mike Brown", 100.00m, new DateTime(2023, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "ItemName", "OrderPlacementId", "Quantity", "SpecialInstructions", "WeightPerItem" },
                values: new object[,]
                {
                    { 1, "Laptop", 1, 1, "Handle with care", 50.00m },
                    { 2, "Mouse", 2, 2, "Wireless", 50.00m },
                    { 3, "Keyboard", 3, 1, "Mechanical", 50.00m },
                    { 4, "Desk", 4, 1, "Assembly required", 50.00m },
                    { 5, "Chair", 5, 1, "Comfortable", 50.00m },
                    { 6, "Phone", 6, 1, "New model", 60.00m },
                    { 7, "Charger", 7, 1, "Fast charging", 60.00m },
                    { 8, "Couch", 8, 1, "Delivery on ground floor only", 60.00m },
                    { 9, "Coffee Table", 9, 1, "Glass top", 60.00m },
                    { 10, "T-Shirt", 10, 5, "Various colors", 60.00m },
                    { 11, "Jeans", 11, 2, "Brand: XYZ", 60.00m },
                    { 12, "Fruits Basket", 12, 1, "Seasonal fruits", 60.00m },
                    { 13, "Vegetable Basket", 13, 1, "Organic", 60.00m },
                    { 14, "Cookbook", 14, 1, "Best seller", 60.00m },
                    { 15, "Spices Set", 15, 1, "Variety pack", 60.00m },
                    { 16, "Headphones", 16, 1, "Noise cancelling", 60.00m },
                    { 17, "Bluetooth Speaker", 17, 1, "Waterproof", 60.00m },
                    { 18, "Backpack", 18, 1, "For travel", 60.00m },
                    { 19, "Water Bottle", 19, 1, "Insulated", 60.00m },
                    { 20, "Camera", 20, 1, "Includes accessories", 60.00m },
                    { 21, "Tripod", 21, 1, "Adjustable height", 60.00m },
                    { 22, "Blanket", 22, 1, "Soft and warm", 60.00m },
                    { 23, "Pillow", 23, 2, "Memory foam", 60.00m },
                    { 24, "Rug", 24, 1, "Non-slip", 60.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderTrackings",
                columns: new[] { "Id", "DeliveryLocation", "Notes", "OrderPlacementId", "PickUpLocation", "Status", "TimeStamps" },
                values: new object[,]
                {
                    { 1, "59.9343,30.3351", "Picked up from warehouse", 1, "55.7558,37.6173", "In Transit", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "54.7349,55.9579", "Delivered to customer", 2, "55.7961,49.1064", "Delivered", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "54.7261,55.9475", "On the way", 3, "56.3269,44.0075", "In Transit", new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "55.7961,49.1064", "Received by customer", 4, "54.7349,55.9579", "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "55.7558,37.6173", "Awaiting pickup", 5, "59.9343,30.3351", "Pending", new DateTime(2023, 9, 15, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "56.3269,44.0075", "Picked up", 6, "54.7261,55.9475", "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "55.7558,37.6173", "On the way to destination", 7, "55.7961,49.1064", "In Transit", new DateTime(2023, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "59.9343,30.3351", "Delivered successfully", 8, "54.7349,55.9579", "Delivered", new DateTime(2023, 9, 15, 13, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "54.7349,55.9579", "Waiting for dispatch", 9, "56.3269,44.0075", "In Warehouse", new DateTime(2023, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "54.7261,55.9475", "On route to delivery", 10, "59.9343,30.3351", "In Transit", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "55.7961,49.1064", "Awaiting confirmation", 11, "55.7558,37.6173", "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "55.7558,37.6173", "Picked up", 12, "54.7261,55.9475", "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "54.7261,55.9475", "On the way", 13, "55.7961,49.1064", "In Transit", new DateTime(2023, 9, 15, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "56.3269,44.0075", "Delivered to customer", 14, "54.7349,55.9579", "Delivered", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "59.9343,30.3351", "On the way", 15, "56.3269,44.0075", "In Transit", new DateTime(2023, 9, 15, 11, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "54.7349,55.9579", "Received by customer", 16, "55.7558,37.6173", "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "55.7961,49.1064", "Awaiting pickup", 17, "59.9343,30.3351", "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "56.3269,44.0075", "Picked up", 18, "54.7261,55.9475", "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "59.9343,30.3351", "On the way to destination", 19, "55.7961,49.1064", "In Transit", new DateTime(2023, 9, 15, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "55.7558,37.6173", "Delivered successfully", 20, "54.7349,55.9579", "Delivered", new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "54.7261,55.9475", "Waiting for dispatch", 21, "56.3269,44.0075", "In Warehouse", new DateTime(2023, 9, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "55.7558,37.6173", "On route to delivery", 22, "59.9343,30.3351", "In Transit", new DateTime(2023, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "56.3269,44.0075", "Awaiting confirmation", 23, "55.7558,37.6173", "Pending", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "55.7961,49.1064", "Picked up", 24, "54.7261,55.9475", "In Transit", new DateTime(2023, 9, 15, 12, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OrderDimension",
                columns: new[] { "Id", "Height", "Length", "OrderItemsId", "Width" },
                values: new object[,]
                {
                    { 1, 200.50m, 305.00m, 1, 250.00m },
                    { 2, 563.50m, 100.00m, 2, 600.00m },
                    { 3, 400.00m, 405.00m, 3, 105.00m },
                    { 4, 175.00m, 120.00m, 4, 160.00m },
                    { 5, 190.00m, 165.00m, 5, 165.00m },
                    { 6, 210.80m, 215.00m, 6, 207.50m },
                    { 7, 202.50m, 110.00m, 7, 15.00m },
                    { 8, 185.00m, 200.00m, 8, 190.00m },
                    { 9, 245.00m, 120.00m, 9, 260.00m },
                    { 10, 232.00m, 130.00m, 10, 225.00m },
                    { 11, 51.00m, 540.00m, 11, 120.00m },
                    { 12, 125.00m, 230.00m, 12, 130.00m },
                    { 13, 125.00m, 230.00m, 13, 130.00m },
                    { 14, 24.00m, 225.00m, 14, 220.00m },
                    { 15, 208.00m, 105.00m, 15, 100.00m },
                    { 16, 108.00m, 220.00m, 16, 218.00m },
                    { 17, 108.00m, 200.00m, 17, 208.00m },
                    { 18, 215.00m, 145.00m, 18, 230.00m },
                    { 19, 107.50m, 125.00m, 19, 107.50m },
                    { 20, 208.00m, 120.00m, 20, 109.00m },
                    { 21, 150.00m, 235.00m, 21, 235.00m },
                    { 22, 220.50m, 200.00m, 22, 150.00m },
                    { 23, 215.00m, 150.00m, 23, 150.00m },
                    { 24, 200.50m, 240.00m, 24, 160.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OrderDimension",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OrderTrackings",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OrderPlacements",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
