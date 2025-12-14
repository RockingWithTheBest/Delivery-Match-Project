using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Documents
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        [StringLength(30)]
        public string Document_Type {  get; set; }
        [Required]
        [StringLength(300)]
        public string File_Url { get; set; }
        public DateOnly Expiry_Date { get; set; }
        [Required]
        [StringLength(20)]
        public string Status {  get; set; }
        [StringLength(50)]
        public string Rejection_Reason { get; set; }
        public DateTime Uploaded_At {  get; set; }
        [StringLength(30)]
        public string Reviewed_By {  get; set; }
        public DateTime Reviewed_At { get;  set; }
        [Required]
        public int DriverId {  get; set; }

        public virtual Driver? Driver { get; set; }
    }
}
