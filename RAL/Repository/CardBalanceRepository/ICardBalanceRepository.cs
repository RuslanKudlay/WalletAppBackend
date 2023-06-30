using DAL.Entity;
using System;
using System.Threading.Tasks;

namespace RAL.Repository.CardBalanceRepository
{
    public interface ICardBalanceRepository
    {
        Task<User> GetCardUserBalance(Guid userId);
    }
}
