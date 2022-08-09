using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTOs.UserDtos;
using FluentValidation;

namespace Service.Validator.User
{
    public class UserValidator : AbstractValidator<CreateUserDto>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty().WithMessage("O {PropertyName} não pode ser vazio nem nulo").Length(10, 130).WithMessage("O {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength}!");

            RuleFor(u => u.Password).NotEmpty().WithMessage("O {PropertyName} não pode ser vazio nem  nulo")
                .Length(5,15).WithMessage("O {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength}!");

            RuleFor(u => u.RePassword).NotEmpty().WithMessage("O {PropertyName} não pode ser vazio nem  nulo")
                .Length(5, 15).WithMessage("O {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength}!");
        }
    }
}
