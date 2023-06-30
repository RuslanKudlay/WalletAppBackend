using System;
using System.Collections.Generic;

namespace BAL.Model
{
    public class UserModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public ICollection<TransactionModel> Transactions { get; set; }
        public ICollection<DailyPointModel> DailyPoints { get; set; }
        public decimal Balance { get; set; }
        public decimal MaxLimit { get; set; }
        public decimal Available { get; set; }
    }
}
