using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Address// Add GeoCoordinate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Label { get; set; }
        [StringLength(200)]
        public string? Location { get; set; }
        [StringLength(100)]
        public string? Latitude { get; set; }
        [StringLength(100)]
        public string? Longitude { get; set; }
        [Required]
        public int UserId {  get; set; }
        public virtual User? User {  get; set; }
    }
}
