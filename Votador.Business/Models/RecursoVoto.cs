using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Votador.Business.Models
{
    [NotMapped]
    public class RecursoVoto
    {
        public Recurso Recurso { get; set; }
        public int NumeroDeVotos { get; set; }
    }
}
