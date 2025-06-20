using System.ComponentModel.DataAnnotations;

namespace SuperHeroes.Data.DTOs
{
    public class PostSuperpoderDTO
    {
        [Required]
        public string Superpoder { get; set; } = null!;

        public string? Descricao { get; set; }
    }
}
