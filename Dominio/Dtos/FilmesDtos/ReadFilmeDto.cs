using Dominio.DTOs.ElencoDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs.FilmesDtos
{
    public class ReadFilmelDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public List<ElencoDto> Atores { get; set; }
    }
}
