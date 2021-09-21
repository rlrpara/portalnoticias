using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalNoticias.Domain.Entities;
using PortalNoticias.Domain.Interfaces;
using PortalNoticias.Infra.Data.Repositories;
using PortalNoticias.Services.Interfaces;
using System;

namespace PortalNoticias.Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            #region Services
            services.AddTransient<IBaseService<Categoria>>();

            #endregion

            #region Repositories
            services.AddTransient<IBaseRepository<Categoria>, CategoriaRepository>();

            #endregion
        }

        private static void BaseService<T>()
        {
            throw new NotImplementedException();
        }
    }
}
