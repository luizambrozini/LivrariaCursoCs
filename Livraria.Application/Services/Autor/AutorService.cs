
using Livraria.Application.Comunications.Requests.Autor;
using Livraria.Data.Contexts;
using Livraria.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Application.Services.Autor
{
    public class AutorService : IAutorService
    {
        private readonly LivrariaContext _context;
        public AutorService(LivrariaContext context)
        {
            _context = context;
        }

        public async Task<List<AutorModel>> ListaAutores()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task<AutorModel> BuscaAutor(int id)
        {
            return await _context.Autores.FirstOrDefaultAsync(a => a.Id == id) ?? null!;
        }

        public async Task<List<AutorModel>> BuscaAutorPeloNome(string nome)
        {
            return await _context.Autores.Where(a => a.Nome.Contains(nome)).ToListAsync();
        }

        public async Task<AutorModel> CriaAutor(CriaAutorRequestJson criaAutorRequest)
        {
            if(criaAutorRequest.NomeAutor == string.Empty) throw new Exception("Nome do autor não informado.");
            var novoAutor = new AutorModel
            {
                Nome = criaAutorRequest.NomeAutor
            };

            _context.Autores.Add(novoAutor);
            await _context.SaveChangesAsync();

            return novoAutor;
        }

        
    }
}