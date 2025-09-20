using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Backend.Models;
using Route = Backend.Models.Route;
namespace Backend.TrainingData
{
    public class RouteData : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasData
            (
                new Route { Id = 1, Route_Data = "Route 1 Data", Total_Distance = "15.2 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 30, 0), DriverId = 1, Order_PlacementId = 1 },
                new Route { Id = 2, Route_Data = "Route 2 Data", Total_Distance = "22.8 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 15, 0), DriverId = 2, Order_PlacementId = 2 },
                new Route { Id = 3, Route_Data = "Route 3 Data", Total_Distance = "18.5 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 45, 0), DriverId = 3, Order_PlacementId = 3 },
                new Route { Id = 4, Route_Data = "Route 4 Data", Total_Distance = "27.3 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 30, 0), DriverId = 4, Order_PlacementId = 4 },
                new Route { Id = 5, Route_Data = "Route 5 Data", Total_Distance = "12.1 km", Estimated_Duration = new DateTime(2024, 1, 1, 1, 50, 0), DriverId = 5, Order_PlacementId = 5 },
                new Route { Id = 6, Route_Data = "Route 6 Data", Total_Distance = "19.7 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 55, 0), DriverId = 6, Order_PlacementId = 6 },
                new Route { Id = 7, Route_Data = "Route 7 Data", Total_Distance = "24.9 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 20, 0), DriverId = 1, Order_PlacementId = 7 },
                new Route { Id = 8, Route_Data = "Route 8 Data", Total_Distance = "16.4 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 25, 0), DriverId = 2, Order_PlacementId = 8 },
                new Route { Id = 9, Route_Data = "Route 9 Data", Total_Distance = "21.2 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 5, 0), DriverId = 3, Order_PlacementId = 9 },
                new Route { Id = 10, Route_Data = "Route 10 Data", Total_Distance = "14.8 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 15, 0), DriverId = 4, Order_PlacementId = 10 },
                new Route { Id = 11, Route_Data = "Route 11 Data", Total_Distance = "23.6 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 40, 0), DriverId = 5, Order_PlacementId = 11 },
                new Route { Id = 12, Route_Data = "Route 12 Data", Total_Distance = "17.9 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 40, 0), DriverId = 6, Order_PlacementId = 12 },
                new Route { Id = 13, Route_Data = "Route 13 Data", Total_Distance = "26.1 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 35, 0), DriverId = 1, Order_PlacementId = 13 },
                new Route { Id = 14, Route_Data = "Route 14 Data", Total_Distance = "13.5 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 10, 0), DriverId = 2, Order_PlacementId = 14 },
                new Route { Id = 15, Route_Data = "Route 15 Data", Total_Distance = "20.3 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 0, 0), DriverId = 3, Order_PlacementId = 15 },
                new Route { Id = 16, Route_Data = "Route 16 Data", Total_Distance = "25.7 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 45, 0), DriverId = 4, Order_PlacementId = 16 },
                new Route { Id = 17, Route_Data = "Route 17 Data", Total_Distance = "15.9 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 35, 0), DriverId = 5, Order_PlacementId = 17 },
                new Route { Id = 18, Route_Data = "Route 18 Data", Total_Distance = "22.4 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 25, 0), DriverId = 6, Order_PlacementId = 18 },
                new Route { Id = 19, Route_Data = "Route 19 Data", Total_Distance = "18.2 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 50, 0), DriverId = 1, Order_PlacementId = 19 },
                new Route { Id = 20, Route_Data = "Route 20 Data", Total_Distance = "24.3 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 30, 0), DriverId = 2, Order_PlacementId = 20 },
                new Route { Id = 21, Route_Data = "Route 21 Data", Total_Distance = "16.7 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 30, 0), DriverId = 3, Order_PlacementId = 21 },
                new Route { Id = 22, Route_Data = "Route 22 Data", Total_Distance = "21.9 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 15, 0), DriverId = 4, Order_PlacementId = 22 },
                new Route { Id = 23, Route_Data = "Route 23 Data", Total_Distance = "14.3 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 20, 0), DriverId = 5, Order_PlacementId = 23 },
                new Route { Id = 24, Route_Data = "Route 24 Data", Total_Distance = "19.8 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 55, 0), DriverId = 6, Order_PlacementId = 24 },
                new Route { Id = 25, Route_Data = "Route 25 Data", Total_Distance = "26.8 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 50, 0), DriverId = 1, Order_PlacementId = 25 },
                new Route { Id = 26, Route_Data = "Route 26 Data", Total_Distance = "12.9 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 5, 0), DriverId = 2, Order_PlacementId = 26 },
                new Route { Id = 27, Route_Data = "Route 27 Data", Total_Distance = "23.1 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 20, 0), DriverId = 3, Order_PlacementId = 27 },
                new Route { Id = 28, Route_Data = "Route 28 Data", Total_Distance = "17.4 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 45, 0), DriverId = 4, Order_PlacementId = 28 },
                new Route { Id = 29, Route_Data = "Route 29 Data", Total_Distance = "22.7 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 35, 0), DriverId = 5, Order_PlacementId = 29 },
                new Route { Id = 30, Route_Data = "Route 30 Data", Total_Distance = "15.6 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 25, 0), DriverId = 6, Order_PlacementId = 30 },
                new Route { Id = 31, Route_Data = "Route 31 Data", Total_Distance = "20.5 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 10, 0), DriverId = 1, Order_PlacementId = 31 },
                new Route { Id = 32, Route_Data = "Route 32 Data", Total_Distance = "25.2 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 40, 0), DriverId = 2, Order_PlacementId = 32 },
                new Route { Id = 33, Route_Data = "Route 33 Data", Total_Distance = "13.8 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 15, 0), DriverId = 3, Order_PlacementId = 33 },
                new Route { Id = 34, Route_Data = "Route 34 Data", Total_Distance = "18.9 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 50, 0), DriverId = 4, Order_PlacementId = 34 },
                new Route { Id = 35, Route_Data = "Route 35 Data", Total_Distance = "24.6 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 30, 0), DriverId = 5, Order_PlacementId = 35 },
                new Route { Id = 36, Route_Data = "Route 36 Data", Total_Distance = "16.2 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 35, 0), DriverId = 6, Order_PlacementId = 36 },
                new Route { Id = 37, Route_Data = "Route 37 Data", Total_Distance = "21.7 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 15, 0), DriverId = 1, Order_PlacementId = 37 },
                new Route { Id = 38, Route_Data = "Route 38 Data", Total_Distance = "14.6 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 20, 0), DriverId = 2, Order_PlacementId = 38 },
                new Route { Id = 39, Route_Data = "Route 39 Data", Total_Distance = "19.3 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 55, 0), DriverId = 3, Order_PlacementId = 39 },
                new Route { Id = 40, Route_Data = "Route 40 Data", Total_Distance = "26.4 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 45, 0), DriverId = 4, Order_PlacementId = 40 },
                new Route { Id = 41, Route_Data = "Route 41 Data", Total_Distance = "12.4 km", Estimated_Duration = new DateTime(2024, 1, 1, 1, 55, 0), DriverId = 5, Order_PlacementId = 41 },
                new Route { Id = 42, Route_Data = "Route 42 Data", Total_Distance = "23.8 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 25, 0), DriverId = 6, Order_PlacementId = 42 },
                new Route { Id = 43, Route_Data = "Route 43 Data", Total_Distance = "17.1 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 40, 0), DriverId = 1, Order_PlacementId = 43 },
                new Route { Id = 44, Route_Data = "Route 44 Data", Total_Distance = "22.2 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 20, 0), DriverId = 2, Order_PlacementId = 44 },
                new Route { Id = 45, Route_Data = "Route 45 Data", Total_Distance = "15.3 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 30, 0), DriverId = 3, Order_PlacementId = 45 },
                new Route { Id = 46, Route_Data = "Route 46 Data", Total_Distance = "20.8 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 5, 0), DriverId = 4, Order_PlacementId = 46 },
                new Route { Id = 47, Route_Data = "Route 47 Data", Total_Distance = "25.9 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 50, 0), DriverId = 5, Order_PlacementId = 47 },
                new Route { Id = 48, Route_Data = "Route 48 Data", Total_Distance = "13.2 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 10, 0), DriverId = 6, Order_PlacementId = 48 },
                new Route { Id = 49, Route_Data = "Route 49 Data", Total_Distance = "18.6 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 50, 0), DriverId = 1, Order_PlacementId = 49 },
                new Route { Id = 50, Route_Data = "Route 50 Data", Total_Distance = "24.1 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 35, 0), DriverId = 2, Order_PlacementId = 50 },
                new Route { Id = 51, Route_Data = "Route 51 Data", Total_Distance = "16.9 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 40, 0), DriverId = 3, Order_PlacementId = 51 },
                new Route { Id = 52, Route_Data = "Route 52 Data", Total_Distance = "21.4 km", Estimated_Duration = new DateTime(2024, 1, 1, 3, 15, 0), DriverId = 4, Order_PlacementId = 52 },
                new Route { Id = 53, Route_Data = "Route 53 Data", Total_Distance = "14.7 km", Estimated_Duration = new DateTime(2024, 1, 1, 2, 25, 0), DriverId = 5, Order_PlacementId = 53 }
            );
        }
    }
}
