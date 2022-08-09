using Dominio.DTOs.FilmesDtos;
using FluentValidation;

namespace Dominio.Validator.Filme
{
    public class UpdateFilmeValidator : AbstractValidator<UpdateFilmeDto>
    {
        public UpdateFilmeValidator()
        {
            RuleFor(f => f.Titulo).Length(40, 100).WithMessage("O {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength}!")
                                  .NotEmpty().WithMessage("O {PropertyName} não pode ser vazio!");

            RuleFor(f => f.Sinopse).Length(10, 190).WithMessage("A {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength}!")
                                   .NotEmpty().WithMessage("A {PropertyName} não pode ser vazia!");

            RuleFor(f => f.Duracao).NotEmpty().WithMessage("A {PropertyName} não pode ser vazia!")
                                   .LessThanOrEqualTo(0).WithMessage("A {PropertyName} tem que ser maior que 0!");

            RuleFor(f => f.Genero).Length(10, 50).WithMessage("O {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength}!")
                                  .NotEmpty().WithMessage("O {PropertyName} não pode ser vazio");

            RuleFor(f => f.Elenco).NotEmpty().WithMessage("A Lista de {PropertyName} não pode ser vazia!");
        }
    }
}
