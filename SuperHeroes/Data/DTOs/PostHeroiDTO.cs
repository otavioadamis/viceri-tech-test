using System.ComponentModel.DataAnnotations;

namespace SuperHeroes.Data.DTOs
{
    public class PostHeroiDTO
    {
        [Required]
        public string Nome { get; set; } = null!;

        [Required]
        public string NomeHeroi { get; set; } = null!;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required]
        public float Altura { get; set; }

        [Required]
        public float Peso { get; set; }

        [Required]
        public List<int> SuperpoderesIds { get; set; } = [];
    }
}
