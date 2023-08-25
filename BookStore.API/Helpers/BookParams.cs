namespace BookStore.API.Helpers
{
    public class BookParams
    {
        public int TakeCount { get; set; } = 0;

        public string? BookName { get; set; }

        public string? AuthorName { get; set; }
        public string? publisherName { get; set; }
        public int Year { get; set; } = 0;
    }

    public class BookSalesParams
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
