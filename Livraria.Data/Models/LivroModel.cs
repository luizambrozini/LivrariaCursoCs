using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Data.Models
{
    [Table("Livros")]
    public class LivroModel
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public Double Preco { get; set; }
        public int CategoriaId { get; set; }
        public int AutorId { get; set; }
    }
}