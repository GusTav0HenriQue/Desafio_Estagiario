using Dominio.DTOs.ElencoDtos;
using FluentValidation;

namespace Service.Validator.Elenco
{
    public class CadastrarElencoValidator : AbstractValidator<CadastrarElencoDto>
    {
        public CadastrarElencoValidator()
        {
            RuleFor(e => e.Nome).NotEmpty().NotNull().WithMessage("O {PropertyName} não pode ser vazio ou nulo")
                                .Length(4, 100).WithMessage("O {PropertyName} não pode ser menor que {MinLength} ou maior de {MaxLength} !");

            RuleFor(e => e.DataDeNascimento).NotEmpty().NotNull().WithMessage("A {PropertyName} não pode ser vazia ou nula!");

            RuleFor(e => e.Papel).NotEmpty().NotNull().WithMessage("O {PropertyName} não pode ser vazio ou nulo!");
        }
    }
}
