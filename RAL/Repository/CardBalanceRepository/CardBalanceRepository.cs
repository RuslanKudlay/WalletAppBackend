using DAL;
using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace RAL.Repository.CardBalanceRepository
{
    public class CardBalanceRepository : ICardBalanceRepository
    {
        private readonly IApplicationDbContext _dbContext;
        public CardBalanceRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetCardUserBalance(Guid userId)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
        }
    }
}
