using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration["Database:Connection"]).UseSnakeCaseNamingConvention();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(UsersConfigure);
            modelBuilder.Entity<Session>(SessionsConfigure);
            modelBuilder.Entity<Account>(AccountsConfigure);
        }
        
        protected void UsersConfigure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users", "blog");
        }

        protected void SessionsConfigure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("sessions", "auth");
        }
        
        protected void AccountsConfigure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts", "auth");
        }
    }
}