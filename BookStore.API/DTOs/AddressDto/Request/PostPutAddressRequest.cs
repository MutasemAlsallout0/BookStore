using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.AddressDto.Request
{
    public class PostPutAddressRequest
    {
        [Required]
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        [Required]

        public string PostalCode { get; set; }
        [Required]
        public int? ZoneId { get; set; }
    }

}
