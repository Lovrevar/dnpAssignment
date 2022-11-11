using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Models.Account
{
    public class EditPost
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        
      
        
        

        public EditPost() { }

        public EditPost(Post post)
        {
            Title = post.title;
            Content = post.content;

        }
    }
}