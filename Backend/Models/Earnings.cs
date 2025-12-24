using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Earnings
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="decimal(10,2)")]
        public decimal GrossAmount {  get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal PlatformFee { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal NetEarnings { get;  set; }
        [StringLength(30)]
        public string IsPaidOut {  get; set; }
        public DateOnly EarnedAt {  get; set; }
        public int? DriverId {  get; set; }
        public int? OrderPlacementId { get; set; }

        public virtual OrderPlacement? OrderPlacement { get; set; }
        public virtual Driver? Driver { get; set; }
    }
}
