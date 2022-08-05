using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.DTOs.DiretorDtos
{
    public class DiretorDto
    {
        public string Nome { get; set; }
        public string DataDeNascimento { get; set; }
        public virtual IEnumerable<Filme> Filmes { get; set; }
    }
}
