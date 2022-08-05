using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Data
{
    public interface IElencoRepository :IBaseRepository<Elenco>
    {
        Task<Elenco?> GetAtorFilmes(string nome, CancellationToken cancellationToken);
        IEnumerable<Elenco> GetFilmesComDiretor(string nome);
        IEnumerable<Elenco> GetFilmesComAtor(string nome);
        IEnumerable<Elenco> GetByDiretor(string diretor);
        Task<Elenco?> GetElencoByName(string nome,CancellationToken cancellationToken);
    }
}
