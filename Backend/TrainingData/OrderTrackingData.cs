using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.TrainingData
{
    public class OrderTrackingData : IEntityTypeConfiguration<OrderTracking>
    {
        public void Configure(EntityTypeBuilder<OrderTracking> builder)
        {
            builder.HasData
 (
     new OrderTracking { Id = 1, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up from warehouse", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), OrderPlacementId = 1 },
     new OrderTracking { Id = 2, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered to customer", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), OrderPlacementId = 2 },

     new OrderTracking { Id = 3, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 11, 0, 0), OrderPlacementId = 3 },
     new OrderTracking { Id = 4, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Received by customer", TimeStamps = new DateTime(2023, 09, 15, 13, 0, 0), OrderPlacementId = 4 },

     new OrderTracking { Id = 5, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting pickup", TimeStamps = new DateTime(2023, 09, 15, 10, 30, 0), OrderPlacementId = 5 },
     new OrderTracking { Id = 6, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), OrderPlacementId = 6 },

     new OrderTracking { Id = 7, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way to destination", TimeStamps = new DateTime(2023, 09, 15, 09, 0, 0), OrderPlacementId = 7 },
     new OrderTracking { Id = 8, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = new DateTime(2023, 09, 15, 13, 30, 0), OrderPlacementId = 8 },

     new OrderTracking { Id = 9, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = new DateTime(2023, 09, 15, 08, 0, 0), OrderPlacementId = 9 },
     new OrderTracking { Id = 10, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On route to delivery", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), OrderPlacementId = 10 },

     new OrderTracking { Id = 11, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), OrderPlacementId = 11 },
     new OrderTracking { Id = 12, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), OrderPlacementId = 12 },

     new OrderTracking { Id = 13, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 11, 0, 0), OrderPlacementId = 13 },
     new OrderTracking { Id = 14, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered to customer", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), OrderPlacementId = 14 },

     new OrderTracking { Id = 15, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 11, 30, 0), OrderPlacementId = 15 },
     new OrderTracking { Id = 16, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Received by customer", TimeStamps = new DateTime(2023, 09, 15, 13, 0, 0), OrderPlacementId = 16 },

     new OrderTracking { Id = 17, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting pickup", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), OrderPlacementId = 17 },
     new OrderTracking { Id = 18, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), OrderPlacementId = 18 },

     new OrderTracking { Id = 19, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way to destination", TimeStamps = new DateTime(2023, 09, 15, 09, 0, 0), OrderPlacementId = 19 },
     new OrderTracking { Id = 20, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = new DateTime(2023, 09, 15, 13, 0, 0), OrderPlacementId = 20 },

     new OrderTracking { Id = 21, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = new DateTime(2023, 09, 15, 08, 0, 0), OrderPlacementId = 21 },
     new OrderTracking { Id = 22, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On route to delivery", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), OrderPlacementId = 22 },

     new OrderTracking { Id = 23, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), OrderPlacementId = 23 },
     new OrderTracking { Id = 24, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), OrderPlacementId = 24 }
            );
        }
    }
}
