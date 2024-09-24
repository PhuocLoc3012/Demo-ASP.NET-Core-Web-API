using System.ComponentModel.DataAnnotations;

namespace DemoASP.NET_CORE1.Dtos.Comment
{
    public class UpdateCommentRequestDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be at least 6 chars")]
        [MaxLength(280, ErrorMessage = "Title cannot be over 280 chars")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MinLength(5, ErrorMessage = "Content must be at least 6 chars")]
        [MaxLength(280, ErrorMessage = "Content cannot be over 280 chars")]
        public string Content { get; set; } = string.Empty;
    }
}
