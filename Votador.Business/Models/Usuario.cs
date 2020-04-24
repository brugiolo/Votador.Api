using System;
using System.Collections.Generic;

namespace Votador.Business.Models
{
    public partial class Usuario : Entidade
    {
        public Usuario()
        {
            Recursos = new HashSet<Recurso>();
            Votos = new HashSet<Voto>();
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
        public int TipoDeUsuario { get; set; }

        public virtual ICollection<Recurso> Recursos { get; set; }
        public virtual ICollection<Voto> Votos { get; set; }
    }
}
