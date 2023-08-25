using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.BookSuggestionDto.Request
{
    public class PostBookSuggestionRequest
    {
        [Required]
        public string BookName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PublisherName { get; set; }
       [Required]
        public string AuthorName { get; set; }
       [Required]
        public string Notes { get; set; }
       
    }
}
