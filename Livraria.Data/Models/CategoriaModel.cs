

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Livraria.Data.Models 
{
    [Table("Categorias")]
    public class CategoriaModel 
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
    }
}