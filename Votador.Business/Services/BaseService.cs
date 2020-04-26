using FluentValidation;
using Votador.Business.Models;

namespace Votador.Business.Services
{
    public class BaseService
    {
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entidade
        {
            var validador = validacao.Validate(entidade);

            if (validador.IsValid)
                return true;

            return false;
        }
    }
}
