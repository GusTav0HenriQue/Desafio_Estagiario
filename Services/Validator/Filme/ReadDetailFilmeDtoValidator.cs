using Dominio.DTOs.FilmesDtos;
using FluentValidation;

namespace Service.Validator.Filme
{
    public class ReadDetailFilmeDtoValidator : AbstractValidator<ReadDetailFilmeDto>
    {
        public ReadDetailFilmeDtoValidator()
        {
            RuleFor(f => f.Id).NotEmpty().WithMessage("O {PropertyName} não pode ser vazio!");

            RuleFor(f => f.Titulo).NotEmpty().WithMessage("O {PropertyName} não pode ser vazio!");

            RuleFor(f => f.Duracao).NotEmpty().WithMessage("A {PropertyName} não pode ser 0 ou vazia!");

            RuleFor(f => f.Genero).NotEmpty().WithMessage("O {PropertyName} não pode ser vazio!");

            RuleFor(f => f.Atores).NotEmpty().WithMessage("A lista de {PropertyName} não pode ser vazia!");

            RuleFor(f => f.Sinopse).NotEmpty().WithMessage("A {PropertyName} não pode ser vazia")
                .Length(10, 180).WithMessage("A {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength}");
        }
    }
}
