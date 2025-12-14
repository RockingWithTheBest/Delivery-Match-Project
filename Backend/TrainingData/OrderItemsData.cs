using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class OrderItemsData : IEntityTypeConfiguration<Order_Items>
    {
        public void Configure(EntityTypeBuilder<Order_Items> builder)
        {
            builder.HasData
            (
                new Order_Items { Id = 1, Item_Name = "Laptop", Quantity = 1, Weight_Per_Item = 2.50m, Special_Instructions = "Handle with care", OrderPlacementId = 1 },
                new Order_Items { Id = 2, Item_Name = "Mouse", Quantity = 2, Weight_Per_Item = 0.10m, Special_Instructions = "Wireless", OrderPlacementId = 2 },
                new Order_Items { Id = 3, Item_Name = "Keyboard", Quantity = 1, Weight_Per_Item = 0.75m, Special_Instructions = "Mechanical", OrderPlacementId = 3 },

                new Order_Items { Id = 4, Item_Name = "Desk", Quantity = 1, Weight_Per_Item = 15.00m, Special_Instructions = "Assembly required", OrderPlacementId = 4 },
                new Order_Items { Id = 5, Item_Name = "Chair", Quantity = 1, Weight_Per_Item = 5.00m, Special_Instructions = "Comfortable", OrderPlacementId = 5 },

                new Order_Items { Id = 6, Item_Name = "Phone", Quantity = 1, Weight_Per_Item = 0.20m, Special_Instructions = "New model", OrderPlacementId = 6 },
                new Order_Items { Id = 7, Item_Name = "Charger", Quantity = 1, Weight_Per_Item = 0.15m, Special_Instructions = "Fast charging", OrderPlacementId = 7 },

                new Order_Items { Id = 8, Item_Name = "Couch", Quantity = 1, Weight_Per_Item = 30.00m, Special_Instructions = "Delivery on ground floor only", OrderPlacementId = 8 },
                new Order_Items { Id = 9, Item_Name = "Coffee Table", Quantity = 1, Weight_Per_Item = 10.00m, Special_Instructions = "Glass top", OrderPlacementId = 9 },

                new Order_Items { Id = 10, Item_Name = "T-Shirt", Quantity = 5, Weight_Per_Item = 0.25m, Special_Instructions = "Various colors", OrderPlacementId = 10 },
                new Order_Items { Id = 11, Item_Name = "Jeans", Quantity = 2, Weight_Per_Item = 0.75m, Special_Instructions = "Brand: XYZ", OrderPlacementId = 11 },

                new Order_Items { Id = 12, Item_Name = "Fruits Basket", Quantity = 1, Weight_Per_Item = 3.00m, Special_Instructions = "Seasonal fruits", OrderPlacementId = 12 },
                new Order_Items { Id = 13, Item_Name = "Vegetable Basket", Quantity = 1, Weight_Per_Item = 3.00m, Special_Instructions = "Organic", OrderPlacementId = 13 },

                new Order_Items { Id = 14, Item_Name = "Cookbook", Quantity = 1, Weight_Per_Item = 1.00m, Special_Instructions = "Best seller", OrderPlacementId = 14 },
                new Order_Items { Id = 15, Item_Name = "Spices Set", Quantity = 1, Weight_Per_Item = 0.50m, Special_Instructions = "Variety pack", OrderPlacementId = 15 },

                new Order_Items { Id = 16, Item_Name = "Headphones", Quantity = 1, Weight_Per_Item = 0.30m, Special_Instructions = "Noise cancelling", OrderPlacementId = 16 },
                new Order_Items { Id = 17, Item_Name = "Bluetooth Speaker", Quantity = 1, Weight_Per_Item = 0.80m, Special_Instructions = "Waterproof", OrderPlacementId = 17 },

                new Order_Items { Id = 18, Item_Name = "Backpack", Quantity = 1, Weight_Per_Item = 0.50m, Special_Instructions = "For travel", OrderPlacementId = 18 },
                new Order_Items { Id = 19, Item_Name = "Water Bottle", Quantity = 1, Weight_Per_Item = 0.20m, Special_Instructions = "Insulated", OrderPlacementId = 19 },

                new Order_Items { Id = 20, Item_Name = "Camera", Quantity = 1, Weight_Per_Item = 1.50m, Special_Instructions = "Includes accessories", OrderPlacementId = 20 },
                new Order_Items { Id = 21, Item_Name = "Tripod", Quantity = 1, Weight_Per_Item = 1.00m, Special_Instructions = "Adjustable height", OrderPlacementId = 21 },

                new Order_Items { Id = 22, Item_Name = "Blanket", Quantity = 1, Weight_Per_Item = 1.00m, Special_Instructions = "Soft and warm", OrderPlacementId = 22 },
                new Order_Items { Id = 23, Item_Name = "Pillow", Quantity = 2, Weight_Per_Item = 0.50m, Special_Instructions = "Memory foam", OrderPlacementId = 23 },

                new Order_Items { Id = 24, Item_Name = "Rug", Quantity = 1, Weight_Per_Item = 5.00m, Special_Instructions = "Non-slip", OrderPlacementId = 24 }
            );
        }
    }
}