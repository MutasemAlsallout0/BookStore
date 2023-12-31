﻿using Mapster;
using MapsterMapper;
using System.Reflection;

namespace BookStore.API.Mapping
{
    public static class MapsterDependancyInjection
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {

            var config = TypeAdapterConfig.GlobalSettings;
          
            config.Scan(Assembly.GetExecutingAssembly());

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}
