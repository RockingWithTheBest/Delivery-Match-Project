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
        public DateOnly EarnedAt {  get; set; }
        [StringLength(50)]
        public string Status {  get; set; }
        public int? DriverId {  get; set; }
        public int? OrderPlacementId { get; set; }

        public virtual OrderPlacement? OrderPlacement { get; set; }
        public virtual Driver? Driver { get; set; }
    }
}
