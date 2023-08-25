namespace BookStore.API.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public List<Book>? Books { get; set; }

    }
}
