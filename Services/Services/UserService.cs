using AutoMapper;
using Dominio.DTOs.UserDtos;
using Dominio.Interfaces.Data;
using Service.Helpers;
using Service.Interfaces;

namespace Service.Services
{
    public class UserService : AbstractService, IUserService

    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _uRepository;

        public UserService(IUserRepository uRepository, IMapper mapper)
        {
            _uRepository = uRepository;
            _mapper = mapper;
        }

        public Task<ResponseService> CreateAdm(CreateUserDto createUser, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService> CreateUser(CreateUserDto createUser, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService> DeleteUser(int id, string email, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService<IEnumerable<ReadUserDto>>> GetAllUsers(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService<LoginOutPutUserDto>> Login(LoginUserDto login, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService> UpdateUser(int id, CreateUserDto updateUser, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
