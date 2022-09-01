using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
