using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Order_Tracking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Latitude { get; set; }
        [Required]
        [StringLength(40)]
        public string Longitude { get; set; }
        [Required]
        [StringLength(30)]
        public string Status { get; set; }
        [Required]
        [StringLength(40)]
        public string Notes { get; set; }
        public DateTime? TimeStamps { get; set; }
        [Required]
        public int? OrderPlacementId {  get; set; }

        public virtual OrderPlacement? OrderPlacement { get; set; }
    }
}
