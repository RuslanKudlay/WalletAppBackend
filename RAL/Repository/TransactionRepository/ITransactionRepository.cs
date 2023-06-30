using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAL.Repository.TransactionRepository
{
    public interface ITransactionRepository
    {
        Task CreateTransaction(Transaction transaction);
        Task<List<Transaction>> GetTransactionsList(Guid userId);
        Task<User> GetTransactionById(Guid transactionId);
    }
}
