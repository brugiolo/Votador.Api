using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Votador.Business.Models;

namespace Votador.Business.Services
{
    public class BaseService
    {
        //private readonly INotificador _notificador;

        //protected BaseService(INotificador notificador)
        //{
        //    _notificador = notificador;
        //}

        //protected void Notificar(ValidationResult validationResult)
        //{
        //    foreach (var error in validationResult.Errors)
        //    {
        //        Notificar(error.ErrorMessage);
        //    }
        //}

        //protected void Notificar(string mensagem)
        //{
        //    _notificador.Handle(new Notificacao(mensagem));
        //}

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entidade
        {
            var validador = validacao.Validate(entidade);

            if (validador.IsValid)
                return true;

            //Notificar(validator);

            return false;
        }
    }
}
