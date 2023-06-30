using DAL.Entity;
using System;

namespace Common.RequestModel
{
    public class TransactionDetail
    {
        public string Name { get; set; }
        public string TransactionName { get; set; }
        public decimal Total { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
