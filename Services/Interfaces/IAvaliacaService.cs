using Dominio.Helpers;
using Dominio.Interfaces.Service;

namespace Dominio.Interfaces
{
    public interface IAvaliacaService : IService
    {
        Task<ResponseService> RegistraAvaliacao(int userId,int filmeId,int avaliacao);
    }
}
