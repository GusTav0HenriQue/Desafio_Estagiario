using Dominio.DTOs.FilmesDtos;
using Dominio.Entities;
using Service.Helpers;

namespace Service.Interfaces
{
    public interface IFilmeService : IService
    {
        Task<ResponseService> CadastraFilme(CreateFilmeDto createfilmeDto, CancellationToken cancellationToken);
        Task<ResponseService> UpdateFilme(int id, UpdateFilmeDto updatefilmeDto, CancellationToken cancellationToken);
        Task<ResponseService> DeleteFilme(int id, CancellationToken cancellationToken);
        Task<ResponseService> RegistrarAvaliacao(RegistraAvaliaçaoFilmeDto registraAvaliacao, CancellationToken cancellationToken);
        ResponseService<IEnumerable<ReadFilmeDto>> GetAllFilmes();
        Task<ResponseService<ReadDetailFilmeDto>>GetFilmesDetail(int id, CancellationToken cancellation);
        ResponseService<IEnumerable<Filme>> GetFilmeByFiltros(ObterTodosFilmesDto obterTodosFilmesDto);
        ResponseService GetFilmeByAvaliacao();
    }
}
