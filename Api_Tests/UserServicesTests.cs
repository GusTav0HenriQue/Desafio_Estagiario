
using System.Net;
using AutoMapper;
using Dominio.DTOs.UserDtos;
using Dominio.Entities;
using Dominio.Enums;
using Dominio.Interfaces.Cryptograph;
using Dominio.Interfaces.Data;
using Dominio.Utils.Cryptografia;
using Moq;
using Service.Profiles;
using Service.Services;

namespace Api_Tests
{
    public class UserServicesTest 
    {
        
        private readonly Mock<IUserRepository> _uRepository = new Mock<IUserRepository>();
        private readonly Mock<ITokenService> _token = new Mock<ITokenService>();
        private readonly ICryptograph _cryptograph = new Cryptograph();
        private readonly List<User> _context;
        private readonly IMapper _mapper;

        public UserServicesTest()
        {
            var context = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Nome = "Admin",
                    Email = "Admin",
                    PassWord = _cryptograph.EncryptPassword("Admin123"),
                    Ativo = true,
                    CargoDoUsuario = UserCargo.Administrador
                },
                new User()
                {
                    Id = 2,
                    Nome = "Test",
                    Email = "test@imdbapi.com",
                    PassWord =  _cryptograph.EncryptPassword("teste123"),

                    Ativo = false,
                    CargoDoUsuario = UserCargo.Usuario
                },
                new User()
                {
                    Id = 3,
                    Nome = "Test2",
                    Email = "test2@imdbapi.com",
                    PassWord =  _cryptograph.EncryptPassword("teste1234"),

                    Ativo = true,
                    CargoDoUsuario = UserCargo.Usuario
                }
            };
            _uRepository.Setup(u => u.GetUserByEmail(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((string email, CancellationToken ct) => _context!.FirstOrDefault(user => user.Email == email));
            _uRepository.Setup(u => u.GetById(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync((int id, CancellationToken ct) => _context!.FirstOrDefault(usuario => usuario.Id == id));

            _uRepository.Setup(u => u.Add(It.IsAny<User>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(
                (User usuario, CancellationToken ct) 
                => 
                { 
                    _context!.Add(usuario); 
                    return usuario;
                }
                );
            _context = context;

            _token.Setup(t => t.GerarToken(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<string>()))
                .ReturnsAsync((string username, int id, string cargo )=> $"Email deste usuario {_context.FirstOrDefault(c=>c.Id==id).Email}");

            var mapperConfig =new MapperConfiguration(conf =>
            {
                conf.AddProfile(new UserProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            _mapper = mapper;

        }

        [Fact]
        public async Task LoginSucesso()
        {
            var request = new LoginUserDto()
            {
                Email = "Admin",
                Password = "Admin123"
            };
            var loginService = new UserService(_uRepository.Object, _mapper, _token.Object, _cryptograph);
            var result = await loginService.Login(request, CancellationToken.None);

            Assert.True(result.Sucesso);
            Assert.Empty(result.Mensagem);
            Assert.Equal(HttpStatusCode.OK, result.Status);
        }

        [Fact]
        public async Task EmailErrado()
        {
            var request = new LoginUserDto()
            {
                Email = "Admi123@",
                Password = "Admin123"
            };
            var loginService = new UserService(_uRepository.Object, _mapper, _token.Object, _cryptograph);
            var result = await loginService.Login(request, CancellationToken.None);

            Assert.False(result.Sucesso);
            Assert.NotEmpty(result.Mensagem);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
        }
        [Fact]
        public async Task SenhaErrada()
        {
            var request = new LoginUserDto()
            {
                Email = "Admin",
                Password = "Admin1234"
            };
            var loginService = new UserService(_uRepository.Object, _mapper, _token.Object, _cryptograph);
            var result = await loginService.Login(request, CancellationToken.None);

            Assert.False(result.Sucesso);
            Assert.NotEmpty(result.Mensagem);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
        }

        [Fact]
        public async Task CadastroSucesso()
        {
            var request = new CreateUserDto()
            {
                Email = "gustavo@imdbapi.com",
                Password = "Gustavo123!",
                RePassword = "Gustavo123!",
                Nome = "Gustavo"

            };

            var cadastroService = new UserService(_uRepository.Object, _mapper, _token.Object, _cryptograph);
            var result = await cadastroService.CreateUser(request, CancellationToken.None);

            Assert.True(result.Sucesso);
            Assert.Empty(result.Mensagem);
        }
        [Fact]
        public async Task CadastroEmailInvalido()
        {
            var request = new CreateUserDto()
            {
                Nome = "testy",
                Email = "test",
                Password = "test123",
                RePassword = "test123"
            };
            var cadastroService = new UserService(_uRepository.Object, _mapper, _token.Object, _cryptograph);
            var result = await cadastroService.CreateUser(request, CancellationToken.None);
            Assert.False(result.Sucesso);
            Assert.NotEmpty(result.Mensagem);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
        }

        [Fact]
        public async Task EmailJaExistente()
        {
            var request = new CreateUserDto()
            {
                Nome = "testy",
                Email = "test@imdbapi.com",
                Password = "test123",
                RePassword = "test123"
            };
            var cadastroService = new UserService(_uRepository.Object, _mapper, _token.Object, _cryptograph);
            var result = await cadastroService.CreateUser(request, CancellationToken.None);
            Assert.False(result.Sucesso);
            Assert.NotEmpty(result.Mensagem);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
        }

        [Fact]
        public async Task AsSenhasNaoSaoIguais()
        {
            var request = new CreateUserDto()
            {
                Nome = "testy",
                Email = "test@testimdb.com",
                Password = "test123",
                RePassword = "test1234"
            };
            var cadastroservice = new UserService(_uRepository.Object, _mapper, _token.Object, _cryptograph);
            var result = await cadastroservice.CreateUser(request, CancellationToken.None);
            Assert.False(result.Sucesso);
            Assert.NotEmpty(result.Mensagem);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
        }

        [Theory]
        [InlineData(3, "test2@imdbapi.com")]
        public async Task DeletarUsuario(int id , string email)
        {
            var deleteService = new UserService(_uRepository.Object, _mapper, _token.Object, _cryptograph);
            var result = await deleteService.DeleteUser(id, email, CancellationToken.None);

            Assert.True(result.Sucesso);
            Assert.Equal(HttpStatusCode.OK, result.Status);
        }

        [Theory]
        [InlineData(-1, "")]
        [InlineData(0, "")]
        public async Task DeletarUsuarioComIdNegativoOuZero(int id, string email)
        {
            var deleteService = new UserService(_uRepository.Object, _mapper, _token.Object, _cryptograph);
            var result = await deleteService.DeleteUser(id, email, CancellationToken.None);

            Assert.False(result.Sucesso);
            Assert.NotEmpty(result.Mensagem);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
        }

        [Theory]
        [InlineData(2, "test@imdbapi.com")]
        public async Task DeletarUsuarioJaDeletado(int id, string email)
        {
            var deleteService = new UserService(_uRepository.Object, _mapper, _token.Object, _cryptograph);
            var result = await deleteService.DeleteUser(id, email, CancellationToken.None);

            Assert.False(result.Sucesso);
            Assert.NotEmpty(result.Mensagem);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
        }
    }
}
