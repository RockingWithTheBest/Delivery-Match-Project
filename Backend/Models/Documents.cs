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
        public string File_Url { get; set; }
        public DateOnly Expiry_Date { get; set; }
        [Required]
        public string Status {  get; set; }
        public string Rejection_Reason { get; set; }
        public string Uploaded_At {  get; set; }
        public string Reviewed_By {  get; set; }
        public DateTime Reviewed_At { get;  set; }
        [Required]
        public int DriverId {  get; set; }

        public virtual Driver Driver { get; set; }
    }
}
