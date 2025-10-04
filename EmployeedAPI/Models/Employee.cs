using System.ComponentModel.DataAnnotations;
namespace EmployeedAPI.Models
{
    public class Employee
    {
        [Key] // se debe colocar para la migracion 
        public int Id {  get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthdayDate { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        // Datos del negocio
        public int BusinessId { get; set; }
        public  string Departament {  get; set; } = string.Empty;
        public string Range { get; set; } = string.Empty;
        public DateOnly HireDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string State { get; set; } = string.Empty;

    }
}
