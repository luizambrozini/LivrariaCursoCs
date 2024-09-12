
using Livraria.Application.Comunications.Requests.Autor;
using Livraria.Data.Models;

namespace Livraria.Application.Services.Autor
{
    public interface IAutorInterface
    {
        Task<List<AutorModel>> ListaAutores();
        Task<AutorModel> BuscaAutor(int id);
        Task<List<AutorModel>> BuscaAutorPeloNome(string nome);
        Task<AutorModel> CriaAutor(CriaAutorRequestJson criaAutorRequest);
    }
}