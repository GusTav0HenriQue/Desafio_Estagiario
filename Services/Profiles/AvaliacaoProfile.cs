using AutoMapper;
using Dominio.DTOs.AvaliacaoDtos;
using Dominio.DTOs.FilmesDtos;
using Dominio.Entities;

namespace Dominio.Profiles
{
    public class AvaliacaoProfile : Profile
    {
        public AvaliacaoProfile()
        {
            CreateMap<RgistraAvaliaçaoFilmeDto, Avaliacao>().ForMember(destMember => destMember.FilmeId,
                opt => opt.MapFrom(srcMember => srcMember.FilmeId))
                .ForMember(destMember => destMember.UserId, opt => opt.MapFrom(srcMember => srcMember.UserId)).ReverseMap();

            CreateMap<ResponseAvaliacaoDto, Avaliacao>().ReverseMap();
        }
    }
}
