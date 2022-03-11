using Consent.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Consent.Actors.DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<App> Apps { get; set; } = null!;
        public DbSet<Flow> Flows { get; set; } = null!;
        public DbSet<Policy> Policies { get; set; } = null!;
        public DbSet<AppPolicy> AppPolicies { get; set; } = null!;
        public DbSet<Decision> Decisions { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=consentDb;Username=postgres;Password=postgres");
        }
    }
}
