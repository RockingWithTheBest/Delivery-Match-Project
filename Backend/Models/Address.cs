using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Label { get; set; }
        [Required]
        [StringLength(50)]
        public string Address_Line { get; set; }
        [Required]
        [StringLength(40)]
        public string City { get; set; }
        [Required]
        public int UserId {  get; set; }
        public virtual User? User {  get; set; }
    }
}
