using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace PortalNoticias.Infra.CrossCutting.Swagger
{
    public static class SwaggerSetup
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, string swaggerName)
        {
            return services.AddSwaggerGen(x => {
                x.SwaggerDoc("v1", new OpenApiInfo
                { 
                    Title = "Portal de Notícias",
                    Version = "v1",
                    Description = "Api de notícias desenvolvido em .Net Core e Blazor",
                    Contact = new OpenApiContact
                    {
                        Name = "Rodrigo de L. Ribeiro",
                        Email = "rlr.para@gmail.com",
                        Url = new Uri(Environment.GetEnvironmentVariable("URL_SITE"))
                    }
                });

                x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, swaggerName));
            });
        }

        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            return app.UseSwagger().UseSwaggerUI(x =>
            {
                x.RoutePrefix = "documentation";
                x.SwaggerEndpoint("../swagger/v1/swagger.json", "API v1");
            });
        }
    }
}
