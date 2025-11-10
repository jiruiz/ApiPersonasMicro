using EmployeedAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeedAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { } // Se usa poirque en ASP.NET Core ya se intecta por Dependency Injection
        public DbSet<Employee> Employees => Set <Employee>() ;


        /*
         * Para no permitir dos Employee con mismo Document se sobreescribe el metodo OnModelCreating
            HasIndex(e => e.Document) → crea un indice en el campo Document.
            .IsUnique() → lo convierte en índice único (UNIQUE constraint).
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Document)
                .IsUnique();
        }

    }
}
