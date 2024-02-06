using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Supermarket.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Hello World API",
                    Version = "v4",
                    Description = "Simple RESTful API built with ASP.NET Core 8 to show how to create RESTful services using a service-oriented architecture.",
                    Contact = new OpenApiContact
                    {
                        Name = "OpsVerse",
                        Url = new Uri("https://opsverse.io/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                cfg.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Hello World API");
                options.DocumentTitle = "Hello World API";
            });
            return app;
        }
    }
}
