using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Application.Comunications.Requests.Livro
{
    public class CriaLivroRequestJson
    {
        public string Titulo { get; set; } = string.Empty;
        public double Preco { get; set; }
        public int AutorId { get; set; }
    }
}