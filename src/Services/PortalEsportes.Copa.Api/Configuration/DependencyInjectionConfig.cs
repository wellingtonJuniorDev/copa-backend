using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalEsportes.Copa.Api.Extensions;
using PortalEsportes.Copa.Application.Extensions.DependencyInjection;
using PortalEsportes.Copa.EquipesAdapter;
using PortalEsportes.Copa.EquipesAdapter.Extensions.DependencyInjection;

namespace PortalEsportes.Copa.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAplication();
            services.AddEquipesAdapter(
                configuration.SafeGet<EquipesAdapterConfiguration>(nameof(EquipesAdapterConfiguration)));
        }
    }
}
