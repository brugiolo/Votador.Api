using System.ComponentModel.DataAnnotations;

namespace Votador.Api.ViewModels
{
    public class RecursoVIewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 5)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(300, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 10)]
        public string Descricao { get; set; }
    }
}
