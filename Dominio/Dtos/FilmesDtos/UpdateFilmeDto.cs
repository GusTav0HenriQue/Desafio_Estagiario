using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs.FilmesDtos
{
    public class UpdateFilmeDto
    {
        public string? Titulo { get; set; }
        public int Duracao { get; set; }
        public string? Sinopse { get; set; }
        public string? Genero { get; set; }
        public string? DataDeLancamento { get; set; }
        public List<AttElencoFilmeDto>? Elenco { get; set; }
    }
    public class AttElencoFilmeDto { public int Id { get; set; } }
}

