namespace Backend.Models
{
    public class GeoCoordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public double DistanceTo(GeoCoordinate other) //haversine formula
        {
            const double R = 6371;//Earth radius in km
            var φ1 = Latitude * Math.PI / 180;
            var φ2 = other.Latitude * Math.PI / 180;

            var Δφ = (other.Latitude -  Latitude)*Math.PI / 180;
            var Δλ = (other.Longitude - Longitude) * Math.PI / 180;
            
            var a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) + Math.Cos(φ1) * Math.Cos(φ2) * Math.Sin(Δλ) * Math.Sin(Δλ);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;// Distance in kilometers
        }
    }
}
