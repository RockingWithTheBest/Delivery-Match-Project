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
        public string Is_Paid_Out {  get; set; }
        public string Earned_At {  get; set; }
        public int? DriverId {  get; set; }
        public int? Order_PlacementId { get; set; }

        public virtual OrderPlacement? Order_Placement { get; set; }
        public virtual Driver? Driver { get; set; }
    }
}
