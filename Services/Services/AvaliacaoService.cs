using Dominio.Entities;
using Dominio.Interfaces.Data;
using Service.Helpers;
using Service.Interfaces;

namespace Service.Services
{
    public class AvaliacaoService : AbstractService, IAvaliacaoService
    {
        private readonly IUserRepository _uRepository;
        private readonly IFilmeRepository _fRepository;
        private readonly IAvaliacaoRepository _aRepository;

        public AvaliacaoService(IUserRepository uRepository, IFilmeRepository fRepository, IAvaliacaoRepository aRepository)
        {
            _uRepository = uRepository;
            _fRepository = fRepository;
            _aRepository = aRepository;
        }

        public async Task<ResponseService> RegistraAvaliacao(int userId, int filmeId, int avaliacao, CancellationToken cancellationToken)
        {
            var usuario = await _uRepository.GetById(userId, cancellationToken);

            var filme = await _fRepository.GetById(filmeId, cancellationToken);

            if (usuario == null)
                return GenereteErroServiceResponse("O usuario não foi encontrado");

            if (filme == null)
                return GenereteErroServiceResponse("O filme não foi encontrado");

            var voto = new Avaliacao()
            {
                ValorDaAvaliacao = avaliacao,
                UserId = userId,
                FilmeId = filmeId
            };
            filme.AdicionarAvaliacao(avaliacao);

            await _aRepository.Add(voto, cancellationToken);
            await _aRepository.SaveChanges(cancellationToken);

            return GenereteServiceResponseSucess("A sua avaliação foi cadastrada");
        }
    }
}
