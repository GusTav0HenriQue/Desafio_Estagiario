using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Data
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserNaoAtivos(CancellationToken cancellationToken);
        IEnumerable<User> GetUserByOrder();
        Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);
    }
}
