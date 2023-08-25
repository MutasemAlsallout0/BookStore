using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.AuthenticationDto.Request
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
