using Data.Seeds;
using Dominio.Entities;
using Dominio.Utils.Cryptografia;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);

            var crypto = new Cryptograph();
            var senha = crypto.EncryptPassword("Administrador");
            new SeedInitialUser(modelBuilder).SeedUser(senha);
        }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Elenco> Elencos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

    }
}
