using BAL.Service.CardBalanceService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WalletAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardBalanceController : ControllerBase
    {
        private readonly ICardBalanceService _balanceService;
        public CardBalanceController(ICardBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpGet]
        [Route("card-balance")]
        public async Task<IActionResult> GetCardBalance(Guid userId)
        {
            try
            {
                var result = await _balanceService.GetCardBalace(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
