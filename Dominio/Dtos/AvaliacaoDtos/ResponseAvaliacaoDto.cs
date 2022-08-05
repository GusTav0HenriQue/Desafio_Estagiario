using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs.AvaliacaoDtos
{
    public class ResponseAvaliacaoDto
    {
        public int UserId { get; set; }
        public int FilmeId { get; set; }
        public int ValorDaAvaliacao { get; set; }
    }
}
