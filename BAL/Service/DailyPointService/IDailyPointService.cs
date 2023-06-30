using System;
using System.Threading.Tasks;

namespace BAL.Service.DeilyPointService
{
    public interface IDailyPointService
    {
        Task<double> CreateDailyPoints(Guid userId);
    }
}
