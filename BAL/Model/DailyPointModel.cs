using System;

namespace BAL.Model
{
    public class DailyPointModel
    {
        public Guid Id { get; set; }
        public double Points { get; set; }
        public double DayBeforeYesterdayPoints { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
