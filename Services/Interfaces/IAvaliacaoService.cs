using Service.Helpers;

namespace Service.Interfaces
{
    public interface IAvaliacaoService : IService
    {
        Task<ResponseService> RegistraAvaliacao(int userId, int filmeId, int avaliacao, CancellationToken cancellationToken);
    }
}
