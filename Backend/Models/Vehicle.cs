using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand {  get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public DateOnly Make_Year { get; set; }
        [Required]
        public string Color {  get; set; }
        [Required]
        public string License_Plate { get; set; }
        [Required]
        [Column(TypeName ="decimal(8,2)")]
        public decimal Max_Weight {  get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Max_Volume { get; set; }
        [Required]
        public int DriverId {  get; set; }

        public virtual Driver? Driver { get; set; }
    }
}
