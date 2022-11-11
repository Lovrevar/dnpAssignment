using System.ComponentModel.DataAnnotations;
namespace BlazorApp.Models.Account

{
    public class AddPost
    {
        
        
        [Required]
        public int postId { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
            
        
    }
}