namespace BookStore.API.Models
{
    public class Contactus
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Message { get; set; }

        public DateTime? ReadAt { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
