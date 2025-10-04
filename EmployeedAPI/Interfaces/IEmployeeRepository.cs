using EmployeedAPI.Dto;
using EmployeedAPI.Models;

namespace EmployeedAPI.Interfaces
{
    public interface IEmployeeRepository
    {
        ICollection<EmployeeDto> GetEmployees();

        Employee GetEmployeeById(int id);
        ICollection<Employee> GetEmployeesIdBusiness(int idBusiness);
        bool AddEmployee(EmployeeCreateDto employee);
        bool Save();

    }
}
