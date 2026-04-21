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
        public DateOnly MakeYear { get; set; }
        [Required]
        [StringLength(50)]
        public string Color {  get; set; }
        [Required]
        [StringLength(10)]
        public string LicensePlate { get; set; }
        [Required]
        [Column(TypeName ="decimal(8,2)")]
        public decimal MaxWeight {  get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Length { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Width { get; set; }
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Height { get; set; }
        //[Required]
        [MaxLength(255)]
        public string FileName { get; set; } = string.Empty;
        //[Required]
        [MaxLength(100)]
        public string ContentType { get; set; } = string.Empty;
        //[Required]
        [Column(TypeName = "VARBINARY(MAX)")]
        public byte[] ImageData { get; set; } = Array.Empty<byte>();
        public long FileSize { get; set; }
        public DateTime UploadedDate { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public int DriverId {  get; set; }
        public virtual Driver? Driver { get; set; }
    }
}
