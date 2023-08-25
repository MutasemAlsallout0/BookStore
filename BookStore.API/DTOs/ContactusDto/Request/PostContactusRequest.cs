using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.ContactusDto.Request
{
    public class PostContactusRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Message { get; set; }

     
    }
}
