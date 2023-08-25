using BookStore.API.DTOs.AddressDto.Response;

namespace BookStore.API.DTOs.AppUserDto.Response
{
    public class InfoResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressResponse Address { get; set; }
    }
}
