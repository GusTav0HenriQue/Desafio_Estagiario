using Dominio.Entities;
using Dominio.Enums;
using Dominio.Interfaces.Data;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _dbSet;

        public UserRepository(AppDbContext context) : base(context)
        {
            _dbSet = context.Set<User>();
        }

        public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
             return await _dbSet.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }

        public IEnumerable<User> GetUserByOrder()
        {
            return _dbSet.OrderBy(u => u.Nome);
        }

        public async Task<User?> GetUserNaoAtivos(CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking()
                               .FirstOrDefaultAsync(u => u.Ativo == false && u.CargoDoUsuario == UserCargo.Usuario,cancellationToken);
        }
    }
}
