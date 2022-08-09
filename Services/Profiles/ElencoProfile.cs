using AutoMapper;
using Dominio.DTOs.ElencoDtos;
using Dominio.Entities;

namespace Dominio.Profiles
{
    public class ElencoProfile : Profile
    {
        public ElencoProfile()
        {
            CreateMap<CadastrarElencoDto, Elenco>().ReverseMap();

            CreateMap<Elenco, ElencoDto>().ForMember(destMember => destMember.DataDeNascimento,
                opt => opt.MapFrom(srcMember => srcMember.DataDeNascimento.ToShortDateString())).ReverseMap();

            CreateMap<Elenco, UpdateElencoDto>().ForMember(destMember => destMember.DataDeNascimento,
                opt => opt.MapFrom(srcMember => srcMember.DataDeNascimento.ToShortDateString()))
                .ForMember(destMember => destMember.Papel, opt => opt.MapFrom(srcMenber => srcMenber.Papel.GetDescription())).ReverseMap();

            CreateMap<Elenco, ReadElencoDto>().ForMember(destMember => destMember.DataDeNascimento,
                opt => opt.MapFrom(srcMember => srcMember.DataDeNascimento.ToShortTimeString()))
                .ForMember(destMember => destMember.Papel, opt => opt.MapFrom(srcMember => srcMember.Papel.GetDescription())).ReverseMap();

            CreateMap<Elenco, ElencoFilmeDto>().ReverseMap();
        }
    }
}
