using Dominio.DTOs.UserDtos;
using Service.Helpers;

namespace Service.Interfaces
{
    public interface IUserService : IService
    {
        Task<ResponseService> CreateUser(CreateUserDto createUser, CancellationToken cancellation);
        Task<ResponseService> CreateAdm(CreateUserDto createUser, CancellationToken cancellation);
        Task<ResponseService> UpdateUser(int id, CreateUserDto updateUser, CancellationToken cancellation);
        Task<ResponseService> DeleteUser(int id, string email, CancellationToken cancellation);
        ResponseService<IEnumerable<ReadUserDto>> GetAllUsers(CancellationToken cancellation);
        Task<ResponseService<LoginOutPutUserDto>> Login(LoginUserDto login, CancellationToken cancellation);
    }
}
