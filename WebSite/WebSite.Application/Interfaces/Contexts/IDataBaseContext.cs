using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebSite.Domain.Entities.Users;

namespace WebSite.Application.Interfaces.Contexts
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);

        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
