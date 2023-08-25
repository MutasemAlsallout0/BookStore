using BookStore.API.DTOs.BookDto.Repsonse;

namespace BookStore.API.DTOs.TranslatorDto
{
    public class TranslatorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class TranslatorDetailsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookResponse> Books { get; set; }
    }
}
