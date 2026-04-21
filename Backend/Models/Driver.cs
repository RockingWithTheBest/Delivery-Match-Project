using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string DriversLicense {  get; set; }
        [Required]
        public DateOnly LicenseExpiry { get; set; }
        
        public bool IsVerified { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [StringLength(10)]
        public string Rating {  get; set; } 
        [StringLength(30)]
        public string CompletionRate {  get; set; }
        [Column(TypeName ="decimal(10,2)")]
        public decimal TotalEarnings { get; set; }
        [Required]
        public int UserId {  get; set; }
        public List<OrderPlacement>? OrdersPlaced { get; set; } = new List<OrderPlacement>();
        public List<Notification> NotificationsPlaced { get; set; } = new List<Notification>();
        public virtual User? User { get; set; }
    }
}
