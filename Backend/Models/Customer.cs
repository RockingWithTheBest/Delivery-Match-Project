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
        public string Business_Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Business_Type { get; set; }
        public string Tax_Identification { get; set; }
        [StringLength(20)]
        public string Rating { get;set; }
        [Required]
        public int Total_Orders { get; set; }
        [Column(TypeName ="decimal(10,2)")]
        public decimal Total_Spent { get; set; }
        [Required]
        public int UserId {  get; set; }

        public virtual User User { get; set; }
    }
}
