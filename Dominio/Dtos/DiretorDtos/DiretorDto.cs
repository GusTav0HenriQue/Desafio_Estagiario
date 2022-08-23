using Dominio.Entities;

namespace Dominio.DTOs.DiretorDtos
{
    public class DiretorDto
    {
        public string Nome { get; set; }
        public string DataDeNascimento { get; set; }
        public virtual IEnumerable<Filme> Filmes { get; set; }
    }
}
