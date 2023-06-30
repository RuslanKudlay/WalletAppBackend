using DAL;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace RAL.Repository.DailyPointRepository
{
    public class DailyPointRepository : IDailyPointRepository
    {
        private readonly IApplicationDbContext _dbContext;
        public DailyPointRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddPoinst(DailyPoint dailyPoint)
        {
            await _dbContext.DailyPoints.AddAsync(dailyPoint);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetPoints(Guid userId)
        {
            return await _dbContext.Users.Include(d => d.DailyPoints).FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
