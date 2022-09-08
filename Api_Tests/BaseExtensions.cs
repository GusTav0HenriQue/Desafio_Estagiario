using Dominio.DTOs.UserDtos;
using Dominio.Entities;
using Dominio.Enums;

namespace Api_Tests
{
    public class BaseExtensions
    {
        protected static User TestCreateUser()
        {
            return new User()
            {
                Id = 1,
                Nome = "Test",
                Email = "test@imdbapi.com",
                PassWord = "test123!",
                
                Ativo = true,
                CargoDoUsuario = UserCargo.Usuario
            };
        }
        protected static User TestCreateAdm()
        {
            return new User()
            {
                Id = 1,
                Nome = "Admin",
                Email = "Admin",
                PassWord = "Adm123!",
                Ativo = true,
                CargoDoUsuario = UserCargo.Administrador
            };
        }

        protected static LoginUserDto LoginUser()
        {
            return new LoginUserDto()
            {
                Email = "test@imdbapi.com",
                Password = "test123!"
            };
        }

        protected static IQueryable<User> GetUserList()
        {
            var list = new List<User>()
            {
                new User()
                {
                    Ativo = true,
                    Id = 1,
                    Nome = "Test",
                    Email = "test@imdbapi.com",
                    CargoDoUsuario = UserCargo.Usuario,
                    PassWord = "test123!"
                }

            }.AsQueryable();
            return list;
        }

        protected static Filme CreateFilme(List<Elenco> elencos)
        {
            return new Filme()
            {
                Id = 1,
                Titulo = "Senhor dos Aneis",
                Sinopse = "Sinopse",
                Duracao = 180,
                Genero = "Fantasia",
                Atores = elencos,
                Ativo = true
            };
        }
        protected static IEnumerable<Filme> CreateFilmeList(List<Elenco> elencos)
        {
            var list = new List<Filme>()
            {
                new Filme()
                {
                    Id = 1,
                    Titulo = "Senhor dos Aneis",
                    Sinopse = "Sinopse",
                    Duracao = 180,
                    Genero = "Fantasia",
                    Atores = elencos,
                    Ativo = true
                }
            }.AsEnumerable();
            return list;
        }

    }
}
