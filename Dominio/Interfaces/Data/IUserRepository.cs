using Dominio.Entities;

namespace Dominio.Interfaces.Data
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserNaoAtivos(CancellationToken cancellationToken);
        IEnumerable<User> GetUserByOrder();
        Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);
    }
}
