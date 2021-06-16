using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalNoticias.Application.Interfaces;
using PortalNoticias.Application.Services;
using PortalNoticias.Domain.Interfaces;
using PortalNoticias.Infra.Data.Repositories;

namespace PortalNoticias.Infra.CrossCutting.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            #region Services
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IMateriaService, MateriaService>();
            services.AddTransient<IMunicipioService, MunicipioService>();
            services.AddTransient<IPerfilUsuarioService, PerfilUsuarioService>();
            services.AddTransient<IPerfilUsuarioPermissaoService, PerfilUsuarioPermissaoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            #endregion

            #region Repositories
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<IMateriaRepository, MateriaRepository>();
            services.AddTransient<IMunicipioRepository, MunicipioRepository>();
            services.AddTransient<IPerfilUsuarioRepository, PerfilUsuarioRepository>();
            services.AddTransient<IPerfilUsuarioPermissaoRepository, PerfilUsuarioPermissaoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            #endregion
        }
    }
}
