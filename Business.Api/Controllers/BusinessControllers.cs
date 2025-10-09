using Microsoft.AspNetCore.Mvc;
using Business.Api.Models;
using Business.Api.Interfaces;
using Business.Api.Dto;
using Business.Api.Data;

namespace Business.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : Controller
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly DataContext _context;

        public BusinessController(IBusinessRepository businessRepository, DataContext context)
        {
            _businessRepository = businessRepository;
            _context = context;
        }

        /// <summary>
        /// ✅ Obtiene la lista completa de negocios registrados en la base de datos.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BusinessDto>))]
        public IActionResult GetBusinesses()
        {
            var businesses = _businessRepository.GetBusinesses();
            return Ok(businesses);
        }

        /// <summary>
        /// ✅ Obtiene un negocio específico por su ID.
        /// </summary>
        /// <param name="idBusiness">ID del negocio que se desea obtener.</param>
        [HttpGet("{idBusiness}")]
        [ProducesResponseType(200, Type = typeof(BusinessDto))]
        [ProducesResponseType(404)]
        public IActionResult GetBusinessById(int idBusiness)
        {
            var business = _businessRepository.GetBusinessById(idBusiness);

            if (business == null)
                return NotFound($"No business found with Id {idBusiness}");

            return Ok(business);
        }

        /// <summary>
        /// ✅ Crea un nuevo negocio en la base de datos.
        /// </summary>
        /// <param name="businessDto">Datos del negocio a crear.</param>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(BusinessDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateBusiness([FromBody] BusinessDto businessDto)
        {
            if (businessDto == null)
                return BadRequest("Invalid business data");

            var created = _businessRepository.AddBusiness(businessDto);

            if (!created)
                return StatusCode(500, "Error saving business");

            return Ok(businessDto);
        }

        /// <summary>
        /// ✏️ Actualiza un negocio existente por su ID.
        /// </summary>
        /// <param name="id">ID del negocio a actualizar.</param>
        /// <param name="updatedBusiness">Datos actualizados del negocio.</param>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateBusiness(int id, [FromBody] BusinessDto updatedBusiness)
        {
            var business = _context.Businesses.FirstOrDefault(b => b.Id == id);
            if (business == null)
                return NotFound($"No business found with Id {id}");

            business.Name = updatedBusiness.Name;
            business.Industry = updatedBusiness.Industry;
            business.PhoneNumber = updatedBusiness.PhoneNumber;
            business.Email = updatedBusiness.Email;
            business.TaxId = updatedBusiness.TaxId;
            business.VATStatus = updatedBusiness.VATStatus;
            business.LegalName = updatedBusiness.LegalName;
            business.StartOfActivities = updatedBusiness.StartOfActivities;
            business.YearsInIndustry = updatedBusiness.YearsInIndustry;
            business.Street = updatedBusiness.Street;
            business.City = updatedBusiness.City;
            business.State = updatedBusiness.State;

            _context.SaveChanges();
            return Ok(business);
        }

        /// <summary>
        /// 🗑️ Elimina un negocio por su ID.
        /// </summary>
        /// <param name="id">ID del negocio a eliminar.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteBusiness(int id)
        {
            var business = _context.Businesses.FirstOrDefault(b => b.Id == id);
            if (business == null)
                return NotFound($"No business found with Id {id}");

            _context.Businesses.Remove(business);
            _context.SaveChanges();

            return Ok($"Business with Id {id} deleted successfully.");
        }

        /// <summary>
        /// 📊 Obtiene todos los negocios que pertenecen a un rubro (industria) específico.
        /// </summary>
        /// <param name="industry">Nombre del rubro a filtrar.</param>
        [HttpGet("industry/{industry}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BusinessDto>))]
        [ProducesResponseType(404)]
        public IActionResult GetBusinessesByIndustry(string industry)
        {
            var businesses = _businessRepository.GetBusinessesByIndustry(industry);

            if (!businesses.Any())
                return NotFound($"No businesses found in industry '{industry}'");

            return Ok(businesses);
        }
    }
}
