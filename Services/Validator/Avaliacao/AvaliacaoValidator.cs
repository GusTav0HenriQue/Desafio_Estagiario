using Dominio.DTOs.FilmesDtos;
using FluentValidation;

namespace Service.Validator.Avaliacao
{
    public class AvaliacaoValidator : AbstractValidator<RgistraAvaliaçaoFilmeDto>
    {
        public AvaliacaoValidator()
        {
            RuleFor(a=>a.FilmeId).GreaterThan(0).WithMessage("O {PropertyName} não pode ser menor que 0");

            RuleFor(a => a.UserId).GreaterThan(0).WithMessage("O {PropertyName} não pode ser menor que 0");

            RuleFor(a => a.Avaliacao).InclusiveBetween(0, 4).WithMessage("A {PropertyName} não pode ser menor que 0 ou maior que 4");
        }
    }
}
