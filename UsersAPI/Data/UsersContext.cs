using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;

namespace UsersAPI.Data
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (Database.IsSqlite())
            {
                modelBuilder.Entity<User>().Property(u => u.UserName).UseCollation("NOCASE");
                modelBuilder.Entity<User>().Property(u => u.Email).UseCollation("NOCASE");
            }
        }
    }
}