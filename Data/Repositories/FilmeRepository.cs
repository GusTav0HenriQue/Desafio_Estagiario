using Dominio.DTOs.FilmesDtos;
using Dominio.Entities;
using Dominio.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.OData.Query;

namespace Data.Repositories
{
    public class FilmeRepository : BaseRepository<Filme>, IFilmeRepository
    {
        private readonly DbSet<Filme> _dbSet;
        public FilmeRepository(AppDbContext context) : base(context)
        {
            _dbSet = context.Set<Filme>();
        }
        public Task<Filme?> GetAllDetail(int id, CancellationToken cancellationToken) => GetById(id, cancellationToken);

        public IEnumerable<Filme> GetAllFilmesComAtor()
        {

            return _dbSet.Include(f => f.Atores).AsQueryable().Where(f => f.Ativo);
        }

        public IEnumerable<Filme> GetFilmeByGenero(string genero)
        {
            return GetAll(f => f.Genero.ToLower() == genero.ToLower());
        }

        public IEnumerable<Filme> GetFilmeByTitulo(string titulo)
        {
            return GetAll(f => f.Titulo.ToLower() == titulo.ToLower());
        }

        public async Task<Filme?> GetFilmePorAtor(int id, CancellationToken cancellationToken)
        {
            return await _dbSet.Include(f => f.Atores).FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
        }

        public IEnumerable<Filme> GetFilmesFiltro(ObterTodosFilmesDto obterTodosFilmesDto)
        {
            (string? Diretor, string? Genero, string? Ator, ObterTodosFilmesDto.TiposOrdenacao? TipoOrdenacao, bool? Decrescente) = obterTodosFilmesDto;

            var filtros = new List<Func<Filme, bool>>();

            if (Diretor is not null)
                filtros.Add(filme => filme.Diretor.Contains(Diretor));
            
            if (Genero is not null)
                filtros.Add(filme => filme.Genero.Contains(Genero));

            if (Ator is not null)
                filtros.Add(filme => filme.Atores.Any(a => a.Nome.Contains(Ator)));

            var filmesFiltrados = filtros.Aggregate(_dbSet.Include(f=>f.Atores).Include(f=>f.Votos) as IEnumerable<Filme>, (currentSeed, filtro) => currentSeed.Where(filtro));

            if (TipoOrdenacao is ObterTodosFilmesDto.TiposOrdenacao.Alfabetica)
                filmesFiltrados = Decrescente is true ? filmesFiltrados.OrderByDescending(f => f.Titulo) : filmesFiltrados.OrderBy(f => f.Titulo);

            if (TipoOrdenacao is ObterTodosFilmesDto.TiposOrdenacao.Avaliacao)
                filmesFiltrados = Decrescente is true ? filmesFiltrados.OrderByDescending(f => f.AvaliacaoTotal) : filmesFiltrados.OrderBy(f => f.AvaliacaoTotal);

            return filmesFiltrados;
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
