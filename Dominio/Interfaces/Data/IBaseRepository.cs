using Dominio.Entities;
using System.Linq.Expressions;


namespace Dominio.Interfaces.Data
{
    public interface IBaseRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> query);
        Task<T?> GetById(int id, CancellationToken cancellationToken);
        Task<T> Add(T entity, CancellationToken cancellationToken);
        T Update(T entity);
        Task Delete(T entity, CancellationToken cancellationToken);
        Task<int> SaveChanges(CancellationToken cancellationToken);

    }
}
