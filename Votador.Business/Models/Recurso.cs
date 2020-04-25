using System;
using System.Collections.Generic;
using Votador.Business.Validations;

namespace Votador.Business.Models
{
    public partial class Recurso : Entidade
    {
        public Recurso()
        {
            Votos = new HashSet<Voto>();
        }

        //public long UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraCadastro { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Voto> Votos { get; set; }

        public override bool IsValid()
        {
            var recursoValidacao = new RecursoValidacao();
            ValidationResult = recursoValidacao.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
