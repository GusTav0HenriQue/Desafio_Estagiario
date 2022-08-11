using Dominio.DTOs.FilmesDtos;
using Service.Helpers;
using Service.Interfaces;

namespace Service.Services
{
    public class FilmeService : AbstractService, IFilmeService
    {
        public Task<ResponseService> CadastraFilme(CreateFilmeDto createfilmeDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService> DeleteFilme(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService<IEnumerable<FilmeDto>>> GetAllFilmes(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService> GetFilmeByAvaliacao(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService<IEnumerable<FilmeDto>>> GetFilmeByFiltros(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService<IEnumerable<ReadFilmeDto>>> GetFilmesDetail(int id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService> RegistrarAvaliacao(RgistraAvaliaçaoFilmeDto registraAvaliaçao, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseService> UpdateFilme(int id, UpdateFilmeDto updatefilmeDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
