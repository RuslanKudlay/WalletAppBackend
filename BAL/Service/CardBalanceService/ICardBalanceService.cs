using BAL.Model;
using System;
using System.Threading.Tasks;

namespace BAL.Service.CardBalanceService
{
    public interface ICardBalanceService
    {
        Task<BalanceModel> GetCardBalace(Guid userId);
    }
}
