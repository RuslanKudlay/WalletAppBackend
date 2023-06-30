using BAL.Model;
using BAL.Service.DeilyPointService;
using DAL.Entity;
using RAL.Repository.DailyPointRepository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BAL.Service.DailyPointService
{
    public class DailyPointService : IDailyPointService
    {
        private readonly IDailyPointRepository _pointRepository;
        private const int PointsForTheFirstDay = 2;
        private const int PointsForTheSecondDay = 3;
        public DailyPointService(IDailyPointRepository pointRepository)
        {
            _pointRepository = pointRepository;
        }
        public async Task<double> CreateDailyPoints(Guid userId)
        {
            var user = await _pointRepository.GetPoints(userId);
            var currentDate = DateTime.UtcNow;

            if (user == null)
            {
                throw new Exception("The user with the specified ID does not exist!");
            }

            var userDailyPoint = user.DailyPoints.OrderByDescending(d => d.CreateAt).FirstOrDefault() ?? new DailyPoint { Points = 0 };

            if (currentDate.Month != (int)Seasons.Winter && currentDate.Month != (int)Seasons.Spring 
                && currentDate.Month != (int)Seasons.Summer && currentDate.Month != (int)Seasons.Autumn)
            {
                return userDailyPoint.Points;
            }

            return await AddPoint(userDailyPoint, PointsForTheFirstDay, PointsForTheSecondDay, currentDate, userId);
        }

        private async Task<double> AddPoint(DailyPoint dailyPoint, int firstPoint, int secondPoint, DateTime currentDate, Guid userId)
        {
            double userDailyPoint = dailyPoint.Points;
            var newDailyPoint = new DailyPoint
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                CreateAt = DateTime.UtcNow,
                DayBeforeYestardayPoints = dailyPoint.Points
            };

            if (currentDate.Day == (int)PointDay.First)
            {
                userDailyPoint += firstPoint;
            }
            else if (currentDate.Day == (int)PointDay.Second)
            {
                userDailyPoint += secondPoint;
            }
            else if (currentDate.Day == (int)PointDay.Third || currentDate.Day == (int)PointDay.Fourth)
            {
                userDailyPoint = userDailyPoint + (dailyPoint.DayBeforeYestardayPoints * 1.0 + userDailyPoint * 0.6);
            }

            newDailyPoint.Points = userDailyPoint;

            await _pointRepository.AddPoinst(newDailyPoint);

            return userDailyPoint;
        }
    }
}
