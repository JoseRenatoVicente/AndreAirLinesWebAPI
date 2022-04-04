using AndreAirLines.Application.Services;
using AndreAirLines.Application.Services.Interfaces;
using AndreAirLines.Infra.Data;
using AndreAirLines.Infra.Data.Repository;
using AndreAirLines.Infra.Data.Repository.Interfaces;
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
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IBasePriceService, BasePriceService>();
            services.AddScoped<IAirportService, AirportService>();

            //repositories
            services.AddScoped<IAircraftRepository, AircraftRepository>();
            services.AddScoped<IAirportRepository, AirportRepository>();
            services.AddScoped<IBasePriceRepository, BasePriceRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IFlightRepository, FlightRepository>();
            services.AddScoped<IPassengerRepository, PassengerRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            //seeder
            services.AddScoped<AndreAirLinesAPISeed>();

        }
    }
}
