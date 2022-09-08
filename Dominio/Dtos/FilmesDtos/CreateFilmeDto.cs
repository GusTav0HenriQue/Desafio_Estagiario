namespace Dominio.DTOs.FilmesDtos
{
    public class CreateFilmeDto
    {
        public string Titulo { get; set; }
        public int Duracao { get; set; }
        public string Sinopse { get; set; }
        public string Genero { get; set; }
        public string DataDeLancamento { get; set; }
        public string Diretor { get; set; }
        public List<ElencoFilmeDto> Elenco { get; set; } = new List<ElencoFilmeDto>();
    }
    public class ElencoFilmeDto { public int Id { get; set; } }
}
