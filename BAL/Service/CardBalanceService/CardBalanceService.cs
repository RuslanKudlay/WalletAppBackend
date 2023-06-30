using BAL.Model;
using RAL.Repository.CardBalanceRepository;
using System;
using System.Threading.Tasks;

namespace BAL.Service.CardBalanceService
{
    public class CardBalanceService : ICardBalanceService
    {
        private readonly ICardBalanceRepository _balanceRepository;
        public CardBalanceService(ICardBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }
        public async Task<BalanceModel> GetCardBalace(Guid userId)
        {
            var user = await _balanceRepository.GetCardUserBalance(userId);
            if (user != null)
            {
                var balanceUser = new BalanceModel
                {
                    Balance = user.Balance,
                    MaxLimit = user.MaxLimit,
                    Available = user.Available
                };
                return balanceUser;
            }
            else
            {
                throw new Exception("User balance with this ID does not exist!");
            }
        }
    }
}
