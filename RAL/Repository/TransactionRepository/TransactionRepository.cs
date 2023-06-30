using DAL;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAL.Repository.TransactionRepository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IApplicationDbContext _dbContext;
        public TransactionRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateTransaction(Transaction transaction)
        {
            await _dbContext.Transactions.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetTransactionById(Guid transactionId)
        {
            return await _dbContext.Users.Include(u => u.Transactions).FirstOrDefaultAsync(u => u.Transactions.Any(t => t.Id == transactionId));
        }

        public async Task<List<Transaction>> GetTransactionsList(Guid userId)
        {
            return await _dbContext.Transactions.Where(u => u.UserId == userId).Take(10).ToListAsync();
        }
    }
}
