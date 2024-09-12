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
    }
}