using System;
using Votador.Business.Validations;

namespace Votador.Business.Models
{
    public partial class Voto : Entidade
    {
        public int UsuarioId { get; set; }
        public int RecursoId { get; set; }
        public string Comentario { get; set; }
        public DateTime DataHoraVoto { get; set; }

        public virtual Recurso Recurso { get; set; }
        public virtual Usuario Usuario { get; set; }

        public override bool IsValid()
        {
            var votoValidacao = new VotoValidacao();
            ValidationResult = votoValidacao.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
