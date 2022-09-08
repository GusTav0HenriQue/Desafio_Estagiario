using Dominio.DTOs.FilmesDtos;
using Dominio.Entities;


namespace Dominio.Interfaces.Data
{
    public interface IFilmeRepository :IBaseRepository<Filme>
    {
        Task<Filme?> GetAllDetail(int id, CancellationToken cancellationToken);
        IEnumerable<Filme> GetFilmesFiltro(ObterTodosFilmesDto obterTodosFilmesDto);
        IEnumerable<Filme> GetAllFilmesComAtor();
        IEnumerable<Filme> GetFilmeByTitulo(string titulo);
        IEnumerable<Filme> GetFilmesByGenero(string genero);
        IEnumerable<Filme> GetFilmesPagiados(ParametroFilme filmesParametros);
        Task<Filme?> GetFilmesbyAtor(int id, CancellationToken cancellationToken);
    }
}
