
using Livraria.Application.Comunications.Requests.Autor;
using Livraria.Data.Contexts;
using Livraria.Data.Models;

namespace Livraria.Application.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        private readonly LivrariaContext _context;
        public AutorService(LivrariaContext context)
        {
            _context = context;
        }

        public Task<List<AutorModel>> ListaAutores()
        {
            throw new NotImplementedException();
        }

        public Task<AutorModel> BuscaAutor(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AutorModel> BuscaAutorPeloNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<AutorModel> CriaAutor(CriaAutorRequestJson criaAutorRequest)
        {
            throw new NotImplementedException();
        }

        
    }
}