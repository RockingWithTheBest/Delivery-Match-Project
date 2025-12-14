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
        [StringLength(20)]
        public string Payment_Method { get; set; }
        [Required]
        [StringLength(30)]
        public string Status {  get; set; }
        [Required]
        [StringLength(30)]
        public string Transaction_Identification { get; set; }
        public DateTime? Processed_At { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Platform_Fee { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Driver_Earnings { get; set; }
        [Required]
        public int OrderPlacementId {  get; set; }

        public virtual OrderPlacement? OrderPlacement { get; set; }
    }
}
