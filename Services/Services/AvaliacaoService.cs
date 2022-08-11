using Service.Helpers;
using Service.Interfaces;

namespace Service.Services
{
    public class AvaliacaoService : AbstractService, IAvaliacaoService
    {
        public Task<ResponseService> RegistraAvaliacao(int userId, int filmeId, int avaliacao)
        {
            throw new NotImplementedException();
        }
    }
}
