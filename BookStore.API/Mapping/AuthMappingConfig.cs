using BookStore.API.DTOs.AddressDto.Request;
using BookStore.API.DTOs.AuthenticationDto.Request;
using BookStore.API.Models;
using Mapster;

namespace BookStore.API.Mapping
{
    public class AuthMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, AppUser>()
                .Map(dest => dest.UserName, src => src.Email);

           
        }
    }
}
