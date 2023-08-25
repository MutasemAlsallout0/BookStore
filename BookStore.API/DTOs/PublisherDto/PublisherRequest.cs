using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.PublisherDto
{
    public class PostPublisherRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public IFormFile LogoImage { get; set; }
    }


    public class PutPublisherRequest
    {
        [Required]
        public string Name { get; set; }
        public IFormFile? LogoImage { get; set; }
    }



}
