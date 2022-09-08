using System.Net;
using AutoMapper;
using Dominio.Config;
using Dominio.DTOs.UserDtos;
using Dominio.Entities;
using Dominio.Enums;
using Dominio.Interfaces.Cryptograph;
using Dominio.Interfaces.Data;
using Service.Helpers;
using Service.Interfaces;
using Service.Validator.User;

namespace Service.Services
{
    public class UserService : AbstractService, IUserService

    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _uRepository;
        private readonly ITokenService _token;
        private readonly ICryptograph _cryptograph;

        public UserService(IUserRepository uRepository, IMapper mapper, ITokenService token, ICryptograph cryptograph)
        {
            _uRepository = uRepository;
            _mapper = mapper;
            _token = token;
            _cryptograph = cryptograph;
        }

        public async Task<ResponseService> CreateAdm(CreateUserDto createUser, CancellationToken cancellation)
        {
            if (!RealizarValidacao(new UserValidator(), createUser))
                return GenereteErroServiceResponse(GetNotifcacao().First());

            var userMail = await _uRepository.GetUserByEmail(createUser.Email, cancellation);
            if(createUser.Email == userMail!.Email)
            {
                userMail.CargoDoUsuario = UserCargo.Administrador;
                await _uRepository.SaveChanges(cancellation);

                return GenereteServiceResponseSucess("Usuario promovido á ADM com sucesso.");
            }
            else
            {
                await _uRepository.Add(new User
                {
                    Nome = createUser.Nome,
                    Email = createUser.Email,
                    Ativo = true,
                    CargoDoUsuario = UserCargo.Administrador,
                    PassWord = _cryptograph.EncryptPassword(createUser.Password)
                }, cancellation);
                await _uRepository.SaveChanges(cancellation);
                return GenereteServiceResponseSucess("Usuario Administrador criado com sucesso.");
            }
        }

        public async Task<ResponseService> CreateUser(CreateUserDto createUser, CancellationToken cancellation)
        {
            if (!RealizarValidacao(new UserValidator(), createUser))
                return GenereteErroServiceResponse(GetNotifcacao().First());

            var userEmail = await _uRepository.GetUserByEmail(createUser.Email, cancellation);
            if (userEmail != null)
                return GenereteErroServiceResponse("Esse email já esta em uso.");
            if (createUser.Password != createUser.RePassword)
                return GenereteErroServiceResponse("A senhas não estão iguais, por favor digite senhas iguais.");
            await _uRepository.Add(new User
            {
                Nome = createUser.Nome,
                Email = createUser.Email,
                Ativo = true,
                CargoDoUsuario = UserCargo.Usuario,
                PassWord = _cryptograph.EncryptPassword(createUser.Password)
            }, cancellation);
            await _uRepository.SaveChanges(cancellation);

            return GenereteServiceResponseSucess(" O Usuario foi criado.");
        }

        public async Task<ResponseService> DeleteUser(int id, string email, CancellationToken cancellation)
        {
            
            var user = await _uRepository.GetById(id, cancellation);
            if (VerificarId(id))
                return GenereteErroServiceResponse("O id não pode ser negativo ou zero");

            if (user!.Ativo == false)
                return GenereteErroServiceResponse("Usuario ja foi excluido");
            if (user.Email != email)
                return GenereteErroServiceResponse("Email não encontrado , Por favor insira um email valido. ");
            if (user.Nome == "Adm" && user.Email == "Admin" && user.CargoDoUsuario == UserCargo.Administrador )
                return GenereteErroServiceResponse("Não pode excluir esse Adm.");
            await _uRepository.Delete(user, cancellation);
            await _uRepository.SaveChanges(cancellation);

            return GenereteServiceResponseSucess("O usuario foi excluido com sucesso.");

        }

        public  ResponseService<IEnumerable<ReadUserDto>> GetAllUsers()
        {
            var user =   _uRepository.GetAll();
            var map = _mapper.Map<IEnumerable<ReadUserDto>>(user);
            if (!user.Any())
                return GenerateErroServiceResponse<IEnumerable<ReadUserDto>>("Nenhum usuario foi cadastrado");
            return GenereteServiceResponseSucess(map);
        }

        public async Task<ResponseService<LoginOutPutUserDto>> Login(LoginUserDto login, CancellationToken cancellation)
        {
            var userAth = await _uRepository.GetUserByEmail(login.Email!, cancellation);

            if (userAth == null)
                return GenerateErroServiceResponse<LoginOutPutUserDto>("Erro ao fazer login, Esse usuario não existe.");

            if (userAth != null && _cryptograph.VerifyPassword(login.Password!, userAth.PassWord))
            {
                var createToken = await _token.GerarToken(userAth.Nome, userAth.Id, userAth.CargoDoUsuario.GetDescription());

                var user = new UserDto()
                {
                    Nome = userAth.Nome,
                    Cargo = userAth.CargoDoUsuario.GetDescription(),
                    Email = userAth.Email
                };

                var result = new LoginOutPutUserDto() { Usuario = user, Token = createToken };

                return GenereteServiceResponseSucess(result);
            }

            return GenerateErroServiceResponse<LoginOutPutUserDto>("Erro ao tentar fazer o login, senha incorreta", HttpStatusCode.BadRequest);
                
        }

        public async Task<ResponseService> UpdateUser(int id, CreateUserDto updateUser, CancellationToken cancellation)
        {
            var user = _uRepository.GetById(id, cancellation);

            if (!RealizarValidacao(new UserValidator(), updateUser))
                return GenereteErroServiceResponse(GetNotifcacao().First());

            if (user == null)
                return GenereteErroServiceResponse("Esse usuario não existe.");

            var upUser = new User()
            {
                Email = updateUser.Email,
                Nome = updateUser.Nome
            };
            _uRepository.Update(upUser);

            await _uRepository.SaveChanges(cancellation);

            return GenereteServiceResponseSucess("Usuario atualiazado com sucesso");
        }
    }
}
