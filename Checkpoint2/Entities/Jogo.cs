using System.ComponentModel.DataAnnotations;

namespace Checkpoint2.Entities
{
    public class Jogo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        public string Genero { get; set; }

        public decimal PrecoLocacao { get; set; }

        public bool Disponivel { get; set; } = true;
    }
}