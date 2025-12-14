using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Earnings
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName ="decimal(10,2)")]
        public decimal Gross_Amount {  get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Platform_Fee { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Net_Earnings { get;  set; }
        [StringLength(30)]
        public string Is_Paid_Out {  get; set; }
        public DateOnly Earned_At {  get; set; }
        public int? DriverId {  get; set; }
        public int? OrderPlacementId { get; set; }

        public virtual OrderPlacement? OrderPlacement { get; set; }
        public virtual Driver? Driver { get; set; }
    }
}
