using BookStore.API.Data;
using BookStore.API.Interfaces.Repositories;
using BookStore.API.Models;
using BookStore.API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookStore.API.Data
{
    public static class DataLayerDI
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddDbContext<BookStoreDbContext>(options =>
            {
                options.UseSqlServer(configurationManager.GetConnectionString("Default"));
            });

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = true;


            })
                .AddEntityFrameworkStores<BookStoreDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IAuthorRepository,AuthorRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<ITranslatorRepository,TranslatorRepository>();
            services.AddScoped<IPublisherRepository,PublisherRepository>();
            services.AddScoped<IZoneRepository,ZoneRepository>();
            services.AddScoped<IBookRepository,BookRepository>();
            services.AddScoped<ISalesRepository,SalesRepository>();
            services.AddScoped<IAddressRepository,AddressRepository>();
            services.AddScoped<IStaticPagesRepository,StaticPagesRepository>();
            services.AddScoped<IContactusRepository,ContactusRepository>();
            services.AddScoped<IBookSuggestionsRepository,BookSuggestionsRepository>();

            return services;
        }


        public static IServiceCollection AddAuthLayer(this IServiceCollection services, ConfigurationManager configuration)
        {
            services
               .AddAuthentication(options =>
               {
                   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               })
               .AddJwtBearer(options => options.TokenValidationParameters =
               new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidAudience = configuration["JWT:ValidAudience"],
                   ValidIssuer = configuration["JWT:ValidIssuer"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secert"])),
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.Zero
               });
            return services;
        }
    }
}
