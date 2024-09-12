using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Application.Services.Autor;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ListaAutores([FromServices] IAutorService autorService)
        {
            var autores = await autorService.ListaAutores();
            return Ok(autores);
        }
    }
}