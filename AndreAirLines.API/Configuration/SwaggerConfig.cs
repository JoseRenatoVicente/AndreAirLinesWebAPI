using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace AndreAirLines.API.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));


            services.AddSwaggerGen(s =>
            {

                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "AndreAirLines.API",
                    Description = "AndreAirLines ",
                    License = new OpenApiLicense { Name = "MIT" }
                });

                /*var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                s.IncludeXmlComments(xmlPath);*/

            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app is null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "AndreAirLines.API v1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
