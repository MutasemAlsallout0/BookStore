using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.BookDto.Request
{
    public class CreateBookRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public decimal Price { get; set; }


        public int? Discount { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }
        [Required]

        public string About { get; set; }

        [Required]

        public int? PublishYear { get; set; }
        [Required]

        public int? PageCount { get; set; }
        [Required]

        public int? AuthorId { get; set; }

        public int? TranslatorId { get; set; }

        [Required]

        public int? PublisherId { get; set; }
        [Required]

        public int? CategoryId { get; set; }

    }





}
