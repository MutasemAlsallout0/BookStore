namespace BookStore.API.DTOs.AuthenticationDto.Response
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
