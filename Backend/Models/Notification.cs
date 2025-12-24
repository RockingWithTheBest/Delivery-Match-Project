using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public string Type {  get; set; }
        [Required]
        [StringLength(30)]
        public string Title {  get; set; }
        [Required]
        [StringLength(50)]
        public string Message { get; set; }
        public bool? IsRead { get; set; }
        public int? UserId {  get; set; }

        public virtual User? User { get; set; }
    }
}
