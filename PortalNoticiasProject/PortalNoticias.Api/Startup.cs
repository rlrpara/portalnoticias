using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PortalNoticias.Infra.CrossCutting.IoC;
using PortalNoticias.Infra.CrossCutting.Swagger;
using PortalNoticias.Services.AutoMapper;
using System.Reflection;

namespace PortalNoticias.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var swaggerName = $"{Assembly.GetExecutingAssembly().GetName().Name.Replace(".", "")}.xml";

            services.AddControllers();
            NativeInjector.RegisterServices(services, Configuration);
            services.AddAutoMapper(typeof(AutoMapperSetup));
            services.AddSwaggerConfiguration(swaggerName);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
