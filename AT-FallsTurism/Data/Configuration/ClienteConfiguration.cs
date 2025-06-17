using AT_FallsTurism.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.Metrics;

namespace AT_FallsTurism.Data.Configuration {
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente> {
        public void Configure(EntityTypeBuilder<Cliente> builder) {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id_cliente");
            builder.Property(c => c.Nome).HasColumnName("nome_cliente").HasMaxLength(50).IsRequired();
            builder.Property(c => c.Email).HasColumnName("email_cliente").HasMaxLength(100).IsRequired();
            builder.HasIndex(c => c.Email).IsUnique();

            builder.HasData(
                new Cliente { Id = 1, Nome = "Maria Silva", Email = "maria@email.com" },
                new Cliente { Id = 2, Nome = "Leandro Santos", Email = "leandro@email.com" }
            );
        }
    }
}
