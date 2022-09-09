using Dominio.DTOs.UserDtos;
using FluentValidation;

namespace Service.Validator.User
{
    public class UpdateUserValidator :  AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(u => u.Nome).NotEmpty().WithMessage("O {PropertyName} não pode ser vazio nem nulo").Length(4, 30).WithMessage("O {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength}");

            RuleFor(u => u.Password).NotEmpty().WithMessage("O {PropertyName} não pode ser vazio nem  nulo")
                .Length(5, 15).WithMessage("O {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength}!");

            RuleFor(u => u.RePassword).NotEmpty().WithMessage("O {PropertyName} não pode ser vazio nem  nulo")
                .Length(5, 15).WithMessage("O {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength}!");
        }
    }
}
