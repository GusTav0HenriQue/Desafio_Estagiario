using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Data
{
    public interface IBaseRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> query);
        Task<T?> GetById(int id, CancellationToken cancellationToken);
        Task<T> Add(T entity, CancellationToken cancellationToken);
        T Update(T entity);
        Task Delete(T entity, CancellationToken cancellationToken);
        Task<int> SavaChanges(CancellationToken cancellationToken);

    }
}
