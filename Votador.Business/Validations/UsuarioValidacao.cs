using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Votador.Business.Models;

namespace Votador.Business.Validations
{
    public class UsuarioValidacao : AbstractValidator<Usuario>
    {
        public UsuarioValidacao()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("Preencha o campo {PropertyName}.")
                .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Preencha o campo {PropertyName}.")
                .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("Preencha o campo {PropertyName}.")
                .Length(6, 200).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
