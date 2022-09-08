namespace Dominio.DTOs.FilmesDtos
{
    public record ObterTodosFilmesDto(string? Diretor, string? Genero, string? Ator, ObterTodosFilmesDto.TiposOrdenacao? TipoOrdenacao, bool? Decrescente)
    {
        public enum TiposOrdenacao
        {
            Alfabetica=1,
            Avaliacao
        }
    }
}
