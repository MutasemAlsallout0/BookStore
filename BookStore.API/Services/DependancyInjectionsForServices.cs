using BookStore.API.Interfaces.Services;

namespace BookStore.API.Services
{
    public static class DependancyInjectionsForServices
    {
        public static IServiceCollection AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
