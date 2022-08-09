using Dominio.DTOs.AvaliacaoDtos;
using Dominio.DTOs.ElencoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs.FilmesDtos
{
    public class FilmeDto
    {
        public int Id { get; set; } 
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int AvaliacaoTotal { get; set; }
        public int UsuariosVotantes { get; set; }
        public DateTime DataDeLancamento { get; set; }
        public virtual List<ElencoDto> Atores { get; set; }
        public virtual List<ResponseAvaliacaoDto> Votos { get; set; }
    }
}
