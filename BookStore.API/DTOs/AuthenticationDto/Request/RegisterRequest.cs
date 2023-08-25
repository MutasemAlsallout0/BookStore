using System.ComponentModel.DataAnnotations;

namespace BookStore.API.DTOs.AuthenticationDto.Request
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]

        public string Password { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
    }
}
