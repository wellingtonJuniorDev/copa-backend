using Microsoft.Extensions.DependencyInjection;
using PortalEsportes.Copa.Domain.Services;
using System;

namespace PortalEsportes.Copa.Application.Extensions.DependencyInjection
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IEquipesService, EquipesService>();
            services.AddScoped<IPartidasService, PartidasService>();

            return services;
        }
    }
}
