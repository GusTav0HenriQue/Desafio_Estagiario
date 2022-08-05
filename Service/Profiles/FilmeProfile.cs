
using AutoMapper;
using Dominio.DTOs.FilmesDtos;
using Dominio.Entities;

namespace Service.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<Filme, FilmeDto>().ReverseMap();

            CreateMap<Filme, ReadDetailFilmeDto>().ReverseMap();

            CreateMap<CreateFilmeDto, Filme>().ReverseMap();

            CreateMap<UpdateFilmeDto, Filme>().ReverseMap();

            CreateMap<Filme, ReadDetailFilmeDto>().ReverseMap();

            CreateMap<Filme, ReadFilmeDto>().ReverseMap();

            CreateMap<Filme, ReadFilmeElencoDto>().ReverseMap();

            CreateMap<Elenco, AttElencoFilmeDto>().ReverseMap();

        }
    }
}
