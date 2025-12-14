using Backend.AdditionalClasses;
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
                new OrderDimension { Id = 1, Length = 35.00m, Width = 25.00m, Height = 2.50m, OrderItemsId = 1 },    // Laptop
                new OrderDimension { Id = 2, Length = 10.00m, Width = 6.00m, Height = 3.50m, OrderItemsId = 2},      // Mouse
                new OrderDimension { Id = 3, Length = 45.00m, Width = 15.00m, Height = 4.00m , OrderItemsId = 3 },     // Keyboard

                // Furniture
                new OrderDimension { Id = 4, Length = 120.00m, Width = 60.00m, Height = 75.00m , OrderItemsId = 4 },   // Desk
                new OrderDimension { Id = 5, Length = 65.00m, Width = 65.00m, Height = 90.00m , OrderItemsId = 5 },    // Chair
                new OrderDimension { Id = 8, Length = 200.00m, Width = 90.00m, Height = 85.00m , OrderItemsId = 8 },   // Couch
                new OrderDimension { Id = 9, Length = 120.00m, Width = 60.00m, Height = 45.00m , OrderItemsId = 9 },   // Coffee Table
                new OrderDimension { Id = 22, Length = 200.00m, Width = 150.00m, Height = 0.50m , OrderItemsId = 22 },   // Blanket
                new OrderDimension { Id = 23, Length = 50.00m, Width = 50.00m, Height = 15.00m , OrderItemsId = 23 },    // Pillow
                new OrderDimension { Id = 24, Length = 240.00m, Width = 160.00m, Height = 0.50m , OrderItemsId = 24 },   // Rug

                // More Electronics
                new OrderDimension { Id = 6, Length = 15.00m, Width = 7.50m, Height = 0.80m , OrderItemsId = 6 },       // Phone
                new OrderDimension { Id = 7, Length = 10.00m, Width = 5.00m, Height = 2.50m , OrderItemsId = 7 },      // Charger
                new OrderDimension { Id = 16, Length = 20.00m, Width = 18.00m, Height = 8.00m , OrderItemsId = 16 },    // Headphones
                new OrderDimension { Id = 17, Length = 20.00m, Width = 8.00m, Height = 8.00m , OrderItemsId = 17 },      // Bluetooth Speaker
                new OrderDimension { Id = 20, Length = 12.00m, Width = 9.00m, Height = 8.00m , OrderItemsId = 20 },      // Camera
                new OrderDimension { Id = 21, Length = 35.00m, Width = 35.00m, Height = 150.00m , OrderItemsId = 21 },  // Tripod

                // Clothing
                new OrderDimension { Id = 10, Length = 30.00m, Width = 25.00m, Height = 2.00m , OrderItemsId = 10 },    // T-Shirt (per item)
                new OrderDimension { Id = 11, Length = 40.00m, Width = 20.00m, Height = 5.00m , OrderItemsId = 11 },    // Jeans (per item)

                // Food
                new OrderDimension { Id = 12, Length = 30.00m, Width = 30.00m, Height = 25.00m , OrderItemsId = 12 },   // Fruits Basket
                new OrderDimension { Id = 13, Length = 30.00m, Width = 30.00m, Height = 25.00m , OrderItemsId = 13 },   // Vegetable Basket

                // Kitchen
                new OrderDimension { Id = 14, Length = 25.00m, Width = 20.00m, Height = 4.00m , OrderItemsId = 14 },    // Cookbook
                new OrderDimension { Id = 15, Length = 15.00m, Width = 10.00m, Height = 8.00m , OrderItemsId = 15 },     // Spices Set

                // Travel/Outdoor
                new OrderDimension { Id = 18, Length = 45.00m, Width = 30.00m, Height = 15.00m , OrderItemsId = 18 },    // Backpack
                new OrderDimension { Id = 19, Length = 25.00m, Width = 7.50m, Height = 7.50m , OrderItemsId = 19 }        // Water Bottle
            );
        }
    }
}