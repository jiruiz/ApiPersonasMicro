using EmployeedAPI.Data;
using EmployeedAPI.Dto;
using EmployeedAPI.Interfaces;
using EmployeedAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeedAPI.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<EmployeeDto> GetEmployees()
        {
            return _context.Employees
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    EmployeeCode = e.EmployeeCode,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    Phone = e.Phone,
                    BirthdayDate = e.BirthdayDate,
                    BusinessId = e.BusinessId,
                    Departament = e.Departament,
                    HireDate = e.HireDate,
                    Range = e.Range,
                    State = e.State
                })
                .ToList();
        }


        public bool AddEmployee(EmployeeCreateDto employeeDto) {

            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Phone = employeeDto.Phone,
                BirthdayDate = employeeDto.BirthdayDate,
                BusinessId = employeeDto.BusinessId,
                Departament = employeeDto.Departament,
                HireDate = employeeDto.HireDate,
                Range = employeeDto.Range,
                State = employeeDto.State
            };

            _context.Employees.Add(employee);
            _context.SaveChanges(); // se genera el Id
            employee.EmployeeCode = $"{employee.BusinessId}{employee.Id}";
            
            return Save();
        }

        public bool Save()
        {
             //el metodo de EF devuelve la cantidad de registros afectados
            return _context.SaveChanges() > 0; // retorna true si guarda
        }

        public ICollection<Employee> GetEmployeesIdBusiness(int idBusiness)
        {
            return _context.Employees.Where(e=>e.BusinessId == idBusiness).ToList();
        }

        public Employee GetEmployeeById(int id) { 
        
            return _context.Employees.Where(p=>p.Id == id).FirstOrDefault();
        }
    }
}
