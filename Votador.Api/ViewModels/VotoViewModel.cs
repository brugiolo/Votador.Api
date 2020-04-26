using System.ComponentModel.DataAnnotations;

namespace Votador.Api.ViewModels
{
    public class VotoViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int RecursoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Comentario { get; set; }
    }
}
