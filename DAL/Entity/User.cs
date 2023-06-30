using System;
using System.Collections.Generic;

namespace DAL.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public decimal Balance { get; set; }
        public decimal MaxLimit { get; set; }
        public decimal Available { get; set; }
        public ICollection<DailyPoint> DailyPoints { get; set; }
    }
}
