using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSite.Application.Interfaces.Contexts;
using WebSite.Domain.Entities.Users;

namespace WebSite.Persistence.Contexts
{
    public class DataBaseContext : IdentityDbContext<User>, IDataBaseContext
    {
        //public DbSet<AudioCollection> AudioCollections { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<AudioCollection>().HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
