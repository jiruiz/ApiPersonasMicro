using EmployeedAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeedAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { } // Se usa poirque en ASP.NET Core ya se intecta por Dependency Injection
        public DbSet<Employee> Employees => Set <Employee>() ;

    }
}
