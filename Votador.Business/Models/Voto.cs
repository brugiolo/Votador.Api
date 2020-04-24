using System;
using System.Collections.Generic;

namespace Votador.Business.Models
{
    public partial class Voto : Entidade
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public long RecursoId { get; set; }
        public string Comentario { get; set; }
        public DateTime DataHoraVoto { get; set; }

        public virtual Recurso Recurso { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
