using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs.FilmesDtos
{
    public class CreateFilmeDto
    {
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public string Sinopse { get; set; }
        public string Genero { get; set; }
        public string DataDeLancamento { get; set; }
        public List<ElencoFilmeDto> Elenco { get; set; }
    }
    public class ElencoFilmeDto { public int Id { get; set; } }
}
