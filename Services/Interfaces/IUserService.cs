using Dominio.DTOs.UserDtos;
using Dominio.Helpers;

namespace Dominio.Interfaces.Service
{
    public interface IUserService : IService
    {
        Task<ResponseService> CreateUser(CreateUserDto createUser, CancellationToken cancellation);
        Task<ResponseService> UpdateUser(int id, CreateUserDto updateUser, CancellationToken cancellation);
        Task<ResponseService> DeleteUser(int id, string email, CancellationToken cancellation);
        Task<ResponseService<IEnumerable<ReadUserDto>>> GetAllUsers(CancellationToken cancellation);
        Task<ResponseService<LoginOutPutUserDto>> Login(LoginUserDto login, CancellationToken cancellation);
    }
}
