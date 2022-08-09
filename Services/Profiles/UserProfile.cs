using AutoMapper;
using Dominio.Config;
using Dominio.DTOs.UserDtos;
using Dominio.Entities;

namespace Service.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(destMember => destMember.Cargo,
                opt => opt.MapFrom(srcMember => srcMember.CargoDoUsuario));

            CreateMap<CreateUserDto, User>().ReverseMap();

            CreateMap<LoginUserDto, User>().ReverseMap();

            CreateMap<LoginOutPutUserDto, User>();

            CreateMap<User, ReadUserDto>().ForMember(destMember => destMember.Cargo,
                opt => opt.MapFrom(srcMember => srcMember.CargoDoUsuario.GetDescription()))
                .ReverseMap();
        }
    }
}
