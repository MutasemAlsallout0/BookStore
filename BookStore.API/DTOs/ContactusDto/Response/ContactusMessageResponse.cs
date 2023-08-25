namespace BookStore.API.DTOs.ContactusDto.Response
{
    public class ContactusMessageResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Message { get; set; }

        public DateTime? ReadAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
