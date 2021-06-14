using Microsoft.Extensions.DependencyInjection;
using PortalNoticias.Application.Interfaces;
using PortalNoticias.Application.Services;
using PortalNoticias.Domain.Interfaces;
using PortalNoticias.Infra.Data.Repositories;

namespace PortalNoticias.Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IBaseService, BaseService>();
            services.AddScoped<IBaseRepository, BaseRepository>();
        }
    }
}
