using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Route
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string RouteData { get; set; }
        [Required]
        [StringLength(20)]
        public string TotalDistance { get; set; }
        public DateTime? EstimatedDuration { get; set; }
        public int DriverId {  get; set; }
        public int? OrderPlacementId {  get; set; }

        public virtual Driver? Driver { get; set; }
        public virtual OrderPlacement? OrderPlacement { get; set; }
    }
}
