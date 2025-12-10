using System.ComponentModel.DataAnnotations;

namespace Lab_4_PAD.Models
{
    public class CreatePostViewModel
    {
        [Required]
        public string Author { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

    }
}
