using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Votador.Business.Models
{
    public abstract class Entidade
    {
        public long Id { get; protected set; }

        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool IsValid();

        public override bool Equals(object entidade)
        {
            var comparacao = entidade as Entidade;

            if (ReferenceEquals(this, comparacao)) return true;
            if (ReferenceEquals(null, comparacao)) return false;

            return Id.Equals(comparacao.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
    }
}
