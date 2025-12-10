namespace Lab_4_PAD.Models
{
    public class PostViewModel
    {
        public string Author { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Created { get; set; } = DateTime.Now;

    }
}
