using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs.FilmesDtos
{
    public class RgistraAvaliaçaoFilmeDto
    {
        public int UserId { get; set; }
        public int FilmeId { get; set; }
        public int Avaliacao { get; set; }
    }
}
