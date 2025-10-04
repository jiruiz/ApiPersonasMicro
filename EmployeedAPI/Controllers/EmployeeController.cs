using EmployeedAPI.Models;
using EmployeedAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EmployeedAPI.Dto;

namespace EmployeedAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeRepository.GetEmployees());
        }

        [HttpGet("{idEmployee}")]
        public IActionResult GetEmployeeById(int idEmployee)
        {

            return Ok(_employeeRepository.GetEmployeeById(idEmployee));
        }

        [HttpGet("business/{idBusiness}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(404)]
        public IActionResult GetEmployeesByIdBusiness(int idBusiness)
        {
            var employees = _employeeRepository.GetEmployeesIdBusiness(idBusiness);

            if (!employees.Any())
            {
                return NotFound($"No employees found for BusinessId {idBusiness}");
            }

            return Ok(employees);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeCreateDto employee)
        {

            if (employee == null)
            {
                return BadRequest("Invalid eployee data");

            }
            var created = _employeeRepository.AddEmployee(employee);

            if (!created)
            {
                return StatusCode(500, "Error saving employee");
            }

            return Ok(employee); // retorna el empleado creado
        }


    }
}
