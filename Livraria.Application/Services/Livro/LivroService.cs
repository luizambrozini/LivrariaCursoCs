
using Livraria.Application.Comunications.Requests.Livro;
using Livraria.Data.Contexts;
using Livraria.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Application.Services.Livro
{
    public class LivroService : ILivroService
    {
        private readonly LivrariaContext _context;

        public LivroService(LivrariaContext context)
        {
            _context = context;
        }

        public async Task<List<LivroModel>> ListaLivros()
        {
            return await _context.Livros
                                        .ToListAsync();
        }

        public async Task<LivroModel> BuscaLivro(int id)
        {
            return await _context.Livros
                                        .FirstOrDefaultAsync(l => l.Id == id) ?? null!;
        }

        public async Task<List<LivroModel>> BuscaLivroPeloTitulo(string titulo)
        {
            return await _context.Livros
                                        .Where(l => l.Titulo.Contains(titulo))
                                        .ToListAsync();
        }

        public async Task<LivroModel> CriaLivro(CriaLivroRequestJson criaLivroRequest)
        {
            if (criaLivroRequest.Titulo == string.Empty) throw new Exception("Título do livro não informado.");
            if (criaLivroRequest.Preco <= 0) throw new Exception("Preço inválido.");

            var novoLivro = new LivroModel
            {
                Titulo = criaLivroRequest.Titulo,
                Preco = criaLivroRequest.Preco,
                AutorId = criaLivroRequest.AutorId,
            };

            _context.Livros.Add(novoLivro);
            await _context.SaveChangesAsync();

            return novoLivro;
        }

        public async Task<LivroModel> EditaLivro(int id, EditaLivroRequestJson editaLivroRequest)
        {
            var livroExistente = await _context.Livros.FindAsync(id);
            if (livroExistente == null) throw new Exception("Livro não encontrado.");

            livroExistente.Titulo = editaLivroRequest.Titulo ?? livroExistente.Titulo;
            livroExistente.Preco = editaLivroRequest.Preco ?? livroExistente.Preco;
            livroExistente.AutorId = editaLivroRequest.AutorId ?? livroExistente.AutorId;
            livroExistente.CategoriaId = editaLivroRequest.CategoriaId ?? livroExistente.CategoriaId;

            _context.Livros.Update(livroExistente);
            await _context.SaveChangesAsync();

            return livroExistente;
        }

        public async Task<bool> RemoveLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null) throw new Exception("Livro não encontrado.");

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}