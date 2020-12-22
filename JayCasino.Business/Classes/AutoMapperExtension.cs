using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace JayCasino.Business.Classes
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            // Add automapper which maps database entities to DTO's
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
