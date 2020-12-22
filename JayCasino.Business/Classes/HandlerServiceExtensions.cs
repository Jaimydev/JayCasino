using JayCasino.Business.Handlers;
using JayCasino.Business.Interfaces;
using JayCasino.Data.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace JayCasino.Business.Classes
{
    public static class HandlerServiceExtensions
    {
        /// <summary>
        /// Adds the handlers.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddServices();

            services.AddScoped<IPlayerHandler, PlayerHandler>();


            return services;
        }
    }
}
