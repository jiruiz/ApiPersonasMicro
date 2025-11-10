using EmployeedAPI.Dto;
using EmployeedAPI.Models;

namespace EmployeedAPI.Interfaces
{
    public interface IEmployeeRepository
    {
        ICollection<EmployeeDto> GetEmployees();

        ICollection<EmployeeDto> GetAllEmployees();

        Employee GetEmployeeById(int id);
        ICollection<Employee> GetEmployeesIdBusiness(int idBusiness);

        ICollection<Employee> GetAllEmployeesIdBusiness(int idBusiness);
        bool AddEmployee(EmployeeCreateDto employee);

        bool EditEmployee(EmployeeCreateDto employee, int idEmployee);
        bool Save();

        bool DeleteEmployee(int idEmployee);

        bool SoftDeleteEmployee (int idEmployee);

        bool RestoreEmployee(int idEmployee);

    }
}
