using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class OrderItemsData : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.HasData
            (
                new OrderItems { Id = 1, ItemName = "Laptop", WeightPerItem = 50.00m,Quantity = 1,SpecialInstructions = "Handle with care", OrderPlacementId = 1 },
                new OrderItems { Id = 2, ItemName = "Mouse", Quantity = 2, WeightPerItem = 50.00m, SpecialInstructions = "Wireless", OrderPlacementId = 2 },
                new OrderItems { Id = 3, ItemName = "Keyboard", Quantity = 1, WeightPerItem = 50.00m, SpecialInstructions = "Mechanical", OrderPlacementId = 3 },

               
                new OrderItems { Id = 4, ItemName = "Desk", Quantity = 1, WeightPerItem = 50.00m, SpecialInstructions = "Assembly required", OrderPlacementId = 4 },
               
                new OrderItems { Id = 5, ItemName = "Chair", Quantity = 1, WeightPerItem = 50.00m, SpecialInstructions = "Comfortable", OrderPlacementId = 5 },

 
                new OrderItems { Id = 6, ItemName = "Phone", WeightPerItem = 60.00m, Quantity = 1, SpecialInstructions = "New model", OrderPlacementId = 6 },
                new OrderItems { Id = 7, ItemName = "Charger", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Fast charging", OrderPlacementId = 7 },

                new OrderItems { Id = 8, ItemName = "Couch", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Delivery on ground floor only", OrderPlacementId = 8 },
                new OrderItems { Id = 9, ItemName = "Coffee Table", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Glass top", OrderPlacementId = 9 },

                new OrderItems { Id = 10, ItemName = "T-Shirt", Quantity = 5, WeightPerItem = 60.00m, SpecialInstructions = "Various colors", OrderPlacementId = 10 },
                new OrderItems { Id = 11, ItemName = "Jeans", Quantity = 2, WeightPerItem = 60.00m, SpecialInstructions = "Brand: XYZ", OrderPlacementId = 11 },

                new OrderItems { Id = 12, ItemName = "Fruits Basket", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Seasonal fruits", OrderPlacementId = 12 },
                new OrderItems { Id = 13, ItemName = "Vegetable Basket", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Organic", OrderPlacementId = 13 },

                new OrderItems { Id = 14, ItemName = "Cookbook", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Best seller", OrderPlacementId = 14 },
                new OrderItems { Id = 15, ItemName = "Spices Set", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Variety pack", OrderPlacementId = 15 },

                new OrderItems { Id = 16, ItemName = "Headphones", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Noise cancelling", OrderPlacementId = 16 },
                new OrderItems { Id = 17, ItemName = "Bluetooth Speaker", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Waterproof", OrderPlacementId = 17 },

                new OrderItems { Id = 18, ItemName = "Backpack", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "For travel", OrderPlacementId = 18 },
                new OrderItems { Id = 19, ItemName = "Water Bottle", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Insulated", OrderPlacementId = 19 },

                new OrderItems { Id = 20, ItemName = "Camera", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Includes accessories", OrderPlacementId = 20 },
                new OrderItems { Id = 21, ItemName = "Tripod", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Adjustable height", OrderPlacementId = 21 },

                new OrderItems { Id = 22, ItemName = "Blanket", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Soft and warm", OrderPlacementId = 22 },
                new OrderItems { Id = 23, ItemName = "Pillow", Quantity = 2, WeightPerItem = 60.00m, SpecialInstructions = "Memory foam", OrderPlacementId = 23 },

                new OrderItems { Id = 24, ItemName = "Rug", Quantity = 1, WeightPerItem = 60.00m, SpecialInstructions = "Non-slip", OrderPlacementId = 24 }
            );
        }
    }
}