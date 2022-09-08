using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class FilmeMapping : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable(nameof(Filme));

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(f => f.Titulo)
                   .IsRequired()
                   .HasColumnType("varchar")
                   .HasMaxLength(100);

            builder.Property(f => f.Genero)
                   .IsRequired()
                   .HasMaxLength(15)
                   .HasColumnType("varchar");

            builder.Property(f => f.Sinopse)
                   .IsRequired()
                   .HasColumnType("varchar")
                   .HasMaxLength(190);

            builder.Property(f => f.DataDeLancamento)
                   .IsRequired();

            builder.Property(f => f.Duracao)
                   .IsRequired();

            builder.Property(f => f.AvaliacaoTotal)
                   .HasDefaultValue(0);

            builder.Property(f => f.UsuariosVotantes)
                   .HasDefaultValue(0);

            builder.HasMany(f => f.Atores)
                   .WithMany(f => f.Filmes);
        }
    }
}
