using Business.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // En ASP.NET Core se inyecta por Dependency Injection
        }

        // ✅ DbSet para la entidad Business
        public DbSet<Models.Business> Businesses => Set <Models.Business>();
    }
}
