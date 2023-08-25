namespace BookStore.API.Models
{
    public class StaticPages
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public string Details { get; set; }
        public string? Slug { get; set; } = null;
    }
}
