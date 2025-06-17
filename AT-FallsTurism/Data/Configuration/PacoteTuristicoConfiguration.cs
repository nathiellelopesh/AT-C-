using AT_FallsTurism.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AT_FallsTurism.Data.Configuration {
    public class PacoteTuristicoConfiguration : IEntityTypeConfiguration<PacoteTuristico> {
        public void Configure(EntityTypeBuilder<PacoteTuristico> builder) {
            builder.ToTable("PacotesTuristicos");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id_pacote_turistico");
            builder.Property(p => p.Titulo).HasColumnName("titulo_pacote_turistico").HasMaxLength(100).IsRequired();
            builder.Property(p => p.DataInicio).HasColumnName("data_pacote_turistico").IsRequired();
            builder.Property(p => p.CapacidadeMaxima).HasColumnName("capacidade_pacote_turistico").IsRequired();
            builder.Property(p => p.Preco).HasColumnName("preco_pacote_turistico").HasColumnType("decimal(18,2)").IsRequired();

            builder.HasData(
                new PacoteTuristico { Id = 1, Titulo = "Aventura no Rio", DataInicio = new DateTime(2025, 10, 15), CapacidadeMaxima = 5, Preco = 560 },
                new PacoteTuristico { Id = 2, Titulo = "Charme de Munique", DataInicio = new DateTime(2026, 03, 15), CapacidadeMaxima = 7, Preco = 1940 },
                new PacoteTuristico { Id = 3, Titulo = "Inverno na Europa", DataInicio = new DateTime(2026, 02, 02), CapacidadeMaxima = 9, Preco = 1840 },
                new PacoteTuristico { Id = 4, Titulo = "Conheça a Patagônia", DataInicio = new DateTime(2025, 07, 05), CapacidadeMaxima = 6, Preco = 1240 }
            );
        }
    }
}
