using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Documents
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        [StringLength(30)]
        public string DocumentType {  get; set; }
        [Required]
        [StringLength(300)]
        public string FileUrl { get; set; }
        public DateOnly ExpiryDate { get; set; }
        [Required]
        [StringLength(20)]
        public string Status {  get; set; }
        [StringLength(50)]
        public string RejectionReason { get; set; }
        public DateTime UploadedAt {  get; set; }
        [StringLength(30)]
        public string ReviewedBy {  get; set; }
        public DateTime ReviewedAt { get;  set; }
        [Required]
        public int DriverId {  get; set; }

        public virtual Driver? Driver { get; set; }
    }
}
