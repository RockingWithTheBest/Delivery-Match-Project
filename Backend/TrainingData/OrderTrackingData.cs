using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class OrderTrackingData : IEntityTypeConfiguration<Order_Tracking>
    {
        public void Configure(EntityTypeBuilder<Order_Tracking> builder)
        {
            builder.HasData
 (
     new Order_Tracking { Id = 1, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up from warehouse", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), Order_PlacementId = 1 },
     new Order_Tracking { Id = 2, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered to customer", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), Order_PlacementId = 2 },

     new Order_Tracking { Id = 3, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 11, 0, 0), Order_PlacementId = 3 },
     new Order_Tracking { Id = 4, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Received by customer", TimeStamps = new DateTime(2023, 09, 15, 13, 0, 0), Order_PlacementId = 4 },

     new Order_Tracking { Id = 5, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting pickup", TimeStamps = new DateTime(2023, 09, 15, 10, 30, 0), Order_PlacementId = 5 },
     new Order_Tracking { Id = 6, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), Order_PlacementId = 6 },

     new Order_Tracking { Id = 7, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way to destination", TimeStamps = new DateTime(2023, 09, 15, 09, 0, 0), Order_PlacementId = 7 },
     new Order_Tracking { Id = 8, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = new DateTime(2023, 09, 15, 13, 30, 0), Order_PlacementId = 8 },

     new Order_Tracking { Id = 9, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = new DateTime(2023, 09, 15, 08, 0, 0), Order_PlacementId = 9 },
     new Order_Tracking { Id = 10, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On route to delivery", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), Order_PlacementId = 10 },

     new Order_Tracking { Id = 11, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), Order_PlacementId = 11 },
     new Order_Tracking { Id = 12, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), Order_PlacementId = 12 },

     new Order_Tracking { Id = 13, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 11, 0, 0), Order_PlacementId = 13 },
     new Order_Tracking { Id = 14, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered to customer", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), Order_PlacementId = 14 },

     new Order_Tracking { Id = 15, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 11, 30, 0), Order_PlacementId = 15 },
     new Order_Tracking { Id = 16, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Received by customer", TimeStamps = new DateTime(2023, 09, 15, 13, 0, 0), Order_PlacementId = 16 },

     new Order_Tracking { Id = 17, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting pickup", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), Order_PlacementId = 17 },
     new Order_Tracking { Id = 18, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), Order_PlacementId = 18 },

     new Order_Tracking { Id = 19, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way to destination", TimeStamps = new DateTime(2023, 09, 15, 09, 0, 0), Order_PlacementId = 19 },
     new Order_Tracking { Id = 20, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = new DateTime(2023, 09, 15, 13, 0, 0), Order_PlacementId = 20 },

     new Order_Tracking { Id = 21, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = new DateTime(2023, 09, 15, 08, 0, 0), Order_PlacementId = 21 },
     new Order_Tracking { Id = 22, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On route to delivery", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), Order_PlacementId = 22 },

     new Order_Tracking { Id = 23, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), Order_PlacementId = 23 },
     new Order_Tracking { Id = 24, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), Order_PlacementId = 24 },

     new Order_Tracking { Id = 25, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 11, 0, 0), Order_PlacementId = 25 },
     new Order_Tracking { Id = 26, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered to customer", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), Order_PlacementId = 26 },

     new Order_Tracking { Id = 27, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 11, 30, 0), Order_PlacementId = 27 },
     new Order_Tracking { Id = 28, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Received by customer", TimeStamps = new DateTime(2023, 09, 15, 13, 0, 0), Order_PlacementId = 28 },

     new Order_Tracking { Id = 29, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting pickup", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), Order_PlacementId = 29 },
     new Order_Tracking { Id = 30, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), Order_PlacementId = 30 },

     new Order_Tracking { Id = 31, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 09, 0, 0), Order_PlacementId = 31 },
     new Order_Tracking { Id = 32, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = new DateTime(2023, 09, 15, 13, 0, 0), Order_PlacementId = 32 },

     new Order_Tracking { Id = 33, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = new DateTime(2023, 09, 15, 08, 0, 0), Order_PlacementId = 33 },
     new Order_Tracking { Id = 34, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On route to delivery", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), Order_PlacementId = 34 },

     new Order_Tracking { Id = 35, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), Order_PlacementId = 35 },
     new Order_Tracking { Id = 36, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), Order_PlacementId = 36 },

     new Order_Tracking { Id = 37, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way to destination", TimeStamps = new DateTime(2023, 09, 15, 11, 0, 0), Order_PlacementId = 37 },
     new Order_Tracking { Id = 38, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), Order_PlacementId = 38 },

     new Order_Tracking { Id = 39, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = new DateTime(2023, 09, 15, 08, 0, 0), Order_PlacementId = 39 },
     new Order_Tracking { Id = 40, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On route to delivery", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), Order_PlacementId = 40 },

     new Order_Tracking { Id = 41, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), Order_PlacementId = 41 },
     new Order_Tracking { Id = 42, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), Order_PlacementId = 42 },

     new Order_Tracking { Id = 43, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 11, 0, 0), Order_PlacementId = 43 },
     new Order_Tracking { Id = 44, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Received by customer", TimeStamps = new DateTime(2023, 09, 15, 13, 0, 0), Order_PlacementId = 44 },

     new Order_Tracking { Id = 45, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting pickup", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), Order_PlacementId = 45 },
     new Order_Tracking { Id = 46, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), Order_PlacementId = 46 },

     new Order_Tracking { Id = 47, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 09, 0, 0), Order_PlacementId = 47 },
     new Order_Tracking { Id = 48, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = new DateTime(2023, 09, 15, 13, 0, 0), Order_PlacementId = 48 },

     new Order_Tracking { Id = 49, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = new DateTime(2023, 09, 15, 08, 0, 0), Order_PlacementId = 49 },
     new Order_Tracking { Id = 50, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On route to delivery", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), Order_PlacementId = 50 },

     new Order_Tracking { Id = 51, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), Order_PlacementId = 51 },
     new Order_Tracking { Id = 52, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), Order_PlacementId = 52 },

     new Order_Tracking { Id = 53, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way to destination", TimeStamps = new DateTime(2023, 09, 15, 11, 0, 0), Order_PlacementId = 53 }
 );
        }
    }
}
