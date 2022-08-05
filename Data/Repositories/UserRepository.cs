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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DbSet<User> _dbSet;

        public UserRepository(AppDbContext context) : base(context)
        {
            _dbSet = context.Set<User>();
        }

        public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
             return await _dbSet.Where(u => u.Email == email).AsNoTracking().FirstOrDefaultAsync();
        }

        public IEnumerable<User> GetUserByOrder()
        {
            return _dbSet.OrderBy(u => u.Nome);
        }

        public async Task<User?> GetUserNaoAtivos(CancellationToken cancellationToken)
        {
            return await _dbSet.AsNoTracking()
                               .Where(u => u.Ativo == false)
                               .Where(u => u.CargoDoUsuario == UserCargo.Usuario)
                               .FirstOrDefaultAsync();
        }
    }
}
