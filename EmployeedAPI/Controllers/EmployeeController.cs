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

        [HttpGet("all/")]
        public IActionResult GetAllEmployees()
        {
            return Ok(_employeeRepository.GetAllEmployees());
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

        // metodo que retorna todos los empleados, hasta los eliminados
        [HttpGet("all/business/{idBusiness}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(404)]
        public IActionResult GetAllEmployeesByIdBusiness(int idBusiness)
        {
            var employees = _employeeRepository.GetAllEmployeesIdBusiness(idBusiness);

            if (!employees.Any())
            {
                return NotFound($"No employees found for BusinessId {idBusiness}");
            }

            return Ok(employees);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeCreateDto employeeDto)
        {
            try
            {
                _employeeRepository.AddEmployee(employeeDto);
                return Ok(new { message = "Empleado creado correctamente." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { error = "Error interno." });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeCreateDto employeeDto)
        {
            if (employeeDto == null) {
                return BadRequest("Invalid employee data");
            }
            var success = _employeeRepository.EditEmployee(employeeDto, id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();// respuesta de okey

        }

        [HttpDelete("{idEmployee}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteEmployee(int idEmployee) { 
        
            if (idEmployee > 0)
            {
                _employeeRepository.DeleteEmployee(idEmployee);
                return NoContent(); //respuesta ok
            }
            else
                return BadRequest("Invalid employee data");

        }

        [HttpPut("softDelete/{idEmployee}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult SoftDeleteEmployee(int idEmployee)
        {
            var success = _employeeRepository.SoftDeleteEmployee(idEmployee);

            if (!success)
                return NotFound($"Empleado con ID {idEmployee} no encontrado.");

            return NoContent();
        }

        [HttpPut("restore/{idEmployee}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult RestoreEmployee(int idEmployee)
        {
            var success = _employeeRepository.RestoreEmployee(idEmployee);

            if (!success)
                return NotFound($"Empleado con ID {idEmployee} no encontrado.");

            return NoContent();
        }


    }
}
