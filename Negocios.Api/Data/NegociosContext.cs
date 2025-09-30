using Microsoft.EntityFrameworkCore;
using Negocios.Api.Models;

namespace Negocios.Api.Data
{
    public class NegociosContext : DbContext
    {
        public NegociosContext(DbContextOptions<NegociosContext> options) : base(options) { }

        public DbSet<Negocio> Negocios { get; set; }
    }
}