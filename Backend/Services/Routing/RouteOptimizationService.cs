using Backend.DatabasContext;
using Backend.Models;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Routing
{
    public class RouteOptimizationService
    {
        private readonly ApplicationDatabaseContext _context;
        private readonly IGeocodingService _geocodingService;
        private readonly ILogger<RouteOptimizationService> _logger;

        public RouteOptimizationService(
            ApplicationDatabaseContext context, 
            ILogger<RouteOptimizationService> logger,
            IGeocodingService geocodingService)
        {
            _context = context;
            _geocodingService = geocodingService;
            _logger = logger;
        }

        public async Task<OptimizedRouteResult> OptimizeDriverRouteAsync(
            int driverId,
            List<int> orderIds,
            CancellationToken cancellationToken = default)
        {

            // Load entities with coordinates
            var driver = await _context.Drivers
                .Include(d => d.User)
                .FirstAsync(d => d.Id == driverId, cancellationToken);

            if (driver == null)
                throw new InvalidOperationException($"Driver {driverId} not found or unavailable");

            var orders = await _context.OrderPlacements
                .Where(o => orderIds.Contains(o.Id))
                .Include(o => o.OrderItems)
                   .ThenInclude(oi => oi.OrderDimension)
                .Include(o => o.OrderTrackings)
                .ToListAsync(cancellationToken);

            // Resolve coordinates (critical step - cache in production)
            var locations = new Dictionary<int, GeoCoordinate>();
            var demands = new Dictionary<int, (double weight, double volume)>();

            foreach (var order in orders)
            {
                // Calculate demand
                var weight = order.OrderItems?.Quantity * (double)(order.OrderItems?.WeightPerItem ?? 0)??50;
                //var volume = order.OrderItems?.OrderDimension != null
                //    ? (double)order.OrderItems.OrderDimension.Length *
                //      (double)order.OrderItems.OrderDimension.Width *
                //      (double)order.OrderItems.OrderDimension.Height
                //    : 0;

                demands[order.Id] = (weight, 0);

                // Get pickup coordinates
                var coord = await _geocodingService.GetCoordinatesAsync(order.Id, cancellationToken);
                if (coord == null || coord.Latitude == 0)
                {
                    // ✅ FALLBACK: Use Minsk city center if geocoding fails (prevents empty routes)
                    _logger.LogWarning("Geocoding failed for address '{Address}', using fallback coordinates", order.PickUpAddress);
                    coord = new GeoCoordinate { Latitude = 53.9045, Longitude = 27.5615 }; // Minsk center
                }

                locations[order.Id] = coord ?? new GeoCoordinate { Latitude = 53.9045, Longitude = 27.5615 };
            }
            if (locations.Count != orders.Count)
                throw new InvalidOperationException("Failed to resolve coordinates for all orders");

            var vehicle = _context.Vehicles.Where(v=>v.DriverId == driver.Id).FirstOrDefault();
            // Run ACO optimization
            var engine = new AcoRoutingEngine(
                _context,
                orders, 
                vehicle, 
                driver, 
                locations, 
                demands);

            var optimizedOrderIds = await engine.OptimizeAsync(cancellationToken);

            // Convert to actual order sequence (skip depot nodes)
            var orderedOrders = optimizedOrderIds
                .Skip(1) // Skip start depot
                .Take(optimizedOrderIds.Count - 2) // Skip end depot
                .Select(idx => orders[idx - 1]) // Convert index to order
                .ToList();

            // Generate route string for storage (simplified - use actual routing service in production)
            var routeString = string.Join(" → ", orderedOrders.Select(o =>
                $"{o.PickUpAddress} (Order #{o.Id})"));

            //var orderObject = new
            //{
            //    DriverId = driverId,
            //    OrderSequence = orderedOrders.Select(o => o.Id).ToList(),
            //    TotalDistanceKm = CalculateTotalDistance(orderedOrders, locations),
            //    EstimatedDuration = CalculateEstimatedDuration(orderedOrders, locations),
            //    RouteData = routeString
            //};

            return new OptimizedRouteResult
            {
                DriverId = driverId,
                OrderSequence = orderedOrders.Select(o => o.Id).ToList(),
                TotalDistanceKm = CalculateTotalDistance(orderedOrders, locations),
                EstimatedDuration = CalculateEstimatedDuration(orderedOrders, locations),
                RouteData = routeString
            };
        }

        private double CalculateTotalDistance(List<OrderPlacement> orders, Dictionary<int, GeoCoordinate> locations)
        {
            if (!orders.Any()) return 0;

            double total = 0;
            var prevCoord = locations[orders[0].Id];

            for (int i = 1; i < orders.Count; i++)
            {
                var currentCoord = locations[orders[i].Id];
                total += prevCoord.DistanceTo(currentCoord);
                prevCoord = currentCoord;
            }
            return Math.Round(total, 2);
        }

        private TimeSpan CalculateEstimatedDuration(List<OrderPlacement> orders, Dictionary<int, GeoCoordinate> locations)
        {
            var distance = CalculateTotalDistance(orders, locations);
            return TimeSpan.FromHours(distance * 1.5);// 40 km/h ≈ 1.5 min per km
        }
    }

    public class OptimizedRouteResult
    {
        public int DriverId { get; set; }
        public List<int> OrderSequence { get; set; } = new();
        public double TotalDistanceKm { get; set; }
        public TimeSpan EstimatedDuration { get; set; }
        public string RouteData { get; set; } = string.Empty;
    }
}
