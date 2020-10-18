using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PortalEsportes.Copa.Api.Configuration.Mappings;

namespace PortalEsportes.Copa.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ModelsMappingProfile));
        }
    }
}
