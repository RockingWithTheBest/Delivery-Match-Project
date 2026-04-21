using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class OrderDimensionsData : IEntityTypeConfiguration<OrderDimension>
    {
        public void Configure(EntityTypeBuilder<OrderDimension> builder)
        {
            builder.HasData
            (
                // Electronics
                new OrderDimension { Id = 1, Length = 305.00m, Width = 250.00m, Height = 200.50m, OrderItemsId = 1 },    // Laptop
                new OrderDimension { Id = 2, Length = 100.00m, Width = 600.00m, Height = 563.50m, OrderItemsId = 2},      // Mouse
                new OrderDimension { Id = 3, Length = 405.00m, Width = 105.00m, Height = 400.00m , OrderItemsId = 3 },     // Keyboard

                // Furniture
                new OrderDimension { Id = 4, Length = 120.00m, Width = 160.00m, Height = 175.00m , OrderItemsId = 4 },   // Desk
                new OrderDimension { Id = 5, Length = 165.00m, Width = 165.00m, Height = 190.00m , OrderItemsId = 5 },    // Chair
                new OrderDimension { Id = 8, Length = 200.00m, Width = 190.00m, Height = 185.00m , OrderItemsId = 8 },   // Couch
                new OrderDimension { Id = 9, Length = 120.00m, Width = 260.00m, Height = 245.00m , OrderItemsId = 9 },   // Coffee Table
                new OrderDimension { Id = 22, Length = 200.00m, Width = 150.00m, Height = 220.50m , OrderItemsId = 22 },   // Blanket
                new OrderDimension { Id = 23, Length = 150.00m, Width = 150.00m, Height = 215.00m , OrderItemsId = 23 },    // Pillow
                new OrderDimension { Id = 24, Length = 240.00m, Width = 160.00m, Height = 200.50m , OrderItemsId = 24 },   // Rug

                // More Electronics
                new OrderDimension { Id = 6, Length = 215.00m, Width = 207.50m, Height = 210.80m , OrderItemsId = 6 },       // Phone
                new OrderDimension { Id = 7, Length = 110.00m, Width = 15.00m, Height = 202.50m , OrderItemsId = 7 },      // Charger
                new OrderDimension { Id = 16, Length = 220.00m, Width = 218.00m, Height = 108.00m , OrderItemsId = 16 },    // Headphones
                new OrderDimension { Id = 17, Length = 200.00m, Width = 208.00m, Height = 108.00m , OrderItemsId = 17 },      // Bluetooth Speaker
                new OrderDimension { Id = 20, Length = 120.00m, Width = 109.00m, Height = 208.00m , OrderItemsId = 20 },      // Camera
                new OrderDimension { Id = 21, Length = 235.00m, Width = 235.00m, Height = 150.00m , OrderItemsId = 21 },  // Tripod

                // Clothing
                new OrderDimension { Id = 10, Length = 130.00m, Width = 225.00m, Height = 232.00m , OrderItemsId = 10 },    // T-Shirt (per item)
                new OrderDimension { Id = 11, Length = 540.00m, Width = 120.00m, Height = 51.00m , OrderItemsId = 11 },    // Jeans (per item)

                // Food
                new OrderDimension { Id = 12, Length = 230.00m, Width = 130.00m, Height = 125.00m , OrderItemsId = 12 },   // Fruits Basket
                new OrderDimension { Id = 13, Length = 230.00m, Width = 130.00m, Height = 125.00m , OrderItemsId = 13 },   // Vegetable Basket

                // Kitchen
                new OrderDimension { Id = 14, Length = 225.00m, Width = 220.00m, Height = 24.00m , OrderItemsId = 14 },    // Cookbook
                new OrderDimension { Id = 15, Length = 105.00m, Width = 100.00m, Height = 208.00m , OrderItemsId = 15 },     // Spices Set

                // Travel/Outdoor
                new OrderDimension { Id = 18, Length = 145.00m, Width = 230.00m, Height = 215.00m , OrderItemsId = 18 },    // Backpack
                new OrderDimension { Id = 19, Length = 125.00m, Width = 107.50m, Height = 107.50m , OrderItemsId = 19 }        // Water Bottle
            );
        }
    }
}