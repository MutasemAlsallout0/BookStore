namespace BookStore.API.Models
{
    public class OrderNotification
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? ReadAt { get; set; } = null;
    }
}
