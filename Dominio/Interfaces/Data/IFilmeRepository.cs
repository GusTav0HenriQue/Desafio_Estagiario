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
        IEnumerable<Filme> GetFilmeByGenero(string genero);
        IEnumerable<Filme> GetFilmesPagiados(ParametroFilme filmesParametros);
        Task<Filme?> GetFilmePorAtor(int id, CancellationToken cancellationToken);
    }
}
