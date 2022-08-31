using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            builder.Property(u => u.Nome)
                   .IsRequired()
                   .HasColumnType("varchar")
                   .HasMaxLength(80);


            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasColumnType("varchar")
                   .HasMaxLength(180);


            builder.Property(u => u.PassWord)
                   .IsRequired();


            builder.Property(u => u.CargoDoUsuario)
                   .IsRequired();

            builder.Property(u => u.Ativo).HasDefaultValue(true);
        }
    }
}
