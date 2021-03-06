﻿using FluentValidation;
using Votador.Business.Models;

namespace Votador.Business.Validations
{
    public class RecursoValidacao : AbstractValidator<Recurso>
    {
        public RecursoValidacao()
        {
            RuleFor(u => u.Titulo)
                .NotEmpty().WithMessage("Preencha o campo {PropertyName}.")
                .Length(10, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(u => u.Descricao)
                .NotEmpty().WithMessage("Preencha o campo {PropertyName}.")
                .Length(20, 300).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(u => u.NomeDoAutor)
                .NotEmpty().WithMessage("Preencha o campo {PropertyName}.")
                .Length(10, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");

            RuleFor(u => u.EmailDoAutor)
                .NotEmpty().WithMessage("Preencha o campo {PropertyName}.")
                .Length(3, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
