using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class OrderPlacement
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Pick_Up_Address { get; set; }
        [Required]
        [StringLength(40)]
        public string Delivery_Up_Address { get; set; }
        [Required]
        [StringLength(40)]
        public string Pick_Up_Contact {  get; set; }
        [Required]
        [StringLength(40)]
        public string Delivery_Contact {  get; set; }
        [Required]
        [Column(TypeName="decimal(8,2)")]
        public decimal Weight {  get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Volume { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Status {  get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price {  get; set; }
        public string Distance {  get; set; }
        public string Created_At {  get; set; }
        public DateTime Scheduled_At { get; set; }
        public DateTime Completed_On { get; set; }
        [Required]
        public int? CustomerId {  get; set; }
        public int? DriverId {  get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
