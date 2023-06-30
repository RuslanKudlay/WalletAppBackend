using DAL.Entity;
using System;
using System.Threading.Tasks;

namespace RAL.Repository.DailyPointRepository
{
    public interface IDailyPointRepository
    {
        Task<User> GetPoints(Guid userId);
        Task AddPoinst(DailyPoint dailyPoint);
    }
}
