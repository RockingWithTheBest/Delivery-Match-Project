using Backend.AdditionalClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Order_Items
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Item_Name {  get; set; }
        [Required]
        public int Quantity {  get; set; }
        [Required]
        [Column(TypeName ="decimal(8,2)")]
        public decimal Weight_Per_Item { get; set; }
        [Required]
        [StringLength(50)]
        public string Special_Instructions { get; set; }
        [Required]
        public int OrderPlacementId { get; set; }

        public virtual OrderDimension? OrderDimension { get; set; }
        public virtual OrderPlacement? OrderPlacemnt {  get; set; }
    }
}
