using BookStore.API.Models;

namespace BookStore.API.DTOs.AddressDto.Response
{
    public class AddressResponse
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string PostalCode { get; set; }

        public Zone Zone { get; set; }
    }
}
