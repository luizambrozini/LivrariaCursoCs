using Livraria.Application.Comunications.Requests.Autor;
using Livraria.Application.Services.Autor;
using Livraria.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<AutorModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListaAutores([FromServices] IAutorService autorService)
        {
            var autores = await autorService.ListaAutores();
            return Ok(autores);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AutorModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Criaautor([FromServices] IAutorService autorService,[FromBody] CriaAutorRequestJson criaAutorRequestJson)
        {
            var autor = await autorService.CriaAutor(criaAutorRequestJson);
            return Created(string.Empty, autor);
        }
    }
}