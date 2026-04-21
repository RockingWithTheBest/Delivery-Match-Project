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
        //[Required]
        //[StringLength(30)]
        //public string Title {  get; set; }
        [Required]
        [StringLength(50)]
        public string Message { get; set; }
        [StringLength(500)]
        public string DriverCommentry {  get; set; }
        //[Required]
        public DateTime? CreatedAt {  get; set; }
        [Required]
        public bool? IsRead { get; set; }
        public int CustomerId {  get; set; }
        public int DriverId {  get; set; }
        [Required]
        public int OrderPlacementId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Driver? Driver { get; set; }
        public virtual OrderPlacement? OrderPlacement { get; set; }
    }
}
