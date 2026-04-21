using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class OrderPlacement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string PickUpAddress { get; set; }
        [StringLength(500)]
        public string? DeliveryUpAddress { get; set; }
        [Required]
        [StringLength(40)]
        public string PickUpContact {  get; set; }
        [Required]
        [StringLength(40)]
        public string DeliveryContact {  get; set; }
        [Required]
        [StringLength(60)]
        public string Description { get; set; }
        [Required]
        [StringLength(40)]
        public string Status {  get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price {  get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Distance { get; set; }//Use Haversine Formula to find the 
        [Required]
        public DateTime CreatedAt {  get; set; }
        [Required]
        public DateTime ScheduledAt { get; set; }
        public DateTime? CompletedOn { get; set; }
        [Required]
        public int CustomerId {  get; set; }
        public int? DriverId {  get; set; }
        public List<Notification> NotificationsPlaced { get; set; } = new List<Notification>();
        public virtual Customer? Customer { get; set; }
        //public virtual Route? Route { get; set; }
        public virtual Driver? Driver { get; set; }
        public virtual OrderItems? OrderItems { get; set; }
        public virtual OrderTracking? OrderTrackings { get; set; }
    }
}
