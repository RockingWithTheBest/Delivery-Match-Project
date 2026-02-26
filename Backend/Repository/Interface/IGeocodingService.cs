using Backend.DatabasContext;
using Backend.Models;

namespace Backend.Repository.Interface
{
    public interface IGeocodingService
    {
        Task<GeoCoordinate> GetCoordinatesAsync(int OrderId, CancellationToken ct = default);
    }

    // Mock implementation for development
    public class MockGeocodingService : IGeocodingService
    {
        private readonly ApplicationDatabaseContext _context;
        public MockGeocodingService(ApplicationDatabaseContext context)
        {
            _context = context;
        }

        public Task<GeoCoordinate> GetCoordinatesAsync(int OrderId, CancellationToken ct = default)
        {
            var orderPlacements = _context.OrderPlacements.ToList();
            var geoCoord = _context.OrderTrackings
                .Where(o => o.OrderPlacementId == OrderId)
                .FirstOrDefault();
            
            var arrayOfCoords = geoCoord.DeliveryLocation.Split(',');
            return Task.FromResult<GeoCoordinate?>(new GeoCoordinate
            {
                Latitude = double.Parse(arrayOfCoords[0]),
                Longitude = double.Parse(arrayOfCoords[1])
            });
        }
    }
}
