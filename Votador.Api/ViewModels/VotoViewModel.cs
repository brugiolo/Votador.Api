using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Votador.Api.ViewModels
{
    public class VotoViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long RecursoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Comentario { get; set; }
    }
}
