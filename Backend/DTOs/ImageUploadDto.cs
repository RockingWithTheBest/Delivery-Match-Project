using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class ImageUploadDto
    {
        [Required]
        public IFormFile Image { get; set; } = null!;
        [MaxLength(500)]
        public string? Description { get; set; }
        
    }

    public class ImageResponseDto
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public DateTime UploadedDate { get; set; }
        public string? Description { get; set; }
        public string ImageBase64 { get; set; } = string.Empty; // For displaying the image
        public string ImageUrl { get; set; } = string.Empty; // API endpoint to get the image
    }
}
