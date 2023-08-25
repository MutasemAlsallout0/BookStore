using BookStore.API.DTOs.AuthenticationDto.Response;
using BookStore.API.Models;

namespace BookStore.API.Interfaces.Services
{
    public interface ITokenService
    {
        Task<AuthenticationResponse> Generate(AppUser user);
    }
}
