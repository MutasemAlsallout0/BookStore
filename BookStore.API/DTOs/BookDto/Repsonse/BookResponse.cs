using BookStore.API.DTOs.AuthorDto;
using BookStore.API.DTOs.CategoryDto;
using BookStore.API.DTOs.PublisherDto;
using BookStore.API.DTOs.TranslatorDto;
using BookStore.API.Models;

namespace BookStore.API.DTOs.BookDto.Repsonse
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int PublishYear { get; set; }

        public string Image { get; set; }

        public CategoryResponse Category { get; set; }
        public AuthorResponse Author { get; set; }
        public TranslatorResponse Translator { get; set; }
        public PublisherResponse Publisher { get; set; }

     

    }

    public class SpecficBookResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

    }
}
