using System.ComponentModel.DataAnnotations;

namespace Lab_4_PAD.Models
{
    public class CreatePostViewModel
    {
        [Required]
        public string Author { get; set; }

        [Required] 
        public string Content { get; set; }
    }
}
