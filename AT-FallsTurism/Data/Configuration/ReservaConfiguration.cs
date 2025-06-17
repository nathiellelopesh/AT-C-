using AT_FallsTurism.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AT_FallsTurism.Data.Configuration {
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva> {
        public void Configure(EntityTypeBuilder<Reserva> builder) {
            builder.ToTable("Reservas");

            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("id_reserva");
            builder.Property(r => r.DataReserva).HasColumnName("data_reserva");

            builder.HasOne(r => r.Cliente) // Uma Reserva TEM UM Cliente
                   .WithMany(c => c.Reservas) // Um Cliente PODE TER MÚLTIPLAS Reservas
                   .HasForeignKey(r => r.ClienteId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.PacoteTuristico)
                   .WithMany(p => p.Reservas)
                   .HasForeignKey(r => r.PacoteTuristicoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new Reserva { Id = 1, ClienteId = 1, PacoteTuristicoId = 1, DataReserva = new DateTime(2025, 03, 25) },
                new Reserva { Id = 2, ClienteId = 2, PacoteTuristicoId = 2, DataReserva = new DateTime(2025, 01, 18) }
            );
        }
    }
}
