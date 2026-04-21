using Backend.Services.Routing;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.DatabasContext;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ACOptimizationController:ControllerBase
    {

        private readonly RouteOptimizationService _routeOptimizationService;
        private readonly ApplicationDatabaseContext _context;
        private readonly ILogger<ACOptimizationController> _logger;

        public ACOptimizationController(ILogger<ACOptimizationController> logger, RouteOptimizationService routeOptimizationService, ApplicationDatabaseContext context)
        {
            _routeOptimizationService = routeOptimizationService;
            _context = context;
            _logger = logger;
        }

        [HttpPost("optimize-route")]
        public async Task<IActionResult> OptimizeRoute([FromBody] OptimizeRouteRequest request)
        {

            if(request.OrderIds == null|| !request.OrderIds.Any())
            {
                return BadRequest(new { error = "At least one order ID is required" });
            }
            try
            {
                _logger.LogInformation("Optimizing route for Driver {DriverId} with orders: {OrderIds}",
                    request.DriverId, string.Join(",", request.OrderIds));

                var result = await _routeOptimizationService.OptimizeDriverRouteAsync(
                request.DriverId,
                request.OrderIds,
                HttpContext.RequestAborted);

                // Persist to Route entity
                var routeEntity = new Models.Route
                {
                    //Id = 100,
                    DriverId = result.DriverId,
                    RouteData = result.RouteData,
                    TotalDistance = result.TotalDistanceKm.ToString("F2"),
                    EstimatedDuration = DateTime.Now + result.EstimatedDuration,
                    TravelinSequency = string.Join("-", result.OrderSequence)
                };
                var DriverIds = _context.Routes.Where(i => i.DriverId == request.DriverId).ToList();
                _context.Routes.RemoveRange(DriverIds);

                var routedata = _context.Routes.Add(routeEntity);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    routeId = routeEntity.Id,
                    OrderPlaceds = _context.OrderPlacements.
                        Where(o => request.OrderIds.Contains(o.Id))
                        .ToList(),
                    sequence = result.OrderSequence,
                    distanceKm = result.TotalDistanceKm,
                    estimatedDuration = FormatedDuration(result.EstimatedDuration)
                });
            }
            catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("FOREIGN KEY") == true)
            {
                _logger.LogError(ex, "FK violation: OrderPlacementId={OrderId} not found",
                    request.OrderIds.FirstOrDefault());
                return BadRequest(new
                {
                    error = "Invalid order ID(s) provided. Verify orders exist and belong to this driver."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Route optimization failed");
                return StatusCode(500, new { error = "Optimization failed", details = ex.Message });
            }

        }

        private string FormatedDuration(TimeSpan duration)
        {
            //TimeSpan duration = TimeSpan.FromHours(hours);
            if (duration.TotalHours >= 1)//if more than an hour, show  mintures and hours
            {
                //e.g 21hr 15m
                return $"{(int)duration.TotalHours}hr {duration.Minutes}m";
            }

            //Just show minutes
            return $"{duration.Minutes:FO}m";
        }
        public class OptimizeRouteRequest
        {
            public int DriverId { get; set; }
            public List<int> OrderIds { get; set; } = new();
        }
    }
}
