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
                
                new Order_Tracking { Id = 1, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up from warehouse", TimeStamps = DateTime.Now.AddHours(-5), Order_Placement_Id = 1 },
                new Order_Tracking { Id = 2, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered to customer", TimeStamps = DateTime.Now.AddHours(-2), Order_Placement_Id =2 },

                new Order_Tracking { Id = 3, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = DateTime.Now.AddHours(-4), Order_Placement_Id = 3 },
                new Order_Tracking { Id = 4, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Received by customer", TimeStamps = DateTime.Now.AddHours(-1), Order_Placement_Id =4 },

                new Order_Tracking { Id = 5, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting pickup", TimeStamps = DateTime.Now.AddHours(-3), Order_Placement_Id = 5 },
                new Order_Tracking { Id = 6, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = DateTime.Now.AddHours(-2), Order_Placement_Id = 6 },

                new Order_Tracking { Id = 7, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way to destination", TimeStamps = DateTime.Now.AddHours(-6), Order_Placement_Id = 7 },
                new Order_Tracking { Id = 8, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = DateTime.Now.AddHours(-1), Order_Placement_Id = 8 },

                new Order_Tracking { Id = 9, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = DateTime.Now.AddHours(-8), Order_Placement_Id = 9 },
                new Order_Tracking { Id = 10, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On route to delivery", TimeStamps = DateTime.Now.AddHours(-2), Order_Placement_Id = 10 },

                new Order_Tracking { Id = 11, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = DateTime.Now.AddHours(-5), Order_Placement_Id = 11 },
                new Order_Tracking { Id = 12, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = DateTime.Now.AddHours(-1), Order_Placement_Id = 12 },

                new Order_Tracking { Id = 13, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = DateTime.Now.AddHours(-4), Order_Placement_Id = 13 },
                new Order_Tracking { Id = 14, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered to customer", TimeStamps = DateTime.Now.AddHours(-2), Order_Placement_Id = 14 },

                new Order_Tracking { Id = 15, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = DateTime.Now.AddHours(-3), Order_Placement_Id = 15 },
                new Order_Tracking { Id = 16, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Received by customer", TimeStamps = DateTime.Now.AddHours(-1), Order_Placement_Id = 16 },

                new Order_Tracking { Id = 17, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting pickup", TimeStamps = DateTime.Now.AddHours(-3), Order_Placement_Id = 17 },
                new Order_Tracking { Id = 18, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = DateTime.Now.AddHours(-2), Order_Placement_Id = 18 },

                new Order_Tracking { Id = 19, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way to destination", TimeStamps = DateTime.Now.AddHours(-6), Order_Placement_Id = 19 },
                new Order_Tracking { Id = 20, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = DateTime.Now.AddHours(-1), Order_Placement_Id = 20 },

                new Order_Tracking { Id = 21, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = DateTime.Now.AddHours(-8), Order_Placement_Id = 21 },
                new Order_Tracking { Id = 22, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On route to delivery", TimeStamps = DateTime.Now.AddHours(-2), Order_Placement_Id = 22 },

                new Order_Tracking { Id = 23, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = DateTime.Now.AddHours(-5), Order_Placement_Id = 23 },
                new Order_Tracking { Id = 24, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = DateTime.Now.AddHours(-1), Order_Placement_Id = 24 },

                new Order_Tracking { Id = 25, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = DateTime.Now.AddHours(-4), Order_Placement_Id = 25 },
                new Order_Tracking { Id = 26, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered to customer", TimeStamps = DateTime.Now.AddHours(-2), Order_Placement_Id = 26 },

                new Order_Tracking { Id = 27, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = DateTime.Now.AddHours(-3), Order_Placement_Id = 27 },
                new Order_Tracking { Id = 28, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Received by customer", TimeStamps = DateTime.Now.AddHours(-1), Order_Placement_Id = 28 },

                new Order_Tracking { Id = 29, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting pickup", TimeStamps = DateTime.Now.AddHours(-3), Order_Placement_Id = 29 },
                new Order_Tracking { Id = 30, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = DateTime.Now.AddHours(-2), Order_Placement_Id = 30 },

                new Order_Tracking { Id = 31, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = DateTime.Now.AddHours(-6), Order_Placement_Id = 31 },
                new Order_Tracking { Id = 32, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = DateTime.Now.AddHours(-1), Order_Placement_Id = 32 },

                new Order_Tracking { Id = 33, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = DateTime.Now.AddHours(-8), Order_Placement_Id = 33 },
                new Order_Tracking { Id = 34, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On route to delivery", TimeStamps = DateTime.Now.AddHours(-2), Order_Placement_Id = 34 },

                new Order_Tracking { Id = 35, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = DateTime.Now.AddHours(-5), Order_Placement_Id = 35 },
                new Order_Tracking { Id = 36, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = DateTime.Now.AddHours(-1), Order_Placement_Id = 36 },

                new Order_Tracking { Id = 37, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way to destination", TimeStamps = DateTime.Now.AddHours(-4), Order_Placement_Id = 37 },
                new Order_Tracking { Id = 38, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = DateTime.Now.AddHours(-2), Order_Placement_Id = 38 },

                new Order_Tracking { Id = 39, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = DateTime.Now.AddHours(-8), Order_Placement_Id = 39 },
                new Order_Tracking { Id = 40, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On route to delivery", TimeStamps = DateTime.Now.AddHours(-2), Order_Placement_Id = 40 },

                new Order_Tracking { Id = 41, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = DateTime.Now.AddHours(-5), Order_Placement_Id = 41 },
                new Order_Tracking { Id = 42, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = DateTime.Now.AddHours(-1), Order_Placement_Id = 42 },

                new Order_Tracking { Id = 43, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = DateTime.Now.AddHours(-3), Order_Placement_Id = 43 },
                new Order_Tracking { Id = 44, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Received by customer", TimeStamps = DateTime.Now.AddHours(-1), Order_Placement_Id = 44 },

                new Order_Tracking { Id = 45, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting pickup", TimeStamps = DateTime.Now.AddHours(-3), Order_Placement_Id = 45 },
                new Order_Tracking { Id = 46, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = DateTime.Now.AddHours(-2), Order_Placement_Id = 46 },

                new Order_Tracking { Id = 47, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way", TimeStamps = DateTime.Now.AddHours(-6), Order_Placement_Id = 47 },
                new Order_Tracking { Id = 48, Latitude = "34.0522", Longitude = "-118.2437", Status = "Delivered", Notes = "Delivered successfully", TimeStamps = DateTime.Now.AddHours(-1), Order_Placement_Id = 48 },

                new Order_Tracking { Id = 49, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Warehouse", Notes = "Waiting for dispatch", TimeStamps = DateTime.Now.AddHours(-8), Order_Placement_Id = 49 },
                new Order_Tracking { Id = 50, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On route to delivery", TimeStamps = DateTime.Now.AddHours(-2), Order_Placement_Id = 50 },

                new Order_Tracking { Id = 51, Latitude = "34.0522", Longitude = "-118.2437", Status = "Pending", Notes = "Awaiting confirmation", TimeStamps = DateTime.Now.AddHours(-5), Order_Placement_Id = 51 },
                new Order_Tracking { Id = 52, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "Picked up", TimeStamps = DateTime.Now.AddHours(-1), Order_Placement_Id = 52 },

                new Order_Tracking { Id = 53, Latitude = "34.0522", Longitude = "-118.2437", Status = "In Transit", Notes = "On the way to destination", TimeStamps = DateTime.Now.AddHours(-4), Order_Placement_Id = 53 }
            );
        }
    }
}
