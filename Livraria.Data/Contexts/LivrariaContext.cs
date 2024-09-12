using Microsoft.EntityFrameworkCore;

namespace Livraria.Data.Contexts
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext> options) : base(options) { }

        // Defina os DbSets para suas entidades (exemplo de Livros)
        //public DbSet<Livro> Livros { get; set; }
    }
}
