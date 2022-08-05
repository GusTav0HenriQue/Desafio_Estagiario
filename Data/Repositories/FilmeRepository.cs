using Dominio.Entities;
using Dominio.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class FilmeRepository : BaseRepository<Filme>, IFilmeRepository
    {
        private readonly DbSet<Filme> _dbSet;
        public FilmeRepository(AppDbContext context): base(context)
        {
            _dbSet= context.Set<Filme>();
        }
        public Task<Filme?> GetAllDetail(int id, CancellationToken cancellationToken) => GetById(id, cancellationToken);

        public IEnumerable<Filme> GetAllFilmesComAtor()
        {

            return _dbSet.Include(f => f.Atores).AsQueryable().Where(f => f.Ativo);
        }

        public IEnumerable<Filme> GetFilmeByGenero(string genero)
        {
            return GetAll(f=>f.Genero.ToLower() == genero.ToLower());
        }

        public IEnumerable<Filme> GetFilmeByTitulo(string titulo)
        {
            return  GetAll(f=>f.Titulo.ToLower() == titulo.ToLower());
        }

        public async Task<Filme?> GetFilmePorAtor(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.Include(f => f.Atores).FirstOrDefaultAsync(f => f.Id == id);
        }

        public IEnumerable<Filme> GetFilmesFiltro()
        {
            return _dbSet.Include(f => f.Atores.Where(f => f.Ativo))
                             .Include(f => f.Votos.Where(f => f.Ativo))
                             .AsQueryable();
        }

        public IEnumerable<Filme> GetFilmesPagiados(ParametroFilme filmesParametros)
        {
            return _dbSet.Include(f => f.Atores)
                .Include(f => f.Votos)
                .OrderBy(f => f.Titulo)
                .Skip((filmesParametros.NumeroPaginas - 1) * filmesParametros.TamanhoDaPag)
                .Take(filmesParametros.TamanhoDaPag)
                .AsQueryable();
        }
    }
}
