using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Drivers_License {  get; set; }
        [Required]
        public DateOnly License_Expiry { get; set; }
        
        public bool Is_Verified { get; set; }
        [Required]
        public bool Is_Available { get; set; }
        public string Rating {  get; set; }
        public string Completion_Rate {  get; set; }
        [Column(TypeName ="decimal(10,2)")]
        public decimal Total_Earnings { get; set; }
        [Required]
        public int UserId {  get; set; }
        public List<Order_Placement>? Orders_Placed { get; set; } = new List<Order_Placement>();

        public virtual User User { get; set; }
        public virtual Documents Documents { get; set; }
    }
}
