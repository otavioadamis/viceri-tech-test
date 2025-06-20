using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperHeroes.Data
{
    public class SuperPoder
    {
        [Key]
        public int Id { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        public required string Superpoder { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string? Descricao { get; set; }
    }
}
