using Dominio.Entities;
using Dominio.Interfaces.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<T> Add(T entity, CancellationToken cancellationToken)
        {
              var entityT = await _dbSet.AddAsync(entity, cancellationToken);
            return entityT.Entity;
        }

        public async Task Delete(T entity, CancellationToken cancellationToken)
        {
            entity.Ativo = false;
            await _context.SaveChangesAsync(cancellationToken);
        }

        public  IQueryable<T> GetAll()
        {
            return  _dbSet.Where(x => x.Ativo);
        }

        public  IQueryable<T> GetAll(Expression<Func<T, bool>> query)
        {
            return _dbSet.Where(query).AsQueryable().Where(x => x.Ativo);
        }

        public async Task<T?> GetById(int id, CancellationToken cancellationToken) => await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.Ativo, cancellationToken);

        public async Task<int> SavaChanges(CancellationToken cancellationToken) => await _context.SaveChangesAsync(cancellationToken);

        public T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }
    }
}
