using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
        [Required]
        [StringLength(20)]
        public string First_Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Last_Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
