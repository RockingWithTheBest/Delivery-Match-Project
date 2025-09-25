using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Route
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Route_Data { get; set; }
        [Required]
        public string Total_Distance { get; set; }
        public DateTime? Estimated_Duration { get; set; }
        public int DriverId {  get; set; }
        public int? Order_PlacementId {  get; set; }

        public virtual Driver? Driver { get; set; }
        public virtual OrderPlacement? Order_Placement { get; set; }
    }
}
