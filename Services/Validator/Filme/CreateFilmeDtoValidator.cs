using Dominio.DTOs.FilmesDtos;
using FluentValidation;

namespace Service.Validator.Filme
{
    public class CreateFilmeDtoValidator : AbstractValidator<CreateFilmeDto>
    {
        public CreateFilmeDtoValidator()
        {
            RuleFor(f => f.Titulo).Length(2, 80).WithMessage("O {PropertyName}nao pode ser menor que {MinLength} ou maior que {MaxLength}.");

            RuleFor(f => f.Duracao).GreaterThan(0).WithMessage("A {PropertyName} do filme deve ser maior que 0.");

            RuleFor(f => f.Genero).NotEmpty().WithMessage("O {PropertyName} não pode ser vazio.");

            RuleFor(f => f.Sinopse).NotEmpty().WithMessage("A {PropertyName} não pode ser vazia.")
                .Length(20, 180).WithMessage("A {PropertyName} não pode ser menor que {MinEngth} ou maior que {Max length}");
        }
    }
}
