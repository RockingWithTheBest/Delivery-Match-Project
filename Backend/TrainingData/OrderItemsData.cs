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
                new Order_Items { Id = 1, Item_Name = "Laptop", Quantity = 1, Weight_Per_Item = 2.50m, Special_Instructions = "Handle with care", Order_PlacementId = 1 },
                new Order_Items { Id = 2, Item_Name = "Mouse", Quantity = 2, Weight_Per_Item = 0.10m, Special_Instructions = "Wireless", Order_PlacementId = 2},
                new Order_Items { Id = 3, Item_Name = "Keyboard", Quantity = 1, Weight_Per_Item = 0.75m, Special_Instructions = "Mechanical", Order_PlacementId = 3 },

              
                new Order_Items { Id = 4, Item_Name = "Desk", Quantity = 1, Weight_Per_Item = 15.00m, Special_Instructions = "Assembly required", Order_PlacementId = 4 },
                new Order_Items { Id = 5, Item_Name = "Chair", Quantity = 1, Weight_Per_Item = 5.00m, Special_Instructions = "Comfortable", Order_PlacementId = 5 },

                new Order_Items { Id = 6, Item_Name = "Phone", Quantity = 1, Weight_Per_Item = 0.20m, Special_Instructions = "New model", Order_PlacementId = 6 },
                new Order_Items { Id = 7, Item_Name = "Charger", Quantity = 1, Weight_Per_Item = 0.15m, Special_Instructions = "Fast charging", Order_PlacementId = 7 },

                new Order_Items { Id = 8, Item_Name = "Couch", Quantity = 1, Weight_Per_Item = 30.00m, Special_Instructions = "Delivery on ground floor only", Order_PlacementId = 8 },
                new Order_Items { Id = 9, Item_Name = "Coffee Table", Quantity = 1, Weight_Per_Item = 10.00m, Special_Instructions = "Glass top", Order_PlacementId = 9 },

                new Order_Items { Id = 10, Item_Name = "T-Shirt", Quantity = 5, Weight_Per_Item = 0.25m, Special_Instructions = "Various colors", Order_PlacementId = 10 },
                new Order_Items { Id = 11, Item_Name = "Jeans", Quantity = 2, Weight_Per_Item = 0.75m, Special_Instructions = "Brand: XYZ", Order_PlacementId = 11 },

                
                new Order_Items { Id = 12, Item_Name = "Fruits Basket", Quantity = 1, Weight_Per_Item = 3.00m, Special_Instructions = "Seasonal fruits", Order_PlacementId = 12 },
                new Order_Items { Id = 13, Item_Name = "Vegetable Basket", Quantity = 1, Weight_Per_Item = 3.00m, Special_Instructions = "Organic", Order_PlacementId = 13 },

             
                new Order_Items { Id = 14, Item_Name = "Cookbook", Quantity = 1, Weight_Per_Item = 1.00m, Special_Instructions = "Best seller", Order_PlacementId = 14 },
                new Order_Items { Id = 15, Item_Name = "Spices Set", Quantity = 1, Weight_Per_Item = 0.50m, Special_Instructions = "Variety pack", Order_PlacementId = 15 },

                new Order_Items { Id = 16, Item_Name = "Headphones", Quantity = 1, Weight_Per_Item = 0.30m, Special_Instructions = "Noise cancelling", Order_PlacementId = 16 },
                new Order_Items { Id = 17, Item_Name = "Bluetooth Speaker", Quantity = 1, Weight_Per_Item = 0.80m, Special_Instructions = "Waterproof", Order_PlacementId = 17 },

                new Order_Items { Id = 18, Item_Name = "Backpack", Quantity = 1, Weight_Per_Item = 0.50m, Special_Instructions = "For travel", Order_PlacementId = 18 },
                new Order_Items { Id = 19, Item_Name = "Water Bottle", Quantity = 1, Weight_Per_Item = 0.20m, Special_Instructions = "Insulated", Order_PlacementId = 19 },

        
                new Order_Items { Id = 20, Item_Name = "Camera", Quantity = 1, Weight_Per_Item = 1.50m, Special_Instructions = "Includes accessories", Order_PlacementId = 20 },
                new Order_Items { Id = 21, Item_Name = "Tripod", Quantity = 1, Weight_Per_Item = 1.00m, Special_Instructions = "Adjustable height", Order_PlacementId = 21 },

                new Order_Items { Id = 22, Item_Name = "Blanket", Quantity = 1, Weight_Per_Item = 1.00m, Special_Instructions = "Soft and warm", Order_PlacementId = 22 },
                new Order_Items { Id = 23, Item_Name = "Pillow", Quantity = 2, Weight_Per_Item = 0.50m, Special_Instructions = "Memory foam", Order_PlacementId = 23 },

  
                new Order_Items { Id = 24, Item_Name = "Rug", Quantity = 1, Weight_Per_Item = 5.00m, Special_Instructions = "Non-slip", Order_PlacementId = 24 },
                new Order_Items { Id = 25, Item_Name = "Curtains", Quantity = 2, Weight_Per_Item = 1.00m, Special_Instructions = "Blackout style", Order_PlacementId = 25 },

                new Order_Items { Id = 26, Item_Name = "Bedding Set", Quantity = 1, Weight_Per_Item = 2.00m, Special_Instructions = "King size", Order_PlacementId = 26 },
                new Order_Items { Id = 27, Item_Name = "Towels", Quantity = 4, Weight_Per_Item = 0.25m, Special_Instructions = "Soft and absorbent", Order_PlacementId = 27 },

                new Order_Items { Id = 28, Item_Name = "Pet Food", Quantity = 1, Weight_Per_Item = 10.00m, Special_Instructions = "For dogs", Order_PlacementId = 28 },
                new Order_Items { Id = 29, Item_Name = "Pet Toys", Quantity = 3, Weight_Per_Item = 0.50m, Special_Instructions = "Variety pack", Order_PlacementId = 29 },

 
                new Order_Items { Id = 30, Item_Name = "Garden Tools", Quantity = 5, Weight_Per_Item = 1.50m, Special_Instructions = "Assorted tools", Order_PlacementId = 30 },
                new Order_Items { Id = 31, Item_Name = "Plant Seeds", Quantity = 10, Weight_Per_Item = 0.05m, Special_Instructions = "Mixed vegetables", Order_PlacementId = 31 },

                new Order_Items { Id = 32, Item_Name = "Laptop Stand", Quantity = 1, Weight_Per_Item = 1.00m, Special_Instructions = "Adjustable height", Order_PlacementId = 32 },
                new Order_Items { Id = 33, Item_Name = "Mouse Pad", Quantity = 1, Weight_Per_Item = 0.20m, Special_Instructions = "Large size", Order_PlacementId = 33 },
                new Order_Items { Id = 34, Item_Name = "USB Hub", Quantity = 1, Weight_Per_Item = 0.30m, Special_Instructions = "4 ports", Order_PlacementId = 34 },
                new Order_Items { Id = 35, Item_Name = "Monitor", Quantity = 1, Weight_Per_Item = 5.00m, Special_Instructions = "27 inch", Order_PlacementId = 35 },
                new Order_Items { Id = 36, Item_Name = "HDMI Cable", Quantity = 1, Weight_Per_Item = 0.10m, Special_Instructions = "3 meters", Order_PlacementId = 36 },

                new Order_Items { Id = 37, Item_Name = "Wireless Router", Quantity = 1, Weight_Per_Item = 0.50m, Special_Instructions = "Dual band", Order_PlacementId = 37 },
                new Order_Items { Id = 38, Item_Name = "Wi-Fi Extender", Quantity = 1, Weight_Per_Item = 0.30m, Special_Instructions = "For large homes", Order_PlacementId = 38 },
                new Order_Items { Id = 39, Item_Name = "Surge Protector", Quantity = 1, Weight_Per_Item = 0.40m, Special_Instructions = "8 outlets", Order_PlacementId = 39 },
                new Order_Items { Id = 40, Item_Name = "Smartwatch", Quantity = 1, Weight_Per_Item = 0.20m, Special_Instructions = "Fitness tracking", Order_PlacementId = 40 },

                new Order_Items { Id = 41, Item_Name = "Fitness Tracker", Quantity = 1, Weight_Per_Item = 0.15m, Special_Instructions = "Water resistant", Order_PlacementId = 41 },
                new Order_Items { Id = 42, Item_Name = "Yoga Mat", Quantity = 1, Weight_Per_Item = 1.00m, Special_Instructions = "Non-slip", Order_PlacementId = 42 },
                new Order_Items { Id = 43, Item_Name = "Dumbbells", Quantity = 2, Weight_Per_Item = 2.00m, Special_Instructions = "Adjustable weight", Order_PlacementId = 43},

                new Order_Items { Id = 44, Item_Name = "Kettlebell", Quantity = 1, Weight_Per_Item = 5.00m, Special_Instructions = "For strength training", Order_PlacementId = 44 },
                new Order_Items { Id = 45, Item_Name = "Resistance Bands", Quantity = 1, Weight_Per_Item = 0.50m, Special_Instructions = "Set of 5", Order_PlacementId = 45 },
                new Order_Items { Id = 46, Item_Name = "Jump Rope", Quantity = 1, Weight_Per_Item = 0.25m, Special_Instructions = "Adjustable length", Order_PlacementId = 46 },

                new Order_Items { Id = 47, Item_Name = "Protein Powder", Quantity = 1, Weight_Per_Item = 1.00m, Special_Instructions = "Chocolate flavor", Order_PlacementId = 47 },
                new Order_Items { Id = 48, Item_Name = "Meal Prep Containers", Quantity = 1, Weight_Per_Item = 1.00m, Special_Instructions = "Set of 5", Order_PlacementId = 48 },
                new Order_Items { Id = 49, Item_Name = "Blender", Quantity = 1, Weight_Per_Item = 3.00m, Special_Instructions = "High speed", Order_PlacementId = 49 },

                new Order_Items { Id = 50, Item_Name = "Juicer", Quantity = 1, Weight_Per_Item = 2.50m, Special_Instructions = "For fruits and veggies", Order_PlacementId = 50 },
                new Order_Items { Id = 51, Item_Name = "Coffee Maker", Quantity = 1, Weight_Per_Item = 3.00m, Special_Instructions = "Auto shut off", Order_PlacementId = 51 },
                new Order_Items { Id = 52, Item_Name = "Tea Kettle", Quantity = 1, Weight_Per_Item = 1.00m, Special_Instructions = "Stainless steel", Order_PlacementId = 52 },

                new Order_Items { Id = 53, Item_Name = "Cookware Set", Quantity = 1, Weight_Per_Item = 5.00m, Special_Instructions = "Non-stick", Order_PlacementId = 53 }
            );
        }
    }
}
