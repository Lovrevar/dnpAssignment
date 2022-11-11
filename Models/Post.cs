namespace BlazorApp.Models
{
    public class Post
    {
        public string title { get; set; }
        public string postId { get; set; }
        public string content { get; set;}
        public bool IsDeletingPost { get; set; }
    }
}