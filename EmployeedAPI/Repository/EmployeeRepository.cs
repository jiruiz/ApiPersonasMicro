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
                .Where(e=>!e.IsDeleted)
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    EmployeeCode = e.EmployeeCode,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Document = e.Document,
                    Email = e.Email,
                    Phone = e.Phone,
                    BirthdayDate = e.BirthdayDate,
                    BusinessId = e.BusinessId,
                    Departament = e.Departament,
                    HireDate = e.HireDate,
                    Range = e.Range,
                    State = e.State,
                    IsDeleted = e.IsDeleted,

                })
                .ToList();
        }

        public ICollection<EmployeeDto> GetAllEmployees()
        {
            return _context.Employees
                .Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    EmployeeCode = e.EmployeeCode,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Document = e.Document,
                    Email = e.Email,
                    Phone = e.Phone,
                    BirthdayDate = e.BirthdayDate,
                    BusinessId = e.BusinessId,
                    Departament = e.Departament,
                    HireDate = e.HireDate,
                    Range = e.Range,
                    State = e.State,
                    IsDeleted = e.IsDeleted
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
                Document = employeeDto.Document,
                BirthdayDate = employeeDto.BirthdayDate,
                BusinessId = employeeDto.BusinessId,
                Departament = employeeDto.Departament,
                //si no viene el dato, se usa la actual
                HireDate = employeeDto.HireDate == default ? DateOnly.FromDateTime(DateTime.Now) : employeeDto.HireDate,
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
            return _context.Employees.Where(e=>e.BusinessId == idBusiness && !e.IsDeleted).ToList();
        }

        public ICollection<Employee> GetAllEmployeesIdBusiness(int idBusiness)
        {
            return _context.Employees.Where(e => e.BusinessId == idBusiness).ToList();
        }

        public Employee GetEmployeeById(int id) { 
        
            return _context.Employees.Where(p=>p.Id == id).FirstOrDefault();
        }

        public bool EditEmployee(EmployeeCreateDto employeeDto,int idEmployee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == idEmployee);
            if (existingEmployee == null) { 
                return false;
            }

            existingEmployee.FirstName = employeeDto.FirstName;
            existingEmployee.LastName = employeeDto.LastName;
            existingEmployee.Document = employeeDto.Document;
            existingEmployee.Email = employeeDto.Email;
            existingEmployee.Phone = employeeDto.Phone;
            existingEmployee.Departament = employeeDto.Departament;
            existingEmployee.Range = employeeDto.Range;
            existingEmployee.State = employeeDto.State;
            existingEmployee.HireDate = employeeDto.HireDate;
            existingEmployee.BirthdayDate = employeeDto.BirthdayDate;

            return Save();
        }

        public bool DeleteEmployee(int idEmployee) { 
        
            var existEmployee = _context.Employees.FirstOrDefault(e => e.Id == idEmployee);
            if (existEmployee == null) {
                return false;
            }

            _context.Employees.Remove(existEmployee);
            return Save();
        
        }

        public bool SoftDeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return false;

            employee.IsDeleted = true;
            return Save(); 
        }

        public bool RestoreEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return false;

            employee.IsDeleted = false;
            return Save();
        }

    }
}
