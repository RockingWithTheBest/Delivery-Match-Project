using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string BusinessName { get; set; }
        [Required]
        [StringLength(20)]
        public string BusinessType { get; set; }
        [StringLength(20)]
        public string TaxIdentification { get; set; }
        [StringLength(20)]
        public string Rating { get;set; }
        public int? TotalOrders { get; set; }
        [Column(TypeName ="decimal(10,2)")]
        public decimal? TotalSpent { get; set; }
        [Required]
        public int UserId {  get; set; }
        public List<OrderPlacement>? OrdersPlaced { get; set; } = new List<OrderPlacement>();

        public virtual User? User { get; set; }
    }
}
