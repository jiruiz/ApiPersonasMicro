using Microsoft.AspNetCore.Mvc;
using Personas.Api.Models;
using Personas.Api.Repositories;

namespace Personas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private readonly IPersonaRepository _repo;

        public PersonasController(IPersonaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            var personas = await _repo.GetAllAsync();
            return Ok(personas);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Persona persona)
        {
            if (string.IsNullOrWhiteSpace(persona.Nombre) || string.IsNullOrWhiteSpace(persona.Apellido))
                return BadRequest("Nombre y Apellido son obligatorios.");

            await _repo.CreateAsync(persona);
            return Ok(persona);
        }
    }
}
