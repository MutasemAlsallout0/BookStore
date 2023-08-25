using BookStore.API.DTOs.AuthorDto;
using BookStore.API.DTOs.BookReviewsDto.Response;
using BookStore.API.DTOs.CategoryDto;
using BookStore.API.DTOs.PublisherDto;
using BookStore.API.DTOs.TranslatorDto;

namespace BookStore.API.DTOs.BookDto.Repsonse
{
    public class BookDetailsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Image { get; set; }

        public string About { get; set; }

        public int PublishYear { get; set; }
        public int PageCount { get; set; }
        public int Discount { get; set; }
        public CategoryResponse Category { get; set; }
        public AuthorResponse Author { get; set; }
        public TranslatorResponse Translator { get; set; }
        public PublisherResponse Publisher { get; set; }
        public List<DisplaySpecficBookReviewResponse> BookReviews { get; set; }
    }
}
