using FluentValidation;
using Votador.Business.Models;

namespace Votador.Business.Validations
{
    public class VotoValidacao : AbstractValidator<Voto>
    {
        public VotoValidacao()
        {
            RuleFor(u => u.UsuarioId)
                .NotEmpty().WithMessage("Preencha o campo {PropertyName}.");

            RuleFor(u => u.RecursoId)
                .NotEmpty().WithMessage("Preencha o campo {PropertyName}.");

            RuleFor(u => u.Comentario)
                .NotEmpty().WithMessage("Preencha o campo {PropertyName}.")
                .Length(10, 500).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres.");
        }
    }
}
