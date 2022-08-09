using Dominio.DTOs.ElencoDtos;
using FluentValidation;

namespace Service.Validator.Elenco
{
    public class ReadElencoValidator : AbstractValidator<ReadElencoDto>
    {
        public ReadElencoValidator()
        {
            RuleFor(e => e.Nome).NotEmpty().NotNull().WithMessage("O {PropertyName} não pode ser vazio ou nulo")
                  .Length(4, 100).WithMessage("O {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength} !");

            RuleFor(e => e.DataDeNascimento).NotEmpty().NotNull().WithMessage("O {PropertyName} não pode ser vazio ou nulo");

            RuleFor(e => e.Papel).NotEmpty().NotNull().WithMessage("O {PropertyName} não pode ser vazio ou nulo");
        }
    }
}
