using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    internal class ElencoMapping : IEntityTypeConfiguration<Elenco>
    {
        public void Configure(EntityTypeBuilder<Elenco> builder)
        {
            builder.ToTable(nameof(Elenco));

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.Nome)
                   .IsRequired()
                   .HasColumnType("varchar").HasMaxLength(100);

            builder.Property(e => e.DataDeNascimento)
                   .IsRequired();

            builder.Property(e => e.Papel)
                   .IsRequired();


            builder.HasMany(e => e.Filmes).WithMany(e => e.Atores);

            builder.Property(e=>e.Ativo).HasDefaultValue(false).IsRequired();


        }
    }
}
