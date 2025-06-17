using AT_FallsTurism.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AT_FallsTurism.Data.Configuration {
    public class DestinoConfiguration : IEntityTypeConfiguration<Destino> {
        public void Configure(EntityTypeBuilder<Destino> builder) {
            builder.ToTable("Destinos");

            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id).HasColumnName("id_destino");
            builder.Property(d => d.Nome).HasColumnName("nome_destino").HasMaxLength(50).IsRequired();
            builder.Property(d => d.Pais).HasColumnName("pais_destino").HasMaxLength(50).IsRequired();

            builder.HasData(
                new Destino { Id = 1, Nome = "Rio de Janeiro", Pais = "Brasil" },
                new Destino { Id = 2, Nome = "Munique", Pais = "Alemanha" }
            );
        }
    }
}
