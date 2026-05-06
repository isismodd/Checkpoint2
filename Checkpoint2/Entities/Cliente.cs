using System.ComponentModel.DataAnnotations;

namespace Checkpoint2.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}