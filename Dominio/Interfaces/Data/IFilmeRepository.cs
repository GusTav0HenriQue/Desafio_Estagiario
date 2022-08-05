using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Data
{
    public interface IFilmeRepository :IBaseRepository<Filme>
    {
        Task<Filme?> GetAllDetail(int id, CancellationToken cancellationToken);
        IEnumerable<Filme> GetFilmesFiltro();
        IEnumerable<Filme> GetAllFilmesComAtor();
        IEnumerable<Filme> GetFilmeByTitulo(string titulo);
        IEnumerable<Filme> GetFilmeByGenero(string genero);
        IEnumerable<Filme> GetFilmesPagiados(ParametroFilme filmesParametros);
        Task<Filme?> GetFilmePorAtor(int id, CancellationToken cancellationToken);
    }
}
