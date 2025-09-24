// Controlador REST con un endpoint de "proxy" que llama a Personas.Api y reenvía el JSON.
using Microsoft.AspNetCore.Mvc;

namespace Clientes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // /api/clientes
    public class ClientesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClientesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // GET /api/clientes/personas -> trae /api/personas desde Personas.Api
        [HttpGet("personas")]
        public async Task<IActionResult> GetPersonas()
        {
            var client = _httpClientFactory.CreateClient("personas");
            var response = await client.GetAsync("api/personas");
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Error consultando Personas.Api");

            var json = await response.Content.ReadAsStringAsync();
            return Content(json, "application/json"); // devolvemos el JSON tal cual
        }
    }
}
