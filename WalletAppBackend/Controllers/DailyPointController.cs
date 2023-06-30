using BAL.Service.DeilyPointService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WalletAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyPointController : ControllerBase
    {
        private readonly IDailyPointService _dailyService;
        public DailyPointController( IDailyPointService dailyService)
        {
            _dailyService = dailyService;
        }

        [HttpPost]
        [Route("add-daily-points")]
        public async Task<IActionResult> AddDailyPoints(Guid userId)
        {
            try
            {
                var result = await _dailyService.CreateDailyPoints(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
