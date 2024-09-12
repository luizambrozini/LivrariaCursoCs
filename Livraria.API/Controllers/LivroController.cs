using Livraria.Application.Comunications.Requests.Livro;
using Livraria.Application.Services.Livro;
using Livraria.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
         [HttpGet]
        [ProducesResponseType(typeof(List<LivroModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListaLivros([FromServices] ILivroService livroService)
        {
            var livros = await livroService.ListaLivros();
            return Ok(livros);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(LivroModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BuscaLivro([FromServices] ILivroService livroService,int id)
        {
            var livro = await livroService.BuscaLivro(id);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpGet("titulo/{titulo}")]
        [ProducesResponseType(typeof(List<LivroModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> BuscaLivroPeloTitulo([FromServices] ILivroService livroService,string titulo)
        {
            var livros = await livroService.BuscaLivroPeloTitulo(titulo);
            return Ok(livros);
        }

        [HttpPost]
        [ProducesResponseType(typeof(LivroModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> CriaLivro([FromServices] ILivroService livroService,[FromBody] CriaLivroRequestJson criaLivroRequest)
        {
            var livro = await livroService.CriaLivro(criaLivroRequest);
            return Created(string.Empty, livro);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(LivroModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditaLivro([FromServices] ILivroService livroService,int id, [FromBody] EditaLivroRequestJson editaLivroRequest)
        {
            var livro = await livroService.EditaLivro(id, editaLivroRequest);
            if (livro == null)
            {
                return NotFound();
            }
            return Ok(livro);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemoveLivro([FromServices] ILivroService livroService,int id)
        {
            var sucesso = await livroService.RemoveLivro(id);
            if (!sucesso)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}