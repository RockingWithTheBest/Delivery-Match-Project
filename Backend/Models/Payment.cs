using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Amount {  get; set; }
        [Required]
        public string Payment_Method { get; set; }
        [Required]
        [StringLength(30)]
        public string Status {  get; set; }
        [Required]
        [StringLength(30)]
        public string Transaction_Identification { get; set; }
        public string? Processed_At { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Platform_Fee { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Driver_Earnings { get; set; }
        [Required]
        public int Order_PlacementId {  get; set; }

        public virtual Order_Placement Order_Placement { get; set; }
    }
}
