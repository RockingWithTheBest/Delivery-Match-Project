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
        public string Title {  get; set; }
        [Required]
        public string Message { get; set; }
        public bool? Is_Read { get; set; }
        public int? User_Id {  get; set; }

        public User User { get; set; }
    }
}
