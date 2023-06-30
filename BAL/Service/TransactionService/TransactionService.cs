using BAL.Helpers;
using BAL.Model;
using Common.RequestModel;
using RAL.Repository.TransactionRepository;
using RAL.Repository.UserRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BAL.Service.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUserRepository _userRepository;
        public TransactionService(ITransactionRepository transactionRepository, IUserRepository userRepository)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
        }
        public async Task CreateTransaction(TransactionModel transaction)
        {
            if (transaction.Sum <= 0 || string.IsNullOrEmpty(transaction.NameTransaction.Trim()) || string.IsNullOrEmpty(transaction.IconPath.Trim()))
            {
                throw new Exception("An error occurred while creating the transaction! Try again!");
            }
            else
            {
                var transactionModel = new TransactionModel
                {
                    Id = Guid.NewGuid(),
                    UserId = transaction.UserId,
                    TransactionType = transaction.TransactionType,
                    Sum = transaction.Sum,
                    NameTransaction = transaction.NameTransaction,
                    DescriptionTransaction = transaction.DescriptionTransaction,
                    CreatedAt = DateTime.UtcNow,
                    IsPending = transaction.IsPending,
                    IconPath = transaction.IconPath
                };

                var transactionEntity = WalletHelper.Map(transactionModel);
                await _transactionRepository.CreateTransaction(transactionEntity);

                var user = await _userRepository.GetUserById(transaction.UserId);

                if (transaction.TransactionType == TransactionType.Payment)
                {
                    user.Balance += transaction.Sum;
                    user.Available = user.MaxLimit - user.Balance;
                    if (user.Available <= 0)
                    {
                        throw new Exception("Limit is over!");
                    }

                }
                else if (transaction.TransactionType == TransactionType.Credit)
                {
                    user.Balance -= transaction.Sum;
                    if (user.Balance <= 0)
                    {
                        throw new Exception("Insufficient balance!");
                    }
                }
                await _userRepository.UpdateUser(user);
            }
        }

        public async Task<List<TransactionModel>> GetListTransactions(Guid userId)
        {
            var listTransactions = await _transactionRepository.GetTransactionsList(userId);
            if(listTransactions.Count == 0)
            {
                throw new Exception("This user has no transactions!");
            }
            else
            {
                var listTransactionsModel = WalletHelper.Map(listTransactions);
                return listTransactionsModel;
            }
        }

        public async Task<TransactionDetail> GetTransactionById(Guid transactionId)
        {
            var transaction = await _transactionRepository.GetTransactionById(transactionId);
            
            if (transaction != null)
            {
                var transactionModel = WalletHelper.Map(transaction);
                var transactionDetail = WalletHelper.MapModelTransactionDetail(transactionModel);
                return transactionDetail;
            }
            else
            {
                throw new Exception("No transaction for this id");
            }
        }
    }
}
