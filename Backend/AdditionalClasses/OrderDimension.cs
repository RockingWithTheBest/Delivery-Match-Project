using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.AdditionalClasses
{
    public class OrderDimension
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Length {  get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Height {  get; set; }
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Width {  get; set; }
    }
}
