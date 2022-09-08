using AutoMapper;
using Dominio.DTOs.FilmesDtos;
using Dominio.Entities;
using Dominio.Enums;
using Dominio.Interfaces.Data;
using Moq;
using Service.Profiles;
using Service.Services;
using System.Net;

namespace Api_Tests
{
    public class FilmeServicesTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _uRepository = new Mock<IUserRepository>();
        private readonly Mock<IFilmeRepository> _fRepository = new Mock<IFilmeRepository>();
        private readonly Mock<IAvaliacaoRepository> _aRepository = new Mock<IAvaliacaoRepository>();
        private readonly Mock<IElencoRepository> _eRepository = new Mock<IElencoRepository>();
        private readonly List<Filme> _context;
        private readonly List<Elenco> _elencoContext;

        public FilmeServicesTest()
        {
            var mapperConfig = new MapperConfiguration(conf =>
            {
                conf.AddProfile(new FilmeProfile());
                conf.AddProfile(new ElencoProfile());
                conf.AddProfile(new AvaliacaoProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            _mapper = mapper;

            var context = new List<Filme>()
            {
                new Filme
                {
                    Id = 1,
                    Titulo = "Senhor Dos Aneis",
                    Genero = "Fantasia",
                    Sinopse = "Anel do poder",
                    Duracao = 180,
                    DataDeLancamento = DateTime.Parse("02/01/2001"),
                    Diretor = "Peter Jackson",
                    Ativo = true,
                    AvaliacaoTotal = 4,
                    Atores = new List<Elenco>()
                },
                new Filme
                {
                    Id = 2,
                    Titulo = "Senhor Dos Aneis II",
                    Genero = "Fantasia",
                    Sinopse = "Anel do poder",
                    Duracao = 180,
                    DataDeLancamento = DateTime.Parse("02/01/2004"),
                    Diretor = "Peter Jackson",
                    Ativo = true,
                    AvaliacaoTotal = 4,
                    Atores = new List<Elenco>()
                }
            };
            _context = context;
            var econtext = new List<Elenco>()
            {
                new Elenco
                {
                    Id = 1,
                    Nome = "Ian McKellen",
                    Ativo = true,
                    Papel = ElencoPapel.Ator,
                    DataDeNascimento = DateTime.Parse("1939/05/25")
                }
            };
            _elencoContext = econtext;

            _fRepository.Setup(f => f.GetById(It.IsAny<int>(), It.IsAny<CancellationToken>())).ReturnsAsync((int id, CancellationToken ct) => _context.FirstOrDefault(filme => filme.Id == id));
            _fRepository.Setup(f => f.GetFilmeByTitulo(It.IsAny<string>())).Returns((string titulo) => _context.Where(filme => filme.Titulo == titulo));
            _fRepository.Setup(f => f.Add(It.IsAny<Filme>(), It.IsAny<CancellationToken>())).ReturnsAsync((Filme filme, CancellationToken ct) =>
            {
                _context.Add(filme);
                return filme;
            });
        }
        [Fact]
        public async Task CadastroValido()
        {
            var filme = new Filme()
            {
                Id = 3,
                Titulo = "Test",
                Sinopse = "muito bom dfajsiodfjasdfokjdnfalsndvja",
                Diretor = "qualquer",
                DataDeLancamento = DateTime.Parse("02/12/1998"),
                Genero = "bom",
                Duracao = 180,
                Ativo = true,
                Atores = new List<Elenco>()
            };
            var request = _mapper.Map<CreateFilmeDto>(filme);

            var cadastroService = new FilmeService(_mapper, _fRepository.Object, _uRepository.Object, _aRepository.Object, _eRepository.Object);

            var result = await cadastroService.CadastraFilme(request, CancellationToken.None);

            Assert.True(result.Sucesso);
            Assert.Equal(HttpStatusCode.OK, result.Status);
        }
        [Fact]
        public async Task FilmeJaCadastrado()
        {
            var filme = new Filme()
            {
                Titulo = "Senhor Dos Aneis",
                Genero = "Fantasia",
                Sinopse = "Anel do poder muito poderoso bixo",
                Duracao = 180,
                DataDeLancamento = DateTime.Parse("02/01/2001"),
                Diretor = "Peter Jackson",
                Ativo = true,
                Atores = new List<Elenco>()
            };

            var request = _mapper.Map<CreateFilmeDto>(filme);

            var cadastroService = new FilmeService(_mapper, _fRepository.Object, _uRepository.Object, _aRepository.Object, _eRepository.Object);

            var result = await cadastroService.CadastraFilme(request, CancellationToken.None);

            Assert.False(result.Sucesso);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
            Assert.NotEmpty(result.Mensagem);
        }

        [Theory]
        [InlineData(2)]
        public async Task DeletandoFilmeSucesso(int id)
        {
            var delService = new FilmeService(_mapper, _fRepository.Object, _uRepository.Object, _aRepository.Object, _eRepository.Object);

            var result = await delService.DeleteFilme(id, CancellationToken.None);

            Assert.True(result.Sucesso);
            Assert.Equal(HttpStatusCode.OK, result.Status);
        }

        [Theory]
        [InlineData(3)]
        public async Task DeletandoFilmeNaoCadastrado(int id)
        {
            var delService = new FilmeService(_mapper, _fRepository.Object, _uRepository.Object, _aRepository.Object, _eRepository.Object);

            var result = await delService.DeleteFilme(id, CancellationToken.None);

            Assert.False(result.Sucesso);
            Assert.Equal(HttpStatusCode.BadRequest, result.Status);
            Assert.NotEmpty(result.Mensagem);
            Assert.Equal("Esse filme em questao não existe.", result.Mensagem);
        }
        [Theory]
        [InlineData(2)]
        public async Task UpdateFilmeSucesso(int id)
        {
            var request = new UpdateFilmeDto()
            {
                Titulo = "Senhor Dos Aneis III",
                Genero = "Fantasia",
                Sinopse = "Anel do poder muito poderoso mesmo pra caramba",
                Duracao = 180,
                Elenco = new List<AttElencoFilmeDto>(),
                DataDeLancamento = "03/12/2006"

            };
            var updateService = new FilmeService(_mapper, _fRepository.Object, _uRepository.Object, _aRepository.Object, _eRepository.Object);
            var result = await updateService.UpdateFilme(id, request, CancellationToken.None);

            Assert.True(result.Sucesso);
            Assert.Equal(HttpStatusCode.OK, result.Status);
        }

    }
}
