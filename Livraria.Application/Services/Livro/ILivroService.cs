using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Application.Comunications.Requests.Livro;
using Livraria.Data.Models;

namespace Livraria.Application.Services.Livro
{
    public interface ILivroService
    {
        Task<List<LivroModel>> ListaLivros();
        Task<LivroModel> BuscaLivro(int id);
        Task<List<LivroModel>> BuscaLivroPeloTitulo(string titulo);
        Task<LivroModel> CriaLivro(CriaLivroRequestJson criaLivroRequest);
        Task<LivroModel> EditaLivro(int id, EditaLivroRequestJson editaLivroRequest);
        Task<bool> RemoveLivro(int id);
    }
}