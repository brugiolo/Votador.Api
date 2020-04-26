using System.Collections.Generic;
using Votador.Business.Validations;

namespace Votador.Business.Models
{
    public partial class Usuario : Entidade
    {
        public Usuario()
        {
            Votos = new HashSet<Voto>();
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }

        public override bool IsValid()
        {
            var usuarioValidacao = new UsuarioValidacao();
            ValidationResult = usuarioValidacao.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
