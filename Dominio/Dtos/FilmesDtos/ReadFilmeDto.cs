using Dominio.DTOs.ElencoDtos;

namespace Dominio.DTOs.FilmesDtos
{
    public class ReadFilmeDto
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Genero { get; set; }
        public int Duracao { get; set; }
        public List<ElencoDto>? Atores { get; set; }
    }
}
