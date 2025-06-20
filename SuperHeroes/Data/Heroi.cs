using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroes.Data
{
    public class Heroi
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(120)")]
        public required string Nome { get; set; } 
        
        [Column(TypeName = "varchar(120)")]
        public required string NomeHeroi { get; set; }
        
        [Column(TypeName = "date")]
        public required DateTime DataNascimento { get; set; }

        public required float Altura { get; set; }

        public required float Peso { get; set; }

        public ICollection<SuperPoder> Superpoderes { get; set; } = null!;
    }
}
