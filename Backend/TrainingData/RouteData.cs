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
                new Route { Id = 1, RouteData = "Route 1 Data", TotalDistance = "15.2 km", EstimatedDuration = new DateTime(2024, 1, 1, 2, 30, 0), DriverId = 1, OrderPlacementId = 1 },
                new Route { Id = 2, RouteData = "Route 2 Data", TotalDistance = "22.8 km", EstimatedDuration = new DateTime(2024, 1, 1, 3, 15, 0), DriverId = 2, OrderPlacementId = 2 },
                new Route { Id = 3, RouteData = "Route 3 Data", TotalDistance = "18.5 km", EstimatedDuration = new DateTime(2024, 1, 1, 2, 45, 0), DriverId = 3, OrderPlacementId = 3 },
                new Route { Id = 4, RouteData = "Route 4 Data", TotalDistance = "27.3 km", EstimatedDuration = new DateTime(2024, 1, 1, 3, 30, 0), DriverId = 4, OrderPlacementId = 4 },
                new Route { Id = 5, RouteData = "Route 5 Data", TotalDistance = "12.1 km", EstimatedDuration = new DateTime(2024, 1, 1, 1, 50, 0), DriverId = 5, OrderPlacementId = 5 },
                new Route { Id = 6, RouteData = "Route 6 Data", TotalDistance = "19.7 km", EstimatedDuration = new DateTime(2024, 1, 1, 2, 55, 0), DriverId = 6, OrderPlacementId = 6 },
                new Route { Id = 7, RouteData = "Route 7 Data", TotalDistance = "24.9 km", EstimatedDuration = new DateTime(2024, 1, 1, 3, 20, 0), DriverId = 1, OrderPlacementId = 7 },
                new Route { Id = 8, RouteData = "Route 8 Data", TotalDistance = "16.4 km", EstimatedDuration = new DateTime(2024, 1, 1, 2, 25, 0), DriverId = 2, OrderPlacementId = 8 },
                new Route { Id = 9, RouteData = "Route 9 Data", TotalDistance = "21.2 km", EstimatedDuration = new DateTime(2024, 1, 1, 3, 5, 0), DriverId = 3, OrderPlacementId = 9 },
                new Route { Id = 10, RouteData = "Route 10 Data", TotalDistance = "14.8 km", EstimatedDuration = new DateTime(2024, 1, 1, 2, 15, 0), DriverId = 4, OrderPlacementId = 10 },
                new Route { Id = 11, RouteData = "Route 11 Data", TotalDistance = "23.6 km", EstimatedDuration = new DateTime(2024, 1, 1, 3, 40, 0), DriverId = 5, OrderPlacementId = 11 },
                new Route { Id = 12, RouteData = "Route 12 Data", TotalDistance = "17.9 km", EstimatedDuration = new DateTime(2024, 1, 1, 2, 40, 0), DriverId = 6, OrderPlacementId = 12 },
                new Route { Id = 13, RouteData = "Route 13 Data", TotalDistance = "26.1 km", EstimatedDuration = new DateTime(2024, 1, 1, 3, 35, 0), DriverId = 1, OrderPlacementId = 13 },
                new Route { Id = 14, RouteData = "Route 14 Data", TotalDistance = "13.5 km", EstimatedDuration = new DateTime(2024, 1, 1, 2, 10, 0), DriverId = 2, OrderPlacementId = 14 },
                new Route { Id = 15, RouteData = "Route 15 Data", TotalDistance = "20.3 km", EstimatedDuration = new DateTime(2024, 1, 1, 3, 0, 0), DriverId = 3, OrderPlacementId = 15 },
                new Route { Id = 16, RouteData = "Route 16 Data", TotalDistance = "25.7 km", EstimatedDuration = new DateTime(2024, 1, 1, 3, 45, 0), DriverId = 4, OrderPlacementId = 16 },
                new Route { Id = 17, RouteData = "Route 17 Data", TotalDistance = "15.9 km", EstimatedDuration = new DateTime(2024, 1, 1, 2, 35, 0), DriverId = 5, OrderPlacementId = 17 },
                new Route { Id = 18, RouteData = "Route 18 Data", TotalDistance = "22.4 km", EstimatedDuration = new DateTime(2024, 1, 1, 3, 25, 0), DriverId = 6, OrderPlacementId = 18 },
                new Route { Id = 19, RouteData = "Route 19 Data", TotalDistance = "18.2 km", EstimatedDuration = new DateTime(2024, 1, 1, 2, 50, 0), DriverId = 1, OrderPlacementId = 19 },
                new Route { Id = 20, RouteData = "Route 20 Data", TotalDistance = "24.3 km", EstimatedDuration = new DateTime(2024, 1, 1, 3, 30, 0), DriverId = 2, OrderPlacementId = 20 },
                new Route { Id = 21, RouteData = "Route 21 Data", TotalDistance = "16.7 km", EstimatedDuration = new DateTime(2024, 1, 1, 2, 30, 0), DriverId = 3, OrderPlacementId = 21 },
                new Route { Id = 22, RouteData = "Route 22 Data", TotalDistance = "21.9 km", EstimatedDuration = new DateTime(2024, 1, 1, 3, 15, 0), DriverId = 4, OrderPlacementId = 22 },
                new Route { Id = 23, RouteData = "Route 23 Data", TotalDistance = "14.3 km", EstimatedDuration = new DateTime(2024, 1, 1, 2, 20, 0), DriverId = 5, OrderPlacementId = 23 },
                new Route { Id = 24, RouteData = "Route 24 Data", TotalDistance = "19.8 km", EstimatedDuration = new DateTime(2024, 1, 1, 2, 55, 0), DriverId = 6, OrderPlacementId = 24 }
            );
        }
    }
}
