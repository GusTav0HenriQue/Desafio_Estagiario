using Dominio.DTOs.ElencoDtos;
using Service.Helpers;

namespace Service.Interfaces
{
    public interface IElencoService : IService
    {
        Task<ResponseService> CadastrarElenco(CadastrarElencoDto cadastrarElencoDto, CancellationToken cancellationToken);
        Task<ResponseService> UpdateElenco(int id,UpdateElencoDto updateElencoDto, CancellationToken cancellationToken);
        Task<ResponseService> Delete(int id, CancellationToken cancellationToken);
        ResponseService<IQueryable<ReadElencoDto>> GetAllElenco();
    }
}
