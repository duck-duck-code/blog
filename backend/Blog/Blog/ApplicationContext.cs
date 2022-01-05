using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Blog
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration["Database:Connection"]);
        }
    }
}