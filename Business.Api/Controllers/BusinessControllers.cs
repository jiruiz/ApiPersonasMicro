using Microsoft.AspNetCore.Mvc;
using Business.Api.Models;
using Business.Api.Interfaces;
using Business.Api.Dto;
using Business.Api.Data; // 👈 ahora usamos TU DataContext

namespace Business.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : Controller
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly DataContext _context; // 👈 tu nuevo contexto con SQLite

        public BusinessController(IBusinessRepository businessRepository, DataContext context)
        {
            _businessRepository = businessRepository;
            _context = context;
        }

        // ✅ Obtener todos los negocios
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BusinessDto>))]
        public IActionResult GetBusinesses()
        {
            var businesses = _businessRepository.GetBusinesses();
            return Ok(businesses);
        }

        // ✅ Obtener un negocio por ID
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

        // ✅ Crear un nuevo negocio (POST con JSON) - versión profesional
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

            return Ok(businessDto); // Retorna el negocio creado
        }

        // ✅ Obtener negocios por rubro
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

        // ✅ Crear un negocio usando query string (versión GET)
        [HttpGet("CreateBusinessQuery")]
        public ActionResult<Models.Business> CreateBusinessQuery(
            string name,
            string industry,
            string phoneNumber,
            string email,
            string taxId,
            string vatStatus,
            string legalName,
            DateTime startOfActivities,
            int yearsInIndustry,
            string street,
            string city,
            string state)
        {
            var business = new Models.Business
            {
                Name = name,
                Industry = industry,
                PhoneNumber = phoneNumber,
                Email = email,
                TaxId = taxId,
                VATStatus = vatStatus,
                LegalName = legalName,
                StartOfActivities = startOfActivities,
                YearsInIndustry = yearsInIndustry,
                Street = street,
                City = city,
                State = state
            };

            _context.Businesses.Add(business);
            _context.SaveChanges();

            return Ok(business); // Devuelve el negocio creado con su Id asignado
        }
    }
}
