using AndreAirLines.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AndreAirLines.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            //services
            services.AddScoped<ViaCepService>();

        }
    }
}
