using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public interface IApplicationDbContext
    {
        DbSet<Transaction> Transactions { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<DailyPoint> DailyPoints { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
