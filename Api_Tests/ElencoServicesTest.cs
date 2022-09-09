using System.Net;
using AutoMapper;
using Dominio.DTOs.ElencoDtos;
using Dominio.Entities;
using Dominio.Enums;
using Dominio.Interfaces.Data;
using Moq;
using Service.Profiles;
using Service.Services;


namespace Api_Tests
{
    public class ElencoServicesTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IElencoRepository> _eRepository =  new Mock<IElencoRepository>();
        private readonly List<Elenco> _elencoContext;
        public ElencoServicesTest()
        {
            var mapperConfg = new MapperConfiguration(confg =>
            {
                confg.AddProfile(new ElencoProfile());
            });
            IMapper mapper = mapperConfg.CreateMapper();
            _mapper = mapper;

            _eRepository.Setup(e => e.Add(It.IsAny<Elenco>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Elenco elenco, CancellationToken ct) 
                => { _elencoContext!.Add(elenco);return elenco; });
            _eRepository.Setup(e => e.GetById(It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((int elencoId, CancellationToken ct) 
                => _elencoContext!.FirstOrDefault(elenco=> elenco.Id == elencoId));
            _eRepository.Setup(e => e.GetElencoByName(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((string nome, CancellationToken ct)
                => _elencoContext!.FirstOrDefault(elenco=> elenco.Nome == nome));

            var context = new List<Elenco>()
            {
                new Elenco()
                {
                    Id = 1,
                    Nome = "Leonardo DiCaprio",
                    DataDeNascimento = DateTime.Parse("11/11/1986"),
                    Ativo = true,
                    Papel = ElencoPapel.Ator,
                    Filmes = new List<Filme>()
                },
                new Elenco()
                {
                    Id = 2,
                    Nome = "Morgan Freeman",
                    DataDeNascimento = DateTime.Parse("07/12/1974"),
                    Ativo = true,
                    Papel = ElencoPapel.Ator,
                    Filmes = new List<Filme>()
                },
                new Elenco()
                {
                    Id = 3,
                    Nome = "Peter Jackson",
                    DataDeNascimento = DateTime.Parse("07/12/1974"),
                    Ativo = true,
                    Papel = ElencoPapel.Diretor,
                    Filmes = new List<Filme>()
                }
            };
            _elencoContext = context;
        }
        [Fact]
        public async Task CastrarElencoSucesso()
        {
            var request = new CadastrarElencoDto()
            {
                Nome = "Zezeee",
                DataDeNascimento = "02/05/1996",
                Papel = "Ator",
            };

            var cadastraService = new ElencoService(_mapper, _eRepository.Object);
            var result = await cadastraService.CadastrarElenco(request, CancellationToken.None);

            Assert.True(result.Sucesso);
            Assert.Equal(HttpStatusCode.OK, result.Status);
            Assert.Empty(result.Mensagem);
        }

        [Fact]
        public async Task CadastrarElencoJaExistente()
        {
            var request = new CadastrarElencoDto()
            {
                Nome = "Morgan Freeman",
                DataDeNascimento = "07/12/1974",
                Papel = "Ator"
            };

            var cadastraService = new ElencoService(_mapper,_eRepository.Object);
            var result = await cadastraService.CadastrarElenco(request, CancellationToken.None);

            Assert.False(result.Sucesso);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
            Assert.NotEmpty(result.Mensagem);
        }

        [Fact]
        public async Task CadastrarElencoSemNome()
        {
            var request = new CadastrarElencoDto()
            {
                Nome = "",
                DataDeNascimento = "07/12/1974",
                Papel = "Ator"
            };

            var cadastraService = new ElencoService(_mapper, _eRepository.Object);
            var result = await cadastraService.CadastrarElenco(request, CancellationToken.None);

            Assert.False(result.Sucesso);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
            Assert.NotEmpty(result.Mensagem);
        }
        [Theory]
        [InlineData(1)]
        public async Task DeletarElencoSucesso(int id)
        {
            var deleteService = new ElencoService(_mapper, _eRepository.Object);
            var result = await deleteService.Delete(id, CancellationToken.None);

            Assert.True(result.Sucesso);
            Assert.Equal(HttpStatusCode.OK, result.Status);
            Assert.Empty(result.Mensagem);
        }

        [Theory]
        [InlineData(6)]
        public async Task DeletarElencoNaoCadastrado(int id)
        {
            var deleteService = new ElencoService(_mapper,_eRepository.Object);
            var result = await deleteService.Delete(id, CancellationToken.None);

            Assert.False(result.Sucesso);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
            Assert.NotEmpty(result.Mensagem);
        }
        [Theory]
        [InlineData(1)]
        public async Task UpdateElencoSucesso(int id)
        {
            var request = new UpdateElencoDto()
            {
                Nome = "test",
                DataDeNascimento = "10/12/1900",
                Papel = "Diretor"
            };

            var updateService = new ElencoService(_mapper,_eRepository.Object);
            var result = await updateService.UpdateElenco(id, request, CancellationToken.None);

            Assert.True(result.Sucesso);
            Assert.Equal(HttpStatusCode.OK, result.Status);
            Assert.Empty(result.Mensagem);
        }

        [Theory]
        [InlineData(6)]
        public async Task UpdateElencoNaoCadastrado(int id)
        {
            var request = new UpdateElencoDto()
            {
                Nome = "test",
                DataDeNascimento = "10/12/1900",
                Papel = "Diretor"
            };

            var updateService = new ElencoService(_mapper, _eRepository.Object);
            var result = await updateService.UpdateElenco(id, request, CancellationToken.None);

            Assert.False(result.Sucesso);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
            Assert.NotEmpty(result.Mensagem);
        }

        [Theory]
        [InlineData(1)]
        public async Task UpdateElencoNomeNaoAtendeOsRequisitos(int id)
        {
            var request = new UpdateElencoDto()
            {
                Nome = "t",
                DataDeNascimento = "10/12/1900",
                Papel = "Diretor"
            };

            var updateService = new ElencoService(_mapper, _eRepository.Object);
            var result = await updateService.UpdateElenco(id, request, CancellationToken.None);

            Assert.False(result.Sucesso);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
            Assert.NotEmpty(result.Mensagem);
        }
    }
}
