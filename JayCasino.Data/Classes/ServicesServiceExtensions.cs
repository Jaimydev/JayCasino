using JayCasino.Data.Interfaces;
using JayCasino.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JayCasino.Data.Classes
{
    public static class ServicesServiceExtensions
    {

        /// <summary>
        /// Adds the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IGenericService, GenericService>();
            services.AddScoped<IPlayerService, PlayerService>();
            
            return services;
        }
    }
}
