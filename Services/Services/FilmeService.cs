using System.Net;
using AutoMapper;
using Dominio.Config;
using Dominio.DTOs.ElencoDtos;
using Dominio.DTOs.FilmesDtos;
using Dominio.Entities;
using Dominio.Interfaces.Data;
using Service.Helpers;
using Service.Interfaces;
using Service.Validator.Avaliacao;
using Service.Validator.Filme;


namespace Service.Services
{
    public class FilmeService : AbstractService, IFilmeService
    {
        private readonly IMapper _mapper;
        private readonly IFilmeRepository _fRepository;
        private readonly IUserRepository _uRepository;
        private readonly IAvaliacaoRepository _aRepository;
        private readonly IElencoRepository _eRepository;
        public FilmeService(IMapper mapper, IFilmeRepository fRepository, IUserRepository uRepository, IAvaliacaoRepository aRepository, IElencoRepository eRepository)
        {
            _mapper = mapper;
            _fRepository = fRepository;
            _uRepository = uRepository;
            _aRepository = aRepository;
            _eRepository = eRepository;
        }

        public async Task<ResponseService> CadastraFilme(CreateFilmeDto createfilmeDto, CancellationToken cancellationToken)
        {
            if (!RealizarValidacao(new CreateFilmeDtoValidator(), createfilmeDto))
                return GenereteErroServiceResponse(GetNotifcacao().First());
            var filme = _fRepository.GetFilmeByTitulo(createfilmeDto.Titulo);

            try
            {
                var entity = _mapper.Map<Filme>(createfilmeDto);
                if (filme.Any())
                {
                    return GenereteErroServiceResponse("Este filme ja foi Cadastrado");
                }
                for (int i = 0; i < createfilmeDto.Elenco.Count; i++)
                {
                    ElencoFilmeDto? ator = createfilmeDto.Elenco[i];
                    var findElenco = await _eRepository.GetById(ator.Id, cancellationToken);
                    if (findElenco == null)
                        return GenereteErroServiceResponse($"O ator com esse id:{ator.Id} não existe");
                    entity.AddAtores(findElenco);
                }
                await _fRepository.Add(entity, cancellationToken);
                await _fRepository.SaveChanges(cancellationToken);
                return GenereteServiceResponseSucess("Filme Cadastrado com sucesso.");
            }
            catch
            {
                return GenereteErroServiceResponse("Erro ao cadastrar.");
            }

        }

        public async Task<ResponseService> DeleteFilme(int id, CancellationToken cancellationToken)
        {
            if (VerificarId(id))
                return GenereteErroServiceResponse("O id precisa ser maior que 0.");
            var filmeTarget = await _fRepository.GetById(id, cancellationToken);

            if (filmeTarget == null)
                return GenereteErroServiceResponse("Esse filme em questao não existe.");

            await _fRepository.Delete(filmeTarget, cancellationToken);

            return GenereteServiceResponseSucess(filmeTarget);
        }

        public ResponseService<IEnumerable<ReadFilmeDto>> GetAllFilmes()
        {
            var filme = _fRepository.GetAllFilmesComAtor();
            if (!filme.Any())
                return GenerateErroServiceResponse<IEnumerable<ReadFilmeDto>>("Não possui nehnhum filme ainda.");
            var mapperFilme = _mapper.Map<IEnumerable<ReadFilmeDto>>(filme);

            return GenereteServiceResponseSucess(mapperFilme);
        }

        public  ResponseService GetFilmeByAvaliacao()
        {
            var filmes = _fRepository.GetAll();
            var ordem = filmes.OrderBy(f => f.Titulo).ThenBy(f => f.AvaliacaoTotal).ToList();

            return GenereteServiceResponseSucess(ordem);
        }

        public ResponseService<IEnumerable<Filme>> GetFilmeByFiltros(ObterTodosFilmesDto obterTodosFilmesDto)
        {
            var filmes = _fRepository.GetFilmesFiltro(obterTodosFilmesDto);
            if (!filmes.Any())
                return GenerateErroServiceResponse<IEnumerable<Filme>>("Filmes não encontrados", HttpStatusCode.NotFound);
           
            return GenereteServiceResponseSucess(filmes);
        }

        public async Task<ResponseService<ReadDetailFilmeDto>> GetFilmesDetail(int id, CancellationToken cancellation)
        {
            if (!VerificarId(id))
                GenerateErroServiceResponse<IEnumerable<ReadDetailFilmeDto>>("O id precisa ser maior que 0.");

            var filme = await _fRepository.GetFilmesbyAtor(id, cancellation);
            var Filmemedia = 0;

            if (filme == null)
                return GenerateErroServiceResponse<ReadDetailFilmeDto>("Esse filme não existe.");

            if (filme.UsuariosVotantes != 0)
            {
                Filmemedia = filme.AvaliacaoTotal / filme.UsuariosVotantes;
            }
            ReadDetailFilmeDto filmeAtt = new()
            {
                Id = filme.Id,
                Titulo = filme.Titulo,
                Sinopse = filme.Sinopse,
                Genero = filme.Genero,
                Avaliacao = Filmemedia,
                Duracao = filme.Duracao,
                Atores = _mapper.Map<List<ElencoDto>>(filme.Atores)
            };
            return GenereteServiceResponseSucess(filmeAtt);
        }

        public async Task<ResponseService> RegistrarAvaliacao(RegistraAvaliaçaoFilmeDto registraAvaliacao, CancellationToken cancellationToken)
        {
            if (!RealizarValidacao(new AvaliacaoValidator(), registraAvaliacao))
                return GenereteErroServiceResponse(GetNotifcacao().First());
            var entity = _mapper.Map<Avaliacao>(registraAvaliacao);
            var filme = await _fRepository.GetById(registraAvaliacao.FilmeId, cancellationToken);
            var usuario = await _uRepository.GetById(registraAvaliacao.UserId, cancellationToken);

            if (usuario == null)
                return GenereteErroServiceResponse($"O usuario não existe.");

            if (filme == null)
                return GenereteErroServiceResponse($"O filme não existe");

            filme.AdicionarAvaliacao(registraAvaliacao.Avaliacao);

            await _aRepository.Add(entity, cancellationToken);

            await _fRepository.SaveChanges(cancellationToken);

            return GenereteServiceResponseSucess(entity);
        }

        public async Task<ResponseService> UpdateFilme(int id, UpdateFilmeDto updatefilmeDto, CancellationToken cancellationToken)
        {
            if (VerificarId(id))
                return GenereteErroServiceResponse("O id tem que ser maior que 0");

            if (!RealizarValidacao(new UpdateFilmeValidator(), updatefilmeDto))
                return GenereteErroServiceResponse(GetNotifcacao().First());

            var filme = await _fRepository.GetById(id, cancellationToken);

            if (filme == null)
                return GenereteErroServiceResponse("Esse filme não existe");
            filme.AttFilme(updatefilmeDto.Titulo, updatefilmeDto.Genero, updatefilmeDto.Sinopse, updatefilmeDto.Duracao);

            foreach (var elenco in updatefilmeDto.Elenco)
            {
                var trocaElenco = await _eRepository.GetById(elenco.Id, cancellationToken);

                if (trocaElenco.Id == elenco.Id)
                    return GenereteErroServiceResponse($"Esse {trocaElenco.Papel.GetDescription()} já está no filme.");
                filme.AddAtores(trocaElenco);
            }

            _fRepository.Update(filme);
            await _fRepository.SaveChanges(cancellationToken);
            return GenereteServiceResponseSucess("Filme atualizado com sucessso");

        }
    }
}
