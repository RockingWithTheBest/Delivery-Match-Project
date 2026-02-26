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
     new OrderTracking { Id = 1, PickUpLocation = "55.7558,37.6173", DeliveryLocation = "59.9343,30.3351", Status = "In Transit", Notes = "Picked up from warehouse", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), OrderPlacementId = 1 },
     new OrderTracking { Id = 2, PickUpLocation = "55.7961,49.1064", DeliveryLocation = "54.7349,55.9579", Status = "Delivered", Notes = "Delivered to customer", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), OrderPlacementId = 2 },

     new OrderTracking { Id = 3, PickUpLocation = "56.3269,44.0075", DeliveryLocation = "54.7261,55.9475", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 11, 0, 0), OrderPlacementId = 3 },
     new OrderTracking { Id = 4, PickUpLocation = "54.7349,55.9579", DeliveryLocation = "55.7961,49.1064", Status = "Delivered", Notes = "Received by customer", TimeStamps = new DateTime(2023, 09, 15, 13, 0, 0), OrderPlacementId = 4 },

     new OrderTracking { Id = 5, PickUpLocation = "59.9343,30.3351", DeliveryLocation = "55.7558,37.6173", Status = "Pending", Notes = "Awaiting pickup", TimeStamps = new DateTime(2023, 09, 15, 10, 30, 0), OrderPlacementId = 5 },
     new OrderTracking { Id = 6, PickUpLocation = "54.7261,55.9475", DeliveryLocation = "56.3269,44.0075", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), OrderPlacementId = 6 },

     new OrderTracking { Id = 7, PickUpLocation = "55.7961,49.1064", DeliveryLocation = "55.7558,37.6173", Status = "In Transit", Notes = "On the way to destination", TimeStamps = new DateTime(2023, 09, 15, 09, 0, 0), OrderPlacementId = 7 },
     new OrderTracking { Id = 8, PickUpLocation = "54.7349,55.9579", DeliveryLocation = "59.9343,30.3351", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = new DateTime(2023, 09, 15, 13, 30, 0), OrderPlacementId = 8 },

     new OrderTracking { Id = 9, PickUpLocation = "56.3269,44.0075", DeliveryLocation = "54.7349,55.9579", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = new DateTime(2023, 09, 15, 08, 0, 0), OrderPlacementId = 9 },
     new OrderTracking { Id = 10, PickUpLocation = "59.9343,30.3351", DeliveryLocation = "54.7261,55.9475", Status = "In Transit", Notes = "On route to delivery", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), OrderPlacementId = 10 },

     new OrderTracking { Id = 11, PickUpLocation = "55.7558,37.6173", DeliveryLocation = "55.7961,49.1064", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), OrderPlacementId = 11 },
     new OrderTracking { Id = 12, PickUpLocation = "54.7261,55.9475", DeliveryLocation = "55.7558,37.6173", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), OrderPlacementId = 12 },

     new OrderTracking { Id = 13, PickUpLocation = "55.7961,49.1064", DeliveryLocation = "54.7261,55.9475", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 11, 0, 0), OrderPlacementId = 13 },
     new OrderTracking { Id = 14, PickUpLocation = "54.7349,55.9579", DeliveryLocation = "56.3269,44.0075", Status = "Delivered", Notes = "Delivered to customer", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), OrderPlacementId = 14 },

     new OrderTracking { Id = 15, PickUpLocation = "56.3269,44.0075", DeliveryLocation = "59.9343,30.3351", Status = "In Transit", Notes = "On the way", TimeStamps = new DateTime(2023, 09, 15, 11, 30, 0), OrderPlacementId = 15 },
     new OrderTracking { Id = 16, PickUpLocation = "55.7558,37.6173", DeliveryLocation = "54.7349,55.9579", Status = "Delivered", Notes = "Received by customer", TimeStamps = new DateTime(2023, 09, 15, 13, 0, 0), OrderPlacementId = 16 },

     new OrderTracking { Id = 17, PickUpLocation = "59.9343,30.3351", DeliveryLocation = "55.7961,49.1064", Status = "Pending", Notes = "Awaiting pickup", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), OrderPlacementId = 17 },
     new OrderTracking { Id = 18, PickUpLocation = "54.7261,55.9475", DeliveryLocation = "56.3269,44.0075", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), OrderPlacementId = 18 },

     new OrderTracking { Id = 19, PickUpLocation = "55.7961,49.1064", DeliveryLocation = "59.9343,30.3351", Status = "In Transit", Notes = "On the way to destination", TimeStamps = new DateTime(2023, 09, 15, 09, 0, 0), OrderPlacementId = 19 },
     new OrderTracking { Id = 20, PickUpLocation = "54.7349,55.9579", DeliveryLocation = "55.7558,37.6173", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = new DateTime(2023, 09, 15, 13, 0, 0), OrderPlacementId = 20 },

     new OrderTracking { Id = 21, PickUpLocation = "56.3269,44.0075", DeliveryLocation = "54.7261,55.9475", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = new DateTime(2023, 09, 15, 08, 0, 0), OrderPlacementId = 21 },
     new OrderTracking { Id = 22, PickUpLocation = "59.9343,30.3351", DeliveryLocation = "55.7558,37.6173", Status = "In Transit", Notes = "On route to delivery", TimeStamps = new DateTime(2023, 09, 15, 12, 0, 0), OrderPlacementId = 22 },

     new OrderTracking { Id = 23, PickUpLocation = "55.7558,37.6173", DeliveryLocation = "56.3269,44.0075", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = new DateTime(2023, 09, 15, 10, 0, 0), OrderPlacementId = 23 },
     new OrderTracking { Id = 24, PickUpLocation = "54.7261,55.9475", DeliveryLocation = "55.7961,49.1064", Status = "In Transit", Notes = "Picked up", TimeStamps = new DateTime(2023, 09, 15, 12, 30, 0), OrderPlacementId = 24 }
            );
        }
    }
}
