using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AndreAirLines.Infra.Data
{
    public class AndreAirLinesAPIContext : DbContext
    {
        public AndreAirLinesAPIContext(DbContextOptions<AndreAirLinesAPIContext> options)
            : base(options)
        {
        }
        public DbSet<Address> Address { get; set; }
        public DbSet<Aircraft> Aircraft { get; set; }
        public DbSet<Airport> Airport { get; set; }
        public DbSet<Passenger> Passenger { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<BasePrice> BasePrice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new AircraftMap());
            modelBuilder.ApplyConfiguration(new AirportMap());
            modelBuilder.ApplyConfiguration(new BasePriceMap());
            modelBuilder.ApplyConfiguration(new ClassMap());
            modelBuilder.ApplyConfiguration(new PassengerMap());
            modelBuilder.ApplyConfiguration(new TicketMap());
        }
    }
}
