using Microsoft.OpenApi.Models;
using System.Reflection;

namespace SatrackBankSystem.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Bank System Satrack Api",
                    Description = "Permite la administracion del sistema bancario de satrack.",
                    Contact = new OpenApiContact
                    {
                        Name = "Soporte",
                        Email = "soporte@soporte.com"
                    }
                });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });

            return services;
        }
    }
}
