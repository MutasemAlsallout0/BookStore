using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.BookReviewsDto.Request
{
    public class AddBookReviewRequest
    {
       
        

        [Required]

        [Range(1,5)]
        public int? Rate { get; set; }
        [Required]

        public string Comment { get; set; }
    }
}
