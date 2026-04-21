using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Route
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RouteData { get; set; }
        [Required]
        [StringLength(20)]
        public string TotalDistance { get; set; }
        public DateTime? EstimatedDuration { get; set; }
        public int DriverId {  get; set; }
        public string TravelinSequency { get; set; }
        public virtual Driver? Driver { get; set; }
    }
}
