using Dominio.DTOs.ElencoDtos;
using Service.Helpers;

namespace Service.Interfaces
{
    public interface IElencoService : IService
    {
        Task<ResponseService> CadastrarElenco(CadastrarElencoDto cadastrarElencoDto, CancellationToken cancellationToken);
        Task<ResponseService> UpdateElenco(UpdateElencoDto updateElencoDto, CancellationToken cancellationToken);
        Task<ResponseService<IEnumerable<ReadElencoDto>>> GetAllElenco(CancellationToken cancellationToken);
    }
}
