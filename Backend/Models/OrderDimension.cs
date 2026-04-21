using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class OrderDimension
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Length { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Height { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Width { get; set; }

        [Required]
        public int OrderItemsId { get; set; }
        public virtual OrderItems? OrderItems {  get; set; }
    }
}
