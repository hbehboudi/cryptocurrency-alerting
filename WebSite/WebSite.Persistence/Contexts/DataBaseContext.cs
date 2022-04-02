using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSite.Application.Interfaces.Contexts;
using WebSite.Domain.Entities.Alert;
using WebSite.Domain.Entities.Rules;
using WebSite.Domain.Entities.Users;

namespace WebSite.Persistence.Contexts
{
    public class DataBaseContext : IdentityDbContext<User>, IDataBaseContext
    {
        public DbSet<Rule> Rules { get; set; }

        public DbSet<Alert> Alerts { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rule>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Alert>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
