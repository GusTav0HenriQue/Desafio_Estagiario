using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTOs.ElencoDtos;
using Dominio.Helpers;

namespace Dominio.Interfaces.Service
{
    public interface IElencoService : IService
    {
        Task<ResponseService> CadastrarElenco(CadastrarElencoDto cadastrarElencoDto, CancellationToken cancellationToken);
        Task<ResponseService> UpdateElenco(UpdateElencoDto updateElencoDto, CancellationToken cancellationToken);
        Task<ResponseService<IEnumerable<ReadElencoDto>>> GetAllElenco(CancellationToken cancellationToken);
    }
}
