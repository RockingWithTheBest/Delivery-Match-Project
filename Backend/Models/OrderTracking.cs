using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class OrderTracking
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string PickUpLocation { get; set; }
        [Required]
        [StringLength(100)]
        public string DeliveryLocation { get; set; }
        [Required]
        [StringLength(30)]
        public string Status { get; set; }
        [Required]
        [StringLength(40)]
        public string Notes { get; set; }
        public DateTime? TimeStamps { get; set; }
        [Required]
        public int OrderPlacementId {  get; set; }

        public virtual OrderPlacement? OrderPlacement { get; set; }
    }
}
