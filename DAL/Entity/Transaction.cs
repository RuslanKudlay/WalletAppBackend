using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entity
{
    public class Transaction
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public Guid UserId { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Sum { get; set; }
        public string NameTransaction { get; set; }
        public string DescriptionTransaction { get; set; }
        public DateTime CreateAt { get; set; }
        public bool IsPending { get; set; }
        public string IconPath { get; set; }
    }
}
