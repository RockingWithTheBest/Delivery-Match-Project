using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Brand {  get; set; }
        [Required]
        [StringLength(50)]
        public string Model { get; set; }
        [Required]
        public DateOnly Make_Year { get; set; }
        [Required]
        [StringLength(50)]
        public string Color {  get; set; }
        [Required]
        [StringLength(10)]
        public string License_Plate { get; set; }
        [Required]
        [Column(TypeName ="decimal(8,2)")]
        public decimal Max_Weight {  get; set; }
        //[Required]
        //[Column(TypeName = "decimal(8,2)")]
        //public decimal Max_Volume { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Length { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Width { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Height { get; set; }

        public int DriverId {  get; set; }

        public virtual Driver? Driver { get; set; }
    }
}
