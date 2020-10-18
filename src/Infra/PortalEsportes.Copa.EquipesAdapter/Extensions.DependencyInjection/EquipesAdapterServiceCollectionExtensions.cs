using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PortalEsportes.Copa.Domain.Adapters;
using PortalEsportes.Copa.EquipesAdapter.Clients;
using System;
using System.Diagnostics.CodeAnalysis;

namespace PortalEsportes.Copa.EquipesAdapter.Extensions.DependencyInjection
{
    public static class EquipesAdapterServiceCollectionExtensions
    {
        [ExcludeFromCodeCoverage]
        public static IServiceCollection AddEquipesAdapter(
            this IServiceCollection services,
            EquipesAdapterConfiguration equipesAdapterConfiguration)
        {
            if (equipesAdapterConfiguration is null)
            {
                throw new ArgumentNullException(nameof(equipesAdapterConfiguration));
            }

            services.AddSingleton(equipesAdapterConfiguration);

            services.AddHttpClient("Refit", options =>
            {
                options.BaseAddress = new Uri(equipesAdapterConfiguration.ApiUrlBase);
            })
            .AddTypedClient(Refit.RestService.For<IEquipesApi>);

            services.AddScoped<IEquipesAdapter, EquipesAdapter>();

            services.AddAutoMapper(typeof(EquipeMapperProfile));

            return services;
        }
    }
}
