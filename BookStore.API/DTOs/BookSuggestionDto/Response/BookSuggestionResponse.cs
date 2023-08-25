namespace BookStore.API.DTOs.BookSuggestionDto.Response
{
    public class BookSuggestionResponse
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Email { get; set; }


        public string PublisherName { get; set; }
        public string AuthorName { get; set; }
        public string Notes { get; set; }
        public DateTime? ReadAt { get; set; } 
        public DateTime CreatedAt { get; set; } 
    }
}
