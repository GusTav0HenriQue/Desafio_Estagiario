using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mapping
{
    public class AvaliacaoMappig : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.ToTable(nameof(Avaliacao));
            builder.HasKey(a => a.Id); 

            builder.Property(a => a.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(a => a.ValorDaAvaliacao).IsRequired();

            builder.HasOne(a => a.User)
                   .WithMany(a => a.Avaliacoes)
                   .HasForeignKey(a => a.UserId);

            builder.HasOne(a => a.Filme)
                   .WithMany(a => a.Votos)
                   .HasForeignKey(a => a.FilmeId);
        }
    }
}
