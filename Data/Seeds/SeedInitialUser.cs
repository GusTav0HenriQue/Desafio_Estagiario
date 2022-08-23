using Dominio.Entities;
using Dominio.Enums;
using Microsoft.EntityFrameworkCore;

namespace Data.Seeds
{
    public class SeedInitialUser
    {
        private readonly ModelBuilder _builder;

        public SeedInitialUser(ModelBuilder builder)
        {
            _builder = builder;
        }

        public void SeedUser(string password) 
        {
            _builder.Entity<User>().HasData(new User
            {
                Id = 1,
                Nome = "Adm",
                Email = "Admin",
                Ativo = true,
                CargoDoUsuario = UserCargo.Administrador,
                PassWord = password
            });
        }
    }
}
