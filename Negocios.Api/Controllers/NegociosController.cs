using Microsoft.AspNetCore.Mvc;
using Negocios.Api.Models;
using Negocios.Api.Data; // Asegúrate de agregar este using

namespace Negocios.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NegociosController : ControllerBase
    {
        private readonly NegociosContext _context;

        public NegociosController(NegociosContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Crea y guarda un negocio con los datos recibidos por query string.
        /// </summary>
        [HttpGet("CrearNegocio")]
        public ActionResult<Negocio> CrearNegocio(
            string nombre,
            string rubro,
            string telefono,
            string correo,
            string cuit,
            string condicionIVA,
            string razonSocial,
            DateTime fechaInicioActividades,
            int antiguedadEnRubro,
            string calle,
            string localidad,
            string provincia)
        {
            Negocio negocio = new Negocio
            {
                Nombre = nombre,
                Rubro = rubro,
                Telefono = telefono,
                Correo = correo,
                Cuit = cuit,
                CondicionIVA = condicionIVA,
                RazonSocial = razonSocial,
                FechaInicioActividades = fechaInicioActividades,
                AntiguedadEnRubro = antiguedadEnRubro,
                Calle = calle,
                Localidad = localidad,
                Provincia = provincia
            };

            _context.Negocios.Add(negocio);
            _context.SaveChanges();

            return Ok(negocio); // Devuelve el negocio guardado (con Id asignado)
        }
    }
}