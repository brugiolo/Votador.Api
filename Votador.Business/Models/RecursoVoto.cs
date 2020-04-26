using System.ComponentModel.DataAnnotations.Schema;

namespace Votador.Business.Models
{
    [NotMapped]
    public class RecursoVoto
    {
        public Recurso Recurso { get; set; }
        public int NumeroDeVotos { get; set; }
    }
}
