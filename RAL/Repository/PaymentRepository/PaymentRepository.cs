using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace RAL.Repository.PaymentRepository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IApplicationDbContext _dbContext;
        public PaymentRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> GetPaymentDue(Guid userId)
        {
            DateTime currentDate = DateTime.UtcNow;

            return await _dbContext.Transactions
                .AnyAsync(t => t.UserId == userId && t.TransactionType.Equals(TransactionType.Payment) && t.CreateAt.Month == currentDate.Month);
        }
    }
}
