using System.Diagnostics.Metrics;
using AT_FallsTurism.Data.Configuration;
using AT_FallsTurism.Models;
using Microsoft.EntityFrameworkCore;

namespace AT_FallsTurism.Data {
    public class FallsTurismContext : DbContext {
        public FallsTurismContext(DbContextOptions<FallsTurismContext> options)
            : base(options) { }

        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PacoteTuristico> PacotesTuristicos { get; set; }
        public DbSet<Destino> Destinos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new DestinoConfiguration());
            modelBuilder.ApplyConfiguration(new PacoteTuristicoConfiguration());
            modelBuilder.ApplyConfiguration(new ReservaConfiguration());

            // Configurar muitos-para-muitos entre PacoteTuristico e Destino
            modelBuilder.Entity<PacoteTuristico>()
                .HasMany(p => p.Destinos)
                .WithMany(d => d.PacotesTuristicos)
                .UsingEntity(j => j.HasData(
                    // Pacote "Aventura no Rio" (Id=1) está ligado a "Rio de Janeiro" (Id=1)
                    new { PacotesTuristicosId = 1, DestinosId = 1 },
                    // Pacote "Charme de Munique" (Id=2) está ligado a "Munique" (Id=2)
                    new { PacotesTuristicosId = 2, DestinosId = 2 }
                ));

        }
    }
}
