using Dominio.Config;
using Dominio.Entities;
using Dominio.Enums;
using Dominio.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ElencoRepository : BaseRepository<Elenco>, IElencoRepository
    {
        private readonly DbSet<Elenco> _dbset;

        public ElencoRepository(AppDbContext context) : base(context)
        {
            _dbset = context.Set<Elenco>();
        }

        public async Task<Elenco?> GetAtorFilmes(string nome, CancellationToken cancellationToken)
        {
           return await _dbset.Include(e => e.Filmes).FirstOrDefaultAsync(e => e.Nome == nome);
        }

        public IEnumerable<Elenco> GetByDiretor(string diretor)
        {
            return GetAll(e => e.Papel.GetDescription() == diretor);
        }

        public async Task<Elenco?> GetElencoByName(string nome,CancellationToken cancellationToken)
        {
            return await _dbset.AsNoTracking().FirstOrDefaultAsync(e => e.Nome.ToLower() == nome.ToLower());
        }

        public IEnumerable<Elenco> GetFilmesComAtor(string nome)
        {
            return _dbset.Include(e => e.Filmes)
                         .Where(e => e.Nome.ToLower() == nome.ToLower() 
                          && e.Papel == ElencoPapel.Ator)
                         .AsQueryable();
        }

        public IEnumerable<Elenco> GetFilmesComDiretor(string nome)
        {
            return _dbset.Include(e => e.Filmes)
                         .Where(e => e.Nome.ToLower() == nome.ToLower()
                          && e.Papel == ElencoPapel.Diretor)
                         .AsQueryable();
        }
    }
}
