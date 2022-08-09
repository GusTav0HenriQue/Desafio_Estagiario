using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.DTOs.FilmesDtos;
using FluentValidation;

namespace Dominio.Validator.Filme
{
    public class FilmeDtoValidator : AbstractValidator<FilmeDto>
    {
        public FilmeDtoValidator()
        {
            RuleFor(f => f.Titulo).Length(40, 100).WithMessage("O {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength}!")
                                  .NotEmpty().WithMessage("O {PropertyName} não pode ser vazio!");

            RuleFor(f => f.Sinopse).Length(10, 190).WithMessage("A {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength}!")
                                   .NotEmpty().WithMessage("A {PropertyName} não pode ser vazia!");

            RuleFor(f => f.Duracao).NotEmpty().WithMessage("A {PropertyName} não pode ser vazia!")
                                   .LessThanOrEqualTo(0).WithMessage("A {PropertyName} tem que ser maior que 0!");

            RuleFor(f => f.Genero).Length(10, 50).WithMessage("O {PropertyName} não pode ser menor que {MinLength} ou maior que {MaxLength}!")
                                  .NotEmpty().WithMessage("O {PropertyName} não pode ser vazio");

            RuleFor(x => x.AvaliacaoTotal).NotEmpty().WithMessage("A {PropertyName} não pode ser vazia")
                                          .GreaterThanOrEqualTo(0).WithMessage("O valor de {PropertyName} não pode ser vazio ou 0");

            RuleFor(f => f.UsuariosVotantes).NotEmpty().WithMessage("O {PropertyName} não pode ser vazio!").InclusiveBetween(0, 4)
                                            .WithMessage("O {PropertyName} nao pode ser menor que {MinLength} ou maior que {MaxLength} !");
        }
    }
}
