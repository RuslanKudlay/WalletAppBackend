using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class DailyPoint
    {
        public Guid Id { get; set; }
        public double Points { get; set; }
        public double DayBeforeYestardayPoints { get; set; }
        public DateTime CreateAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
