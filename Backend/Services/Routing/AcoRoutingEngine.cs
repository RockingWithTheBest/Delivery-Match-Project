using Backend.DatabasContext;
using Backend.Models;

namespace Backend.Services.Routing
{
    public class AcoRoutingEngine
    {
        private readonly Random _random = new ();
        private readonly double[,] _pheromones;
        private readonly double[,] _distances;
        private readonly double[,] _heuristics;
        private readonly List<OrderPlacement> _orders;
        private readonly Vehicle _vehicle;
        private readonly Driver _driver;
        // orderId -> coordinate
        private readonly Dictionary<int, GeoCoordinate> _locations;        
        private readonly Dictionary<int, (double weight, 
            double volume)> _demands;
        private readonly ApplicationDatabaseContext context;

        // ACO Parameters (tunable)
        private const double Alpha = 1.0;// Pheromone importance
        private const double Beta = 2.0; // Heuristic importance
        private const double Rho = 0.1; //Evaporation rate
        private const double Q = 100.0; // Pheromone deposit factor
        private const int AntCount = 30;
        private const int MaxIterations = 100;
        private const double InitialPheromone = 0.1;


        public AcoRoutingEngine(
            ApplicationDatabaseContext _context,
            List<OrderPlacement> orders, 
            Vehicle vehicle, 
            Driver driver, 
            Dictionary<int, GeoCoordinate> locations, 
            Dictionary<int, (double weight, double volume)> demands)
        {
            _orders = orders;
            _vehicle = vehicle;
            _driver = driver;
            _locations = locations;
            _demands = demands;
            context = _context;

            var n = orders.Count + 1; //+1 for depot
            _pheromones = new double[n, n];
            _distances = new double[n, n];
            _heuristics = new double[n, n];

            InitializeMatrices(_driver.Id);
        }

        public void InitializeMatrices(int DriverId)
        {
            var n = _orders.Count + 1;
            var depotCoord = GetDepotCoordinate(DriverId);// Implement based on driver's base location

            // Build location index: 0=depot, 1...n=orders
            var coords = new List<GeoCoordinate> { depotCoord };
            coords.AddRange(_orders.Select(o => _locations[o.Id]));

            // Calculate distances & heuristics
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(i == j) continue;

                    _distances[i, j] = coords[i].DistanceTo(coords[j]);
                    // i  represents the "from" location
                    // j represents the "to" location
                    _pheromones[i, j] = InitialPheromone; 
                    _heuristics[i, j] = 1.0 / _distances[i,j];
                }
            }
        }

        private GeoCoordinate GetDepotCoordinate(int DriverId)
        {
            if (DriverId <= 0)
            {
                throw new Exception("Driver must not be less than Zero!");
            }
            var users = context.Drivers
                .Where(d => d.Id == DriverId)
                .Select(t => t.UserId)
                .FirstOrDefault();

            var address = context.Addresses.Where(o =>
                  o.UserId == users
            ).FirstOrDefault();

            if(address == null)
            {
                throw new Exception("The particular driver doesn't have an Address");
            }
            // Implement based on driver's home base or first pickup location
            return new GeoCoordinate { Latitude = double.Parse(address.Latitude), Longitude = double.Parse(address.Longitude) }; 
        }

        public async Task<List<int>>OptimizeAsync(CancellationToken 
            cancellationToken= default)
        {
            var bestRoute = new List<int>();
            var bestDistance = double.MaxValue;

            for(int iteration = 0; iteration < MaxIterations && 
                !cancellationToken.IsCancellationRequested; iteration++)
            {
                var antRoutes = await GenerateAntRouteAsync(cancellationToken);

                // Evaluate & update best solution
                foreach(var route in antRoutes)
                {
                    var distance = CalculateRouteDistance(route);
                    if(distance < bestDistance && ValidateConstraints(route))
                    {
                        bestDistance = distance;
                        bestRoute = new List<int>(route);
                    }
                }

                //Pheromone update
                UpdatePheromones(antRoutes);
            }

            return bestRoute;
        }

        private async Task<List<List<int>>> GenerateAntRouteAsync(CancellationToken ct)
        {
            var tasks = Enumerable.Range(0, AntCount).Select(_ => Task.Run(() => BuildAntRoute(ct), ct));
            var routes = await Task.WhenAll(tasks);
            return routes.Where(r=>r !=null && r.Count>0).ToList()!;
        }

        private List<int>? BuildAntRoute(CancellationToken ct)
        {
            var route = new List<int> { 0 }; // Start at depot (index 0)
            var visited = new HashSet<int> { 0 };
            var remaining = new HashSet<int>(Enumerable.Range(1, _orders.Count));

            // Track current load
            double currentWeight = 0;
            double currentVolume = 0;

            while(remaining.Any() && !ct.IsCancellationRequested)
            {
                var next  = SelectNextNode(route.Last(), visited, remaining, ref  currentWeight, ref currentVolume);
                if(next == -1)break; // No feasible next node

                route.Add(next);
                visited.Add(next);
                remaining.Remove(next);

                // Update load if this is a delivery (simplified logic - enhance for pickup/delivery pairs)
                if(next > 0)
                {
                    var demand = _demands[_orders[next - 1].Id];
                    currentVolume += demand.volume;
                    currentWeight += demand.weight;
                }
            }

            route.Add(0);//Return to depot
            return ValidateConstraints(route) ? route : null;
        }

        private bool ValidateConstraints(List<int> route)
        {
            // Implement comprehensive constraint validation:
            // 1. Capacity limits
            // 2. Time windows
            // 3. Pickup before delivery for paired orders
            // 4. Driver working hours

            double currentWeight = 0;
            foreach (var node in route.Skip(1).Take(route.Count - 2)) // Skip depot nodes
            {
                var order = _orders[node - 1];
                currentWeight += _demands[order.Id].weight;

                if (currentWeight > (double)_vehicle.MaxWeight) 
                    return false;
            }
            return true;
        }

        private int SelectNextNode(int currentNode, HashSet<int> visited, HashSet<int> remaining, 
            ref double currentWeight, ref double currentVolume)
        {
            var candidates = new List<int>();

            foreach (var idx in remaining)
            {
                double testWeight = currentWeight;
                double testVolume = currentVolume;
                if (IsFeasibleTransition(currentNode, idx, ref testWeight, ref testVolume))
                {
                    candidates.Add(idx);
                }
            }

            if (!candidates.Any()) return -1;

            // Calculate probabilities using ACO transition rule
            var probabilities = new List<(int node, double prob)>();
            double total = 0.0;

            foreach (var candidate in candidates)
            {
                double pheromone = Math.Pow(_pheromones[currentNode, candidate], Alpha);
                double heuristic = Math.Pow(_heuristics[currentNode, candidate], Beta);
                double prob = pheromone * heuristic;
                total += prob;
                probabilities.Add((node: candidate, prob: prob)); // Explicitly name tuple elements
            }

            if (total == 0) return candidates[_random.Next(candidates.Count)];

            // Roulette wheel selection
            double rand = _random.NextDouble() * total;
            double cumulative = 0.0;
            foreach (var (node, prob) in probabilities)
            {
                cumulative += prob;
                if (rand <= cumulative) return node;
            }

            return candidates.Last();
        }

        private bool IsFeasibleTransition(int from, int to, ref double currentWeight, ref double currentVolume)
        {
            // Vehicle capacity constraints
            if (to > 0) // Not depot
            {
                var order = _orders[to - 1];
                var demand = _demands[order.Id];

                // Check weight capacity
                if (currentWeight + demand.weight > (double)_vehicle.MaxWeight)////Object reference not set to an instance of an object
                    return false;

                // Check volume capacity (simplified - use actual dimension math)
                var itemVolume = demand.volume;
                var vehicleVolume = (double)_vehicle.Length * (double)_vehicle.Width * (double)_vehicle.Height;
                if (currentVolume + itemVolume > vehicleVolume * 0.85) // 85% utilization limit
                    return false;

            }
            return true;
        }

        private double CalculateRouteDistance(List<int> route)
        {
            double total = 0;
            for (int i = 0; i < route.Count - 1; i++)
            {
                total += _distances[route[i], route[i + 1]];
            }
            return total;
        }

        private void UpdatePheromones(List<List<int>> antRoutes)
        {
            //Evaporation
            var n  = _pheromones.GetLength(0);
            for(int i = 0;i < n; i++)
            {
                for(int j=0; j < n; j++)
                {
                    _pheromones[i, j] *= (1 - Rho);
                }
            }

            //Deposit pheromones proportional to the solution quality
            foreach(var route in antRoutes)
            {
                var distance = CalculateRouteDistance(route);
                var deposit = Q / distance;

                for(int i = 0;i<route.Count - 1; i++)
                {
                    _pheromones[route[i], route[i + 1] ] += deposit;// Asymetric
                }
            }
        }
    }
}
