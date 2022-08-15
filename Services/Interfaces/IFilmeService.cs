using Dominio.DTOs.FilmesDtos;
using Service.Helpers;

namespace Service.Interfaces
{
    public interface IFilmeService : IService
    {
        Task<ResponseService> CadastraFilme(CreateFilmeDto createfilmeDto, CancellationToken cancellationToken);
        Task<ResponseService> UpdateFilme(int id, UpdateFilmeDto updatefilmeDto, CancellationToken cancellationToken);
        Task<ResponseService> DeleteFilme(int id, CancellationToken cancellationToken);
        Task<ResponseService> RegistrarAvaliacao(RegistraAvaliaçaoFilmeDto registraAvaliacao, CancellationToken cancellationToken);
        Task<ResponseService<IEnumerable<ReadFilmeDto>>> GetAllFilmes(CancellationToken cancellation);
        Task<ResponseService<ReadDetailFilmeDto>>GetFilmesDetail(int id, CancellationToken cancellation);
        Task<ResponseService<IEnumerable<FilmeDto>>> GetFilmeByFiltros(CancellationToken cancellation);
        Task<ResponseService> GetFilmeByAvaliacao(CancellationToken cancellation);
    }
}
