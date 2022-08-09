using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTOs.FilmesDtos;
using Service.Helpers;

namespace Service.Interfaces
{
    public interface IFilmeService : IService
    {
        Task<ResponseService> CadastraFilme(CreateFilmeDto createfilmeDto, CancellationToken cancellationToken);
        Task<ResponseService> UpdateFilme(int id, UpdateFilmeDto updatefilmeDto, CancellationToken cancellationToken);
        Task<ResponseService> DeleteFilme(int id, CancellationToken cancellationToken);
        Task<ResponseService> RegistrarAvaliacao(RgistraAvaliaçaoFilmeDto registraAvaliaçao, CancellationToken cancellationToken);
        Task<ResponseService<IEnumerable<FilmeDto>>> GetAllFilmes(CancellationToken cancellation);
        Task<ResponseService<IEnumerable<ReadFilmeDto>>> GetFilmesDetail(int id, CancellationToken cancellation);
        Task<ResponseService<IEnumerable<FilmeDto>>> GetFilmeByFiltros(CancellationToken cancellation);
        Task<ResponseService> GetFilmeByAvaliacao(CancellationToken cancellation);
    }
}
