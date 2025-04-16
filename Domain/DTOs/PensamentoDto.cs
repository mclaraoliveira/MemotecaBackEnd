using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class PensamentoDto
    {
        [Required(ErrorMessage = "O campo Pensamento é obrigatório.")]
        [StringLength(500, ErrorMessage = "O pensamento deve ter no máximo 500 caracteres.")]
        public string Pensamento { get; set; }

        [Required(ErrorMessage = "O campo Autor é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do autor deve ter no máximo 100 caracteres.")]
        public string Autor { get; set; }

        [Range(1, 3, ErrorMessage = "O modelo deve estar entre 1 e 3.")]
        public int Modelo { get; set; }
    }
}
