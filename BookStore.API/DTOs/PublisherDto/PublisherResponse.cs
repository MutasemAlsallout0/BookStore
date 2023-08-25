using BookStore.API.DTOs.BookDto.Repsonse;

namespace BookStore.API.DTOs.PublisherDto
{
    public class PublisherResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
    }


    public class PublisherDetailsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }

        public List<BookResponse> Books { get; set; }
    }

}
