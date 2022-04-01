using AndreAirLines.Domain.Entities;
using AndreAirLines.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace AndreAirLines.Infra.Data
{
    public class AndreAirLinesAPIContext : DbContext
    {
        public AndreAirLinesAPIContext(DbContextOptions<AndreAirLinesAPIContext> options)
            : base(options)
        {
        }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Aeronave> Aeronave { get; set; }
        public DbSet<Aeroporto> Aeroporto { get; set; }
        public DbSet<Passageiro> Passageiro { get; set; }
        public DbSet<Passagem> Passagem { get; set; }
        public DbSet<Voo> Voo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PassageiroMap());
        }

    }
}
