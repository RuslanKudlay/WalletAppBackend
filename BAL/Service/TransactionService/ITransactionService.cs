using BAL.Model;
using Common.RequestModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BAL.Service.TransactionService
{
    public interface ITransactionService
    {
        Task CreateTransaction(TransactionModel transaction);
        Task<List<TransactionModel>> GetListTransactions(Guid userId);
        Task<TransactionDetail> GetTransactionById(Guid transactionId);
    }
}
