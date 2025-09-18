using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Order_Tracking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Notes { get; set; }
        public DateTime? TimeStamps { get; set; }
        [Required]
        public int Order_PlacementId {  get; set; }

        public virtual Order_Placement Order_Placement { get; set; }
    }
}
