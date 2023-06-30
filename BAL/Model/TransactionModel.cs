using System;

namespace BAL.Model
{
    public class TransactionModel
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Sum { get; set; }
        public string NameTransaction { get; set; }
        public string DescriptionTransaction { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPending { get; set; }
        public string IconPath { get; set; }
    }
}
